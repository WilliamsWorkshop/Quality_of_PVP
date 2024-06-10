using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QualityofPvP.Items;
using QualityofPvP.Keys;
using QualityofPvP.QualityofPVPDust;
using QualityofPvP.QualityofPVPGore;
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
    public class MagazineofEachGun : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public short reloadCD = 0;//装弹计时器，持有枪械时每秒+60

        public bool isReloading;//装弹判断，装弹时返回true

        //public bool isOutofAmmo = false;//判断弹夹是否打空，打空时返回true

        public short BulletLeft = 0;//弹夹内剩余子弹

        public short MaxLoadofMagazing = 0;//弹夹装填上限 ！！！需要初始化！！！

        public short check;//

        public short soundcheck;

        public short MaxreloadCD = 0;//装弹CD，单位为60/秒  ！！！需要初始化！！！

        public int LastEjectionCheck = 0;

        public SlotId ActivationSoundSlot;

        public List<GunWithMagazing> initializeListofWeapon()//在此更改武器列表
        {
            var List = new List<GunWithMagazing>
            {
                new GunWithMagazing(ItemID.Handgun,21,60,1,15,QualityofPvPSound.Pistol_Reloading,QualityofPvPSound.Pistol_Fire1,QualityofPvPSound.Pistol_LastBulletFire1){ },
                new GunWithMagazing(ItemID.Uzi,40,120,1, QualityofPvPSound.SMG_Reloading1,QualityofPvPSound.SMG_Fire1,QualityofPvPSound.SMG_LastBulletFire1){ },
                new GunWithMagazing(ItemID.SDMG,28,128,1,34, QualityofPvPSound.AutomaticRifle_Reloading2,QualityofPvPSound.AutomaticRifle_Fire2,QualityofPvPSound.AutomaticRifle_LastBulletFire2){},
                new GunWithMagazing(ItemID.Minishark,50,220,1, QualityofPvPSound.MechineGun_Reloading1,QualityofPvPSound.MechineGun_Fire1,QualityofPvPSound.MechineGun_LastBulletFire1){ },
                new GunWithMagazing((short)ModContent.ItemType<ProwlerSMG>(),35,150,5,QualityofPvPSound.ProwlerSMGReloading,QualityofPvPSound.ProwlerSMGFire,QualityofPvPSound.ProwlerSMGLastBulletFire){ },
                new GunWithMagazing(ItemID.SniperRifle,7,220,1,17,QualityofPvPSound.Sniperrifle_Reloading2,QualityofPvPSound.HalfAutomaticRifle_Fire1,QualityofPvPSound.HalfAutomaticRifle_LastBulletFire1){},
                new GunWithMagazing(ItemID.TacticalShotgun,8,135,1,QualityofPvPSound.Shotgun_Reloading2,QualityofPvPSound.Shotgun_Fire2,QualityofPvPSound.Shotgun_LastBulletFire2){},
                new GunWithMagazing(ItemID.PhoenixBlaster,25,105,1,10,QualityofPvPSound.AutomaticPistol_Reloading,QualityofPvPSound.AutomaticPistol_Fire1,QualityofPvPSound.AutomaticPistol_LastBulletFire1){ },
                new GunWithMagazing(ItemID.VenusMagnum,6,140,1,0,QualityofPvPSound.Magnum_Reloading1,QualityofPvPSound.Magnum_Fire1,QualityofPvPSound.Magnum_LastBulletFire1){ },
                new GunWithMagazing(ItemID.Megashark,30,160,1,10,QualityofPvPSound.AutomaticRifle_Reloading1,QualityofPvPSound.AutomaticRifle_Fire1,QualityofPvPSound.AutomaticRifle_LastBulletFire1){},
                new GunWithMagazing(ItemID.ChainGun,80,220,1,10,QualityofPvPSound.MechineGun_Reloading1,QualityofPvPSound.MechineGun_Fire1,QualityofPvPSound.MechineGun_LastBulletFire1){},
                //new GunWithMagazing(ItemID.VortexBeater,26,120,1,10,QualityofPvPSound.EnergySMG_Reloading1,QualityofPvPSound.EnergySMG_Fire1,QualityofPvPSound.EnergySMG_LastBulletFire1){}
                new GunWithMagazing(ItemID.SuperStarCannon,32,170,4,false,QualityofPvPSound.EnergyAssaultRifle_Reloading1,QualityofPvPSound.EnergyAssaultRifle_Fire1,QualityofPvPSound.EnergyAssaultRifle_LastBulletFire1){},
                new GunWithMagazing(ItemID.StarCannon,26,130,1,false,QualityofPvPSound.EnergySMG_Reloading1,QualityofPvPSound.EnergySMG_Fire1,QualityofPvPSound.EnergySMG_LastBulletFire1){}
            };
            return List;
        }

        public override void HoldItem(Item item, Player player)
        {
            foreach (var aimitem in initializeListofWeapon())
            {

                if (item.type == aimitem.ID && item.type != Main.mouseItem.type)
                {

                    if (QualityofPVPKeybinds.Reload.JustPressed && BulletLeft < MaxLoadofMagazing)
                    {

                        isReloading = true;
                        BulletLeft = 0;

                    }
                    if (isReloading)
                    {
                        //只跟左轮和狙相关
                        if (aimitem.ID == ItemID.VenusMagnum)
                        {
                            if (LastEjectionCheck == 0)
                            {
                                for (int i2 = 1; i2 <= MaxLoadofMagazing; i2++)
                                {
                                    //GunWithMagazing.EjectionDustSpawn(player, aimitem);
                                    GunWithMagazing.EjectionGoreSpawn(player, aimitem);
                                }
                                LastEjectionCheck++;
                            }
                        }
                        if (aimitem.ID == ItemID.SniperRifle)
                        {
                            if (LastEjectionCheck == 0)
                            {

                                GunWithMagazing.EjectionGoreSpawn(player, ItemID.SniperRifle,0);

                                LastEjectionCheck++;
                            }
                        }
                        //只跟左轮和狙相关
                        if (soundcheck == 0)
                        {
                            SoundStyle Reloading = aimitem.ReloadingSound
                            //    with
                            //{
                            //    Volume = 1f
                            //}
                            ;
                            ActivationSoundSlot = SoundEngine.PlaySound(Reloading, player.Center);

                            soundcheck = 1;
                        }


                        reloadCD++;

                    }

                    if (SoundEngine.TryGetActiveSound(ActivationSoundSlot, out var t) && t.IsPlaying)//音效跟随玩家
                    {

                        t.Position = player.Center;

                    }
                    if (reloadCD >= MaxreloadCD)
                    {

                        isReloading = false;
                        BulletLeft = aimitem.MaxLoadofMagazing;
                        reloadCD = 0;
                        //只跟左轮和狙相关
                        LastEjectionCheck = 0;
                        //只跟左轮和狙相关
                        soundcheck = 0;
                    }
                }

            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            Item itemHeld = player.inventory[player.selectedItem];
            Item itemHover = player.inventory[58];
            foreach (var aimitem in initializeListofWeapon())
            {

                if (item.type == aimitem.ID)
                {
                    if (itemHeld.type != item.type)
                    {
                        soundcheck = 0;
                        if (SoundEngine.TryGetActiveSound(ActivationSoundSlot, out var t1) && t1.IsPlaying)
                        {

                            t1.Stop();
                        }

                        reloadCD = 0;
                    }


                }

            }



        }


        public override void PostDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            initialize(item);
            foreach (var aimitem in initializeListofWeapon())
            {
                if (item.type == aimitem.ID)
                {
                    if (reloadCD < 0)
                    {
                        return;
                    }
                    float BarScale = 0.75f;


                    var BarBackground = ModContent.Request<Texture2D>("QualityofPvP/UI/ReloadingBarBack").Value;
                    var BarFrontground = ModContent.Request<Texture2D>("QualityofPvP/UI/ReloadingBarFront").Value;

                    Vector2 barOrigin = BarBackground.Size() * 0.5f;
                    float yOffset = 20f;
                    Vector2 drawPos = position + Vector2.UnitY /** scale*/ * (yOffset/*- frame.Height*/);
                    Rectangle frameCrop1 = new Rectangle(0, 0, (int)(BulletLeft / (float)MaxLoadofMagazing * BarFrontground.Width), BarFrontground.Height);
                    Rectangle frameCrop2 = new Rectangle(0, 0, (int)(reloadCD / (float)MaxreloadCD * BarFrontground.Width), BarFrontground.Height);


                    Color color = Main.hslToRgb((Main.GlobalTimeWrappedHourly * 0.6f) % 1, 1, 0.85f + (float)Math.Sin(Main.GlobalTimeWrappedHourly * 3f) * 0.1f);
                    Color color1 = new Color();

                    color1.R = (byte)(255 - 255 * (BulletLeft / (float)MaxLoadofMagazing));
                    color1.G = (byte)(255 * (BulletLeft / (float)MaxLoadofMagazing));
                    color1.B = 0;

                    Color color2 = new Color();

                    color2.R = (byte)(255 - 255 * (reloadCD / (float)MaxreloadCD));
                    color2.G = (byte)(255 * (reloadCD / (float)MaxreloadCD));
                    color2.B = 64;

                    Color color3 = new Color();

                    color3.R = 255;
                    color3.G = 128;
                    color3.B = 128;

                    if (BulletLeft < MaxLoadofMagazing)
                    {
                        spriteBatch.Draw(BarBackground, drawPos, null, color, 0f, barOrigin, BarScale, 0f, 0f);
                        if (!isReloading)
                        {
                            spriteBatch.Draw(BarFrontground, drawPos, frameCrop1, color1 * 0.8f, 0f, barOrigin,/* scale **/ BarScale, 0f, 0f);


                        }
                        if (isReloading)
                        {

                            spriteBatch.Draw(BarFrontground, drawPos, frameCrop2, color2 * 0.8f, 0f, barOrigin, /*scale **/ BarScale, 0f, 0f);
                        }
                    }
                }



            }
        }

        public override bool CanUseItem(Item item, Player player)
        {

            foreach (var aimitem in initializeListofWeapon())
            {
                if (item.type == aimitem.ID)
                {

                    if (!isReloading && BulletLeft > 0)
                    {
                        BulletLeft -= aimitem.step;

                        for (int i = 1; i <= aimitem.step; i++)
                        {
                            //只跟左轮和狙相关
                            if (aimitem.ID != ItemID.VenusMagnum && aimitem.ID != ItemID.SniperRifle)
                                //只跟左轮和狙相关
                                //GunWithMagazing.EjectionDustSpawn(player, aimitem);
                                GunWithMagazing.EjectionGoreSpawn(player, aimitem);
                        }
                        //只跟狙有关
                        if (aimitem.ID == ItemID.SniperRifle)
                        {
                            if (BulletLeft != 0)
                            {
                                GunWithMagazing.EjectionGoreSpawn(player, aimitem);
                            }
                        }
                        //只跟狙有关



                        if (aimitem.HaveFireSound)
                        {
                            if (BulletLeft > 0)
                            {
                                SoundStyle FireSound = aimitem.FireSound1 with
                                {
                                    MaxInstances = aimitem.MaxLoadofMagazing,
                                    PitchVariance = 0.15f,

                                };
                                SoundEngine.PlaySound(FireSound, player.Center);

                            }


                            else if (BulletLeft == 0)
                            {
                                SoundStyle LastFireSound = aimitem.LastFire
                                //    with
                                //{

                                //    Volume = 1f
                                //}
                                ;
                                SoundEngine.PlaySound(LastFireSound, player.Center);

                            }

                        }


                        return true;
                    }
                    if (BulletLeft <= 0 && !isReloading && item != player.inventory[58])
                    {
                        isReloading = true;

                    }


                    if (isReloading/*BulletLeft == 0*/)
                    {
                        return false;
                    }
                    return false;
                }
            }


            return base.CanUseItem(item, player);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            foreach (var aimitem in initializeListofWeapon())
            {
                if (item.type == aimitem.ID)
                {
                    tooltips.Add(new TooltipLine(Mod, "cantReloadInMouse", "必须在快捷栏中手持才能进行换弹"));
                    tooltips.Add(new TooltipLine(Mod, "Mag", "弹药：" + BulletLeft + "/" + MaxLoadofMagazing));
                    if (BulletLeft != MaxLoadofMagazing && !isReloading)
                    {
                        tooltips.Add(new TooltipLine(Mod, "CanReload", "按 " + InTooltip.KeytoString(QualityofPVPKeybinds.Reload) + " 键重装"));
                    }

                    if (isReloading/*BulletLeft == 0*/) { tooltips.Add(new TooltipLine(Mod, "Reloading", "重装中... (" + persentage(item) + ")")); }
                    foreach (var line in tooltips)
                    {
                        if (line.Name == "Mag")
                        {
                            line.OverrideColor = Color.Yellow;
                        }
                        if (line.Name == "Reloading" || line.Name == "CanReload" || line.Name == "cantReloadInMouse")
                        {
                            line.OverrideColor = Color.Red;
                        }
                    }
                }
            }

        }
        public void initialize(Item item)//物品属性初始化
        {
            foreach (var aimitem in initializeListofWeapon())
            {
                if (item.type == aimitem.ID)
                {
                    if (check == 0)
                    {
                        MaxLoadofMagazing = aimitem.MaxLoadofMagazing;
                        BulletLeft = MaxLoadofMagazing;
                        MaxreloadCD = aimitem.MaxreloadCD;
                        check = 1;
                    }
                }
            }

        }
        public string persentage(Item item)
        {
            double persentage = 0;
            foreach (var aimitem in initializeListofWeapon())
            {
                if (item.type == aimitem.ID)
                {
                    persentage = 100 * ((double)reloadCD / MaxreloadCD);
                }
            }

            return Math.Round(persentage, 2).ToString() + "%";
        }//返回装弹百分比的字符串



    }

    public class GunWithMagazing//所有带弹夹的枪都用这个类来写
    {

        /// <summary>
        /// 初始化带弹夹枪械
        /// </summary>
        public GunWithMagazing(short ID, short MaxLoadofMagazing, short MaxreloadCD, short step, short EjectionOffset, SoundStyle ReloadingSound, SoundStyle FireSound, SoundStyle LastFire)
        {
            this.ID = ID;
            this.MaxLoadofMagazing = MaxLoadofMagazing;
            this.MaxreloadCD = MaxreloadCD;
            this.step = step;
            this.FireSound1 = FireSound;
            this.FireSound2 = FireSound;
            this.ReloadingSound = ReloadingSound;
            this.LastFire = LastFire;
            this.EjectionOffset = EjectionOffset;



        }
        public GunWithMagazing(short ID, short MaxLoadofMagazing, short MaxreloadCD, short step, bool ejection, SoundStyle ReloadingSound, SoundStyle FireSound, SoundStyle LastFire)
        {
            this.ID = ID;
            this.MaxLoadofMagazing = MaxLoadofMagazing;
            this.MaxreloadCD = MaxreloadCD;
            this.step = step;
            this.FireSound1 = FireSound;
            this.FireSound2 = FireSound;
            this.ReloadingSound = ReloadingSound;
            this.LastFire = LastFire;
            this.ejection = ejection;



        }

        public GunWithMagazing(short ID, short MaxLoadofMagazing, short MaxreloadCD, short step, SoundStyle ReloadingSound, SoundStyle FireSound, SoundStyle LastFire)
        {
            this.ID = ID;
            this.MaxLoadofMagazing = MaxLoadofMagazing;
            this.MaxreloadCD = MaxreloadCD;
            this.step = step;
            this.FireSound1 = FireSound;
            this.FireSound2 = FireSound;
            this.ReloadingSound = ReloadingSound;
            this.LastFire = LastFire;
        }


        public GunWithMagazing(short ID, short MaxLoadofMagazing, short MaxreloadCD, short step, SoundStyle ReloadingSound, bool HaveFireSound)
        {
            this.ID = ID;
            this.MaxLoadofMagazing = MaxLoadofMagazing;
            this.MaxreloadCD = MaxreloadCD;
            this.step = step;
            this.ReloadingSound = ReloadingSound;
            this.HaveFireSound = HaveFireSound;
        }
        public short ID;
        public short MaxLoadofMagazing;
        public short MaxreloadCD;
        public SoundStyle ReloadingSound;
        public SoundStyle FireSound1;
        public SoundStyle FireSound2;
        public SoundStyle LastFire;
        public bool HaveFireSound = true;
        public short step = 1;
        public short EjectionOffset = 10;
        public bool ejection = true;
        public static void EjectionDustSpawn(Player player, GunWithMagazing gun)
        {
            if (gun.ejection == true)
            {
                Vector2 Direction = Main.MouseWorld - player.RotatedRelativePoint(player.Center);
                Direction /= Direction.Length();
                Direction *= gun.EjectionOffset;
                Direction += player.RotatedRelativePoint(player.Center);

                Dust dust;
                dust = Dust.NewDustPerfect(Direction, ModContent.DustType<EjectionDust>());
            }
            else
                return;

        }
        public static void EjectionGoreSpawn(Player player, GunWithMagazing gun)
        {
            if (gun.ejection == true)
            {
                Random rand = new Random();
                Item item = new Item(gun.ID);
                double r1, r2;
                r1 = NextDouble(rand, -1.3, -0.2);
                r2 = NextDouble(rand, -2.8, -0.9);
                Vector2 Direction = Main.MouseWorld - player.RotatedRelativePoint(player.Center);
                Vector2 velocity = Vector2.UnitX * (float)r1 * Main.LocalPlayer.direction + Vector2.UnitY * (float)r2;
                Direction /= Direction.Length();
                Direction *= gun.EjectionOffset;
                Direction += player.RotatedRelativePoint(player.Center);
                var entitySource = player.GetSource_ItemUse(item);
                Gore.NewGore(entitySource, Direction, velocity, ModContent.GoreType<BulletEjecting>());
            }
            else
                return;

        }
        public static void EjectionGoreSpawn(Player player, short itemID, short offset)
        {

            Random rand = new Random();
            Item item = new Item(itemID);
            double r1, r2;
            r1 = NextDouble(rand, -1.3, -0.2);
            r2 = NextDouble(rand, -2.8, -0.9);
            Vector2 Direction = Main.MouseWorld - player.RotatedRelativePoint(player.Center);
            Vector2 velocity = Vector2.UnitX * (float)r1 * Main.LocalPlayer.direction + Vector2.UnitY * (float)r2;
            Direction /= Direction.Length();
            Direction *= offset;
            Direction += player.RotatedRelativePoint(player.Center);
            var entitySource = player.GetSource_ItemUse(item);
            Gore.NewGore(entitySource, Direction, velocity, ModContent.GoreType<BulletEjecting>());


        }

        public static double NextDouble(Random ran, double minValue, double maxValue)
        {
            return ran.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}

