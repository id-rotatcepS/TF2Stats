using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;

namespace StatsData.WikiPages
{
    public class EffectVM
    {
        private Effect effect;
        private WeaponVMDamageFunctionTimes times;


        private EffectVM(Effect effect, WeaponVMDamageFunctionTimes times)
        {
            this.effect = effect;
            this.times = times;
            this.AltEffects = times.Alts?.Select(
                (a) => a.Effects.Any(e => e.Name == effect.Name)
                ? new EffectVM(a.Effects.First(e => e.Name == effect.Name), a, this)
                : new EffectVM(new Effect() { Name = "NULL" }, a)); // plain null caused WPF ItemsControl to use the previous value again 
        }

        private EffectVM(Effect effect, WeaponVMDamageFunctionTimes times, EffectVM diffBase)
            :this(effect, times)
        {
            this.DiffBase = diffBase;
        }

        public IEnumerable<EffectVM> AltEffects { get; }
        public EffectVM DiffBase { get; }

        public string Name => effect.Name;

        public decimal DamageRate => effect.DamageRate;
        public decimal? DamageBase => effect.Damage?.Base;

        public Visibility Visibility => (EffectVisibility == Visibility.Visible || AltEffects.Any(e => e != null && e.EffectVisibility == Visibility.Visible)) ? Visibility.Visible : Visibility.Collapsed;
        public string Damage => EffectDamage;
        public bool Diff => DiffBase?.Damage != Damage;

        public Visibility MinicritVisibility => times.MiniCritVisibility == Visibility.Visible ? EffectVisibility : Visibility.Collapsed;
        public string MinicritDamage => EffectMinicrit;
        public bool MinicritDiff => DiffBase?.MinicritDamage != MinicritDamage;

        public Visibility DurationVisibility => IsEffectDurationInteresting(effect) || AltEffects.Any(e => e != null && IsEffectDurationInteresting(e.effect)) ? Visibility.Visible : Visibility.Collapsed;
        public string Duration => EffectDuration;
        public bool DurationDiff => DiffBase?.Duration != Duration;

        private string EffectDamageFormat = "{0:0.#} / {1:0.#} s\n{2:0} total";
        private string EffectDamage => DamageBase.HasValue
            ? string.Format(EffectDamageFormat, WeaponVMDetail.Round(DamageBase.Value), effect.DamageRate, EffectDamageTotal(WeaponVMDetail.Round(DamageBase.Value)))
            : null;

        private decimal EffectDamageTotal(decimal? d)
        {
            if (!d.HasValue)
            {
                return 0;
            }

            return d.Value * (effect.Maximum) * 1m / (effect.DamageRate);
        }

        //TODO include Weapon.CanMinicrit
        private string EffectMinicrit => DamageBase.HasValue
            ? string.Format(EffectDamageFormat, MiniCritCalc(DamageBase), effect.DamageRate, EffectDamageTotal(MiniCritCalc(DamageBase)))
            : null;

        private decimal? MiniCritCalc(decimal? baseDamage, decimal range = 1.0m, bool CanMinicrit=true)
        {
            if (!baseDamage.HasValue || !CanMinicrit)
            {
                return null;
            }

            decimal rangeMod = 1.35m * range;
            decimal fullDamage = WeaponVMDetail.Round(rangeMod * baseDamage.Value);
            return fullDamage;
        }

        private string EffectDuration => //v.EffectMin.HasValue
            IsEffectDurationInteresting(effect)
            ? string.Format(
                (effect.Minimum == effect.Maximum)
                ? "{0:0.#} s"
                : "{0:0.#}-{1:0.#} s",
                effect.Minimum, effect.Maximum)
            : null
            ;
        //public string EffectLabel => v.EffectDamage.HasValue && v.EffectDamage.Value != 0
        //    ? v.Effect
        //    : v.Alts?.FirstOrDefault(v => (v.Effect != null && v.EffectDamage.HasValue))?.Effect
        //    // prefer effect that causes damage, otherwise, anything will do.
        //    ?? (v.Effect != null
        //    ? v.Effect
        //    : v.Alts?.FirstOrDefault(v => v.Effect != null)?.Effect);
        private Visibility EffectVisibility => (Name != null && DamageBase.HasValue && DamageBase.Value != 0) //|| (AltEffects != null && AltEffects.Any(v => v?.Name != null && v?.DamageBase != 0))
            ? Visibility.Visible
            : Visibility.Collapsed;

        public static EffectVM GetEffectVM(WeaponVMDamageFunctionTimes v1, Effect v)
        {
            if (v == null)
                return null;
            return new EffectVM(v, v1);
        }

        private Effect GetEffect(WeaponVMDamageFunctionTimes v, Effect effect)
        {
            return v.Effects.FirstOrDefault(e => e.Name == effect.Name);
        }

        private static bool IsEffectDurationInteresting(Effect v)
        {
            return v.Minimum > 0 || v.Maximum > 0;
        }
    }
}