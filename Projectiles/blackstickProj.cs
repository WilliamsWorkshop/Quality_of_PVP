using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Projectiles
{
    public class blackstickProj:ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1;
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.penetrate = 15;
            Projectile.ignoreWater = true; 
            Projectile.tileCollide = false;

        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.Pi / 2;
            Projectile.ai[0] += 1;
            if (Projectile.ai[0] > 180) { Projectile.Kill(); }
            

        }
    }
}
