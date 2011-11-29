
namespace ADBParser.Formats
{
    public sealed class Item : IClientDbRecord
    {
        public int Id { get; set; }
        public int Class { get; set; }
        public int SubClass { get; set; }
        public int Unk0 { get; set; }
        public int Material { get; set; }
        public int DisplayId { get; set; }
        public int InventoryType { get; set; }
        public int Sheath { get; set; }
    }
}
