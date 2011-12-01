using System.Text;
using ADBParser.Formats;

namespace ADBParser
{
    public sealed class ItemSqlBuilder
    {
        public ItemSqlBuilder(Item item, Item_sparse sparse, int build)
        {
            _item = item;
            _sparse = sparse;
            _build = build;
        }

        private Item _item;
        private Item_sparse _sparse;
        private int _build;

        public string GetInsertQuery()
        {
            var str = new StringBuilder();
            // values
            //writer.Write("`GemProperties`,`ArmorDamageModifier`,`Duration`,`ItemLimitCategory`,`HolidayId`,`StatScalingFactor`,`Field130`,`Field131`");
            str.AppendFormat("({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},", _item.Id, _item.Class, _item.SubClass, _item.Unk0, _sparse.Name.EscapeSQL(), _item.DisplayId, _sparse.Quality, _sparse.Flags, _sparse.Flags2, _sparse.BuyPrice, _sparse.SellPrice, _item.InventoryType);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},", _sparse.AllowableClass, _sparse.AllowableRace, _sparse.ItemLevel, _sparse.RequiredLevel, _sparse.RequiredSkill, _sparse.RequiredSkillRank, _sparse.RequiredSpell, _sparse.RequiredHonorRank);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},", _sparse.RequiredCityRank, _sparse.RequiredReputationFaction, _sparse.RequiredReputationRank, _sparse.MaxCount, _sparse.Stackable, _sparse.ContainerSlots);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},", _sparse.ItemStatType1, _sparse.ItemStatValue1, _sparse.ItemStatUnk1_1, _sparse.ItemStatUnk2_1, _sparse.ItemStatType2, _sparse.ItemStatValue2, _sparse.ItemStatUnk1_2, _sparse.ItemStatUnk2_2);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},", _sparse.ItemStatType3, _sparse.ItemStatValue3, _sparse.ItemStatUnk1_3, _sparse.ItemStatUnk2_3, _sparse.ItemStatType4, _sparse.ItemStatValue4, _sparse.ItemStatUnk1_4, _sparse.ItemStatUnk2_4);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},", _sparse.ItemStatType5, _sparse.ItemStatValue5, _sparse.ItemStatUnk1_5, _sparse.ItemStatUnk2_5, _sparse.ItemStatType6, _sparse.ItemStatValue6, _sparse.ItemStatUnk1_6, _sparse.ItemStatUnk2_6);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},", _sparse.ItemStatType7, _sparse.ItemStatValue7, _sparse.ItemStatUnk1_7, _sparse.ItemStatUnk2_7, _sparse.ItemStatType8, _sparse.ItemStatValue8, _sparse.ItemStatUnk1_8, _sparse.ItemStatUnk2_8);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},", _sparse.ItemStatType9, _sparse.ItemStatValue9, _sparse.ItemStatUnk1_9, _sparse.ItemStatUnk2_9, _sparse.ItemStatType10, _sparse.ItemStatValue10, _sparse.ItemStatUnk1_10, _sparse.ItemStatUnk2_10);
            str.AppendFormat("{0},{1},{2},{3},", _sparse.ScalingStatDistribution, _sparse.DamageType, _sparse.Delay, _sparse.RangedModRange);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},", _sparse.SpellId1, _sparse.SpellTrigger1, _sparse.SpellCharges1, _sparse.SpellCooldown1, _sparse.SpellCategory1, _sparse.SpellCategoryCooldown1);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},", _sparse.SpellId2, _sparse.SpellTrigger2, _sparse.SpellCharges2, _sparse.SpellCooldown2, _sparse.SpellCategory2, _sparse.SpellCategoryCooldown2);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},", _sparse.SpellId3, _sparse.SpellTrigger3, _sparse.SpellCharges3, _sparse.SpellCooldown3, _sparse.SpellCategory3, _sparse.SpellCategoryCooldown3);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},", _sparse.SpellId4, _sparse.SpellTrigger4, _sparse.SpellCharges4, _sparse.SpellCooldown4, _sparse.SpellCategory4, _sparse.SpellCategoryCooldown4);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},", _sparse.SpellId5, _sparse.SpellTrigger5, _sparse.SpellCharges5, _sparse.SpellCooldown5, _sparse.SpellCategory5, _sparse.SpellCategoryCooldown5);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},", _sparse.Bonding, _sparse.Description.EscapeSQL(), _sparse.PageText, _sparse.LanguageID, _sparse.PageMaterial, _sparse.StartQuest, _sparse.LockID, _item.Material);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},", _item.Sheath, _sparse.RandomProperty, _sparse.RandomSuffix, _sparse.ItemSet, 0/*_sparse.MaxDurability*/, _sparse.Area, _sparse.Map, _sparse.BagFamily, _sparse.TotemCategory);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},", _sparse.Color1, _sparse.Content1, _sparse.Color2, _sparse.Content2, _sparse.Color3, _sparse.Content3, _sparse.SocketBonus);
            str.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8})", _sparse.GemProperties, _sparse.ArmorDamageModifier, _sparse.Duration, _sparse.ItemLimitCategory, _sparse.HolidayId, _sparse.StatScalingFactor, _sparse.Field130, _sparse.Field131, _build);
            return str.ToString();
        }
    }
}
