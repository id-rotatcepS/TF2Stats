using System;

namespace StatsData
{

    public class WeaponVMDetail
    {
        /// <summary>
        /// round decimal damage values to ints in our standard way (because C#'s default is round to even number, not larger)
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int Round(decimal val)
        {
            // default Math.Round is to get the EVEN number always... I don't know why they use that?? 
            return (int)Math.Round(val, MidpointRounding.AwayFromZero);
        }

        public WeaponVM v { get; }

        private Weapon w;
        private Weapon p;

        public string Notes => w.Notes;
        public string GameItemSummary => GameFiles.GameItem.Get(w.ItemsID)?.Summary;

        public WeaponVMDamageFunctionTimes FunctionTimes { get; }
        public string FunctionTimeParams => new WikiPages.WeaponFuncTimeBlock(v).GetBody();

        public WeaponVMDetail(WeaponVM weaponVM, Weapon w, Weapon p)
        {
            this.v = weaponVM;
            this.w = w;
            this.p = p;

            this.FunctionTimes = new WeaponVMDamageFunctionTimes(v, w);
        }

        public string RangePercents => (v.Damage?.ZeroRangeRamp == v.Damage?.LongRangeRamp
            ? "any range"
            :
            RangePercent(v.Damage?.ZeroRangeRamp)
            + "-" +
            RangePercent(v.Damage?.LongRangeRamp)
            )
;
        public static string RangePercent(decimal? RangeRamp)
        {
            return (RangeRamp == null || RangeRamp == 1.0m)
                ? string.Empty
                : string.Format("{0:0.##}%", RangeRamp * 100);
        }

        public string RangeDamage =>
            v.Damage == null ? string.Empty
            : GetRangeIntDamage(v.Damage, v.MaxRange)
            ;

        private string GetRangeIntDamage(Damage d, decimal? maxRange)
        {
            string format;

            bool isNotRanged = d.ZeroRangeRamp == d.LongRangeRamp;
            if (d.BuildingModifier != 1.0m)
            {
                format = isNotRanged
                    ? "({1} buildings)"
                    : "{0} - {2} ({1} buildings)";
            }
            else
            {
                format = isNotRanged
                    ? string.Empty
                    : "{0} - {2}";
            }

            return
            string.Format(format,
                Close(d),
                Building(d),
                Far(d, maxRange));
        }

        private int Close(Damage d)
        {
            decimal x = d?.Offset ?? 23.5m;
            return CloseWithOffset(d, x);
        }

        private int CloseWithOffset(Damage d, decimal offset)
        {
            // offset is distance from eye, so it's a REDUCTION in range... I assume the collision box size of 32 keeps the eyes apart by half each (so 32 total).
            // I assume the hit target is the middle of the collision box and the eyes are at the middle of the collision box ( just higher up )
            // I assume the offset is where the start of range is measured from (could be wrong, in which case all offsets become 0, but calculation still needs to happen)
            // so closest distance is (32-offset)
            // That means offsets of 32 are "as close as possible" and offsets of 0 are "as far as possible"
            decimal offsetRange = 32 - offset;

            return Round(GetDamageAtRange(d, offsetRange));
        }

        private int CloseMinicritWithOffset(Damage d, decimal x)
        {
            decimal offsetRange = 32 - x;

            return Round(GetDamageAtRange(d, offsetRange) * 1.35m);
        }

        private int CloseCrit(Damage d)
        {
            if (d.CritIncludesRamp)
            {
                decimal x = 32;//TODO pass this in like others?
                decimal offsetRange = 32 - x;
                return Round(GetDamageAtRange(d, offsetRange) * 3.0m);
            }
            return Round(d.Base * 3.0m);
        }

        private int Building(Damage d)
        {
            return Round(d.Base * d.BuildingModifier);
        }

        private int Far(Damage d, decimal? maxRange)
        {
            if (maxRange.HasValue)
            {
                decimal max = maxRange.Value;
                return Round(GetDamageAtRange(d, max));
            }
            return Round(d.Base * d.LongRangeRamp);
        }

