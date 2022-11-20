﻿using System.Collections.Generic;

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
            FireRate = 1.5m;

            //charge & headshots/scoping are alt modes
        }
    }

    public class SniperRifle : ASniperRifle
    {
        public SniperRifle()
        {
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
            Name = "Sniper Rifle (scoped, no charge)";

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
            Name = "sniper rifle (fully charged)";
            ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
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
            Name = "sydney sleeper";
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

            Effect = null;//no crit on headshot

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
            Name = "sydney sleeper (scoped, no charge)";

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
            Name = "Sydney Sleeper (fully charged)";
            ActivationTime = 1.5m + 1.3m;// sec charge time + pre-charge delay;

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
            Name = "bazaar bargain";
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
            ActivationTime = 5.0m + 1.3m;// sec charge time + pre-charge delay;
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
            ActivationTime = 0.5m + 1.3m;// sec charge time + pre-charge delay;
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
            Name = "machina (scoped, no charge)";
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
            Name = "machina (charged)";
            ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
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
            Name = "machina (fully charged)";
            ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;

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
            Name = "hitman's heatmaker";
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
                new ScopedHitmansHeatmakerBodyshot(),
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
            Name = "Hitman's Heatmaker (body shot)";
            ActivationTime = 0.0m;// no zoom-in delay since it's not a headshot
        }
    }
    internal class ScopedHitmansHeatmakerHeadshot : ASniperRifle
    {
        public ScopedHitmansHeatmakerHeadshot()
        {
            Name = "Hitman's Heatmaker (head shot)";
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
            Name = "Hitman's Heatmaker (fully charged head shot)";
            ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
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
            Name = "Hitman's Heatmaker (fully charged body shot)";
            ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
        }
    }
    internal class FocusChargedHitmansHeatmakerHeadshot : ASniperRifle
    {
        public FocusChargedHitmansHeatmakerHeadshot()
            : base(150)
        {
            Name = "Focus (fully charged head shot)";
            ActivationTime = 1.5m + 1.3m;// sec focus charge time + pre-charge delay;
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
            ActivationTime = 1.5m + 1.3m;// sec charge time + pre-charge delay;
        }
    }

    public class Classic : ASniperRifle
    {
        public Classic()
            : base(45)
        {
            Name = "Classic";
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
            Name = "Classic (scoped, no charge)";
            ActivationTime = 0;// no delay;
            // no crit on not-fully-charged headshot
        }
    }
    internal class ChargedClassicHeadshot : ASniperRifle
    {
        public ChargedClassicHeadshot()
            : base(150)
        {
            Name = "Classic (fully charged head shot)";
            ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;

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
            Name = "Classic (fully charged body shot)";
            ActivationTime = 2.0m + 1.3m;// sec charge time + pre-charge delay;
        }
    }

}