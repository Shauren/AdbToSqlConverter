using System.IO;
using ADBParser.Formats;

namespace ADBParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var sparse = new ADBReader<Item_sparse>("Item-sparse.adb");
            var itemDb = new ADBReader<Item>("Item.adb");
            using (var writer = new StreamWriter("item_parsed.sql", false))
            {
                writer.Write("REPLACE INTO `item_template` (");
                writer.Write("`entry`,`Class`,`SubClass`,`Unk0`,`Name`,`DisplayId`,`Quality`,`Flags`,`FlagsExtra`,`Unk430_1`,`Unk430_2`,`BuyCount`,`BuyPrice`,`SellPrice`,`InventoryType`,");
                writer.Write("`AllowableClass`,`AllowableRace`,`ItemLevel`,`RequiredLevel`,`RequiredSkill`,`RequiredSkillRank`,`RequiredSpell`,`RequiredHonorRank`,");
                writer.Write("`RequiredCityRank`,`RequiredReputationFaction`,`RequiredReputationRank`,`MaxCount`,`Stackable`,`ContainerSlots`,");
                writer.Write("`stat_type1`,`stat_value1`,`stat_unk1_1`,`stat_unk2_1`,`stat_type2`,`stat_value2`,`stat_unk1_2`,`stat_unk2_2`,");
                writer.Write("`stat_type3`,`stat_value3`,`stat_unk1_3`,`stat_unk2_3`,`stat_type4`,`stat_value4`,`stat_unk1_4`,`stat_unk2_4`,");
                writer.Write("`stat_type5`,`stat_value5`,`stat_unk1_5`,`stat_unk2_5`,`stat_type6`,`stat_value6`,`stat_unk1_6`,`stat_unk2_6`,");
                writer.Write("`stat_type7`,`stat_value7`,`stat_unk1_7`,`stat_unk2_7`,`stat_type8`,`stat_value8`,`stat_unk1_8`,`stat_unk2_8`,");
                writer.Write("`stat_type9`,`stat_value9`,`stat_unk1_9`,`stat_unk2_9`,`stat_type10`,`stat_value10`,`stat_unk1_10`,`stat_unk2_10`,");
                writer.Write("`ScalingStatDistribution`,`DamageType`,`Delay`,`RangedModRange`,");
                writer.Write("`spellid_1`,`spelltrigger_1`,`spellcharges_1`,`spellcooldown_1`,`spellcategory_1`,`spellcategorycooldown_1`,");
                writer.Write("`spellid_2`,`spelltrigger_2`,`spellcharges_2`,`spellcooldown_2`,`spellcategory_2`,`spellcategorycooldown_2`,");
                writer.Write("`spellid_3`,`spelltrigger_3`,`spellcharges_3`,`spellcooldown_3`,`spellcategory_3`,`spellcategorycooldown_3`,");
                writer.Write("`spellid_4`,`spelltrigger_4`,`spellcharges_4`,`spellcooldown_4`,`spellcategory_4`,`spellcategorycooldown_4`,");
                writer.Write("`spellid_5`,`spelltrigger_5`,`spellcharges_5`,`spellcooldown_5`,`spellcategory_5`,`spellcategorycooldown_5`,");
                writer.Write("`Bonding`,`Description`,`PageText`,`LanguageID`,`PageMaterial`,`StartQuest`,`LockID`,`Material`,");
                writer.Write("`Sheath`,`RandomProperty`,`RandomSuffix`,`ItemSet`,`Area`,`Map`,`BagFamily`,`TotemCategory`,");
                writer.Write("`SocketColor_1`,`SocketContent_1`,`SocketColor_2`,`SocketContent_2`,`SocketColor_3`,`SocketContent_3`,`SocketBonus`,");
                writer.Write("`GemProperties`,`ArmorDamageModifier`,`Duration`,`ItemLimitCategory`,`HolidayId`,`StatScalingFactor`,`Field130`,`Field131`,`WDBVerified`");
                writer.WriteLine(") VALUES");

                bool first = true;
                foreach (var item in sparse.Entries)
                {
                    if (!itemDb.Entries.ContainsKey(item.Key))
                        continue;

                    if (!first)
                        writer.WriteLine(',');
                    else
                        first = false;

                    writer.Write("{0}", new ItemSqlBuilder(itemDb.Entries[item.Key], item.Value, itemDb.Build).GetInsertQuery());
                }

                writer.WriteLine(';');
            }
        }
    }
}