        private decimal GetDamageAtRange(Damage d, decimal distance)
        {
            decimal medRange = 512m;
            if (distance < medRange)
            {
                // Max far is actually in the close range (512=0%, 0=100%)
                decimal percentOfClose = (medRange - distance) / medRange;
                decimal rampValue = PercentOfRamp(percentOfClose, d.ZeroRangeRamp);
                return d.Base * rampValue;
            }
            else if (distance < medRange * 2)
            {
                // Max far is not the entire long range ramp (1024=100%, 512=0%)
                decimal percentOfLong = (distance - medRange) / medRange;
                decimal rampValue = PercentOfRamp(percentOfLong, d.LongRangeRamp);
                return d.Base * rampValue;
            }
            else
                return d.Base * d.LongRangeRamp;
        }

        // we want percent of difference from 1.0
        private decimal PercentOfRamp(decimal percent, decimal rampValue)
        {
            if (rampValue > 1.0m)
            {
                decimal midIncr = rampValue - 1.0m;
                return 1.0m + (percent * midIncr);
            }
            else if (rampValue < 1.0m)
            {
                decimal midReduc = 1.0m - rampValue;
                return 1.0m - (percent * midReduc);
            }
            else
                return 1.0m;
        }

        private int FarMinicrit(Damage d, decimal? maxRange)
        {
            decimal far = 1024m;
            if (maxRange.HasValue)
            {
                decimal max = maxRange.Value;
                decimal medRange = 512m;
                if (max < medRange)
                {
                    return Round(GetDamageAtRange(d, max) * 1.35m);
                }
                // max uses usual range... probably
                if(max < far)
                    far = max;
            }

            if (d.CritIncludesRamp)
            {
                return Round(GetDamageAtRange(d, far) * 1.35m);
            }
            return Round(d.Base * 1.35m);
        }

        private int FarCrit(Damage d)
        {
            if (d.CritIncludesRamp)
            {
                return Round(GetDamageAtRange(d, 1024m) * 3.0m);
            }
            return Round(d.Base * 3.0m);
        }

        /*
<!-- D*H, but accounting for hitbox separation try (1+(({{{H|1}}}-1)*(508/512)))   (1+(({{{MH|{{{H|1}}}}}}-1)*(508/512)))   (1+(({{{CH|1.0}}}-1)*(508/512))) 
if we use firing x point as a parameter, replace 508/512 with (512-(32-Xoffset))/512 - default Xoffset to something for bullets like 28 (which would result in 508)... but why not use 23.5 like so many other weapons. (512-(32-{{{Xoffset|23.5}}}))/512

(1+(({{{H|1}}}-1)*((512-(32-{{{Xoffset|23.5}}}))/512)))   (1+(({{{MH|{{{H|1}}}}}}-1)*((512-(32-{{{Xoffset|23.5}}}))/512)))   (1+(({{{CH|1.0}}}-1)*((512-(32-{{{Xoffset|23.5}}}))/512))) 

I believe distance would be spawn point vs. target impact point, spawn points vary for projectiles:
https://youtu.be/UFtZMIWt0WI?t=37 
original, rocket launchers & flare gun, energy weapons (including cm5k), bolts(including grapple) spawn (from eyes) 23.5x

While trigonometry says all coordinates matter for measuring distance, for our purposes x position, since we're firing forward, is the only one that makes a significant difference for point blank. (Eye y position varies by class, but I assume x and z are the same for all.)
Entity movement hitbox is 32x32y, so we will assume 32x separation between two enemy centers at "point blank" minus the x value of entity spawn.  This is probably a bad assumption, but it's better than assuming a distance of 0 always.

Bullet weapons likely also would include the target body part's distance adding more distance.

-->
| point blank
| close     = {{#ifeq:{{{F|0}}}|0||{{tooltip|{{#expr:({{{D|0}}}/{{{F}}}*(1+(({{{H|1}}}-1)*((512-(32-{{{Xoffset|23.5}}}))/512))))round0}}|1 {{{pellet|pellet}}} of {{{F}}}}}-}}{{#ifexpr:{{{E|0}}}>0|{{tooltip|{{#expr:({{{D|0}}}*(1+(({{{H|1}}}-1)*((512-(32-{{{Xoffset|23.5}}}))/512)))*{{{EL|.50}}})round0}}|splash ≥ {{#expr:{{{EL|.50}}}*100round0}}%}}-}}{{#expr:({{{D|0}}}*(1+(({{{H|1}}}-1)*((512-(32-{{{Xoffset|23.5}}}))/512))))round0}}
| fragment-close = {{#expr:{{{D|0}}}/{{{F}}}*{{{H|1}}}}}         
*/

        //private string GetRangeDecimalDamage(Damage d)
        //{
        //    string format;

