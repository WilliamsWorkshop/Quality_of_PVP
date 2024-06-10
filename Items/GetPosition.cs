using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace QualityofPvP.Items
{
    public class GetPosition:ModItem
    {

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTime = 1;
            Item.useAnimation = 1;
            base.SetDefaults();
        }

        public override bool CanUseItem(Player player)
        {
            Console.WriteLine("MouseX=" + Main.MouseWorld.X.ToString() + "\nMouseY=" + Main.MouseWorld.Y);
            return true;
        }


    }
}
