
namespace ADBParser.Formats
{
    public sealed class Item_sparse : IClientDbRecord
    {
        public int    Id { get; set; }                                           // 0
        public int    Quality { get; set; }                                      // 1
        public int    Flags { get; set; }                                        // 2
        public int    Flags2 { get; set; }                                       // 3
        public int    BuyPrice { get; set; }                                     // 4
        public int    SellPrice { get; set; }                                    // 5
        public int    InventoryType { get; set; }                                // 6
        public int    AllowableClass { get; set; }                               // 7
        public int    AllowableRace { get; set; }                                // 8
        public int    ItemLevel { get; set; }                                    // 9
        public int    RequiredLevel { get; set; }                                // 10
        public int    RequiredSkill { get; set; }                                // 11
        public int    RequiredSkillRank { get; set; }                            // 12
        public int    RequiredSpell { get; set; }                                // 13
        public int    RequiredHonorRank { get; set; }                            // 14
        public int    RequiredCityRank { get; set; }                             // 15
        public int    RequiredReputationFaction { get; set; }                    // 16
        public int    RequiredReputationRank { get; set; }                       // 17
        public int    MaxCount { get; set; }                                     // 18
        public int    Stackable { get; set; }                                    // 19
        public int    ContainerSlots { get; set; }                               // 20
        public int    ItemStatType1 { get; set; }                                // 21 - 30
        public int    ItemStatType2 { get; set; }                                // 21 - 30
        public int    ItemStatType3 { get; set; }                                // 21 - 30
        public int    ItemStatType4 { get; set; }                                // 21 - 30
        public int    ItemStatType5 { get; set; }                                // 21 - 30
        public int    ItemStatType6 { get; set; }                                // 21 - 30
        public int    ItemStatType7 { get; set; }                                // 21 - 30
        public int    ItemStatType8 { get; set; }                                // 21 - 30
        public int    ItemStatType9 { get; set; }                                // 21 - 30
        public int    ItemStatType10 { get; set; }                               // 21 - 30
        public int    ItemStatValue1 { get; set; }                               // 31 - 40
        public int    ItemStatValue2 { get; set; }                               // 31 - 40
        public int    ItemStatValue3 { get; set; }                               // 31 - 40
        public int    ItemStatValue4 { get; set; }                               // 31 - 40
        public int    ItemStatValue5 { get; set; }                               // 31 - 40
        public int    ItemStatValue6 { get; set; }                               // 31 - 40
        public int    ItemStatValue7 { get; set; }                               // 31 - 40
        public int    ItemStatValue8 { get; set; }                               // 31 - 40
        public int    ItemStatValue9 { get; set; }                               // 31 - 40
        public int    ItemStatValue10 { get; set; }                              // 31 - 40
        public int    ItemStatUnk1_1 { get; set; }
        public int    ItemStatUnk1_2 { get; set; }
        public int    ItemStatUnk1_3 { get; set; }
        public int    ItemStatUnk1_4 { get; set; }
        public int    ItemStatUnk1_5 { get; set; }
        public int    ItemStatUnk1_6 { get; set; }
        public int    ItemStatUnk1_7 { get; set; }
        public int    ItemStatUnk1_8 { get; set; }
        public int    ItemStatUnk1_9 { get; set; }
        public int    ItemStatUnk1_10 { get; set; }
        public int    ItemStatUnk2_1 { get; set; }
        public int    ItemStatUnk2_2 { get; set; }
        public int    ItemStatUnk2_3 { get; set; }
        public int    ItemStatUnk2_4 { get; set; }
        public int    ItemStatUnk2_5 { get; set; }
        public int    ItemStatUnk2_6 { get; set; }
        public int    ItemStatUnk2_7 { get; set; }
        public int    ItemStatUnk2_8 { get; set; }
        public int    ItemStatUnk2_9 { get; set; }
        public int    ItemStatUnk2_10 { get; set; }
        public int    ScalingStatDistribution { get; set; }                      // 61
        public int    DamageType { get; set; }                                   // 62
        public int    Delay { get; set; }                                        // 63
        public float  RangedModRange { get; set; }                               // 64
        public int    SpellId1 { get; set; }
        public int    SpellId2 { get; set; }
        public int    SpellId3 { get; set; }
        public int    SpellId4 { get; set; }
        public int    SpellId5 { get; set; }
        public int    SpellTrigger1 { get; set; }
        public int    SpellTrigger2 { get; set; }
        public int    SpellTrigger3 { get; set; }
        public int    SpellTrigger4 { get; set; }
        public int    SpellTrigger5 { get; set; }
        public int    SpellCharges1 { get; set; }
        public int    SpellCharges2 { get; set; }
        public int    SpellCharges3 { get; set; }
        public int    SpellCharges4 { get; set; }
        public int    SpellCharges5 { get; set; }
        public int    SpellCooldown1 { get; set; }
        public int    SpellCooldown2 { get; set; }
        public int    SpellCooldown3 { get; set; }
        public int    SpellCooldown4 { get; set; }
        public int    SpellCooldown5 { get; set; }
        public int    SpellCategory1 { get; set; }
        public int    SpellCategory2 { get; set; }
        public int    SpellCategory3 { get; set; }
        public int    SpellCategory4 { get; set; }
        public int    SpellCategory5 { get; set; }
        public int    SpellCategoryCooldown1 { get; set; }
        public int    SpellCategoryCooldown2 { get; set; }
        public int    SpellCategoryCooldown3 { get; set; }
        public int    SpellCategoryCooldown4 { get; set; }
        public int    SpellCategoryCooldown5 { get; set; }
        public int    Bonding { get; set; }                                      // 95
        public string Name { get; set; }                                         // 96
        public string Name2 { get; set; }                                        // 97
        public string Name3 { get; set; }                                        // 98
        public string Name4 { get; set; }                                        // 99
        public string Description { get; set; }                                  // 100
        public int    PageText { get; set; }                                     // 101
        public int    LanguageID { get; set; }                                   // 102
        public int    PageMaterial { get; set; }                                 // 103
        public int    StartQuest { get; set; }                                   // 104
        public int    LockID { get; set; }                                       // 105
        public int    Material { get; set; }                                     // 106
        public int    Sheath { get; set; }                                       // 107
        public int    RandomProperty { get; set; }                               // 108
        public int    RandomSuffix { get; set; }                                 // 109
        public int    ItemSet { get; set; }                                      // 110
        public int    MaxDurability { get; set; }                                // 111
        public int    Area { get; set; }                                         // 112
        public int    Map { get; set; }                                          // 113
        public int    BagFamily { get; set; }                                    // 114
        public int    TotemCategory { get; set; }                                // 115
        public int    Color1 { get; set; }                                       // 116
        public int    Color2 { get; set; }                                       // 117
        public int    Color3 { get; set; }                                       // 118
        public int    Content1 { get; set; }                                     // 119
        public int    Content2 { get; set; }                                     // 120
        public int    Content3 { get; set; }                                     // 121
        public int    SocketBonus { get; set; }                                  // 122
        public int    GemProperties { get; set; }                                // 123
        public float  ArmorDamageModifier { get; set; }                          // 124
        public int    Duration { get; set; }                                     // 125
        public int    ItemLimitCategory { get; set; }                            // 126
        public int    HolidayId { get; set; }                                    // 127
        public float  StatScalingFactor { get; set; }                            // 128
        public int    Field130 { get; set; }                                     // 129
        public int    Field131 { get; set; }                                     // 130
    }
}