        //    bool isNotRanged = d.ZeroRangeRamp == d.LongRangeRamp;
        //    if (d.BuildingModifier != 1.0m)
        //    {
        //        format = isNotRanged
        //            ? "({1:0.##}bld)"
        //            : "{0:0.##} ({1:0.##}bld) {2:0.##}";
        //    }
        //    else
        //    {
        //        format = isNotRanged
        //            ? "{0:0.##}"
        //            : "{0:0.##} - {2:0.##}";
        //    }

        //    return string.Format(format,
        //        d.Base * d.ZeroRangeRamp,
        //        d.Base * d.BuildingModifier,
        //        d.Base * d.LongRangeRamp);
        //}


        public string DPS => v?.DPS != null
            ? $"{v.DPS}"
            : string.Empty;

        public string MaxRange => (v?.MaxRange) != null && v.MaxRange != 0
            ? string.Format("Max Range: {0:0.}%", v.MaxRange / 512.0m * 100.0m)
            //$"{v.MaxRange} Hu"
            : string.Empty;

        /*         | accuracy = {{#ifexpr:{{{recovery|0}}}+0>0|{{#expr:({{User:RotatcepS/tests/AccurateRange|C={{{S|0}}}|V=0|E=0}}/512*100)round0}}% ({{tooltip|recoil spread|starts with one accurate shot with {{{recovery}}} {{common strings|seconds}} recovery}})
         *         |{{#ifexpr:{{{S|0}}}+0>0|{{#expr:({{User:RotatcepS/tests/AccurateRange|C={{{S|0}}}|V=0|E=0}}/512*100)round0}}% ({{tooltip|shot spread|one accurate {{{pellet|pellet}}} of {{{F}}} {{{pellet|pellet}}}s per shot}})
         *         |{{#ifexpr:{{{E|0}}}+0>0 and {{{V|0}}}+0>0|{{#expr:(( ((49/2)/300) *({{{V|0}}}+0))/512*100)round0}}% ({{tooltip|projectile|{{{V}}}{{common strings|Hus}}}})<br/>{{#expr:({{User:RotatcepS/tests/AccurateRange|C=0|V={{{V|0}}}|E={{{E|1.0}}}}}/512*100)round0}}% (projectile {{tooltip|splash|{{#expr:{{{E|1}}}*146}}Hu radius}})
         *         |{{#ifexpr:{{{V|0}}}+0>0|{{#expr:(( ((49/2)/300) *{{{V|0}}})/512*100)round0}}% ({{tooltip|projectile|{{{V}}}{{common strings|Hus}}}})|{{#ifexpr:{{{maxRange|0}}}+0=0|infinite|melee}}}}}}}}}} */

        public string Accuracy =>
            (v?.Recovery ?? 0) > 0 ? GetRecoveryAccuracy()
            : ((v?.Spread ?? 0) > 0 ? GetSpreadAccuracy()
            //: (((v?.SplashRadius ?? 0) > 0 && (v?.Speed ?? 0) > 0) ? GetSplashSpeedAccuracy()
            : ((v?.Speed ?? 0) > 0 ? GetSpeedAccuracy()
            : ((v?.MaxRange ?? 0) == 0 ? "infinite" 
            : "melee"
            )))
            //)
        ;
        public string AccuracySplash =>
            (v?.SplashRadius ?? 0) > 0
            ? GetSplashAccuracy()
            : string.Empty;

