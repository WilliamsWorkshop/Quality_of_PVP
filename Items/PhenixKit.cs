using Microsoft.Xna.Framework;
using QualityofPvP.Projectiles.AbstractProjectile;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Items
{
    public class PhenixKit : ModItem
    {
        public int usetick;
        // public bool usecheck = true;
        public bool soundcheck;
        public bool clear = false;
        public int usecheck1 = 0;
        public int usecheck2 = 0;
        public override void SetDefaults()
        {
            //Item.width = 24;
            //Item.height = 32;
            //Item.useTurn = true;
            //Item.maxStack = 1;
            //Item.useAnimation = 1;
            //Item.useTime = 1;
            //Item.useStyle = ItemUseStyleID.Shoot;
            //Item.value = Item.buyPrice(1, 0, 0, 0);
            //Item.rare = ItemRarityID.Purple;
            //Item.autoReuse = true;
            Item.rare = ItemRarityID.Purple;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<PhenixKitHoldOut>();
            Item.useStyle = ItemUseStyleID.Guitar;
            Item.consumable = false;
            

        }
        public override bool CanUseItem(Player player)
        {
            
            //player.moveSpeed *= 0.2f;
            //float Speed = player.maxRunSpeed / 2f;
            //player.maxRunSpeed -= Speed;
            //player.accRunSpeed = player.maxRunSpeed;
            return base.CanUseItem(player);
        }
  
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "PhinexKit", "按住以使用，将血量恢复至生命上限"));
            foreach (TooltipLine line in tooltips)
            {
                if (line.Name== "PhinexKit")
                {
                    line.OverrideColor = Color.Purple;
                }
            }
            base.ModifyTooltips(tooltips);
        }

    }
}
