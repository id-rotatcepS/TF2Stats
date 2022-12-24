using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Media;

namespace StatsData
{
    public class LoadoutStatsVM
    {
        private readonly Weapon w;

        public LoadoutStatsVM(Weapon w)
        {
            this.w = w;
        }

        public IEnumerable<AttributeVM> Attributes => w.Attributes.Select(a => new AttributeVM(a));

        public string LevelAndType =>
            string.Format("Level {0} {1}",
                
                w.Level == 0 
                ? "1-100" 
                : ((w.Level < 0) 
                ? "1-" + (0 - (w.Level - 1)) 
                : w.Level.ToString()),

                w.WeaponType);

        public string MiniStats =>
            GetMiniStats(w);

        private string GetMiniStats(Weapon w)
        {
            //damage: 60 (75 DPS) ranges 120%-52.8% (buildings 20%)
            //accurate range: 18% (projectile, 1100Hu/s)
            //                122% (projectile splash, 1100Hu/s 146Hu radius)
            //accurate range: 61% (recoil spread, 1.25 sec recovery)
            //accurate range: 36% (shot spread, 10 pellets)
            //accurate range: melee
            //Max Range: 54%

            //60 dps:75 clo:120% far:53% bld:20%
            //1200Hu/s acc @ 19% of mid

            //30 dps:15
            //2000Hu/s acc @ 32% of mid

            //60 dps:75 clo:120% far:53%
            //1200Hu/s acc @ 19% of mid
            //  Splash acc @ 90% of mid

            //40 dps:80 clo:150% far:53%
            //Recoil acc @ 98% of mid

            //50 dps:33

            //60 dps:96 clo:175% far:53%
            //10 pellets acc @ 36% of mid

            //36 dps:343 clo:150% far:53%
            //4 bullets acc @ 30% of mid

            //3 dps:43 clo:200%
            //2450Hu/s acc @ 39% of mid
            //Max range @ 75% of mid

            //100 dps:167 bld:120%
            //1513Hu/s acc @ 24% of mid
            //  Splash acc @ 132% of mid
            //Max range @ 680% of mid


            StringBuilder stats = new StringBuilder();
            WeaponVM weaponVM = new WeaponVM(w);
            //stats.AppendLine(weaponVM.Detail.RangePercents);
            //stats.AppendLine(weaponVM.Detail.RangeDamage);

            string damage = string.Format(MINI_DAMAGE_FORMAT,
                GetBaseDamage(weaponVM),
                !weaponVM.DPS.HasValue ? string.Empty
                  : string.Format(MINI_DAMAGE_DPS_FORMAT, weaponVM.DPS.Value),
                weaponVM.Damage?.ZeroRangeRamp == weaponVM.Damage?.LongRangeRamp || (weaponVM.Damage?.ZeroRangeRamp??1.0m)==1.0m ? string.Empty
                  : string.Format(MINI_DAMAGE_CLO_FORMAT, RangePercent(weaponVM.Damage?.ZeroRangeRamp)),
                weaponVM.Damage?.ZeroRangeRamp == weaponVM.Damage?.LongRangeRamp || (weaponVM.Damage?.LongRangeRamp ?? 1.0m) == 1.0m ? string.Empty
                  : string.Format(MINI_DAMAGE_FAR_FORMAT, RangePercent(weaponVM.Damage?.LongRangeRamp)),
                weaponVM.Damage == null || weaponVM.Damage.BuildingModifier == 1.0m ? string.Empty
                  : string.Format(MINI_DAMAGE_BLD_FORMAT, WeaponVMDetail.RangePercent(weaponVM.Damage.BuildingModifier))
                  );
            if (!damage.Equals(string.Format(MINI_DAMAGE_FORMAT, null, null, null, null, null)))
                stats.AppendLine(damage);

            string accuracy
                = (weaponVM.Recovery ?? 0) > 0 ? string.Format(MINI_RECOIL_FORMAT, WeaponVMDetail.GetSpreadAccuracyValue(weaponVM), weaponVM.Recovery)
                : ((weaponVM.Spread ?? 0) > 0 ? string.Format(MINI_PELLETS_FORMAT, WeaponVMDetail.GetSpreadAccuracyValue(weaponVM), weaponVM.Fragments, weaponVM.FragmentType)
                : ((weaponVM.Speed ?? 0) > 0 ? string.Format(MINI_PROJECTILE_FORMAT, WeaponVMDetail.GetSpeedAccuracyValue(weaponVM), weaponVM.Speed ?? 0)
                : ""/*((weaponVM?.MaxRange ?? 0) == 0 ? "infinite"
                : "melee")*/
                ));
            if (!string.IsNullOrWhiteSpace(accuracy))
                stats.AppendLine(accuracy);

            string accuracySplash
                = (weaponVM.SplashRadius ?? 0) > 0
                ? string.Format(MINI_SPLASH_FORMAT, WeaponVMDetail.GetSplashAccuracyValue(weaponVM), weaponVM.SplashRadius ?? 1.0m, weaponVM.Speed ?? 0)
                : string.Empty;
            if (!string.IsNullOrWhiteSpace(accuracySplash))
                stats.AppendLine(accuracySplash);
            
            string maxRange =
                weaponVM.MaxRange != null && weaponVM.MaxRange != 0
            ? string.Format(MINI_MAXRANGE_FORMAT, weaponVM.MaxRange / 512.0m * 100.0m)
            : string.Empty;
            if (!string.IsNullOrWhiteSpace(maxRange))
                stats.AppendLine(maxRange);

            return stats.ToString();
        }
        private static readonly string MINI_DAMAGE_FORMAT = "{0}{1}{2}{3}{4}";
        private static readonly string MINI_DAMAGE_BAS_FORMAT = "{0:0.}";
        private static readonly string MINI_DAMAGE_DPS_FORMAT = " ({0:0.} dps)";
        private static readonly string MINI_DAMAGE_CLO_FORMAT = " clo:{0}";
        private static readonly string MINI_DAMAGE_FAR_FORMAT = " far:{0}";
        private static readonly string MINI_DAMAGE_BLD_FORMAT = " bld:{0}";
        private static readonly string MINI_RECOIL_FORMAT = "Recoil acc @ {0:0.}% of mid";
        private static readonly string MINI_PELLETS_FORMAT = "{1} {2}s acc @ {0:0.}% of mid";
        private static readonly string MINI_PROJECTILE_FORMAT = "{1:0.}Hu/s acc @ {0:0.}% of mid";
        private static readonly string MINI_SPLASH_FORMAT = "  Splash acc @ {0:0.}% of mid";
        private static readonly string MINI_MAXRANGE_FORMAT = "Max range @ {0:0.}% of mid";
        //private static readonly string MINI_DAMAGE_FORMAT = "damage: {0}{1}{2}{3}{4}";
        //private static readonly string MINI_DAMAGE_BAS_FORMAT = "{0}";
        //private static readonly string MINI_DAMAGE_DPS_FORMAT = " ({0:0.##} DPS)";
        //private static readonly string MINI_DAMAGE_CLO_FORMAT = " ranges{0}";
        //private static readonly string MINI_DAMAGE_FAR_FORMAT = "-{0}";
        //private static readonly string MINI_DAMAGE_BLD_FORMAT = " (buildings {0})";
        //private static readonly string MINI_RECOIL_FORMAT = "{0}% (recoil spread, {1} sec recovery)";
        //private static readonly string MINI_PELLETS_FORMAT = "{0}% (shot spread, {1} {2}s)";
        //private static readonly string MINI_PROJECTILE_FORMAT = "{0}% (projectile, {1}Hu/s)";
        //private static readonly string MINI_SPLASH_FORMAT = "             " + "{0}% (projectile splash, {2}Hu/s {1}Hu radius)";
        //private static readonly string MINI_MAXRANGE_FORMAT = "Max Range: {0:0.}%";