        //{{User:RotatcepS/tests/Damage weapon|rocket launcher|type=explosive-accuracy}} {{User:RotatcepS/tests/Damage weapon|rocket launcher|type=velocity-accuracy}
        /*
    | spread-accuracy = accurate at {{#expr:({{User:RotatcepS/tests/AccurateRange|C={{{S}}}}}/512*100)round0}}% range
    | spread-ratio-old = spread of {{#expr:(1/tan((asin({{{S}}}))/2))round0}}:1
    | spread-ratio
    | spread-ratio-half = spread of {{#expr:(1/tan((asin({{{S}}}))))round0}}:1
    | velocity-accuracy  = closes range in {{#expr:(512/{{{V}}})round1}} {{common strings|seconds}}, accurate at {{#expr:(( ((49/2)/300) *{{{V}}})/512*100)round0}}% range
    | explosive-accuracy  = splash accurate at {{#expr:({{User:RotatcepS/tests/AccurateRange|V={{{V}}}|E={{{E|1.0}}}}}/512*100)round0}}% range
    | time-to-target
    | ttt       = {{#expr:512/{{{V}}}}}
    | accuracy = {{#ifexpr:{{{recovery|0}}}+0>0|{{#expr:({{User:RotatcepS/tests/AccurateRange|C={{{S|0}}}|V=0|E=0}}/512*100)round0}}% ({{tooltip|recoil spread|starts with one accurate shot with {{{recovery}}} {{common strings|seconds}} recovery}})|{{#ifexpr:{{{S|0}}}+0>0|{{#expr:({{User:RotatcepS/tests/AccurateRange|C={{{S|0}}}|V=0|E=0}}/512*100)round0}}% ({{tooltip|shot spread|one accurate {{{pellet|pellet}}} of {{{F}}} {{{pellet|pellet}}}s per shot}})|{{#ifexpr:{{{E|0}}}+0>0 and {{{V|0}}}+0>0|{{#expr:(( ((49/2)/300) *({{{V|0}}}+0))/512*100)round0}}% ({{tooltip|projectile|{{{V}}}{{common strings|Hus}}}})<br/>{{#expr:({{User:RotatcepS/tests/AccurateRange|C=0|V={{{V|0}}}|E={{{E|1.0}}}}}/512*100)round0}}% (projectile {{tooltip|splash|{{#expr:{{{E|1}}}*146}}Hu radius}})|{{#ifexpr:{{{V|0}}}+0>0|{{#expr:(( ((49/2)/300) *{{{V|0}}})/512*100)round0}}% ({{tooltip|projectile|{{{V}}}{{common strings|Hus}}}})|{{#ifexpr:{{{maxRange|0}}}+0=0|infinite|melee}}}}}}}}}}
<!--  Another type of accuracy text:
accuracy: extra-fast hitscan, reaches point-blank range (melee)
accuracy: instant hitscan, reaches point-blank range (knife)
accuracy: instant hitscan, recoil spread is accurate to below-medium range (pistol)
accuracy: instant hitscan, spread is accurate to close range (shotgun)
accuracy: penetrating x-fast speed projectile, reaches medium range (dragon)
accuracy: penetrating flame, reaches below-medium range (flamethrower)
accuracy: medium speed projectile, splash is accurate to medium-plus range (rocket)
accuracy: medium speed arced projectile (syringe)
accuracy: medium-fast speed arced projectile, splash is accurate to medium-plus range (grenade)
accuracy: slow speed charge, reaches above-long range (shield charge)

required precision:  penetrating || arced || hitscan | projectile | charge | flame || explosive splash %
accurate spread range: close | close+ | medium- | medium | medium+ | ...long+...
projectile max range:
accurate splash range:
medium range travel time: instant / (xxfast) / xfast / fast / med-fast / medium / med-slow / slow 
instant(0), melee(0.2), 0.2(charged/ball/fireball), 0.3(flare/huntsman), 0.4(grenade/pomson), 0.5(syringe/rocket), 0.6(sticky), 0.7(shield) ... 1.7(walk)
  
(0%-10%) point-blank             / melee
(25%+/-15)close             / shotgun&minigun accurate
(55%+/-15)below-medium      / pistol accurate, (sticky air flak accurate), flamethrower max reach
(100%+/-30)medium range    / revolver&smg accurate, (sticky ground spam accurate), medigun max reach
(145%+/-15)above-medium      / (rocket&grenade accurate)
(175%+/-15)below-long
(205%+/-15)long range
(235%+/-15)above-long       / shield charge & sentry max reach
(265%+/-15)x-long           / (charged sticky accurate)
(295%-15/+...)xx-long 

pointblank -90%close-45%med-close0medium+45%med-long+90long+135xlong+180xxlong+225
 -->
        * 
         */

        private string GetSpeedAccuracy()
        {
            int speedAccuracy = GetSpeedAccuracyValue(v);
            decimal projectileSpeed = (v?.Speed ?? 0);
            return $"{speedAccuracy}% (projectile, {projectileSpeed}Hu/s)";

            //closes range in {{#expr:(512/{{{V}}})round1}} {{common strings|seconds}}, accurate at {{#expr:(( ((49/2)/300) *{{{V}}})/512*100)round0}}% range
            //return $"closes range in {round1((512 / speed))} seconds, accurate at {round0(((((49 / 2) / 300) * speed) / 512 * 100))}% range";
        }

