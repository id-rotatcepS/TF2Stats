using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;

namespace StatsData
{

    /* https://wiki.teamfortress.com/wiki/Template:Damage_table
Damage parameters

All damage parameters are optional.
Parameter name 	Notes
effect range 	
ramp up 	
ramp up % 	defaults to 150
base 	
fall off 	
fall off % 	defaults to 52.8
bullet count 	for miniguns
pellet count 	for shotguns
point blank 	
long range 	
flame close 	
flame far 	
flame far % 	
bodyshot 	
crit 	
minicrit 	
afterburn 	
afterburn minicrit 	
bleeding 	
bleeding minicrit 	
damage repaired 	
upgrade amount 	
metal cost repairing 	
metal cost reloading 	
selfdamage 	
selfdamage jump 	for rocket launchers
charge fill dmg 	for buff weapons
splash damage 	Set to yes if any below are needed
splash radius 	
splash min % 	
splash reduction 	
healing 	Set to yes if any below are needed
selfheal 	
heal amt 	
heal combat 	Use this and the following ones for mediguns
heal noncombat 	
heal noncombat % 	
Function time parameters

All function time parameters are also optional.
Parameter name 	Notes
attack interval 	
ammo interval 	
taunt duration 	
windup time 	
reload 	
reload first 	shotguns, rocket launchers, etc.
reload more 	
consumption time 	
cloak duration 	
cloak fade 	
decloak fade 	
recharge 	
recharge duration ratio 	
effect time 	
drop expiry 	
afterburn time 	
bleeding time 	
airblast cooldown 	
max charge time 	
zoom charge delay 	
zoom headshot delay 	
spread recovery 
    (not doc'd: aim fatigue; building destroy time)
charge fill speed 	
activation time 	
beamconnect 	mediguns
beamdisconnect 	mediguns 
     */
    public class WeaponVMDamageFunctionTimes
    {
        private readonly WeaponVM v;
        private readonly Weapon w;
        private readonly WeaponVMDamageFunctionTimes b;
        private readonly WeaponVMDamageFunctionTimes p;

        private WeaponVMDamageFunctionTimes(WeaponVMDamageFunctionTimes b, WeaponVMDamageFunctionTimes p)
        {
            this.b = b;
            this.v = b.v;
            this.w = b.w;
            this.p = p;
        }
        public WeaponVMDamageFunctionTimes(WeaponVM vm, Weapon w)
        {
            this.v = vm;
            this.w = w;
        }

        public string Name => w.Name;
        public IEnumerable<WeaponVMDamageFunctionTimes> Alts => v.Alts?.Select(vm => new WeaponVMDamageFunctionTimes(vm.Detail.FunctionTimes, this));

        //public string ShotType => "Hitscan", etc.
        //public string DamageType => "Bullet" etc.
        //public string RangedOrMeleeDamage => "Ranged"
        public string MaximumRampUpPercent => PercentString(v.ZeroRangeMod);
        public string MaximumRampUp => FragmentDamage(v.ZeroRangeMod);
        public Visibility CloseRampVisibility => PercentVisibility((v) => v.ZeroRangeMod);
        public bool CloseRampDiff => IfDifferent((f) => f.MaximumRampUp);

        private bool IfDifferent(Func<WeaponVMDamageFunctionTimes, string> x)
        {
            return p == null || x(p) != x(b);
        }

        public string BaseDamagePercent => PercentString(1.0m);
        public string BaseDamage => FragmentDamage(1.0m);
        public Visibility BaseDamageVisibility => (v.BaseDamage.HasValue && v.BaseDamage.Value != 0) || (v.Alts != null && v.Alts.Any(v => (v.BaseDamage.HasValue && v.BaseDamage.Value != 0)))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool BaseDamageDiff => IfDifferent((f) => f.BaseDamage);


        public string MaximumFallOffPercent => PercentString(v.LongRangeMod);
        public string MaximumFallOff => FragmentDamage(v.LongRangeMod);
        public Visibility FarRampVisibility => PercentVisibility((v) => v.LongRangeMod);
        public bool FarRampDiff => IfDifferent((f) => f.MaximumFallOff);

