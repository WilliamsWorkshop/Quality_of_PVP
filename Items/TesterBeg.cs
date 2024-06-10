using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace QualityofPvP.Items
{
    public class TesterBeg:ModItem
    {
        
        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.rare = ItemRarityID.Purple;
            Item.maxStack = 9999;
        }
        public override bool CanRightClick()=>true;
       
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            foreach(var item in ItemsLists.GetTestItems())
            {
               
                    itemLoot.Add(ItemDropRule.Common(item.type,1,item.stack,item.stack));
                
                
            }
            


            base.ModifyItemLoot(itemLoot);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "TesterBeg", "获取所有测试用物品"));
            foreach(var tootip in tooltips)
            {
                if (tootip.Name== "TesterBeg")
                {
                    tootip.OverrideColor = Color.Red;
                }
            }
            base.ModifyTooltips(tooltips);
        }
    }
}
