using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using QualityofPvP.Sound;
using System;
using Terraria.ID;

namespace QualityofPvP.Projectiles.AbstractProjectile
{
    public class PhenixKitHoldOut : ModProjectile
    {
        public Player Owner => Main.player[Projectile.owner];

        public ref float Time => ref Projectile.ai[0];

        public const int Lifetime = 600;

        public SlotId ActivationSoundSlot;

        public Player plr = Main.LocalPlayer;


        public override string Texture => "QualityofPvP/Items/PhenixKit";
        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = Lifetime;
            Projectile.penetrate = -1;
        }
        public override void AI()
        {
            Time++;

            if (!Owner.channel || Owner.noItems || Owner.CCed)
            {

                if (SoundEngine.TryGetActiveSound(ActivationSoundSlot, out var t) && t.IsPlaying)
                {

                    t.Stop();
                }
                Projectile.Kill();
                return;
            }
            UpdatePlayerFields();
            //Owner.velocity *= 0.1f;
            //Owner.moveSpeed *= 0.3f;
            //Owner.maxRunSpeed /= 2f;
            //Owner.accRunSpeed = Owner.maxRunSpeed;
            Owner.AddBuff(BuffID.OgreSpit,1);
            if (Time >= Lifetime)
            {
                Owner.Heal(Owner.statLifeMax2);
            }
            if (Time == 2f)
                ActivationSoundSlot = SoundEngine.PlaySound(QualityofPvPSound.PhenixKitSound, Main.LocalPlayer.Center);

            if (SoundEngine.TryGetActiveSound(ActivationSoundSlot, out var t2) && t2.IsPlaying)
            {
                t2.Position = Projectile.Center;

            }

        }
        public void UpdatePlayerFields()
        {
            if (Projectile.localAI[0] == 0f)
            {
                Projectile.spriteDirection = Owner.direction;
                Projectile.localAI[0] = 1f;
            }
            Owner.itemRotation = 0f;
            Owner.heldProj = Projectile.whoAmI;
            Owner.itemTime = 2;
            Owner.itemAnimation = 2;
            Owner.ChangeDir(Projectile.spriteDirection);
            Projectile.rotation = Owner.direction*MathHelper.Pi / 4;
            if (Owner.direction == 1)
            {
                Projectile.Center = Owner.RotatedRelativePoint(Owner.MountedCenter, false) + Vector2.UnitX * Projectile.spriteDirection * 13f;
            }
            else if (Owner.direction == -1)
            {
                Projectile.Center = Owner.RotatedRelativePoint(Owner.MountedCenter, false) + Vector2.UnitX * Projectile.spriteDirection * 23f;
            }
        }

    }

}
