using System;
using System.Collections.Generic;

namespace StatsData
{
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

            if (parent == null && w?.AlternateModes != null)
            {
                foreach (Weapon alt in w.AlternateModes)
                {
                    if (alt != null)
                        Alts.Add(new WeaponVM(alt, w));
                }
            }
        }

        private Weapon W { get; set; }
        private Weapon P { get; set; }

        public Ammo Ammo => W.Ammo;

        public IList<WeaponVM> Alts { get; } = new List<WeaponVM>();

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
                if ((EffectDamageRate ?? 0) != 0)
                {
                    return EffectDamage * (1.0m / EffectDamageRate);
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

        public string Effect => W.Effect?.Name;
        public decimal? EffectDamage => W.Effect?.Damage?.Base;
        // damage details never of interest for an Effect:
        //public decimal? EffectZeroRangeMod => W.Effect?.Damage?.ZeroRangeRamp;
        //public decimal? EffectLongRangeMod => W.Effect?.Damage?.LongRangeRamp;
        //public decimal? EffectClosestRangeOffset => W.Effect?.Damage?.Offset;
        //public decimal? EffectBuildingMod => W.Effect?.Damage?.BuildingModifier;
        public decimal? EffectDamageRate => W.Effect?.DamageRate;
        public decimal? EffectMin => W.Effect?.Minimum;
        public decimal? EffectMax => W.Effect?.Maximum;
        public decimal? RadiusOfEffect => W.AreaOfEffect?.Radius;

        public WeaponVMDetail Detail { get; set; }
        public bool CanCrit => W.CanCrit;
        public bool CanMinicrit => W.CanMinicrit;

        public decimal? CritLongRangeMod => Damage?.CritLongRangeRamp;
        public decimal? CritZeroRangeMod => Damage?.CritZeroRangeRamp;
        public decimal? MinicritLongRangeMod => Damage?.MinicritLongRangeRamp;
        public decimal? MinicritZeroRangeMod => Damage?.MinicritZeroRangeRamp;

        public int CompareTo(object obj)
        {
            return Name.CompareTo(obj);
        }
    }
}