        public string BuildingDamagePercent => PercentString(v.BuildingMod);
        public string BuildingDamage => FragmentDamage(v.BuildingMod);
        public Visibility BuildingVisibility => PercentVisibility((v) => v.BuildingMod);
        public bool BuildingDiff => IfDifferent((f) => f.BuildingDamage);

        public string Fragment => v.Fragments?.ToString();
        public Visibility FragmentVisibility => NullableVisibility((v) => v.Fragments);
        public bool FragmentDiff => IfDifferent((f) => f.Fragment);

        public string PointBlank => FullDamage(v.ZeroRangeMod);
        public Visibility PointBlankVisibility => FullDamageVisibility((v) => v.ZeroRangeMod);
        public bool PointBlankDiff => IfDifferent((f) => f.PointBlank);
        public string MediumRange => FullDamage(1.0m);
        public Visibility MediumRangeVisibility => FullDamageVisibility((v) => 1.0m);
        public bool MediumRangeDiff => IfDifferent((f) => f.MediumRange);
        public string LongRange => FullDamage(v.LongRangeMod);
        public Visibility LongRangeVisibility => FullDamageVisibility((v) => v.LongRangeMod);
        public bool LongRangeDiff => IfDifferent((f) => f.LongRange);

        public string Critical => CriticalDamage();
        public Visibility CriticalVisibility => (v.CanCrit || (v.Alts != null && v.Alts.Any((v) => v.CanCrit))) ? Visibility.Visible : Visibility.Collapsed;
        public bool CriticalDiff => IfDifferent((f) => f.Critical);
        public string MiniCrit => MiniCritDamage();
        public Visibility MiniCritVisibility => (v.CanMinicrit || (v.Alts != null && v.Alts.Any((v) => v.CanMinicrit))) ? Visibility.Visible : Visibility.Collapsed;
        public bool MiniCritDiff => IfDifferent((f) => f.MiniCrit);


        private Visibility NullableVisibility(Func<WeaponVM, int?> fragments)
        {
            return (fragments.Invoke(v).HasValue || (v.Alts != null && v.Alts.Any(v => fragments.Invoke(v).HasValue)))
                        ? Visibility.Visible
                        : Visibility.Collapsed;
        }

        private Visibility NullableVisibility(Func<WeaponVM, decimal?> fragments)
        {
            return (fragments.Invoke(v).HasValue || (v.Alts != null && v.Alts.Any(v => fragments.Invoke(v).HasValue)))
                        ? Visibility.Visible
                        : Visibility.Collapsed;
        }

        private Visibility PercentVisibility(Func<WeaponVM, decimal?> buildingMod)
        {
            Func<WeaponVM, bool> x = (v) => buildingMod.Invoke(v).HasValue && buildingMod.Invoke(v).Value != 1.0m;
            return (x.Invoke(v) || (v.Alts != null && v.Alts.Any(x)))
                        ? Visibility.Visible
                        : Visibility.Collapsed;
        }

        public string Spread => SpreadRatio(v.Spread);
        public Visibility SpreadVisibility => NullableVisibility((v) => v.Spread);
        public bool SpreadDiff => IfDifferent((f) => f.Spread);

        public string MinimumSplashDamagePercent => PercentString(0.50m);//TODO a few items need a variable source for this fact.
        public string MinimumSplashDamage => RadiusSize(v.SplashRadius);

        private string RadiusSize(decimal? splashRadius)
        {
            return splashRadius.HasValue
                ? new HammerUnit(splashRadius.Value).GetDetail()
                : null;
        }

        public Visibility MinimumSplashVisibility => NullableVisibility((v) => v.SplashRadius);
        public bool MinimumSplashDiff => IfDifferent((f) => f.MinimumSplashDamage) || IfDifferent((f) => f.MinimumSplashDamagePercent);
        public string DamageReduction => DamageReductionString(v.SplashRadius);

