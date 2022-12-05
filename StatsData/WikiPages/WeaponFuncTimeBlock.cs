using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace StatsData.WikiPages
{
    public class WeaponFuncTimeBlock
    {
        //private readonly WeaponVM vm;
        private readonly WeaponVMDamageFunctionTimes times;

        public WeaponFuncTimeBlock(WeaponVM vm)
        {
            //this.vm = vm;
            this.times = vm.Detail.FunctionTimes;
        }

        public string GetBody()
        {
            StringBuilder fullBody = new StringBuilder();

            //     https://wiki.teamfortress.com/wiki/Template:Damage_table

            //type
            //    The "shot type".Among common shot types are hitscan, projectile and particle.
            //damagetype
            //rangetype
            //    The type of damage dealt by the weapon. Common values for damage type are bullet, explosive, and fire; rangetype should be ranged, melee, or untyped.
            //effect
            //    A description of the weapon's effect (for example, "Gives the drinker Mini-Crits for the next 6 seconds").
            //| type = [[Projectile]]
            //| damagetype = Explosive
            //| rangetype = Ranged
            //| type = [[Hitscan]]
            //| damagetype = Bullet
            //| rangetype = Ranged

            //Damage parameters
            //All damage parameters are optional.
            //Parameter name 	Notes

            AddSection(fullBody, "damage", (body) =>
            {
                //effect range 	
                //TODO Area of Effect range
                //AddLine(body, "effect range", times., times.);

                //ramp up 	
                AddLine(body, "ramp up", times, (times) => times.CloseRampVisibility, (times) => times.MaximumRampUp, (times) => times.CloseRampDiff);
                //ramp up % 	defaults to 150
                AddLine(body, "ramp up %", times, (times) => times.CloseRampVisibility, (times) => times.MaximumRampUpPercent.Replace("%", string.Empty), null);
                //TODO use the special flame version?
                //flame close 	

                //base 	
                AddLine(body, "base", times, (times) => times.BaseDamageVisibility, (times) => times.BaseDamage, (times) => times.BaseDamageDiff);
                //** unfortunately, this is how Building damage has to show up, too.
                AddBuildingsAfterBase(body);

                //fall off 	
                AddLine(body, "fall off", times, (times) => times.FarRampVisibility, (times) => times.MaximumFallOff, (times) => times.FarRampDiff);
                //fall off % 	defaults to 52.8
                AddLine(body, "fall off %", times, (times) => times.FarRampVisibility, (times) => times.MaximumFallOffPercent.Replace("%", string.Empty), null);
                //TODO use the special flame version?
                //flame far 	
                //flame far % 	

                {
                    Dictionary<string, string> fragmentCountAttribute = new Dictionary<string, string>()
                    {
                        //bullet count 	for miniguns
                        {"bullet", "bullet count"},
                        //pellet count 	for shotguns
                        {"pellet", "pellet count"},
                    };
                    string fragAttr = fragmentCountAttribute.GetValueOrDefault(times.FragmentType ?? string.Empty);
                    AddLine(body, fragAttr, times, (times) => times.FragmentVisibility, (times) => times.Fragment, (times) => times.FragmentDiff);
                }

                //point blank 	
                AddLine(body, "point blank", times, (times) => times.PointBlankVisibility, (times) => times.PointBlank, (times) => times.PointBlankDiff);
                //* undoc'd medium range
                AddLine(body, "medium range", times, (times) => times.MediumRangeVisibility, (times) => times.MediumRange, (times) => times.MediumRangeDiff);
                //long range 	
                AddLine(body, "long range", times, (times) => times.LongRangeVisibility, (times) => times.LongRange, (times) => times.LongRangeDiff);

                //bodyshot 	

                //* undoc'd bullet/pellet spread
                {
                    Dictionary<string, string> fragmentSpreadAttribute = new Dictionary<string, string>()
                    {
                        {"bullet", "bullet spread"},
                        {"pellet", "pellet spread"},
                    };
                    string spreadAttr = fragmentSpreadAttribute.GetValueOrDefault(times.FragmentType ?? string.Empty);
                    AddLine(body, spreadAttr, times, (times) => times.SpreadVisibility, (times) => times.Spread, (times) => times.SpreadDiff);
                }

                //crit 	
                AddLine(body, "crit", times, (times) => times.CriticalVisibility, (times) => times.Critical, (times) => times.CriticalDiff);
                //minicrit 	
                AddLine(body, "minicrit", times, (times) => times.MiniCritVisibility, (times) => times.MiniCrit, (times) => times.MiniCritDiff);

                //foreach(var effect in times.Effects)
                {
                    var effect = times;

                    Dictionary<string, string> effectLabelToAttributePrefix = new Dictionary<string, string>()
                    {
                        //afterburn 	
                        {"Afterburn", "afterburn"},
                        //bleeding 	
                        {"Bleeding", "bleeding"},
                    };
                    string name = effectLabelToAttributePrefix.GetValueOrDefault(effect.EffectLabel ?? string.Empty);

                    if (name != null)
                    {
                        AddLine(body, name, effect, (times) => times.EffectVisibility, (times) => times.EffectDamage, (times) => times.EffectDiff);//NOTE should this instead be null for diff?
                        //afterburn minicrit 	
                        //bleeding minicrit 	
                        AddLine(body, name + " minicrit", effect, (times) => times.EffectMinicritVisibility, (times) => times.EffectMinicrit, (times) => times.EffectMinicritDiff);
                    }
                }

                //damage repaired 	
                //upgrade amount 	
                //metal cost repairing 	
                //metal cost reloading 	

                //selfdamage 	
                //selfdamage jump 	for rocket launchers
                //charge fill dmg 	for buff weapons

            });

            //splash damage 	Set to yes if any below are needed
            if (Visibility.Visible == times.MinimumSplashVisibility)
            {
                AddSection(fullBody, "splash damage", (splashBody) =>
                {
                    //splash radius 	
                    AddLine(splashBody, "splash radius", times, (times) => times.MinimumSplashVisibility, (times) => times.MinimumSplashDamage, (times) => times.MinimumSplashDiff);
                    //splash min % 	
                    AddLine(splashBody, "splash min %", times, (times) => times.MinimumSplashVisibility, (times) => times.MinimumSplashDamagePercent.Replace("%", string.Empty), null);
                    //splash reduction 	
                    AddLine(splashBody, "splash reduction", times, (times) => times.MinimumSplashVisibility, (times) => times.DamageReduction, (times) => times.MinimumSplashDiff);
                });
            }

            //healing 	Set to yes if any below are needed
            AddSection(fullBody, "healing", (healBody) =>
            {
                //selfheal 	
                //heal amt 	
                //heal combat 	Use this and the following ones for mediguns
                //heal noncombat 	
                //heal noncombat % 	
            });

            //Function time parameters
            //All function time parameters are also optional.
            //Parameter name 	Notes

            AddSection(fullBody, "function times", (body) =>
            {

                //attack interval 	
                AddLine(body, "attack interval", times, (times) => times.AttackIntervalVisibility, (times) => times.AttackInterval, (times) => times.AttackIntervalDiff);
                //TODO distinguish different types of attacks?
                //airblast cooldown 	

                //ammo interval

                /// grenade fuse; sticky explode time; melee delay; "zoom charge delay"; huntsman accurate draw time "aim fatigue"; minigun rev "windup time"; banner "taunt duration"
                //activation time 	
                AddLine(body, "activation time", times, (times) => times.ActivationTimeVisibility, (times) => times.ActivationTime, (times) => times.ActivationTimeDiff);
                //TODO distinguish different types of activations
                //taunt duration 	
                //windup time 	
                //consumption time 	
                //zoom charge delay 	

                /// sticky arm time; "zoom headshot delay"; huntsman min charge time (unknown); 
                /// TODO (except arm time is currently held on Projectile, so it doesn't work for headshot delay)
                //zoom headshot delay 	
                //AddLine(body, "", times, (times)=>times.ArmTimeVisibility, (times)=>times.ArmTime, (times)=>times.ArmTimeDiff);
                // earliest time to activate; takes additional (activation time) to have an effect

                //reload 	
                AddLine(body, "reload", times, (times) => times.ReloadVisibility, (times) => times.Reload, (times) => times.ReloadDiff);
                //reload first 	shotguns, rocket launchers, etc.
                AddLine(body, "reload first", times, (times) => times.ReloadFirstVisibility, (times) => times.ReloadFirst, (times) => times.ReloadFirstDiff);
                //reload more 	
                AddLine(body, "reload more", times, (times) => times.ReloadConsecutiveVisibility, (times) => times.ReloadConsecutive, (times) => times.ReloadConsecutiveDiff);

                //cloak duration 	
                //cloak fade 	
                //decloak fade 	

                //recharge 	
                //drop expiry 	
                //max charge time 	

                //recharge duration ratio 	

                //foreach(var effect in times.Effects)
                {
                    var effect = times;

                    //afterburn time 	
                    //bleeding time 	
                    //aim fatigue       (not doc'd) 
                    Dictionary<string, string> effectLabelToAttribute = new Dictionary<string, string>()
                    {
                        {"Afterburn", "afterburn time"},
                        {"Bleeding", "bleeding time"},
                        {"No Aim Fatigue", "aim fatigue"},
                    };
                    string name = effectLabelToAttribute.GetValueOrDefault(effect.EffectLabel ?? string.Empty);

                    if (name == null)
                        //effect time 	
                        name = "effect time";
                    AddLine(body, name, effect, (times) => times.EffectDurationVisibility, (times) => times.EffectDuration, (times) => times.EffectDurationDiff);
                }

                //spread recovery 
                AddLine(body, "spread recovery", times, (times) => times.SpreadRecoveryVisibility, (times) => times.SpreadRecovery, (times) => times.SpreadRecoveryDiff);

                //building destroy time    (not doc'd) 
                //charge fill speed 	

                //beamconnect 	mediguns
                //beamdisconnect 	mediguns 
            });

            return fullBody.ToString();
        }

        private void AddBuildingsAfterBase(StringBuilder body)
        {
            // what might have been better:
            //AddLine(body, "building", times, (times) => times.BuildingVisibility, (times) => times.BuildingDamage, (times) => times.BuildingDiff);
            //AddLine(body, "building %", times, (times) => times.BuildingVisibility, (times) => times.BuildingDamagePercent, null);
            if (times.BuildingVisibility == Visibility.Visible)
            {
                string buildingVal = times.BuildingDamage;
                if (!string.IsNullOrEmpty(buildingVal))
                {
                    body.Length -= new StringBuilder().AppendLine().Length; // remove newline of preceding AddLine call
                    body.Append("<br/>");
                    //TODO use times.BuildingDamagePercent in a tooltip
                    body.AppendLine(string.Format("<div style=\"float:left\">{0}:</div> {1}", "[[Buildings]]", buildingVal));
                }
            }
        }

        private void AddSection(StringBuilder body, string v, Action<StringBuilder> p)
        {
            StringBuilder sect = new StringBuilder();
            p(sect);
            if(sect.Length != 0)
            {
                body.AppendLine(string.Format("| {0,-18} = {1}", v, "yes"));
                body.Append(sect);
            }
        }

        private void AddLine(StringBuilder body, string name, WeaponVMDamageFunctionTimes times, Func<WeaponVMDamageFunctionTimes, Windows.UI.Xaml.Visibility> visibility, Func<WeaponVMDamageFunctionTimes, string> valString, Func<WeaponVMDamageFunctionTimes, bool> difference)
        {
            if (visibility(times) != Windows.UI.Xaml.Visibility.Visible)
                return;
            // no nulls, no newlines
            Func<WeaponVMDamageFunctionTimes, string> value = (v) => (valString(v) ?? string.Empty).Replace("\n", "<br/>");
            string val = value(times);

            if (difference == null)
            {
                difference = (x) => value(x) != value(times);
            }

            foreach (var x in times.Alts)
            {
                if (difference(x))
                {
                    string diffVal = value(x);
                    
                    if (string.IsNullOrEmpty(diffVal))//debatable... this is a case where it's explicitly blank for the alternate...like Shortstop Shove blanks a lot of stuff out.
                        continue;

                    if (val.Length != 0)
                        val += "<br/>";
                    val += string.Format("<div style=\"float:left\">{0}:</div> {1}", x.Name, diffVal);
                }
            }
            body.AppendLine(param(name, val));
        }

        private string param(string name, string value)
        {
            return string.Format("|  {0,-17} = {1}", name, value);
        }
    }
}
