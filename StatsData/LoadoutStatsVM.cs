using System.Collections.Generic;
using System.Linq;
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
                //text = Regex.Replace(text, "\n", "N|");
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
