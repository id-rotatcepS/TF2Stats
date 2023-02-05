using StatsData.WikiPages;
using System;
using System.Collections.Generic;

namespace StatsData
{
    /* Playing with short-form text stats: */

    //  9-90; 6dx10(28:1), 96dps; 3-32; 8-81 - 12-121 minicrit; 18-180 crit

    // pistol (scout)
    // dmg: 22 / b:15 (100/s) / 8
    // amm: 12 (1.005s reload) / 36
    // acc: 47:1 recoil spread
    //
    // mini: 30 / 20 ; crit: 45
    // accu: 61% (recoil)

    // shotgun (common)
    // dmg: 9-90 / b:6-60 (96/s) / 3-32
    // amm: 6 (.87-3.37s reload) / 32
    // acc: 28:1 shot spread
    //
    // mini: 12-121 / 8-81 ; crit: 18-180
    // accu: 36% (spread)

    // rocket launcher
    // dmg: 56-112 / b:45-90 (112.5/s) / 24-48
    // amm: 4 (.92-3.32s reload) / 20
    // acc: 1100 HU/s; 146 HU radius
    //
    // mini: ?-151 / ?-122 ; crit: ?-270
    // accu: 12m/s; 1.2m radius
    // accu: 18% (impact) 122% (splash)

    // grenade launcher; roller
    // dmg: 50-100 (166.67/s); 30-60
    // amm: 4 (1.24-3.04s reload) / 16
    // acc: 1216.6 HU/s; 146 HU radius; fuse: 2.3s
    //
    // mini: ?-135; ?-81 ; crit: ?-300; ?-180
    // accu: 12m/s; 1.2m radius; fuse: 2.3s
    // accu: 19% (impact) 135% (splash) max: 547%

    // flame thrower (not including afterburn)
    // dmg: 13 (170/s) / b:6-13  / 3
    // amm: 200
    // acc: 2450 HU/s 8.5% drag; limit: 385.24 HU
    //
    // mini: 9-17 / 4-9 ; crit: 19-38 / 10-19
    // accu: 24m/s 8.5% drag; limit: 5.6m
    // accu: 39% (impact); max: 75%

    /********************************************/


    //https://docs.google.com/spreadsheets/d/1-Qu7WHA9dlTAlVEEI3DSeYrhZs2l157e2azezESt7b4/edit#gid=0
    public class WeaponVM : IComparable
    {
        public WeaponVM(Weapon w) : this(w, null)
        {
        }
        public WeaponVM(Weapon w, Weapon parent)
        {
            W = w;
            P = parent;
            Detail = new WeaponVMDetail(this, w, parent);
            LoadoutStats = new LoadoutStatsVM(w);

            if (parent == null && w?.AlternateModes != null)
            {
                foreach (Weapon alt in w.AlternateModes)
                {
                    if (alt != null)
                        Alts.Add(new WeaponVM(alt, w));
                }
            }

            if (parent == null && w?.SeparateModes != null)
            {
                foreach (Weapon alt in w.SeparateModes)
                {
                    if (alt != null)
                        Separates.Add(new WeaponVM(alt, null));//TODO passing null because I don't remember why it works this way and need to populate Alts in these VMs
                }
            }
        }

        private Weapon W { get; set; }
        private Weapon P { get; set; }

        public Ammo Ammo => W.Ammo;

        public IList<WeaponVM> Alts { get; } = new List<WeaponVM>();
        public IList<WeaponVM> Separates { get; } = new List<WeaponVM>();

        public string Name => P != null
            ? P.Name + "\n>" + W.Name
            : W.Name;

        internal Damage Damage => W.Melee?.Damage
            ?? W.Hitscan?.Damage
            ?? W.Projectile?.HitDamage;
        public decimal? BaseDamage => Damage?.Base;
        public decimal? ZeroRangeMod => (Damage?.ZeroRangeRamp) == 1.0m
            ? null
            : Damage?.ZeroRangeRamp;
        public decimal? LongRangeMod => (Damage?.LongRangeRamp) == 1.0m
            ? null
            : Damage?.LongRangeRamp;
        public decimal? BuildingMod => (Damage?.BuildingModifier) == 1.0m
            ? null
            : Damage?.BuildingModifier;

