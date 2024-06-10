using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Overhaul
{
    internal class Knockback : GlobalItem
    {
        
        public override void OnHitPvp(Item item, Player player, Player target, Player.HurtInfo hurtInfo)
        {
            Vector2 KnockbackDirection = target.Center - player.Center;
            KnockbackDirection /= KnockbackDirection.Length();

            if (item.type == ItemID.SlapHand)
            {
                target.velocity = KnockbackDirection*500;
            }
        }
       
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.CopperShortsword)
            {
                tooltips.Add(new TooltipLine(Mod, "coppershortsword", "拥有无敌击退的神剑,但是由于开发者太懒，目前尚不能发挥实力"));

                foreach (var line in tooltips)
                {
                    if (line.Name == "coppershortsword")
                    {
                        line.OverrideColor = Color.Red;
                    }

                }
            }

        }

    }
}