        private string DamageReductionString(decimal? splashRadius)
        {
            if (!splashRadius.HasValue)
            {
                return null;
            }

            decimal minSplashPercent = 0.50m;
            decimal numberPercents = (1 - minSplashPercent) * 100;
            decimal onePercentRadius = splashRadius.Value / numberPercents;
            return string.Format("1% / {0:0.##} HU", onePercentRadius);
        }

        public bool DamageReductionDiff => IfDifferent((f) => f.DamageReduction);

        /// <summary>
        /// 
        ///attack interval 	
        /// airblast cooldown
        /// </summary>
        public string AttackInterval => string.Format("{0:0.####} s", v.FireRate);
        public Visibility AttackIntervalVisibility => (v.FireRate != 0) || (v.Alts != null && v.Alts.Any(v => (v.FireRate != 0)))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool AttackIntervalDiff => IfDifferent((f) => f.AttackInterval);

        /// <summary>
        /// grenade fuse; sticky explode time; melee delay; "zoom charge delay"; huntsman accurate draw time "aim fatigue"; minigun rev "windup time"; banner "taunt duration"
        ///activation time
        /// taunt duration
        /// consumption time
        ///windup time
        ///zoom charge delay
        /// </summary>
        public string ActivationTime => v.Activation.HasValue
            ? string.Format("{0:0.####} s", v.Activation)
            : null;
        public Visibility ActivationTimeVisibility => (v.Activation.HasValue && v.Activation != 0) || (v.Alts != null && v.Alts.Any(v => (v.Activation.HasValue && v.Activation != 0)))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool ActivationTimeDiff => IfDifferent((f) => f.ActivationTime);

        /// <summary>
        /// sticky arm time; "zoom headshot delay"; huntsman min charge time (unknown); 
        /// TODO (except arm time is currently held on Projectile, so it doesn't work for headshot delay)
        ///(arm time)
        /// zoom headshot delay
        /// 
        /// </summary>
        public string ArmTime => v.Arm.HasValue
            ? string.Format("{0:0.####} s", v.Arm)
            : null;
        public Visibility ArmTimeVisibility => (v.Arm.HasValue && v.Arm != 0) || (v.Alts != null && v.Alts.Any(v => (v.Arm.HasValue && v.Arm != 0)))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool ArmTimeDiff => IfDifferent((f) => f.ArmTime);

        // sticky max charge; sniper max charge time (including delay?); huntsman max charge; minigun rev max warmup; banner timed charge time
        //max charge time
        // recharge
        // drop expiry
        //TODO public string MaxChargeTime =>

        //ammo interval
        //TODO public string AmmoInterval =>

        //recharge duration ratio

        //charge fill speed

        public string SpreadRecovery => v.Recovery.HasValue
            ? string.Format("{0:0.####} s", v.Recovery)
            : null;
        public Visibility SpreadRecoveryVisibility => (v.Recovery.HasValue && v.Recovery != 0) || (v.Alts != null && v.Alts.Any(v => (v.Recovery.HasValue && v.Recovery != 0)))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool SpreadRecoveryDiff => IfDifferent((f) => f.SpreadRecovery);

        private string EffectDamageFormat = "{0:0.#} / {1:0.#} s\n{2:0} total";
        public string EffectDamage => v.EffectDamage.HasValue
            ? string.Format(EffectDamageFormat, WeaponVMDetail.Round(v.EffectDamage.Value), v.EffectDamageRate, EffectDamageTotal(WeaponVMDetail.Round(v.EffectDamage.Value)))
            : null;

        private decimal EffectDamageTotal(decimal? d)
        {
            if (!d.HasValue)
            {
                return 0;
            }

            return d.Value * (v.EffectMax ?? 1) * 1m / (v.EffectDamageRate ?? 1);
        }