        public decimal? DPS => GetDPS();

        private decimal? GetDPS()
        {
            decimal fireRate = GetEffectiveFireRate();

            if (fireRate == 0)
            {
                EffectVM effectVM = EffectVM.GetEffectVM(Detail.FunctionTimes, W.Effect);
                if (effectVM != null && effectVM.DamageRate != 0)
                {
                    return effectVM.DamageBase * (1.0m / effectVM.DamageRate);
                }

                return null;
            }

            return Damage?.Base * (1.0m / fireRate);
        }

        //TODO use this value in a tooltip or something on fire rate when it's a different value.
        private decimal GetEffectiveFireRate()
        {
            decimal fireRate = FireRate;
            // single shot weapon reload is functionally part of its rate
            if (W.Ammo != null && W.Ammo.Loaded == 1 && W.Ammo.Reload > 0 && Damage?.Base != 0)
            {
                fireRate += W.Ammo.Reload;
            }

            return fireRate;
        }

        public decimal? MaxRange => W.Melee?.MaxRange
            ?? (W.Projectile?.MaxRangeTime > 0 ? (W.Projectile.MaxRangeTime * W.Projectile.Speed) : (decimal?)null);

        //AccurateRange
        public decimal? AccurateRange => GetAccurateRange(Spread ?? 0, Speed ?? 0, SplashRadius ?? 0);

        public static decimal GetAccurateRange(decimal spread, decimal speed, decimal splashradius)
        {
            //?? 0.049
            if (spread > 0)
                return 1.0m / ((decimal)Math.Tan((double)spread)) * (0.5m * 25);

            //(exp radius + coll box "radius" / 300Hu/s median speed) = time to edge of impact zone .. * V = travel distance for explosion to still impact target

            //{{#ifexpr:{{{V|0}}}>0|{{#expr:((({{{E|1.0}}}*146)+16)/300)*{{{V|1100}}}}}}}
            if (speed > 0)
            {
                decimal impactZoneSize = (49.0m / 2.0m);
                //((({{{E|1.0}}}*146)+16)/300)*{{{V|1100}}}
                if (splashradius == 0)
                {
                    decimal projectileSpeed = speed;
                    //{{#expr:(( ((49/2)/300) *{{{V|0}}})/512*100)round0}}% ({{tooltip|projectile|{{{V}}}{{common strings|Hus}}}})
                    decimal maxTimeInImpactZone = impactZoneSize / 300.0m; // (targetSize/2) / targetMoveSpeed
                    decimal maxDistanceToHitImpactZone = maxTimeInImpactZone * projectileSpeed;
                    return maxDistanceToHitImpactZone;
                    //return (((1.0 * 146.0) + 16.0) / 300.0) * speed;
                }
                else
                {
                    decimal splashZoneSize = splashradius;// (splashradius * 146.0);
                    return ((splashZoneSize + impactZoneSize) / 300.0m) * speed;
                    //return (((splashradius * 146.0) + 16.0) / 300.0) * speed;
                }

            }

            return 0;
        }

        private decimal? SpreadBase => W.Hitscan?.Fragmentation?.Spread
            ?? W.Hitscan?.Recoil?.Spread
            ?? W.Projectile?.Spread
            ;
        public decimal? Spread => SpreadBase == 0 ? (decimal?)null : SpreadBase;
        public int? Fragments => W.Hitscan?.Fragmentation?.Fragments;
        public decimal? Recovery => W.Hitscan?.Recoil?.Recovery;
        public decimal? Speed => W.Projectile?.Speed;
        public string NoGrav => NoGravBase.HasValue
            ? (NoGravBase.Value ? "Straight" : "Arch")
            : "";
        private bool? NoGravBase => W.Projectile?.Propelled;
        public string Deflects => DeflectsBase.HasValue
            ? (DeflectsBase.Value ? "" : "Immune")
            : "";
        private bool? DeflectsBase => W.Projectile?.Influenceable;
        public string Pen => PenBase.HasValue
            ? (PenBase.Value ? "Penetrates" : "")
            : "";
        private bool? PenBase => W.Projectile?.Penetrating
            ?? W.Hitscan?.Penetrating
            ;
        public decimal? SplashRadius => W.Projectile?.Splash?.Radius
            ?? W.Hitscan?.Splash?.Radius;// not including AOE - that's below for Effect
        public string FragmentType => W.Hitscan?.Fragmentation?.FragmentType;
        public decimal? Arm => W.Projectile?.ArmTime == 0
            ? (decimal?)null
            : W.Projectile?.ArmTime;
        public decimal? Activation => W.ActivationTime == 0
            ? (decimal?)null
            : W.ActivationTime;
        public decimal? ChargeTime => W.ChargeTime == 0
            ? (decimal?)null
            : W.ChargeTime;
        public decimal FireRate => W.FireRate;
        public string Type => W.WeaponType;
        public int Level => W.Level;
        public decimal? ClosestRangeOffset => Damage?.Offset;

