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
            StringBuilder stats = new StringBuilder();
            WeaponVM weaponVM = new WeaponVM(w);
            //stats.AppendLine(weaponVM.Detail.RangePercents);
            //stats.AppendLine(weaponVM.Detail.RangeDamage);
            string rangePercent = GetRangePercents(weaponVM);
            string damageFormat = "damage: {0}{1} ranges{2}";
            if (string.IsNullOrWhiteSpace(rangePercent))
                damageFormat = "damage: {0}{1}{2}";
            string damage = string.Format(damageFormat,
                            GetBaseDamage(weaponVM),
                            weaponVM.DPS.HasValue ? string.Format(" ({0:0.##} DPS)", weaponVM.DPS.Value) : string.Empty,
                            rangePercent);
            if (!damage.Equals(string.Format(damageFormat, null, null, null)))
                stats.AppendLine(damage);

            string accuracy = weaponVM.Detail.Accuracy;
            if ("infinite" != accuracy)
                stats.AppendLine("accurate range: " + accuracy);

            string accuracySplash = weaponVM.Detail.AccuracySplash;
            if (!string.IsNullOrWhiteSpace(accuracySplash))
                stats.AppendLine("             " + accuracySplash);
            
            string maxRange = weaponVM.Detail.MaxRange;
            if(!string.IsNullOrWhiteSpace(maxRange))
                stats.AppendLine(maxRange);

            return stats.ToString();
        }

        private string GetBaseDamage(WeaponVM weaponVM)
        {
            return weaponVM.BaseDamage.HasValue? weaponVM.BaseDamage.Value.ToString():null;
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
            if (d != null && d.BuildingModifier != 1.0m)
            {
                return
                string.Format(" (buildings {0})",
                    WeaponVMDetail.RangePercent(d.BuildingModifier)
                    );
            }
            return string.Empty;
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