        public static int GetSpeedAccuracyValue(WeaponVM v)
        {
            decimal projectileSpeed = (v?.Speed ?? 0);
            //{{#expr:(( ((49/2)/300) *{{{V|0}}})/512*100)round0}}% ({{tooltip|projectile|{{{V}}}{{common strings|Hus}}}})
            decimal maxTimeInImpactZone = (49.0m / 2.0m) / 300.0m; // (targetSize/2) / targetMoveSpeed
            decimal maxDistanceToHitImpactZone = maxTimeInImpactZone * projectileSpeed;
            decimal percentOfRange = maxDistanceToHitImpactZone / 512.0m;

            return round0(percentOfRange * 100.0m);
        }

        private string GetSplashAccuracy()
        {
            decimal speed = (v?.Speed ?? 0);
            decimal splash = (v?.SplashRadius ?? 1.0m);

            ////{{#expr:(( ((49/2)/300) *({{{V|0}}}+0))/512*100)round0}}% ({{tooltip|projectile|{{{V}}}{{common strings|Hus}}}})<br/>{{#expr:({{User:RotatcepS/tests/AccurateRange|C=0|V={{{V|0}}}|E={{{E|1.0}}}}}/512*100)round0}}% (projectile {{tooltip|splash|{{#expr:{{{E|1}}}*146}}Hu radius}})
            //int splashAccuracy = round0(AccurateRange(0, speed, splash) / 512.0m * 100.0m);
            int splashAccuracy = GetSplashAccuracyValue(v);
            return $"{splashAccuracy}% (projectile splash, {speed}Hu/s {splash}Hu radius)";
        }

        public static int GetSplashAccuracyValue(WeaponVM v)
        {
            decimal speed = (v?.Speed ?? 0);
            decimal splash = (v?.SplashRadius ?? 1.0m);

            //{{#expr:(( ((49/2)/300) *({{{V|0}}}+0))/512*100)round0}}% ({{tooltip|projectile|{{{V}}}{{common strings|Hus}}}})<br/>{{#expr:({{User:RotatcepS/tests/AccurateRange|C=0|V={{{V|0}}}|E={{{E|1.0}}}}}/512*100)round0}}% (projectile {{tooltip|splash|{{#expr:{{{E|1}}}*146}}Hu radius}})
            return round0(AccurateRange(0, speed, splash) / 512.0m * 100.0m);
        }

        private static decimal AccurateRange(decimal spread, decimal speed, decimal splashradius) => WeaponVM.GetAccurateRange(spread, speed, splashradius);

        private string GetSplashSpeedAccuracy()
        {
            decimal speed = (v?.Speed ?? 0);
            int splashAccuracy = round0(AccurateRange(0, speed, 0) / 512.0m * 100.0m);
            return GetSpeedAccuracy() + "\n"
                + GetSplashAccuracy();

            //splash accurate at {{#expr:({{User:RotatcepS/tests/AccurateRange|V={{{V}}}|E={{{E|1.0}}}}}/512*100)round0}}% range
            //return GetSpeedAccuracy() + "\n"
            //    + $"splash accurate at {round0((AccurateRange(0, speed, splash) / 512 * 100))}% range";
        }

        private string GetSpreadAccuracy()
        {
            int spreadAccuracy = GetSpreadAccuracyValue(v);
            //decimal speed = (v?.Speed ?? 0);
            ////{{#expr:({{User:RotatcepS/tests/AccurateRange|C={{{S|0}}}|V=0|E=0}}/512*100)round0}}% ({{tooltip|shot spread|one accurate {{{pellet|pellet}}} of {{{F}}} {{{pellet|pellet}}}s per shot}})
            //int spreadAccuracy = round0(AccurateRange(v?.Spread ?? 0, speed, v?.SplashRadius ?? 0) / 512.0m * 100.0m);
            return $"{spreadAccuracy}% (shot spread, {v?.Fragments} {v?.FragmentType}s)";
        }

        private string GetRecoveryAccuracy()
        {
            int recoveryAccuracy = GetSpreadAccuracyValue(v);
            return $"{recoveryAccuracy}% (recoil spread, {v?.Recovery} sec recovery)";
        }

