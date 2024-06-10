using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Projectiles
{
    public class SmartBullet : ModProjectile
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
            Lighting.AddLight(Projectile.Center, 0f, 0.8f, 0f);

            int indexofPlayer = FindPlayerTargetWithLineOfSight(1250);
          
            if (indexofPlayer >= 0)
            {
                Player player = Main.player[indexofPlayer];
                if (player != owner && !player.dead && player.hostile && owner.hostile)
                {
                    Vector2 ProjectileDirecition = player.Center - Projectile.Center;

                    if (ProjectileDirecition.Length() == 0) { Projectile.Kill(); };
                    ProjectileDirecition /= ProjectileDirecition.Length();
                    ProjectileDirecition *= 25;
                    if (Time>=30) { Projectile.velocity = ProjectileDirecition; }
                    
                }
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.Pi / 2;
            Dust dust;

            Vector2 position = Projectile.Center;
            dust = Dust.NewDustPerfect(position, 217, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 2f);
            dust.noGravity = true;
            dust.color = Color.Green;
            dust.noLight = false;

            base.AI();
        }
        public override void OnKill(int timeLeft)
        {
            
            base.OnKill(timeLeft);
        }
        public int FindPlayerTargetWithLineOfSight(float maxRange = 800f)
        {
            float num = maxRange;
            int result = -1;
            for (int i = 0; i < 200; i++)
            {
                Player pLAYER = Main.player[i];
                //bool flag = pLAYER.CanBeChasedBy(this);
                //if (localNPCImmunity[i] != 0)
                //    flag = false;

                //if (flag)
                //{
                    float num2 = Projectile.Distance(Main.player[i].Center);
                    if (num2 < num && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, pLAYER.position, pLAYER.width, pLAYER.height))
                    {
                        num = num2;
                        result = i;
                    }
               // }
            }

            return result;
        }
    }
}
