using System.Collections.Generic;

namespace StatsData
{

    public abstract class ASniperRifle : Weapon
    {
        public ASniperRifle(decimal baseDamage = 50)
        {
            Name = "sniper rifle";
            //not activation of a hip shot, though. ActivationTime = 1.3m;// sec pre-charge delay;
            Hitscan = new Hitscan()
            {
                Damage = new Damage(baseDamage)
                {
                    Offset = Damage.OFFSET_HITSCAN_SNIPER,
                    ZeroRangeRamp = 1,
                    LongRangeRamp = 1,
                },
                //Recoil = new Recoil(0) // aka Damage.SPREAD_SNIPER
                //{
                //    Recovery = 0
                //},
                // Penetrates teammates, but not enemies
            };
            FireRate = 0m; // single shot reload is functionally its rate

            //charge & headshots/scoping are alt modes

            Ammo = new Ammo(1, 25)
            {
                Reload = 1.5m,//TODO fire rate or reload, not really both.
            };
        }
    }

    public class SniperRifle : ASniperRifle
    {
        public SniperRifle()
        {
            Attributes.AddRange(new WeaponAttribute[] { 
            new NeutralAttribute("Dual-use: Hipshot or Headshot"),
            new PositiveAttribute("Deals 100% damage at any range"),
            new PositiveAttribute("Scoped headshots always critical hit"),
            new NegativeAttribute("No random critical hits"),
            new NegativeAttribute("-73% move speed while zoomed"),
            new NeutralAttribute("Shots pass through teammates"),
            new DescriptionAttribute("Alt-Fire: Zoom in for headshots, charge up to +200% damage<br/>Charge: 1.3 second delay, 3.3 second max charge"),
            });
            
            Name = "Sniper Rifle"; Level = 1; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n50 damage (33 dps) \n Accurate at any range\n 25 carried"),
});
            AlternateModes = new List<Weapon>
            {
                new ScopedSniperRifle(),
                new ChargedSniperRifle()
            };
        }
    }

    public class ScopedSniperRifle : ASniperRifle
    {
        public ScopedSniperRifle()
        {
            Name = "(scoped, no charge)";

            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }

    public class ChargedSniperRifle : ASniperRifle
    {
        public ChargedSniperRifle()
            : base(150)
        {
            Name = "(fully charged)";
            //ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 2.0m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;
            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }

    public class SydneySleeper : ASniperRifle
    {
        public SydneySleeper()
        {
            Name = "Sydney Sleeper"; Level = 1; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("+25% charge rate"),
new PositiveAttribute("On Scoped Hit: Apply Jarate for 2 to 5 seconds based on charge level."),
new PositiveAttribute("Nature's Call: Scoped headshots always mini-crit and reduce the remaining cooldown of Jarate by 1 second."),
new NegativeAttribute("No random critical hits"),
new NegativeAttribute("No headshots"),
}); 
            //ActivationTime = 1.3;// sec pre-charge delay;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(50)
            //    {
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //    Recoil = new Recoil(0)
            //    {

            //    },

            //};
            //FireRate = 1.5;

            Effects.Clear();//no crit on headshot

            AlternateModes = new List<Weapon>
            {
                new ScopedSydneySleeper(),
                new ChargedSydneySleeper()
            };
        }
    }
    public class ScopedSydneySleeper : ASniperRifle
    {
        public ScopedSydneySleeper()
        {
            Name = "(scoped, no charge)";

            Effect = new Effect()
            {
                Name = "Jarate; Mini-crit on Headshot",
                Minimum = 2m,
                Maximum = 2m,
            };
        }
    }
    public class ChargedSydneySleeper : ASniperRifle
    {
        public ChargedSydneySleeper()
            : base(150)
        {
            Name = "(fully charged)";
            //ActivationTime = 1.5m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 1.5m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;

            Effect = new Effect()
            {
                Name = "Jarate; Mini-crit on Headshot",
                Minimum = 5m,
                Maximum = 5m,
            };
        }
    }

    public class BazaarBargain : ASniperRifle
    {
        public BazaarBargain()
        {
            Name = "Bazaar Bargain"; Level = 10; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new NegativeAttribute("Base charge rate decreased by 50%"),
new DescriptionAttribute("Each scoped headshot kill increases the weapon's charge rate by 25% up to 200%."),
});
            //ActivationTime = 1.3;// sec pre-charge delay;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(50)
            //    {
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },

            //    Recoil = new Recoil(0)
            //    {

            //    },

            //};
            //FireRate = 1.5;

            AlternateModes = new List<Weapon>
            {
                new ScopedSniperRifle(),
                new NoHeadsChargedBazaarBargain(),
                new MaxHeadsChargedBazaarBargain(),
            };

        }
    }
    internal class NoHeadsChargedBazaarBargain : ASniperRifle
    {
        public NoHeadsChargedBazaarBargain()
            : base(150)
        {
            Name = "zero heads (fully charged)";
            //ActivationTime = 5.0m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 5.0m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;
            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }
    internal class MaxHeadsChargedBazaarBargain : ASniperRifle
    {
        public MaxHeadsChargedBazaarBargain()
            : base(150)
        {
            Name = "six heads (fully charged)";
            //ActivationTime = 0.5m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 0.5m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;
            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }


    public class Machina : ASniperRifle
    {
        public Machina()
            : base(50)
        {
            Name = "Machina (scoped, no charge)";
            Name = "Machina"; Level = 5; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("On Full Charge: +15% damage per shot"),
new PositiveAttribute("On Full Charge: Projectiles penetrate players"),
new NegativeAttribute("Cannot fire unless zoomed"),
new NegativeAttribute("Fires tracer rounds"),
});
            //ActivationTime = 1.3;// sec pre-charge delay;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(50)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SNIPER,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //    //Recoil = new Recoil(0)
            //    //{
            //    //    Recovery = 0
            //    //},
            //};
            //FireRate = 1.5;

            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };

            AlternateModes = new List<Weapon>
            {
                //TODO technically machina "doesn't fire" except scoped alternate, so we only list the alternate, but now name doesn't match up.
                // Full charge penetrates, but regular shot, partial charge, doesn't
                new ChargedMachina(),
                new FullyChargedMachina() //172.5
            };

        }
    }
    internal class ChargedMachina : ASniperRifle
    {
        public ChargedMachina()
            : base(150)
        {
            Name = "(charged)";
            //ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 2.0m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;
            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }
    internal class FullyChargedMachina : ASniperRifle
    {
        // "On Full Charge: +15% damage per shot"
        // "On Full Charge: Projectiles penetrate players"
        public FullyChargedMachina()
        :base(172.5m) 
        {
            Name = "(fully charged)";


            //ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 2.0m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;

            // Full charge penetrates, but regular shot doesn't
            Hitscan.Penetrating = true;
            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }

    public class HitmansHeatmaker : ASniperRifle
    {
        public HitmansHeatmaker()
            : base(40)
        {
            Name = "Hitman's Heatmaker"; Level = 1; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Gain Focus on kills and assists"),
new PositiveAttribute("Press 'Reload' to activate focus"),
new PositiveAttribute("In Focus: +25% faster charge and no unscoping"),
new NegativeAttribute("-20% damage on body shot"),
new DescriptionAttribute("Heads will roll."),
}); 
            //ActivationTime = 1.3;// sec pre-charge delay, none with focus;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(40)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SNIPER,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },

            //};
            //FireRate = 1.5;
            AlternateModes = new List<Weapon>
            {
                new ScopedHitmansHeatmakerBodyshot(),// Is this really worthwhile? no actual difference from a hipshot.
                new ScopedHitmansHeatmakerHeadshot(),
                new ChargedHitmansHeatmakerBodyshot(),
                new ChargedHitmansHeatmakerHeadshot(),
                new FocusChargedHitmansHeatmakerBodyshot(),
                new FocusChargedHitmansHeatmakerHeadshot()
            };
        }
    }
    internal class ScopedHitmansHeatmakerBodyshot : ASniperRifle
    {
        public ScopedHitmansHeatmakerBodyshot()
            : base(40)
        {
            Name = "(body shot)";
            ActivationTime = 0.0m;// no zoom-in delay since it's not a headshot
        }
    }
    internal class ScopedHitmansHeatmakerHeadshot : ASniperRifle
    {
        public ScopedHitmansHeatmakerHeadshot()
        {
            Name = "(head shot)";
            ActivationTime = 0.2m;// zoom-in headshot delay
            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }
    internal class ChargedHitmansHeatmakerHeadshot : ASniperRifle
    {
        public ChargedHitmansHeatmakerHeadshot()
            : base(150)
        {
            Name = "(fully charged head shot)";
            //ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 2.0m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;
            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }
    internal class ChargedHitmansHeatmakerBodyshot : ASniperRifle
    {
        public ChargedHitmansHeatmakerBodyshot()
            : base(120)
        {
            Name = "(fully charged body shot)";
            //ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 2.0m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;
        }
    }
    internal class FocusChargedHitmansHeatmakerHeadshot : ASniperRifle
    {
        public FocusChargedHitmansHeatmakerHeadshot()
            : base(150)
        {
            Name = "Focus (fully charged head shot)";
            //ActivationTime = 1.5m + 1.3m;// sec focus charge time + pre-charge delay;
            ActivationTime = 0m;//focus has no pre-charge delay;
            ChargeTime = 1.5m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;
            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }
    internal class FocusChargedHitmansHeatmakerBodyshot : ASniperRifle
    {
        public FocusChargedHitmansHeatmakerBodyshot()
            : base(120)
        {
            Name = "Focus (fully charged body shot)";
            //ActivationTime = 1.5m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 0m;//focus has no pre-charge delay;
            ChargeTime = 1.5m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;
        }
    }

    public class Classic : ASniperRifle
    {
        public Classic()
            : base(45)
        {
            Name = "Classic"; Level = 1 - 100; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
new PositiveAttribute("Charge and fire shots independent of zoom"),
new NegativeAttribute("No headshots when not fully charged"),
new NegativeAttribute("-10% damage on body shot"),
});
            ActivationTime = 0;// no delay;
            //Hitscan = new Hitscan()
            //{
            //    Damage = new Damage(45)
            //    {
            //        Offset = Damage.OFFSET_HITSCAN_SNIPER,
            //        ZeroRangeRamp = 1,
            //        LongRangeRamp = 1,
            //    },
            //    //Recoil = new Recoil(0)
            //    //{
            //    //    Recovery = 0
            //    //},

            //};
            //FireRate = 1.5;
            AlternateModes = new List<Weapon>
            {
                new ScopedClassic(),
                new ChargedClassicBodyshot(),
                new ChargedClassicHeadshot()
            };
        }
    }
    internal class ScopedClassic : ASniperRifle
    {
        public ScopedClassic()
        {
            Name = "(scoped, no charge)";
            ActivationTime = 0;// no delay;
            // no crit on not-fully-charged headshot
        }
    }
    internal class ChargedClassicHeadshot : ASniperRifle
    {
        public ChargedClassicHeadshot()
            : base(150)
        {
            Name = "(fully charged head shot)";
            //ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 2.0m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;

            Effect = new Effect()
            {
                Name = "Crit on Headshot"
            };
        }
    }
    internal class ChargedClassicBodyshot : ASniperRifle
    {
        public ChargedClassicBodyshot()
            : base(135)
        {
            Name = "(fully charged body shot)";
            //ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
            ActivationTime = 1.3m;// sec pre-charge delay;
            ChargeTime = 2.0m; // 0-100 time
            FireRate = ChargeTime + ActivationTime;
        }
    }

}