        private string GetBaseDamage(WeaponVM weaponVM)
        {
            return weaponVM.BaseDamage.HasValue? string.Format(MINI_DAMAGE_BAS_FORMAT, weaponVM.BaseDamage.Value):null;
        }

        private string GetRangePercents(WeaponVM weaponVM)
        {
            return GetRangePercents(weaponVM.Damage) + GetBuildingPercent(weaponVM.Damage);
        }
        private string GetRangePercents(Damage d)
        {
            return (d?.ZeroRangeRamp == d?.LongRangeRamp
               ? ""
                : string.Format(" {0}-{1}",
                RangePercent(d?.ZeroRangeRamp),
                RangePercent(d?.LongRangeRamp)
                ));
        }

        private string RangePercent(decimal? percent)
        {
            return (percent == null ) // but not skipping if 1.0
                ? string.Empty
                : string.Format("{0:0.##}%", percent * 100);
        }

        private string GetBuildingPercent(Damage d)
        {
            return d == null || d.BuildingModifier == 1.0m
                ? string.Empty
                : string.Format(" (buildings {0})",
                    WeaponVMDetail.RangePercent(d.BuildingModifier)
                    );
        }
        //private int Building(Damage d)
        //{
        //    return WeaponVMDetail.Round(d.Base * d.BuildingModifier);
        //}
    }

    public class AttributeVM
    {
        private WeaponAttribute a;

        public AttributeVM(WeaponAttribute a)
        {
            this.a = a;
        }

        public string Text
        {
            get
            {
                string text = a.Text;
                if (text.Contains("\n"))
                    return "---------"; // my stats entries meant for the "level" section.
                //text = Regex.Replace(text, "\n", "|");
                text = Regex.Replace(text, @"<br\s*\/?>", "\n");

                if (a is DescriptionAttribute)
                    text = "\n" + text;

                return text;
            }
        }
        public Brush Foreground
        {
            get
            {
                switch (a)
                {
                    case NeutralAttribute _:
                        return new SolidColorBrush(Windows.UI.Colors.AntiqueWhite);
                    case PositiveAttribute _:
                        return new SolidColorBrush(Windows.UI.Colors.CornflowerBlue);
                    case NegativeAttribute _:
                        return new SolidColorBrush(Windows.UI.Colors.IndianRed);
                    case DescriptionAttribute _:
                    default:
                        return new SolidColorBrush(Windows.UI.Colors.White);
                }
            }
        }
    }
}
