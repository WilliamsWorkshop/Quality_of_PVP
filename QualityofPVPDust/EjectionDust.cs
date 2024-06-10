using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System.Diagnostics;
namespace QualityofPvP.QualityofPVPDust
{
    public class EjectionDust:ModDust
    {
        
        public override void OnSpawn(Terraria.Dust dust)
        {
            Random rand = new Random();
            dust.frame = Texture2D.Frame();
            dust.rotation = (float)NextDouble(rand, -MathHelper.Pi, MathHelper.Pi);
            dust.noGravity = false;
            double r1, r2;
            r1 = NextDouble(rand, -1.3, -0.2);
            r2 = NextDouble(rand, -2.8, -0.9);
            dust.velocity = Vector2.UnitX * (float)r1*Main.LocalPlayer.direction + Vector2.UnitY * (float)r2;
            
            base.OnSpawn(dust);
        }
        public override bool Update(Terraria.Dust dust)
        {
            
            return true;
        }
        public override bool MidUpdate(Dust dust)
        {
            dust.fadeIn++;
            dust.scale = 1.1f;


            if (dust.fadeIn >= 1.5 * 60)
                dust.active = false;
            return true;
        }
        public double NextDouble(Random ran, double minValue, double maxValue)
        {
            return ran.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
