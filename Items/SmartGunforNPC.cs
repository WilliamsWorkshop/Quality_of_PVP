using Microsoft.Xna.Framework.Graphics;
using QualityofPvP.Projectiles;
using QualityofPvP.Sound;
using Terraria.ID;
using Terraria.ModLoader;
namespace QualityofPvP.Items
{
    public class SmartGunforNPC : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 23;
            Item.height = 8;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;

            Item.damage = 100;
            Item.DamageType = DamageClass.Ranged;

            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Expert;
            Item.UseSound = QualityofPvPSound.SmartBulletPistol_Fire;
            Item.autoReuse = true;
            Item.reuseDelay = 20;
            Item.shoot = ModContent.ProjectileType<SmartBulletForNPC>();
            Item.shootSpeed = 25;
            Item.autoReuse = false;
            Item.scale = 0.63f;
            
            base.SetDefaults();
        }
    }
}
