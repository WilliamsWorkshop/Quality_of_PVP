using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Items
{
    public class ItemsLists
    {
        /// <summary>
        ///返回测试物品表
        /// </summary>
        public static List<Item> GetTestItems()
        {
            var List = new List<Item>
            {
                new Item(ItemID.Minishark),

        new Item(ItemID.Uzi),

        new Item(ItemID.HeatRay),

        new Item(ItemID.SDMG),

        new Item(4954),//天界星盘

        new Item(4989),//翱翔

        new Item (ItemID.HighVelocityBullet,9999),

        new Item(ItemID.ManaCrystal,99),

        new Item(ItemID.BeetleWings),

        new Item(ItemID.VenusMagnum),

        new Item(ItemID.SuperManaPotion,9999),

        new Item(ItemID.LifeCrystal,99),

        new Item(ItemID.LifeFruit,99),

        new Item(ItemID.RodofDiscord),

        new Item(ItemID.SniperRifle),

        new Item(ItemID.TacticalShotgun),

        new Item(ItemID.Handgun),

        new Item(ItemID.PhoenixBlaster),

        new Item(ItemID.Megashark),

        new Item(ItemID.FallenStar,9999),

        new Item(ItemID.ChainGun),

        new Item(ItemID.SuperStarCannon),

        new Item(ModContent.ItemType<ProwlerSMG>()),

        new Item(ModContent.ItemType<SmartGun>()),

        new Item(ModContent.ItemType<SmartGunforNPC>()),

        new Item(ModContent.ItemType<PhenixKit>())
            };
            return List;
        }
        public static List<Item> FireSilent()
        {
            var List = new List<Item>
            {
                new Item(ItemID.TacticalShotgun),
                new Item(ItemID.PhoenixBlaster),
                new Item(ItemID.SDMG),
                new Item(ItemID.Minishark),
                new Item(ItemID.Handgun),
                new Item(ItemID.VenusMagnum),
                //new Item(ItemID.SniperRifle)
                new Item(ItemID.Megashark),
                new Item(ItemID.ChainGun)
                
            };
            return List;
        }
    }
}
