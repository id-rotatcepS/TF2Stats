using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;

namespace StatsData
{

    public class WeaponVMDamageFunctionTimes
    {
        private readonly WeaponVM v;
        private readonly Weapon w;

        public WeaponVMDamageFunctionTimes(WeaponVM vm, Weapon w)
        {
            this.v = vm;
            this.w = w;
        }

        public string Name => w.Name;
        public IEnumerable<WeaponVMDamageFunctionTimes> Alts => v.Alts?.Select(vm => vm.Detail.FunctionTimes);

        //public string ShotType => "Hitscan", etc.
        //public string DamageType => "Bullet" etc.
        //public string RangedOrMeleeDamage => "Ranged"
        public string MaximumRampUpPercent => PercentString(v.ZeroRangeMod);
        public string MaximumRampUp => FragmentDamage(v.ZeroRangeMod);
        public Visibility CloseRampVisibility => PercentVisibility((v) => v.ZeroRangeMod);

        public string BaseDamagePercent => PercentString(1.0m);
        public string BaseDamage => FragmentDamage(1.0m);
        
        public string MaximumFallOffPercent => PercentString(v.LongRangeMod);
        public string MaximumFallOff => FragmentDamage(v.LongRangeMod);
        public Visibility FarRampVisibility => PercentVisibility((v) => v.LongRangeMod);
        
        public string BuildingDamagePercent => PercentString(v.BuildingMod);
        public string BuildingDamage => FragmentDamage(v.BuildingMod);
        public Visibility BuildingVisibility => PercentVisibility((v) => v.BuildingMod);

        public string Fragment => v.Fragments?.ToString();
        public Visibility FragmentVisibility => NullableVisibility((v) => v.Fragments);

        public string PointBlank => FullDamage(v.ZeroRangeMod);
        public Visibility PointBlankVisibility => FullDamageVisibility((v) => v.ZeroRangeMod);
        public string MediumRange => FullDamage(1.0m);
        public Visibility MediumRangeVisibility => FullDamageVisibility((v) => 1.0m);
        public string LongRange => FullDamage(v.LongRangeMod);
        public Visibility LongRangeVisibility => FullDamageVisibility((v) => v.LongRangeMod);

        public string Critical => CriticalDamage();
        public Visibility CriticalVisibility => (v.CanCrit || v.Alts.Any((v) =>v.CanCrit)) ? Visibility.Visible : Visibility.Collapsed;
        public string MiniCrit => MiniCritDamage();
        public Visibility MiniCritVisibility => Visibility.Visible;


        private Visibility NullableVisibility(Func<WeaponVM, int?> fragments)
        {
            return (fragments.Invoke(v).HasValue || v.Alts.Any(v=>fragments.Invoke(v).HasValue))
                        ? Visibility.Visible
                        : Visibility.Collapsed;
        }
        
        private Visibility NullableVisibility(Func<WeaponVM, decimal?> fragments)
        {
            return (fragments.Invoke(v).HasValue || v.Alts.Any(v => fragments.Invoke(v).HasValue))
                        ? Visibility.Visible
                        : Visibility.Collapsed;
        }

        private Visibility PercentVisibility(Func<WeaponVM, decimal?> buildingMod)
        {
            Func<WeaponVM, bool> x = (v)=>buildingMod.Invoke(v).HasValue && buildingMod.Invoke(v).Value != 1.0m;
            return (x.Invoke(v) || v.Alts.Any(x))
                        ? Visibility.Visible
                        : Visibility.Collapsed;
        }

        public string Spread => SpreadRatio(v.Spread);
        public Visibility SpreadVisibility => NullableVisibility((v)=>v.Spread);

        public string AttackInterval => string.Format("{0:0.####} s", v.FireRate);

        /// <summary>
        /// calculation based on https://imgur.com/a/ZmWeqe9
        /// (however, that example uses a different value for shotgun spread than it should.)
        /// (Pistol: calculator math says it should come out to 47.5 aka 48:1 like that picture, but using either double or decimal types the precision fails and we get just less than 47.5 before rounding.)
        /// </summary>
        /// <param name="spread"></param>
        /// <returns></returns>
        private string SpreadRatio(decimal? spread)
        {
            if (!spread.HasValue)
            {
                return string.Empty;
            }

            decimal defaultSpread = 1.9m;// "1.9 +/- 0.025"
            //2.0m; //"cures" shotgun values, but breaks others
            // no explanation for what this value really is.
            // perhaps it should just be 2.0

            // I actually may subscribe to the idea that was debated due to Gearheart's Jan 2021 edit that changed a 30:1 to 15:1
            // ... I think the ratio is expressed incorrect vs. what it's claimed to represent
            // ... that would make this value just 1.0
            // That said, I don't care for SpreadRatio as a concept at all,
            // I have come up with an Accuracy expression that I consider much more useful.
            // ... so I'm leaving this alone.

            decimal deviance = spread.Value / defaultSpread;
            decimal spreadToOne = 1.0m / deviance;
            return string.Format("{0}:1",
                //$"{{0}}({spreadToOne}):1",

                //"{0}({1}=1.0/({2}/{3}[={4}])):1",
                //Math.Round(spreadToOne, MidpointRounding.AwayFromZero), spreadToOne, spread.Value, defaultSpread, spread.Value/defaultSpread);
                WeaponVMDetail.Round(spreadToOne));
        }

