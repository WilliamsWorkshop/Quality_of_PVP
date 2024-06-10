using QualityofPvP.Items;
using QualityofPvP.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace QualityofPvP.Overhaul
{
    public class PvPItemsPrefix:GlobalItem
    {
        public List<Item> PVPItems;

        public override bool InstancePerEntity => true;
        public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand)
        {
            PVPItems = ItemsLists.GetTestItems();
            if (pre==-1)
            {
                foreach (var aimitem in PVPItems)
                {
                    if (item.type == aimitem.type)
                    {
                        
                        return false;
                    }
                }
            }
           
            
            return null;
        }

       
        public override void AddRecipes()
        {
            
            base.AddRecipes();
        }
    }
}