        public string EffectMinicrit => v.EffectDamage.HasValue
            ? string.Format(EffectDamageFormat, MiniCritCalc(v.EffectDamage), v.EffectDamageRate, EffectDamageTotal(MiniCritCalc(v.EffectDamage)))
            : null;
        public string EffectDuration => v.EffectMin.HasValue
            ? string.Format(
                (v.EffectMin == v.EffectMax)
                ? "{0:0.#} s"
                : "{0:0.#}-{1:0.#} s",
                v.EffectMin, v.EffectMax)
            : null;
        public string EffectLabel => v.EffectDamage.HasValue && v.EffectDamage.Value != 0
            ? v.Effect
            : v.Alts?.FirstOrDefault(v => (v.Effect != null && v.EffectDamage.HasValue))?.Effect
            // prefer effect that causes damage, otherwise, anything will do.
            ?? (v.Effect != null
            ? v.Effect
            : v.Alts?.FirstOrDefault(v => v.Effect != null)?.Effect);
        public Visibility EffectVisibility => (v.Effect != null && v.EffectDamage.HasValue && v.EffectDamage.Value != 0) || (v.Alts != null && v.Alts.Any(v => (v.Effect != null && v.EffectDamage.HasValue && v.EffectDamage.Value != 0)))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool EffectDiff => IfDifferent((f) => f.EffectDamage);
        public Visibility EffectDurationVisibility => (v.Effect != null && v.EffectMin.HasValue && v.EffectMin.Value != 0) || (v.Alts != null && v.Alts.Any(v => (v.Effect != null && v.EffectMin.HasValue && v.EffectMin.Value != 0)))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool EffectDurationDiff => IfDifferent((f) => f.EffectDuration);
        public Visibility EffectMinicritVisibility => EffectVisibility == Visibility.Visible && MiniCritVisibility == Visibility.Visible
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool EffectMinicritDiff => IfDifferent((f) => f.EffectMinicrit);

        public string Velocity => v.Speed.HasValue
            ? string.Format("{0:0.##} HU/s", v.Speed.Value)
            : null;
        public Visibility VelocityVisibility => v.Speed.HasValue || (v.Alts != null && v.Alts.Any(v => v.Speed.HasValue))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool VelocityDiff => IfDifferent((f) => f.Velocity);
        
        public string SpreadAmount => v.Spread.HasValue
            ? string.Format("{0:0.#####}", v.Spread.Value)
            : null;
        public Visibility SpreadAmountVisibility => v.Spread.HasValue || (v.Alts != null && v.Alts.Any(v => v.Spread.HasValue))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool SpreadAmountDiff => IfDifferent((f) => f.SpreadAmount);

        public string MaxRange => v.MaxRange.HasValue
            ? new HammerUnit(v.MaxRange.Value).GetDetail()
            : null;
        public Visibility MaxRangeVisibility => v.MaxRange.HasValue || (v.Alts != null && v.Alts.Any(v => v.MaxRange.HasValue))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool MaxRangeDiff => IfDifferent((f) => f.MaxRange);

        public string Accuracy => GetAccuracy();
        private string GetAccuracy()
        {
            string all = string.Empty;

            if (v.Spread.HasValue && v.Spread.Value > 0)
            {
                int spreadAccuracy = WeaponVMDetail.GetSpreadAccuracyValue(v);
                if (all.Length > 0) all += "\n";
                all += string.Format("{0}% (spread)", spreadAccuracy);
            }
            if (v.Speed.HasValue && v.Speed.Value > 0)
            {
                int speedAccuracy = WeaponVMDetail.GetSpeedAccuracyValue(v);
                if (all.Length > 0) all += "\n";
                all += string.Format("{0}% (impact)", speedAccuracy);
            }
            if (v.SplashRadius.HasValue && v.SplashRadius.Value > 0)
            {
                int speedSplashAccuracy = WeaponVMDetail.GetSplashAccuracyValue(v);
                if (all.Length > 0) all += "\n";
                all += string.Format("{0}% (splash)", speedSplashAccuracy);
            }
            if (v.MaxRange.HasValue && v.MaxRange.Value > 0)
            {
                if (all.Length > 0) all += "\n";
                all += string.Format("{0:0.}% (max)", v.MaxRange / 512.0m * 100.0m);
            }

            return all;
        }
        public Visibility AccuracyVisibility => v.Spread.HasValue || v.Speed.HasValue || v.SplashRadius.HasValue || v.MaxRange.HasValue
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool AccuracyDiff => IfDifferent((f) => f.Accuracy);