        private string FullDamage(decimal? longRangeMod)
        {
            decimal? baseDamage = v.BaseDamage;
            int? fragments = v.Fragments;

            if (!baseDamage.HasValue)
            {
                return string.Empty;
            }

            decimal rangeMod = longRangeMod ?? 1.0m;
            decimal fullDamage = WeaponVMDetail.Round(rangeMod * baseDamage.Value);
            //for a while I was using Math.Round(... , MidpointRounding.ToEven);
            // but I didn't explain why...must have fixed something, but broke other stuff.
            if (fragments.HasValue)
            {
                decimal oneFragDamage = rangeMod * baseDamage.Value / fragments.Value;
                return string.Format("{1:0}-{0:0}",
                    fullDamage,
                    oneFragDamage,
                    v.FragmentType);
            }

            if (v.SplashRadius.HasValue)
            {
                decimal splashMinMod = 0.5m;
                decimal splashMinDamage = splashMinMod * rangeMod * baseDamage.Value;
                return string.Format("{1:0}-{0:0}",
                    fullDamage,
                    splashMinDamage,
                    v.SplashRadius.Value);
            }
            return string.Format("{0:0}",
                    fullDamage);
        }

        private Visibility FullDamageVisibility(Func<WeaponVM, decimal?> rangeMod)
        {
            Func<WeaponVM, bool> x = (v) => rangeMod.Invoke(v).HasValue
                 && (v.Fragments.HasValue || v.SplashRadius.HasValue);
            return
               (x.Invoke(v)||v.Alts.Any(x))
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private string CriticalDamage()
        {
            //decimal? longRangeMod = v.LongRangeMod;
            decimal? baseDamage = v.BaseDamage;
            int? fragments = v.Fragments;

            if (!baseDamage.HasValue || !v.CanCrit)
            {
                return string.Empty;
            }

            decimal rangeMod = 3.0m;// longRangeMod ?? 1.0m;
            decimal fullDamage = WeaponVMDetail.Round(rangeMod * baseDamage.Value);
            //for a while I was using Math.Round(... , MidpointRounding.ToEven);
            // but I didn't explain why...must have fixed something, but broke other stuff.
            if (fragments.HasValue)
            {
                decimal oneFragDamage = rangeMod * baseDamage.Value / fragments.Value;
                return string.Format("{1:0}, {0:0.####} / {2}",
                     oneFragDamage,
                     fullDamage,
                     v.FragmentType);
            }

            return string.Format("{0:0}",
                fullDamage);
        }

        private string MiniCritDamage()
        {
            //decimal? longRangeMod = v.LongRangeMod;
            decimal? closeRangeMod = v.ZeroRangeMod;
            decimal? baseDamage = v.BaseDamage;
            int? fragments = v.Fragments;

            if (!baseDamage.HasValue)
            {
                return string.Empty;
            }

            decimal rangeMod = 1.35m;// longRangeMod ?? 1.0m;
            decimal fullDamage = WeaponVMDetail.Round(rangeMod * baseDamage.Value);
            if (fragments.HasValue)
            {
                decimal oneFragDamage = rangeMod * baseDamage.Value / fragments.Value;
                if (closeRangeMod.HasValue)
                {
                    decimal closeDamage = WeaponVMDetail.Round(rangeMod * closeRangeMod.Value * baseDamage.Value);
                    //Math.Round(rangeMode * closeRangeMod.Value * baseDamage.Value, MidpointRounding.ToEven);
                    decimal oneCloseFragDamage = rangeMod * closeRangeMod.Value * baseDamage.Value / fragments.Value;
                    return string.Format("{1:0} - {4:0}, {0:0.####} - {3:0.####} / {2}",
                        oneFragDamage, fullDamage,
                        v.FragmentType,
                        oneCloseFragDamage, closeDamage);
                }

                return string.Format("{0:0}, {1:0.####} / {2}",
                    fullDamage,
                     oneFragDamage,
                     v.FragmentType);
            }

            if (closeRangeMod.HasValue)
            {
                decimal closeDamage = Math.Round(rangeMod * closeRangeMod.Value * baseDamage.Value, MidpointRounding.ToEven);
                return string.Format("{0:0}-{1:0}",
                    fullDamage, closeDamage);
            }

            return string.Format("{0:0}",
                fullDamage);
        }

        private string FragmentDamage(decimal? longRangeMod)
        {
            decimal? baseDamage = v.BaseDamage;
            int? fragments = v.Fragments;

            if (!baseDamage.HasValue)
            {
                return string.Empty;
            }

            decimal rangeMod = longRangeMod ?? 1.0m;
            if (fragments.HasValue)
            {
                return string.Format("{0:0.####} / {1}",
                     rangeMod * baseDamage.Value / fragments.Value,
                     v.FragmentType);
            }

            // some things on the wiki use decimals but most don't
            return string.Format("{0:0}",
                WeaponVMDetail.Round(rangeMod * baseDamage.Value));
            //TODO for a while I was using this style and thought it fixed something, but what? still needed? Math.Round(rangeMode * baseDamage.Value, MidpointRounding.ToEven));
        }

        private string PercentString(decimal? zeroRangeMod)
        {
            return zeroRangeMod.HasValue 
                ? string.Format("{0:0.#}%", zeroRangeMod.Value * 100.0m)
                : string.Empty;
        }
    }
}
