using Microsoft.Extensions.Logging.Abstractions;
using QualityofPvP.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Overhaul
{
    public class AttributeOverhaul : GlobalItem
    {
        public override void SetDefaults(Item entity)
        {
           
            if (entity.type == ItemID.TacticalShotgun)
            {
                entity.damage = 40;
                entity.useTime = 28;
                entity.useAnimation = 28;
            }
            if (entity.type==ItemID.PhoenixBlaster)
            {
                entity.damage = 20;
                entity.useTime = 4;
                entity.useAnimation = 4;
            }
            if (entity.type == ItemID.Uzi)
            {   
                entity.damage = 30;
                entity.useTime = (int)(entity.useTime * 0.7);
                entity.useAnimation = (int)(entity.useAnimation * 0.7);
            }
            if (entity.type == ItemID.SDMG)
            {
                entity.damage = 100;
            }
            if (entity.type==ItemID.Handgun)
            {
                entity.useAnimation = 9;
                entity.useTime = 9;
            }
            if (entity.type==ItemID.VenusMagnum)
            {
                entity.damage = 125;
                entity.useTime = 26;
                entity.useAnimation = 26;
            }
            if (entity.type==ItemID.Megashark)
            {
                entity.damage = 45;
            }
            if (entity.type==ItemID.SuperStarCannon)
            {
                entity.damage = 90;
                entity.reuseDelay = 16;
                entity.useTime = 4;
                entity.useAnimation = 16;
                entity.useLimitPerAnimation = 4;
                entity.shootSpeed = 60;
            }
            if (entity.type==ItemID.StarCannon)
            {
                entity.useTime = 6;
                entity.useAnimation = 6;
                entity.shootSpeed = 55;
            }
            if (entity.type == ItemID.ChainGun) 
            {
                entity.damage = 39;
            }
            base.SetDefaults(entity);
        }
        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
           
            foreach (var item1 in ItemsLists.FireSilent())
            {
                if (item.type==item1.type)
                {
                    item.UseSound = null;
                }
            }
        }
    }
}