        public string DPS => v.DPS.HasValue
            ? string.Format("{0:0.##}", v.DPS.Value)
            : null;
        public Visibility DPSVisibility => v.DPS.HasValue || (v.Alts != null && v.Alts.Any(v => v.DPS.HasValue))
            ? Visibility.Visible
            : Visibility.Collapsed;
        public bool DPSDiff => IfDifferent((f) => f.DPS);

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
               (x.Invoke(v) || (v.Alts != null && v.Alts.Any(x)))
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private string CriticalDamage()
        {
            decimal crit = 3.0m;
            decimal longRangeMod = v.CritLongRangeMod ?? 1.0m;
            decimal closeRangeMod = v.CritZeroRangeMod ?? 1.0m;
            if (closeRangeMod == longRangeMod)
                return CritifiedDamage(crit * longRangeMod, v.CanCrit);
            else
                return CritifiedDamage(crit * longRangeMod, crit * closeRangeMod, v.CanCrit);
        }

        private decimal? MiniCritCalc(decimal? baseDamage, decimal range = 1.0m)
        {
            if (!baseDamage.HasValue || !v.CanMinicrit)
            {
                return null;
            }

            decimal rangeMod = 1.35m * range;
            decimal fullDamage = WeaponVMDetail.Round(rangeMod * baseDamage.Value);
            return fullDamage;
        }
        private string MiniCritDamage()
        {
            decimal minicrit = 1.35m;
            decimal longRangeMod = v.MinicritLongRangeMod ?? 1.0m;
            decimal closeRangeMod = v.MinicritZeroRangeMod ?? 1.0m;
            if (closeRangeMod == longRangeMod)
                return CritifiedDamage(minicrit * longRangeMod, v.CanMinicrit);
            else
                return CritifiedDamage(minicrit * longRangeMod, minicrit * closeRangeMod, v.CanMinicrit);
        }

        private string CritifiedDamage(decimal longRangeMod, decimal closeRangeMod, bool can)
        {
            decimal? baseDamage = v.BaseDamage;
            int? fragments = v.Fragments;

            if (!baseDamage.HasValue || !can)
            {
                return string.Empty;
            }
            decimal fullDamage = WeaponVMDetail.Round(longRangeMod * baseDamage.Value);
            if (fragments.HasValue)
            {
                decimal oneFragDamage = longRangeMod * baseDamage.Value / fragments.Value;
                decimal closeDamage = WeaponVMDetail.Round(closeRangeMod * baseDamage.Value);
                decimal oneCloseFragDamage = closeRangeMod * baseDamage.Value / fragments.Value;
                return string.Format("{1:0} - {4:0} ({0:0.####} - {3:0.####} / {2})",
                    oneFragDamage, fullDamage,
                    v.FragmentType,
                    oneCloseFragDamage, closeDamage);
            }
            else
            {
                decimal closeDamage = WeaponVMDetail.Round(closeRangeMod * baseDamage.Value);
                return string.Format("{0:0} - {1:0}",
                    fullDamage, closeDamage);
            }
        }
        private string CritifiedDamage(decimal longRangeMod, bool can)
        {
            decimal? baseDamage = v.BaseDamage;
            int? fragments = v.Fragments;

            if (!baseDamage.HasValue || !can)
            {
                return string.Empty;
            }
            decimal fullDamage = WeaponVMDetail.Round(longRangeMod * baseDamage.Value);
            if (fragments.HasValue)
            {
                decimal oneFragDamage = longRangeMod * baseDamage.Value / fragments.Value;

                return string.Format("{0:0} ({1:0.####} / {2})",
                    fullDamage,
                     oneFragDamage,
                     v.FragmentType);
            }
            else
            {
                return string.Format("{0:0}",
                    fullDamage);
            }
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
        }

        private string PercentString(decimal? zeroRangeMod)
        {
            return zeroRangeMod.HasValue
                ? string.Format("{0:0.#}%", zeroRangeMod.Value * 100.0m)
                : string.Empty;
        }
    }
}
