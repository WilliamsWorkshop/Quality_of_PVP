using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QualityofPvP.Sound;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace QualityofPvP.Overhaul
{
    public class HeatRay : GlobalItem
    {


        public override bool InstancePerEntity => true;

        public int WarningCheck = 0;

        public int OverheatCheck = 0;

        public float Time = 0;

        public SlotId ActivationSoundSlot;

        public int overheat = 0;//过热值，每使用一次热射线提升一点，积累至12点后过热，热射线无法使用

        public int overheatCoolDown = 0;//过热后的冷却计数器

        public float PersentageofOverheat = 0;//过热条百分比

        public int overheatCD = 0;//过热cd计数器，每秒增加60点

        public bool isOverheat = false;//过热状态判断，如果为true则过热

        public int overheatcheck = 0;

        public Player plr = Main.LocalPlayer;


        public override void SetDefaults(Item item)
        {

            if (item.type == ItemID.HeatRay)
            {
                item.rare = ItemRarityID.Expert;
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (player.inventory[58].type== ItemID.HeatRay)
            {
                return false;
            }
            if (item.type == ItemID.HeatRay)
            {

                if (isOverheat || overheat>=12)
                {

                    return false;
                }
                if (!isOverheat && player.statMana > item.mana && overheat < 12)
                {

                    overheat++;


                    return true;
                }
            }
            return base.CanUseItem(item, player);
        }
        public override void UpdateInventory(Item item, Player player)
        {
            PersentageofOverheat = (float)Math.Round(100 * ((float)overheat / 12), 2);
            if (overheatCD <= 30)
            {
                overheatCD++;
            }
            if (overheatCD >= 30 && overheat > 0)
            {
                overheat--;
                overheatCD = 0;
            }
            if (overheat == 8 && WarningCheck == 0)
            {

                ActivationSoundSlot = SoundEngine.PlaySound(QualityofPvPSound.HeatRayOverheatWarning, player.Center);

                WarningCheck++;
            }
            if (overheat == 12 && OverheatCheck == 0)
            {
                ActivationSoundSlot = SoundEngine.PlaySound(QualityofPvPSound.HeatRayOverheat, player.Center);
                OverheatCheck++;
            }
            if (overheat < 7 && WarningCheck != 0)
            {
                WarningCheck = 0;
                OverheatCheck = 0;
            }
            if (overheat >= 12)
            {
                isOverheat = true;
                overheatcheck = 1;
            }

            if (overheat <= 6 && overheatcheck == 1)
            {
                isOverheat = false;
                overheatCoolDown = 0;
                overheatcheck = 0;
            }
            if (isOverheat)
            {
                overheatCoolDown++;
            }

            if (SoundEngine.TryGetActiveSound(ActivationSoundSlot, out var t1) && t1.IsPlaying)//过热音效跟随玩家
            {
                t1.Position = player.Center;

            }
            base.UpdateInventory(item, player);
        }
        public override void PostDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (item.type == ItemID.HeatRay)
            {
                float BarScale = 0.75f;


                var BarBackground = ModContent.Request<Texture2D>("QualityofPvP/UI/ReloadingBarBack").Value;
                var BarFrontground = ModContent.Request<Texture2D>("QualityofPvP/UI/ReloadingBarFront").Value;

                Vector2 barOrigin = BarBackground.Size() * 0.5f;
                float yOffset = 20f;
                Vector2 drawPos = position + Vector2.UnitY /** scale*/ * (yOffset/*- frame.Height*/);
                Rectangle frameCrop1 = new Rectangle(0, 0, (int)(overheat / 12f * BarFrontground.Width), BarFrontground.Height);
                Rectangle frameCrop2 = new Rectangle(0, 0, (int)(overheatCoolDown / 180f * BarFrontground.Width), BarFrontground.Height);


                Color color = Main.hslToRgb((Main.GlobalTimeWrappedHourly * 0.6f) % 1, 1, 0.85f + (float)Math.Sin(Main.GlobalTimeWrappedHourly * 3f) * 0.1f);
                Color color1 = new Color();

                if (overheat <= 6)
                {
                    color1.G = 255;
                }
                if (overheat > 6)
                {
                    color1.G = (byte)(255 - 255 * (overheat / 12f));
                }


                color1.R = (byte)(255 * (overheat / 12f));
                color1.B = 0;

                Color color2 = new Color();

                color2.R = 128;
                color2.G = 0;
                color2.B = 0;

                if (overheat>0)
                {
                    spriteBatch.Draw(BarBackground, drawPos, null, color, 0f, barOrigin, /*scale **/ BarScale, 0f, 0f);
                    if (!isOverheat)
                    {
                        spriteBatch.Draw(BarFrontground, drawPos, frameCrop1, color1 * 0.8f, 0f, barOrigin,/* scale **/ BarScale, 0f, 0f);
                    }
                    if (isOverheat)
                    {
                        spriteBatch.Draw(BarFrontground, drawPos, frameCrop2, color2 * 0.8f, 0f, barOrigin, /*scale **/ BarScale, 0f, 0f);
                    }
                }
               
            }
            else
                return;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.HeatRay)
            {
                tooltips.Add(new TooltipLine(Mod, "cantUseInMouse", "用鼠标拿起时无法使用"));
                tooltips.Add(new TooltipLine(Mod, "HeatRayToolTip", "频繁使用将会积累过热值\n当过热值达到100%后,需要三秒的时间才能再次使用\n伤害随过热值的升高而降低"));
                tooltips.Add(new TooltipLine(Mod, "OverheatHint", "过热值" + PersentageofOverheat.ToString() + "%"));
                if (overheat >= 8 && overheatcheck == 0) { tooltips.Add(new TooltipLine(Mod, "AbouttoOverheat", "即将过热")); }
                if (overheat >= 6 && overheatcheck == 1) { tooltips.Add(new TooltipLine(Mod, "Overheating", "过热恢复中...")); }
                foreach (var line in tooltips)
                {
                    if (line.Name == "HeatRayToolTip")
                    {
                        line.OverrideColor = Color.Yellow;
                    }
                    if (line.Name == "OverheatHint")
                    {
                        line.OverrideColor = Color.White;
                    }
                    if (line.Name == "AbouttoOverheat" || line.Name == "Overheating" || line.Name== "cantUseInMouse")
                    {
                        line.OverrideColor = Color.Red;
                    }
                }
            }

        }
        
        public override void PostUpdate(Item item)
        {
            if (item.type==ItemID.HeatRay)
            {
               

                base.PostUpdate(item);
            }
           
           
            base.PostUpdate(item);
        }
        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {


            if (item.type == ItemID.HeatRay)
            {
               
                for (int i = 0; i < overheat; i++)
                {
                    damage *= 0.9f;
                }
            }
        }

    }
}