        public static int GetSpreadAccuracyValue(WeaponVM v)
        {
            decimal speed = (v?.Speed ?? 0);
            //{{#expr:({{User:RotatcepS/tests/AccurateRange|C={{{S|0}}}|V=0|E=0}}/512*100)round0}}% ({{tooltip|recoil spread|starts with one accurate shot with {{{recovery}}} {{common strings|seconds}} recovery}})
            int recoveryAccuracy = round0(AccurateRange(v?.Spread ?? 0, speed, v?.SplashRadius ?? 0) / 512.0m * 100.0m);
            return recoveryAccuracy;
        }

        private static int round0(decimal v)
        {
            return Round(v);
        }
        //private string round1(decimal v)
        //{
        //    return string.Format("{0:#.#}", v);
        //}

        public string WeaponTestsCols
        {
            get
            {
                Damage d = v.Damage;
                decimal closeOffset = d?.Offset ?? 23.5m;
                decimal? maxRange = v.MaxRange;

                if (d == null) return "";
                string sep = "\t";
                string r = ColsForCloseOffset(closeOffset, d, sep, maxRange,v.CanCrit,v.CanMinicrit);

                WeaponTestData observed = GetWeaponTestData(v.Name, p?.Name);
                if (observed != null)
                {
                    string observedRow = "";
                    observedRow += observed.Far;
                    observedRow += sep;
                    observedRow += observed.FarMiniCrit;
                    observedRow += sep;
                    observedRow += observed.FarCrit;
                    observedRow += sep;
                    observedRow += observed.Close;
                    observedRow += sep;
                    observedRow += observed.CloseMinicrit;
                    observedRow += sep;
                    observedRow += observed.CloseCrit;

                    string result;
                    if (r.Equals(observedRow))
                    {
                        result = "     -------match-------[" + closeOffset + "]\n";
                    }
                    else
                    {
                        result = r + " [" + closeOffset + "]\n";
                    }
                    foreach (decimal x in new decimal[] {0,
                        23.5m, // 8.5 (nearly 8 (boxdepth/2)) distance
                        25,
                        30,
                        32,// translates to 0 distance
                    })
                    {
                        if (x == closeOffset) continue;
                        string nofar = $"0{sep}0{sep}0{sep}";

                        string rt = ColsForCloseOffset(x, d, sep, maxRange,v.CanCrit,v.CanMinicrit);
                        if (rt.Equals(observedRow))
                        {
                            result += "     -------match-------" + x + "\n";
                        }
                        else if (observedRow.StartsWith(nofar) && rt.EndsWith(observedRow.Substring(nofar.Length)))
                        {
                            result += "     -0-0-0-match-------" + x + "\n";
                        }
                        else
                        {
                            result += rt + " (" + x + ")\n";
                        }
                    }
                    result += observedRow + " (observed)";
                    return result;

                }
                return r;
            }
        }

        private string ColsForCloseOffset(decimal y, Damage d, string sep, decimal? maxRange, bool canCrit, bool canMinicrit)
        {
            string result = string.Empty;
            //far	far minicrit	far crit	close	close minicrit	close crit
            result += Far(d, maxRange);
            result += sep;
            result += canMinicrit ? FarMinicrit(d, maxRange) : (canCrit ? FarCrit(d) : Far(d, maxRange));
            result += sep;
            result += canCrit ? FarCrit(d) : Far(d, maxRange);
            result += sep;
            result += CloseWithOffset(d, y);
            result += sep;
            result += canMinicrit ? CloseMinicritWithOffset(d, y) : (canCrit ? CloseCrit(d) : CloseWithOffset(d,y));
            result += sep;
            result += canCrit ? CloseCrit(d) : CloseWithOffset(d, y);
            return result;
        }

        public WeaponTestData GetWeaponTestData(string name, string parentName)
        {
            string[] parts = GetWeaponTestsDataArray(name, parentName);
            if (parts == null)
            {
                return null;
            }

            return new WeaponTestData
            {
                Name = parts[0],
                url = parts[1],
                Far = GetInt(parts, 2),
                FarMiniCrit = GetInt(parts, 3),
                FarCrit = GetInt(parts, 4),
                Close = GetInt(parts, 5),
                CloseMinicrit = GetInt(parts, 6),
                CloseCrit = GetInt(parts, 7),
            };
        }

