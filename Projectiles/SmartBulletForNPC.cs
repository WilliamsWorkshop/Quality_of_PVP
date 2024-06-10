using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace QualityofPvP.Projectiles
{
    public class SmartBulletForNPC : ModProjectile
    {

        Player owner => Main.player[Projectile.owner];

        int Time;
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;

        }
        public override void AI()
        {
            Time++;

            Lighting.AddLight(Projectile.Center, 0f, 0f, 0.8f);
            int index = Projectile.FindTargetWithLineOfSight(1250);


            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                if (!npc.friendly)
                {
                    Vector2 ProjectileDirecition = npc.Center - Projectile.Center;

                    if (ProjectileDirecition.Length() == 0) { Projectile.Kill(); };
                    ProjectileDirecition /= ProjectileDirecition.Length();
                    ProjectileDirecition *= 25;
                    if (Time >= 30) { Projectile.velocity = ProjectileDirecition; }
                }
            }
           

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.Pi / 2;
            Dust dust;

            Vector2 position = Projectile.Center;
            dust = Dust.NewDustPerfect(position, 217, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 2f);
            dust.noGravity = true;
            dust.color = Color.Blue;
            dust.noLight = false;

            base.AI();
        }
      
    }
}
