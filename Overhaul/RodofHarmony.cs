using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Overhaul
{
    public class RodofHarmony:GlobalItem
    {
        public override bool CanUseItem(Item item, Player player)
        {
            //现在拥有混乱状态debuff的时候无法使用混沌传送杖
            int check = 0;
           
            if (item.type==ItemID.RodOfHarmony)
            {
                player.AddBuff(88, 300);
                foreach (var buff in player.buffType)
                {
                    if (buff == 88)
                    {
                        check++;
                    }

                }
                if (check == 0)
                {
                    return true;
                }
                if (check == 1)
                {
                    check = 0;
                    return false;

                }
            }
            return base.CanUseItem(item, player);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type== ItemID.RodOfHarmony)
            {
                tooltips.Add(new TooltipLine(Mod, "RODToolTip1", "处于混乱状态时将无法使用"));
            }
            foreach(var tooltip in tooltips)
            {
                if (tooltip.Name== "RODToolTip1")
                {
                    tooltip.OverrideColor = Color.Red;
                }
            }
            base.ModifyTooltips(item, tooltips);
        }
    }
}
