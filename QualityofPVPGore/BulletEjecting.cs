using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace QualityofPvP.QualityofPVPGore
{
    public class BulletEjecting:ModGore
    {
        public override void OnSpawn(Gore gore, IEntitySource source)
        {
            Random rand = new Random();
            gore.Frame = new SpriteFrame(1, 1, 0, 0);
            gore.rotation = (float)NextDouble(rand, -MathHelper.Pi, MathHelper.Pi);
            
          
            base.OnSpawn(gore, source);
        }
        public double NextDouble(Random ran, double minValue, double maxValue)
        {
            return ran.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
