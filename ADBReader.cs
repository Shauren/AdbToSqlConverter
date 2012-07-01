using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ADBParser
{
    public sealed class ADBReader<T>
        where T: class, IClientDbRecord, new()
    {
        public ADBReader(string fileName)
        {
            FileName = fileName;

            StringTable = new Dictionary<int, string>();
            Entries = new Dictionary<int, T>();

            ReadFile();
        }

        public int HeaderMagic
        {
            get { return 0x32484357; }
        }

        public const int NewHeaderBuild = 12880;

        public int FieldCount { get; private set; }

        public int RecordSize { get; private set; }

        public int Build { get; private set; }

        public int LastUpdated { get; private set; }

        public int MinId { get; private set; }

        public int MaxId { get; private set; }

        public int Locale { get; private set; }

        public string FileName { get; private set; }

        public int RecordCount { get; private set; }

        public int StringTableSize { get; private set; }

        private Dictionary<int, string> StringTable { get; set; }

        public Dictionary<int, T> Entries { get; private set; }

        private void Read(BinaryReader reader)
        {
            if (reader.ReadInt32() != HeaderMagic)
                throw new InvalidDataException("Invalid client DB header magic number.");

            var data = ReadData(reader);

            ReadStringTable(reader);

            MapRecords(data);
        }

        private void ReadFile()
        {
            using (var stream = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (var reader = new BinaryReader(stream, Encoding.UTF8))
                    Read(reader);
        }

        private byte[] ReadData(BinaryReader reader)
        {
            RecordCount = reader.ReadInt32();

            if (RecordCount < 0)
                throw new InvalidDataException("Negative record count was encountered.");

            FieldCount = reader.ReadInt32();

            if (FieldCount < 0)
                throw new InvalidDataException("Negative field count was encountered.");

            RecordSize = reader.ReadInt32();

            if (RecordSize < 0)
                throw new InvalidDataException("Negative record size was encountered.");

            StringTableSize = reader.ReadInt32();

            if (StringTableSize < 0)
                throw new InvalidDataException("Negative string table size was encountered.");

            reader.ReadInt32(); // table hash
            Build = reader.ReadInt32();

            if (Build < 0)
                throw new InvalidDataException("Negative build was encountered.");

            LastUpdated = reader.ReadInt32();

            if (Build > NewHeaderBuild)
            {
                MinId = reader.ReadInt32();

                if (MinId < 0)
                    throw new InvalidDataException("Negative minimum ID was encountered.");

                MaxId = reader.ReadInt32();

                if (MaxId < 0)
                    throw new InvalidDataException("Negative maximum ID was encountered.");

                Locale = reader.ReadInt32();
                reader.ReadInt32(); // unknown

                // Table indexes
                // TODO: Unhackify this.
                if (MaxId > 0)
                {
                    if (MaxId < 12)
                        throw new InvalidDataException("Invalid maximum ID value was encountered.");

                    var indexes = MaxId - MinId + 1;
                    reader.ReadBytes(indexes * 4);
                    reader.ReadBytes(indexes * 2);
                }
            }

            // Read in all the records.
            var count = RecordCount * RecordSize;
            return reader.ReadBytes(count);
        }

        private void MapRecords(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data), Encoding.UTF8))
            {
                for (var i = 0; i < RecordCount; ++i)
                {
                    var obj = new T();
                    ReadValuesToClass(obj, reader);
                    // Apparently adb files can contain multiple entries for the same item
                    // Assume the last one is "newest" and has the desired info
                    if (!Entries.ContainsKey(obj.Id))
                        Entries.Add(obj.Id, obj);
                    else
                        Entries[obj.Id] = obj;
                }
            }
        }

        private void ReadValuesToClass(object obj, BinaryReader reader)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                var value = ReadValueToProperty(prop, reader);
                prop.SetValue(obj, value, null);
            }
        }

        private object ReadValueToProperty(PropertyInfo prop, BinaryReader reader)
        {
            var type = prop.PropertyType;
            object value;

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Object:
                    value = Activator.CreateInstance(type);
                    ReadValuesToClass(value, reader);
                    break;
                case TypeCode.Boolean:
                    value = reader.ReadBoolean();
                    break;
                case TypeCode.SByte:
                    value = reader.ReadSByte();
                    break;
                case TypeCode.Byte:
                    value = reader.ReadByte();
                    break;
                case TypeCode.Int16:
                    value = reader.ReadInt16();
                    break;
                case TypeCode.UInt16:
                    value = reader.ReadUInt16();
                    break;
                case TypeCode.Int32:
                    value = reader.ReadInt32();
                    break;
                case TypeCode.UInt32:
                    value = reader.ReadUInt32();
                    break;
                case TypeCode.Int64:
                    value = reader.ReadInt64();
                    break;
                case TypeCode.UInt64:
                    value = reader.ReadUInt64();
                    break;
                case TypeCode.Single:
                    value = reader.ReadSingle();
                    break;
                case TypeCode.String:
                    value = StringTable[reader.ReadInt32()];
                    break;
                default:
                    return null;
            }

            if (type.IsEnum)
                value = Enum.ToObject(type, value);

            return value;
        }

        private void ReadStringTable(BinaryReader reader)
        {
            var stream = reader.BaseStream;
            var stringTableStart = stream.Position;
            var stringTableEnd = stringTableStart + StringTableSize;

            while (stream.Position != stringTableEnd)
            {
                var stringIndex = (int)(stream.Position - stringTableStart);
                StringTable[stringIndex] = reader.ReadCString();
            }
        }
    }
}
