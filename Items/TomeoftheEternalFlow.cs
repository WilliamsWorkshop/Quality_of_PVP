using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Items
{
    public class TomeoftheEternalFlow:ModItem
    {
        public override void SetDefaults() 
        {
            Item.damage = 542;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            Item.width = 16;
            Item.height = 16;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item13;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.knockBack = 0f;
            Item.value = 1000000;
            Item.rare = ItemRarityID.Blue;
            //Item.Calamity().donorItem = true;
           // Item.shoot = ModContent.ProjectileType<DarkSparkPrism>();
            Item.shootSpeed = 30f;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "unFinished", "尚未制作完成"));
            foreach (TooltipLine tooltip in tooltips)
            {
                if (tooltip.Name=="unFinished")
                {
                    tooltip.OverrideColor = Color.Red;
                }
            }
            base.ModifyTooltips(tooltips);
        }
    }
}
