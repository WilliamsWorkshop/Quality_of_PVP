using Microsoft.Xna.Framework;
using QualityofPvP.Projectiles;
using QualityofPvP.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Items
{
    public class ProwlerSMG:ModItem
    {
        //public static readonly SoundStyle ProwlerSMGSound = new("QualityofPvP/Sound/ProwlerSMG");
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 10;
            Item.height = 10;
            Item.useTime = 2;
            Item.useAnimation = 10;
            Item.useLimitPerAnimation = 5;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Red;
            Item.autoReuse = true;
            Item.reuseDelay = 20;
            Item.shoot = ProjectileID.BulletHighVelocity;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 18;
            Item.autoReuse = false;
            Item.scale = 0.63f;
            
           
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "FromAnotherWorld", "来自另一个世界"));
            foreach(var tooltip in tooltips)
            {
                if (tooltip.Name=="FromAnotherWorld")
                {
                    tooltip.OverrideColor = Color.Red;
                }
            }
            base.ModifyTooltips(tooltips);
        }
        public override Vector2? HoldoutOffset() => new Vector2(-13, 0);

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
