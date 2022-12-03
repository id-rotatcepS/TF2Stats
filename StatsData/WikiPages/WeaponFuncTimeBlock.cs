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
            StringBuilder body = new StringBuilder();

            //     https://wiki.teamfortress.com/wiki/Template:Damage_table
            //Damage parameters
            //All damage parameters are optional.
            //Parameter name 	Notes

            //effect range 	
            //TODO Area of Effect range
            //AddLine(body, "effect range", times., times.);

            //ramp up 	
            AddLine(body, "ramp up", times.CloseRampVisibility, times.MaximumRampUp);
            //ramp up % 	defaults to 150
            AddLine(body, "ramp up %", times.CloseRampVisibility, times.MaximumRampUpPercent);
            //TODO use the special flame version?
            //flame close 	

            //base 	
            AddLine(body, "base", times.BaseDamageVisibility, times.BaseDamage);

            //fall off 	
            AddLine(body, "fall off", times.FarRampVisibility, times.MaximumFallOff);
            //fall off % 	defaults to 52.8
            AddLine(body, "fall off %", times.FarRampVisibility, times.MaximumFallOffPercent);
            //TODO use the special flame version?
            //flame far 	
            //flame far % 	

            Dictionary<string, string> fragmentCountAttribute = new Dictionary<string, string>()
            {
                //bullet count 	for miniguns
                {"bullet", "bullet count"},
                //pellet count 	for shotguns
                {"pellet", "pellet count"},
            };
            string fragAttr = fragmentCountAttribute.GetValueOrDefault(times.Fragment??string.Empty);
            AddLine(body, fragAttr, times.FragmentVisibility, times.Fragment);

            //point blank 	
            AddLine(body, "point blank", times.PointBlankVisibility, times.PointBlank);
            //long range 	
            AddLine(body, "long range", times.LongRangeVisibility, times.LongRange);

            //bodyshot 	
            
            //crit 	
            AddLine(body, "crit", times.CriticalVisibility, times.Critical);
            //minicrit 	
            AddLine(body, "minicrit", times.MiniCritVisibility, times.MiniCrit);

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
                    AddLine(body, name, effect.EffectVisibility, effect.EffectDamage);
                    //afterburn minicrit 	
                    //bleeding minicrit 	
                    AddLine(body, name + " minicrit", effect.EffectMinicritVisibility, effect.EffectMinicrit);
                }
            }

            //damage repaired 	
            //upgrade amount 	
            //metal cost repairing 	
            //metal cost reloading 	

            //selfdamage 	
            //selfdamage jump 	for rocket launchers
            //charge fill dmg 	for buff weapons

            //splash damage 	Set to yes if any below are needed
            if (Visibility.Visible == times.MinimumSplashVisibility)
            {
                body.AppendLine(param("splash damage", "yes"));
                //splash radius 	
                AddLine(body, "splash radius", times.MinimumSplashVisibility, times.MinimumSplashDamage);
                //splash min % 	
                AddLine(body, "splash min %", times.MinimumSplashVisibility, times.MinimumSplashDamagePercent);
                //splash reduction 	
                AddLine(body, "splash reduction", times.MinimumSplashVisibility, times.DamageReduction);
            }

            //healing 	Set to yes if any below are needed
            //selfheal 	
            //heal amt 	
            //heal combat 	Use this and the following ones for mediguns
            //heal noncombat 	
            //heal noncombat % 	

            //Function time parameters
            //All function time parameters are also optional.
            //Parameter name 	Notes

            //attack interval 	
            AddLine(body, "attack interval", times.AttackIntervalVisibility, times.AttackInterval);
            //TODO distinguish different types of attacks?
            //airblast cooldown 	

            //ammo interval

            /// grenade fuse; sticky explode time; melee delay; "zoom charge delay"; huntsman accurate draw time "aim fatigue"; minigun rev "windup time"; banner "taunt duration"
            //activation time 	
            AddLine(body, "activation time", times.ActivationTimeVisibility, times.ActivationTime);
            //TODO distinguish different types of activations
            //taunt duration 	
            //windup time 	
            //consumption time 	
            //zoom charge delay 	

            /// sticky arm time; "zoom headshot delay"; huntsman min charge time (unknown); 
            /// TODO (except arm time is currently held on Projectile, so it doesn't work for headshot delay)
            //zoom headshot delay 	
            //AddLine(body, "", times.ArmTimeVisibility, times.ArmTime);
            // earliest time to activate; takes additional (activation time) to have an effect

            //reload 	
            AddLine(body, "reload", times.ReloadVisibility, times.Reload);
            //reload first 	shotguns, rocket launchers, etc.
            AddLine(body, "reload first", times.ReloadFirstVisibility, times.ReloadFirst);
            //reload more 	
            AddLine(body, "reload more", times.ReloadConsecutiveVisibility, times.ReloadConsecutive);

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

                if (name != null)
                    AddLine(body, name, effect.EffectDurationVisibility, effect.EffectDuration);
                else
                    //effect time 	
                    AddLine(body, "effect time", effect.EffectDurationVisibility, effect.EffectDuration);
            }

            //spread recovery 
            AddLine(body, "spread recovery", times.SpreadRecoveryVisibility, times.SpreadRecovery);

            //building destroy time    (not doc'd) 
            //charge fill speed 	

            //beamconnect 	mediguns
            //beamdisconnect 	mediguns 

            return body.ToString();
        }

        private void AddLine(StringBuilder body, string name, Visibility vis, string value)
        {
            if (vis != Windows.UI.Xaml.Visibility.Visible)
                return;
            body.AppendLine(param(name, value));
        }

        private string param(string name, string value)
        {
            return string.Format("{0}={1}|", name, value);
        }
    }
}
