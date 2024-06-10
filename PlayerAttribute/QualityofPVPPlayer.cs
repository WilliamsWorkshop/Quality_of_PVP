using QualityofPvP.Items;
using QualityofPvP.Overhaul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.PlayerAttribute
{
    public class QualityofPVPPlayer:ModPlayer
    {
        //public static int reloadCD=0;
        //public int GetreloadCD()
        //{
        //    return reloadCD;
        //}
        //public void IncreloadCD()
        //{
        //    reloadCD++;
        //}
        //public void ResreloadCD()
        //{ 
        //    reloadCD=0;
        //}
        
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {

            //return ItemsLists.GetTestItems();
            return new List<Item>
            {
                new Item(ModContent.ItemType<TesterBeg>())
            }
            ;

            
        }

        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {

            // 把原版提供的三件套删掉,现在不再需要
            //itemsByMod["Terraria"].RemoveAll(item => item.type == ItemID.CopperPickaxe);

            //itemsByMod["Terraria"].RemoveAll(item => item.type == ItemID.CopperShortsword);

            //itemsByMod["Terraria"].RemoveAll(item => item.type == ItemID.CopperAxe);
        }
    }
}