        //public string Ammo => W.Ammo?.AmmoType;
        //public int? LoadedInit => W.Ammo?.InitialLoaded;
        //public int? Loaded => W.Ammo?.Loaded;
        //public int? Carried => W.Ammo?.Carried;
        //public decimal? ReloadFirst => W.Ammo?.ReloadFirst;
        //public decimal? ReloadAdditional => W.Ammo?.ReloadAdditional;
        ////public string Reload => W.Ammo?.Reload
        //public string ReloadType => W.Ammo?.ReloadUsing;

        //public string FireType => W.Ammo?.FireType;

        public string Effect => GetEffectsText();

        private string GetEffectsText()
        {
            string result = string.Empty;
            Weapon We = W;
            result = GetEffectsTextWithAlts(result, We);
            if (We.SeparateModes != null)
            {
                foreach (Weapon w in W.SeparateModes)
                {
                    result = GetEffectsTextWithAlts(result, w);
                }
            }

            return result;
        }

        private string GetEffectsTextWithAlts(string result, Weapon We)
        {
            result = GetEffectsText(result, We);
            if (We.AlternateModes != null)
            {
                foreach (Weapon w in We.AlternateModes)
                {
                    result = GetEffectsText(result, w);
                }
            }

            return result;
        }

        private static string GetEffectsText(string result, Weapon We)
        {
            foreach (Effect e in We.Effects)
            {
                string effect = e.Name;
                if (e.Damage != null)
                {
                    //TODO include this
                }
                if (e.DamageRate > 0)
                {

                }
                if (e.Minimum == e.Maximum && e.Minimum > 0)
                {
                    effect = string.Format("{0:0.#} s ", e.Minimum) + effect;
                }
                else if (e.Minimum > 0 || e.Maximum > 0)
                {
                    effect = string.Format("{0:0.#}-{0:0.#} s ", e.Minimum, e.Maximum) + effect;
                }
                if (!result.Contains(effect))
                    result += effect + "\n";
            }

            return result;
        }

        //public decimal? EffectDamage => W.Effect?.Damage?.Base;
        //// damage details never of interest for an Effect:
        ////public decimal? EffectZeroRangeMod => W.Effect?.Damage?.ZeroRangeRamp;
        ////public decimal? EffectLongRangeMod => W.Effect?.Damage?.LongRangeRamp;
        ////public decimal? EffectClosestRangeOffset => W.Effect?.Damage?.Offset;
        ////public decimal? EffectBuildingMod => W.Effect?.Damage?.BuildingModifier;
        //public decimal? EffectDamageRate => W.Effect?.DamageRate;
        //public decimal? EffectMin => W.Effect?.Minimum;
        //public decimal? EffectMax => W.Effect?.Maximum;
        //public decimal? RadiusOfEffect => W.AreaOfEffect?.Radius;

        public WeaponVMDetail Detail { get; set; }
        public LoadoutStatsVM LoadoutStats { get; }

        public bool CanCrit => W.CanCrit;
        public bool CanMinicrit => W.CanMinicrit;

        //public decimal? CritLongRangeMod => Damage?.CritLongRangeRamp;
        //public decimal? CritZeroRangeMod => Damage?.CritZeroRangeRamp;
        //public decimal? MinicritLongRangeMod => Damage?.MinicritLongRangeRamp;
        //public decimal? MinicritZeroRangeMod => Damage?.MinicritZeroRangeRamp;

        public int CompareTo(object obj)
        {
            return Name.CompareTo(obj);
        }
    }
}