        public string[] GetWeaponTestsDataArray(string name, string parentName)
        {
            foreach (string line in WeaponTestsTSV)
            {
                string[] parts = line.Split("\t");
                if (parts.Length > 0)
                {
                    if (
                        (parts[0].Equals(name, StringComparison.OrdinalIgnoreCase)
                        || name.EndsWith(parts[0], StringComparison.OrdinalIgnoreCase)
                        //|| ((parts.Length > 1) && parts[0].Equals(parentName, StringComparison.OrdinalIgnoreCase) && parts[1].Equals(name, StringComparison.OrdinalIgnoreCase))
                        //|| (parts[0].Equals(parentName + " " + name, StringComparison.OrdinalIgnoreCase))
                    ))
                    {
                        return parts;
                    }
                }
            }
            return null;
        }

        private int GetInt(string[] parts, int i)
        {
            try
            {
                return int.Parse(parts[i]);
            }
            catch
            {
                return 0;
            }
        }

        string[] WeaponTestsTSV = new string[] {
        "Pomson 6000	https://youtu.be/-K0HGz1kKs4	32	81	180	72	97	180",
        "Righteous Bison	https://youtu.be/P8oY8jX68MI	22	54	120	48	64	120",
        "Short Circuit	https://youtu.be/PBjJp3wUyoo	9	13	9	10	14	10",
        "Short Circuit\n>electrical airblast	https://youtu.be/eti3ZoTLWzE	15	20	15	15	20	15",//"alt Short Circuit(orb blast)	https://youtu.be/eti3ZoTLWzE	15	20	15	15	20	15",
        "Dragon's Fury	https://youtu.be/aK90XPG2a_Q	24	34	75	30	40	75",
        "Dragon's Fury\n>(burning)	flaming	72	106	225	90	121	225",//"Dragon's Fury	flaming	72	106	225	90	121	225",
        //"Dragon's Fury	https://youtu.be/aLt6NL8iOKk	24	34	75			",
        //"Dragon's Fury	flaming	71	101	225			",
        "Flare Gun	https://youtu.be/u3yRQEyD0HM	30	41	90	30	41	90",
        "Detonator	https://youtu.be/ahq2U0IlEhs	23	30	68	23	30	68",
        //"Detonator	https://youtu.be/2QcsTCdOW3s	8	15	?			",
        "Detonator		16	28	?",
        "Scorch Shot	https://youtu.be/qPNDcPNseG8	20	26	59	20	26	59",
        //"Scorch Shot	https://youtu.be/uFnCp_yUPvg	10	13	32			",
        //"Scorch Shot     16	23	49			",
        "Manmelter	https://youtu.be/5kQYq9B3Qgk	30	41	90	30	41	90",
        "Rescue Ranger	https://youtu.be/Mx4sESdVNHs	21	54	120	60	81	120",
        "Huntsman	https://youtu.be/ho8L5T3548c	54	73	172	53	73	159",
        "Huntsman\n>charged		120	162	360	120	162	360", //"Huntsman charged		120	162	360	120	162	360",
        "Crusader's Crossbow	https://youtu.be/ivCOJvt5YDc	75	101	225	38	52	115",
        //"Crusader's Crossbow		64	85	194			",
        "Splendid Screen	https://youtu.be/6k2RGZaXh3U	85	115	85	27	36	27",
        "Tide Turner	https://youtu.be/weNcJwsHtL0	50	68	50	16	21	16",
        "Chargin' Targe	https://youtu.be/6yDguA4wsSQ	50	68	50	16	21	16",
        "Flying Guillotine	https://youtu.be/hKfGVds7vGg	54	73	154	54	73	154",
        "Sandman\n>Ball	https://youtu.be/9qDER1W83IM	15	20	45	15	20	45",//"Sandman	https://youtu.be/9qDER1W83IM	15	20	45	15	20	45",
        //"Sandman moonshot    23	30	68			",
        //"Wrap Assassin	https://youtu.be/hf_YWEBO0bo						",
        //"Force-a-Nature	https://youtu.be/CRkyu4KuCZY	3	7	16	9	13	16",
        "Force-a-Nature					113	152	194",//"Force-a-Nature all 12 pellets	36	84	192	113	152	194",
        //"Soda Popper	https://youtu.be/iG8P60IwTjk	3	8	18	10	14	18",
        "Soda Popper					104	141	180",//"Soda Popper		30	80	180	104	141	180",
        //"Shortstop	https://youtu.be/7HsyIs3cN9U	6	16	36	18	24	36",
        "Shortstop					72	97	144",//"Shortstop all 4 pellets	24	64	144	72	97	144",
        //"Backscatter	https://youtu.be/taY3sgiHPyI	3	8	18	10	14	18",
        "Back scatter					104	141	180",//"Backscatter					104	141	180",//"Backscatter		30	80	180	104	141	180",
        //"Scattergun	https://youtu.be/uEBXn1hUsmg	3	8	18	10	14	18",
        "Scattergun					104	141	180",//"Scattergun		30	80	180	104	141	180",
        //"Baby Face's Blaster	https://youtu.be/k4eqrM7kA40	3	8	18	10	14	18",
        "Baby Face's Blaster					104	141	180",//"Baby Face's Blaster		30	80	180	104	141	180",
        "Pistol	https://youtu.be/MhgAobh5f9E	8	20	45	22	30	45",
        "Pretty Boy's Pocket Pistol	https://youtu.be/BFjRYnC3yGo	8	20	45	22	30	45",
        "Winger	https://youtu.be/GGR_USZuZ2Q	9	23	52	26	35	52",
        "Rocket Launcher	https://youtu.be/zAewmCdIRaU	48	122	270	112	151	270",
        //"Rocket Launcher		24	61	135	56	76	135",
        "Direct Hit	https://youtu.be/aAmSLlxpJDo	59	152	338	140	189	338",
        "Black Box	https://youtu.be/ZHBvlMd80fc	48	122	270	112	151	270",
        "Rocket Jumper	https://youtu.be/ixpSAIsEazs						",
        "Liberty Launcher	https://youtu.be/xm6bKrioSlY	36	91	203	84	114	203",
        //"Liberty Launcher		18	46	101	42	57	101",
        "Cow mangler 5000	https://youtu.be/9gveiR7brfM	48	122	122	112	151	122",//"Cowmangler 5000	https://youtu.be/9gveiR7brfM	48	122	122	112	151	122",
        //"Cowmangler 5000		24	61	61	56	76	61",
        "Cowmangler 5000\n>charged shot	https://youtu.be/zyG7LgKB5Mw	122	122	122	151	151	151",//"Cowmangler charged shot	https://youtu.be/zyG7LgKB5Mw	122	122	122	151	151	151",
        "Beggar's Bazooka	https://youtu.be/lBPldb6_AFQ	48	122	270	112	151	270",
        "Air Strike	https://youtu.be/InL_ycMP8sE	40	103	230	95	129	230",
        //"Air Strike		20	52	115	48	64	115",
        "Original	https://youtu.be/oq5yMTasmTU	48	122	270	112	151	270",
        //"Original		24	61	135	56	76	135",
        //"Widowmaker	https://youtu.be/vKrbbHCkI6I	3	8	18	9	12	18",
        "Widowmaker					90	121	180",//"Widowmaker		30	80	180	90	121	180",
        //"Widowmaker	https://youtu.be/Mi_MPZ4BdLk	3	9	20	10	13	20",
        "Widowmaker\n>sentry target					99	133	198", //3.../9.../20... ...99/...133/...198
        //"Frontier Justice	https://youtu.be/a2eT-rfm5rI	3	8	18	9	12	18",
        "Frontier Justice					90	121	180",//"Frontier Justice		30	80	180	90	121	180",
        //"Shotgun	https://youtu.be/Hz3GmGv6YKg	3	8	18	9	12	18",
        "Shotgun					90	121	180",//"Shotgun		30	80	180	90	121	180",
        //"Reserve Shooter	https://youtu.be/iGeJKzW4UfQ	3	8	18	9	12	18",
        "Reserve Shooter					90	121	180",//"Reserve Shooter		30	80	180	90	121	180",
        //"Panic Attack	https://youtu.be/pRKZZ1z7nH4	3	6	14	7	10	14",
        "Panic Attack					108	145	216",//"Panic Attack		45	90	210	108	145	216",
        //"Family Business	https://youtu.be/ahJJIKJl-6M	5	7	15	8	10	15",
        "Family Business					76	103	153",//"Family Business		50	70	150	76	103	153",
        };
    }

    public class WeaponTestData
    {
        public string Name { get; set; }
        public string url { get; set; }
        public int Far { get; set; }
        public int FarMiniCrit { get; set; }
        public int FarCrit { get; set; }
        public int Close { get; set; }
        public int CloseMinicrit { get; set; }
        public int CloseCrit { get; set; }
    }

}
