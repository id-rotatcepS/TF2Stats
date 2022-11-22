using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StatsData
{
    public class TF2CasualMode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        static Scout Scout = new Scout();
        static Soldier Soldier = new Soldier();
        static Pyro Pyro = new Pyro();
        static Demoman Demoman = new Demoman();
        static Heavy Heavy = new Heavy();
        static Engineer Engineer = new Engineer();
        static Medic Medic = new Medic();
        static Sniper Sniper = new Sniper();
        static Spy Spy = new Spy();

        public List<PlayerClass> Classes
        {
            get;
        } = new List<PlayerClass>() {
            Scout,
            Soldier,
            Pyro,
            Demoman,
            Heavy,
            Engineer,
            Medic,
            Sniper,
            Spy
        };

        static Pomson6000 Pomson6000 = new Pomson6000();
        static RighteousBison RighteousBison = new RighteousBison();

        static FlareGun FlareGun = new FlareGun();
        static Detonator Detonator = new Detonator();
        static Manmelter Manmelter = new Manmelter();
        static ScorchShot ScorchShot = new ScorchShot();

        static Huntsman Huntsman = new Huntsman();
        static CrusadersCrossbow CrusadersCrossbow = new CrusadersCrossbow();
        static RescueRanger RescueRanger = new RescueRanger();

        static CharginTarge CharginTarge = new CharginTarge();
        static SplendidScreen SplendidScreen = new SplendidScreen();
        static TideTurner TideTurner = new TideTurner();

        static BuffBanner BuffBanner = new BuffBanner();
        static BatallionsBackup BatallionsBackup = new BatallionsBackup();
        static Concheror Concheror = new Concheror();

        static ThermalThruster ThermalThruster = new ThermalThruster();
        static Mantreads Mantreads = new Mantreads();

        static BASEJumper BASEJumper = new BASEJumper();
        static Gunboats Gunboats = new Gunboats();
        static AliBabasWeeBooties AliBabasWeeBooties = new AliBabasWeeBooties();
        static Razorback Razorback = new Razorback();
        static DarwinsDangerShield DarwinsDangerShield = new DarwinsDangerShield();
        static CozyCamper CozyCamper = new CozyCamper();

        static Sandvich Sandvich = new Sandvich();
        static DalokahsBar DalokahsBar = new DalokahsBar();
        static BuffaloSteakSandvich BuffaloSteakSandvich = new BuffaloSteakSandvich();
        static SecondBanana SecondBanana = new SecondBanana();

        static BonkAtomicPunch BonkAtomicPunch = new BonkAtomicPunch();
        static CritACola CritACola = new CritACola();

        static FlyingGuillotine FlyingGuillotine = new FlyingGuillotine();

        static Jarate Jarate = new Jarate();
        static MadMilk MadMilk = new MadMilk();
        static GasPasser GasPasser = new GasPasser();

        static EngineerPistol EngineerPistol = new EngineerPistol();
        static ShortCircuit ShortCircuit = new ShortCircuit();
        static Wrangler Wrangler = new Wrangler();

        static ScoutPistol ScoutPistol = new ScoutPistol();
        static Winger Winger = new Winger();
        static PrettyBoysPocketPistol PrettyBoysPocketPistol = new PrettyBoysPocketPistol();

        static RocketLauncher RocketLauncher = new RocketLauncher();
        static DirectHit DirectHit = new DirectHit();
        static BlackBox BlackBox = new BlackBox();
        static LibertyLauncher LibertyLauncher = new LibertyLauncher();
        static CowMangler5000 CowMangler5000 = new CowMangler5000();
        static BeggarsBazooka BeggarsBazooka = new BeggarsBazooka();
        static AirStrike AirStrike = new AirStrike();

        static Shotgun Shotgun = new Shotgun();
        static ReserveShooter ReserveShooter = new ReserveShooter();
        static PanicAttack PanicAttack = new PanicAttack();
        static FamilyBusiness FamilyBusiness = new FamilyBusiness();
        static FrontierJustice FrontierJustice = new FrontierJustice();
        static Widowmaker Widowmaker = new Widowmaker();

        static Scattergun Scattergun = new Scattergun();
        static ForceANature ForceANature = new ForceANature();
        static Shortstop Shortstop = new Shortstop();
        static SodaPopper SodaPopper = new SodaPopper();
        static BabyFacesBlaster BabyFacesBlaster = new BabyFacesBlaster();
        static BackScatter BackScatter = new BackScatter();

        static FlameThrower Flamethrower = new FlameThrower();
        static BackBurner BackBurner = new BackBurner();
        static Degreaser Degreaser = new Degreaser();
        static Phlogistinator Phlogistinator = new Phlogistinator();

        static DragonsFury DragonsFury = new DragonsFury();

        static GrenadeLauncher GrenadeLauncher = new GrenadeLauncher();
        static LochNLoad LochNLoad = new LochNLoad();
        static LooseCannon LooseCannon = new LooseCannon();
        static IronBomber IronBomber = new IronBomber();

        static StickybombLauncher StickybombLauncher = new StickybombLauncher();
        static ScottishResistance ScottishResistance = new ScottishResistance();
        static QuickiebombLauncher QuickiebombLauncher = new QuickiebombLauncher();

        static Minigun Minigun = new Minigun();
        static Natascha Natascha = new Natascha();
        static BrassBeast BrassBeast = new BrassBeast();
        static Tomislav Tomislav = new Tomislav();
        static HuoLongHeater HuoLongHeater = new HuoLongHeater();

        static SyringeGun SyringeGun = new SyringeGun();
        static Blutsauger Blutsauger = new Blutsauger();
        static Overdose Overdose = new Overdose();

        static MediGun MediGun = new MediGun();
        static Kritzkrieg Kritzkrieg = new Kritzkrieg();
        static QuickFix QuickFix = new QuickFix();
        static Vaccinator Vaccinator = new Vaccinator();

        static SniperRifle SniperRifle = new SniperRifle();
        static SydneySleeper SydneySleeper = new SydneySleeper();
        static BazaarBargain BazaarBargain = new BazaarBargain();
        static Machina Machina = new Machina();
        static HitmansHeatmaker HitmansHeatmaker = new HitmansHeatmaker();
        static Classic Classic = new Classic();

        static SMG SMG = new SMG();
        static CleanersCarbine CleanersCarbine = new CleanersCarbine();

        static Revolver Revolver = new Revolver();
        static Ambassador Ambassador = new Ambassador();
        static LEtranger LEtranger = new LEtranger();
        static Enforcer Enforcer = new Enforcer();
        static Diamondback Diamondback = new Diamondback();

        static Sapper Sapper = new Sapper();
        static RedTapeRecorder RedTapeRecorder = new RedTapeRecorder();

        static InvisWatch InvisWatch = new InvisWatch();
        static Deadringer Deadringer = new Deadringer();
        static CloakAndDagger CloakAndDagger = new CloakAndDagger();

        static Wrench Wrench = new Wrench();
        static SouthernHospitality SouthernHospitality = new SouthernHospitality();
        static Jag Jag = new Jag();
        static EurekaEffect EurekaEffect = new EurekaEffect();

        static Gunslinger Gunslinger = new Gunslinger();

        static Knife Knife = new Knife();
        static YourEternalReward YourEternalReward = new YourEternalReward();
        static ConniversKunai ConniversKunai = new ConniversKunai();
        static BigEarner BigEarner = new BigEarner();
        static Spycicle Spycicle = new Spycicle();

        static Bat Bat = new Bat();
        static Sandman Sandman = new Sandman();
        static CandyCane CandyCane = new CandyCane();
        static BostonBasher BostonBasher = new BostonBasher();
        static SunOnAStick SunOnAStick = new SunOnAStick();
        static FanOWar FanOWar = new FanOWar();
        static Atomizer Atomizer = new Atomizer();
        static WrapAssassin WrapAssassin = new WrapAssassin();

        static EscapePlan EscapePlan = new EscapePlan();
        static DisciplinaryAction DisciplinaryAction = new DisciplinaryAction();
        static HotHand HotHand = new HotHand();
        static PowerJack PowerJack = new PowerJack();
        static GlovesOfRunningUrgently GlovesOfRunningUrgently = new GlovesOfRunningUrgently();
        static EvictionNotice EvictionNotice = new EvictionNotice();

        // stock Melees ...

        static PainTrain PainTrain = new PainTrain();
        static HalfZatoichi HalfZatoichi = new HalfZatoichi();

        static Equalizer Equalizer = new Equalizer();
        static MarketGardener MarketGardener = new MarketGardener();
        static Axtinguisher Axtinguisher = new Axtinguisher();
        static Homewrecker Homewrecker = new Homewrecker();
        static BackScratcher BackScratcher = new BackScratcher();
        static SharpenedVolcanoFragment SharpenedVolcanoFragment = new SharpenedVolcanoFragment();
        static ThirdDegree ThirdDegree = new ThirdDegree();
        static NeonAnnihilator NeonAnnihilator = new NeonAnnihilator();
        static Eyelander Eyelander = new Eyelander();
        static UllapoolCaber UllapoolCaber = new UllapoolCaber();
        static ClaidheamhMor ClaidheamhMor = new ClaidheamhMor();
        static PersionPersuader PersionPersuader = new PersionPersuader();
        static ScotsmansSkullcutter ScottsmansSkullcutter = new ScotsmansSkullcutter();
        static KillingGlovesOfBoxing KillingGlovesOfBoxing = new KillingGlovesOfBoxing();
        static WarriorsSpirit WarriorsSpirit = new WarriorsSpirit();
        static HolidayPunch HolidayPunch = new HolidayPunch();
        static FistsOfSteel FistsOfSteel = new FistsOfSteel();
        static Ubersaw Ubersaw = new Ubersaw();
        static Vitasaw Vitasaw = new Vitasaw();
        static Amputator Amputator = new Amputator();
        static SolemnVow SolemnVow = new SolemnVow();
        static TribalmansShiv TribalmansShiv = new TribalmansShiv();
        static Bushwaka Bushwaka = new Bushwaka();
        static Shahanshah Shahanshah = new Shahanshah();

        public List<Weapon> Weapons
        {
            get;
        } = new List<Weapon>() {

            Pomson6000,
            RighteousBison,
            
            FlareGun,
            Detonator,
            Manmelter,
            ScorchShot,
            
            Huntsman,
            CrusadersCrossbow,
            RescueRanger,
            
            EngineerPistol,
            ShortCircuit,
            Wrangler,

            ScoutPistol,
            Winger,
            PrettyBoysPocketPistol,

            RocketLauncher,
            DirectHit,
            BlackBox,
            LibertyLauncher, 
            CowMangler5000,
            BeggarsBazooka,
            AirStrike,

            Shotgun,
            ReserveShooter,
            PanicAttack,
            FamilyBusiness,
            FrontierJustice,
            Widowmaker,

            Scattergun,
            ForceANature,
            Shortstop,
            SodaPopper,
            BabyFacesBlaster,
            BackScatter,

            Flamethrower,
            BackBurner,
            Degreaser,
            Phlogistinator,

            DragonsFury,

            GrenadeLauncher,
            LochNLoad,
            LooseCannon,
            IronBomber,

            StickybombLauncher,
            ScottishResistance,
            QuickiebombLauncher,

            Minigun,
            Natascha,
            BrassBeast,
            Tomislav,
            HuoLongHeater,

            SyringeGun,
            Blutsauger,
            Overdose,

            SniperRifle,
            SydneySleeper,
            BazaarBargain,
            Machina,
            HitmansHeatmaker,
            Classic,

            SMG,
            CleanersCarbine,

            Revolver,
            Ambassador,
            LEtranger,
            Enforcer,
            Diamondback,

            FlyingGuillotine,

            CharginTarge,
            SplendidScreen,
            TideTurner,

            ThermalThruster,
            Mantreads,

            BuffBanner,
            BatallionsBackup,
            Concheror,

            MediGun,
            Kritzkrieg,
            QuickFix,
            Vaccinator,

            BASEJumper,
            Gunboats,
            AliBabasWeeBooties,
            Razorback,
            DarwinsDangerShield,
            CozyCamper,

            Sandvich,
            DalokahsBar,
            BuffaloSteakSandvich,
            SecondBanana,

            BonkAtomicPunch,
            CritACola,

            Jarate,
            MadMilk,
            GasPasser,

            Sapper,
            RedTapeRecorder,
            
            InvisWatch,
            Deadringer,
            CloakAndDagger,

            Wrench,
            SouthernHospitality,
            Jag,
            EurekaEffect,

            Gunslinger,

            Knife,
            YourEternalReward,
            ConniversKunai,
            BigEarner,
            Spycicle,
            
            Bat,
            Sandman,
            CandyCane,
            BostonBasher,
            SunOnAStick,
            FanOWar,
            Atomizer,
            WrapAssassin,

            EscapePlan,
            DisciplinaryAction,
            HotHand,
            PowerJack,
            GlovesOfRunningUrgently,
            EvictionNotice,

            // stock Melees ...

            PainTrain,
            HalfZatoichi,

            Equalizer,
            MarketGardener,
            Axtinguisher,
            Homewrecker,
            BackScratcher,
            SharpenedVolcanoFragment,
            ThirdDegree,
            NeonAnnihilator,
            Eyelander,
            UllapoolCaber,
            ClaidheamhMor,
            PersionPersuader,
            ScottsmansSkullcutter,
            KillingGlovesOfBoxing,
            WarriorsSpirit,
            HolidayPunch,
            FistsOfSteel,
            Ubersaw,
            Vitasaw,
            Amputator,
            SolemnVow,
            TribalmansShiv,
            Bushwaka,
            Shahanshah,
        };

        public string WeaponHeader => WeaponCSVHeader();
        public string WeaponText => GetWeaponText();

        //private WeaponVM _selectedWeapon;
        //public WeaponVM SelectedWeapon
        //{
        //    get => _selectedWeapon; 
        //    set { _selectedWeapon = value; }
        //}

        public ObservableCollection<WeaponVM> WeaponCollection
        {
            get
            {
                if (rows == null)
                {
                    rows = new ObservableCollection<WeaponVM>();
                    foreach (Weapon w in Weapons)
                    {
                        rows.Add(new WeaponVM(w));
                        if (IsIncludingAlternates && w.AlternateModes != null)
                        {
                            foreach (Weapon x in w.AlternateModes)
                            {
                                if (x != null)
                                    rows.Add(new WeaponVM(x, w));
                            }
                        }
                    }
                }
                return rows;
            }
        }
        private ObservableCollection<WeaponVM> rows = null;

        private bool _IsIncludingAlternates = true;

        public bool IsIncludingAlternates
        {
            get => _IsIncludingAlternates;
            set
            {
                _IsIncludingAlternates = value; 
                rows = null;
                NotifyPropertyChanged(nameof(WeaponCollection));
            }
        }

        //public List<WeaponVM> WeaponTextGrid
        //{
        //    get
        //    {
        //        List<WeaponVM> rows = new List<WeaponVM>();
        //        foreach (Weapon w in Weapons)
        //        {
        //            rows.Add(new WeaponVM(w));
        //            if (w.AlternateModes != null)
        //            {
        //                foreach (Weapon x in w.AlternateModes)
        //                {
        //                    rows.Add(new WeaponVM(x, w));
        //                }
        //            }
        //        }
        //        return rows;
        //    }
        //}
        public List<View> WeaponTextStringGrid
        {
            get
            {
                string t = GetWeaponText();
                string[] rowraw = t.Split("\n");
                List<View> rows = new List<View>();
                foreach (string row in rowraw)
                {
                    if (row.Trim().Length == 0) continue;
                    string[] cols = row.Split("\t");
                    rows.Add(new View(cols));
                }
                return rows;
            }
        }

        private string GetWeaponText()
        {
            string result = "";
            foreach (Weapon w in Weapons)
            {
                result += WeaponCSV(w) + "\n";
                //GetWeaponText(w)
            }
            return result;
        }
        public class View
        {
            public View(string[] cols)
            {
                Name = cols[0];
                Type = cols[1];
                Level = cols[2];
                BaseDamage = cols[3];
                ZeroRangeMod = cols[4];
                LongRangeMod = cols[5];
                ClosestRangeOffset = cols[6];
                BuildingMod = cols[7];
                MaxRange = cols[8];
                Spread = cols[9];
                SplashRadius = cols[10];
                Pen = cols[11];
                Fragments = cols[12];
                FragmentType = cols[13];
                Recovery = cols[14];
                Speed = cols[15];
                Arm = cols[16];
                NoGrav = cols[17];
                Activation = cols[18];
                FireRate = cols[19];

                Ammo = cols[20];
                LoadedInit = cols[21];
                Loaded = cols[22];
                Carried = cols[23];
                ReloadFirst = cols[24];
                ReloadAdditional = cols[25];
                //public string Reload {get;set;}
                ReloadType = cols[26];

                FireType = cols[27];

                Effect = cols[28];
                EffectDamage = cols[29];
                EffectZeroRangeMod = cols[30];
                EffectLongRangeMod = cols[31];
                EffectClosestRangeOffset = cols[32];
                EffectBuildingMod = cols[33];
                EffectDamageRate = cols[34];
                EffectMin = cols[35];
                EffectMax = cols[36];
                RadiusOfEffect = cols[37];

                Deflects = cols[38];//w.Projectile?.Influenceable
            }

            public string Name { get; set; }
            public string Type { get; set; }
            public string Level { get; set; }
            public string BaseDamage { get; set; }
            public string ZeroRangeMod { get; set; }
            public string LongRangeMod { get; set; }
            public string ClosestRangeOffset { get; set; }
            public string BuildingMod { get; set; }
            public string MaxRange { get; set; }
            public string Spread { get; set; }
            public string SplashRadius { get; set; }
            public string Pen { get; set; }
            public string Fragments { get; set; }
            public string FragmentType { get; set; }
            public string Recovery { get; set; }
            public string Speed { get; set; }
            public string Arm { get; set; }
            public string NoGrav { get; set; }
            public string Deflects { get; set; }
            public string Activation { get; set; }
            public string FireRate { get; set; }

            public string Ammo { get; set; }
            public string LoadedInit { get; set; }
            public string Loaded { get; set; }
            public string Carried { get; set; }
            public string ReloadFirst { get; set; }
            public string ReloadAdditional { get; set; }
            //public string Reload {get;set;}
            public string ReloadType { get; set; }

            public string FireType { get; set; }

            public string Effect { get; set; }
            public string EffectDamage { get; set; }
            public string EffectZeroRangeMod { get; set; }
            public string EffectLongRangeMod { get; set; }
            public string EffectClosestRangeOffset { get; set; }
            public string EffectBuildingMod { get; set; }
            public string EffectDamageRate { get; set; }
            public string EffectMin { get; set; }
            public string EffectMax { get; set; }
            public string RadiusOfEffect { get; set; }
        }
        private string WeaponCSVHeader()
        {
            return escapeCSV("Name") +
                escapeCSV("Type") +
                escapeCSV("Level") +
                escapeCSV("Base Damage") +
                escapeCSV("Zero Range Mod") + escapeCSV("Long Range Mod") + escapeCSV("Closest Range Offset") + escapeCSV("Building Mod") +
                escapeCSV("Max Range Hu") +
                escapeCSV("Spread") +
                escapeCSV("Splash Radius") +
                escapeCSV("Pen?") +
                escapeCSV("Fragments") +
                escapeCSV("Fragment Type") +
                escapeCSV("Recovery s") +
                escapeCSV("Speed Hu/s") +
                escapeCSV("Arm s") +
                escapeCSV("no grav?") +
                escapeCSV("Activation s") +
                escapeCSV("Fire Rate") +

                escapeCSV("Ammo") +
                escapeCSV("Loaded (init)") +
                escapeCSV("Loaded") +
                escapeCSV("Carried") +
                escapeCSV("Reload (first)") +
                escapeCSV("Reload (additional)") +
                //escapeCSV("Reload") +
                escapeCSV("Reload Type") +

                escapeCSV("Fire Type") +

                escapeCSV("Effect") +
                escapeCSV("Damage") +
                escapeCSV("Zero Range Mod") + escapeCSV("Long Range Mod") + escapeCSV("Closest Range Offset") + escapeCSV("Building Mod") +
                escapeCSV("Effect Damage Rate") +
                escapeCSV("Effect Min s") +
                escapeCSV("Effect Max s") +
                escapeCSV("Radius of Effect") +
                
                // Attributes
                "";

        }

        private string WeaponCSV(Weapon w)
        {
            string result = string.Empty;

            result +=
            csv(w.Name) +
            csv(w.WeaponType) +
            csv(w.Level);

            result +=
            csvDamage((w.Melee?.Damage
            ?? w.Hitscan?.Damage)
            ?? w.Projectile?.HitDamage);

            result += w.Melee != null
            ? csv(w.Melee.MaxRange)
            : (
            w.Projectile != null
            ? csv(CalcMaxRange(w.Projectile.MaxRangeTime, w.Projectile.Speed)
            )
            : csv(0));

            result += csv(((w.Hitscan?.Fragmentation?.Spread
            ?? w.Hitscan?.Recoil?.Spread)
            ?? w.Projectile?.Spread)
            ?? 0);

            result += csv((w.Hitscan?.Splash?.Radius
            ?? w.Projectile?.Splash?.Radius)
            ?? 0);

            result += csvBool((w.Hitscan?.Penetrating
            ?? w.Projectile?.Penetrating)
            ?? false);

            result += csv(w.Hitscan?.Fragmentation?.Fragments ?? 0) +
            csv(w.Hitscan?.Fragmentation?.FragmentType ?? string.Empty) +
            csv(w.Hitscan?.Recoil?.Recovery ?? 0);

            result += csv(w.Projectile?.Speed ?? 0) +
            csv(w.Projectile?.ArmTime ?? 0) +
            csvBool(w.Projectile?.Propelled ?? false);

            result += csv(w.ActivationTime) +
            csv(w.FireRate);

            result += csv(w.Ammo?.AmmoType ?? string.Empty) +
            csv(w.Ammo?.InitialLoaded ?? 0) +
            csv(w.Ammo?.Loaded ?? 0) +
            csv(w.Ammo?.Carried ?? 0);

            result += csv(w.Ammo?.ReloadFirst ?? 0) +
            csv(w.Ammo?.ReloadAdditional ?? 0) +
            // w.Ammo.Reload
            csv(w.Ammo?.ReloadUsing ?? string.Empty);

            result += csv(w.Ammo?.FireType ?? string.Empty);

            result += csv(w.Effect?.Name ?? string.Empty) +
            csvDamage(w.Effect?.Damage) +
            csv(w.Effect?.DamageRate ?? 0) +
            csv(w.Effect?.Minimum ?? 0) +
            csv(w.Effect?.Maximum ?? 0) +
            csv(w.AreaOfEffect?.Radius ?? 0);

            // added projectile feature that defaults to true
            result += csv(w.Projectile == null ? "" : (w.Projectile.Influenceable ? "true" : "immune"));

            result +=
            //w.Attributes;

            "";

            if (w.AlternateModes != null)
                foreach (Weapon w2 in w.AlternateModes)
                {
                    result += "\n>" + WeaponCSV(w2);
                }

            return result;
        }

        private decimal CalcMaxRange(decimal maxRangeTime, decimal speed)
        {
            return speed * maxRangeTime;
        }

        private string csvBool(bool penetrating)
        {
            if (penetrating) return escapeCSV("true");
            return escapeCSV(string.Empty);
        }

        private string csv(decimal maxRange)
        {
            if (maxRange == 0) return escapeCSV(string.Empty);
            return escapeCSV($"{maxRange}");
        }

        private string csvDamage(Damage damage)
        {
            // building damage modifier only interesting if it's not 1.0.
            string building = string.Empty;
            if (damage != null && damage.BuildingModifier != 1.0m)
            {
                building = $"{damage.BuildingModifier}";
            }
            building = escapeCSV(building);

            return csv(damage?.Base ?? 0) +
                csv(damage?.ZeroRangeRamp ?? 0) +
                csv(damage?.LongRangeRamp ?? 0) +
                csv(damage?.Offset ?? 0) +
                building;
        }

        private string csv(int level)
        {
            if (level == 0) return escapeCSV(string.Empty);
            return escapeCSV($"{level}");
        }

        private string csv(string name)
        {
            return escapeCSV(name);
        }

        private string escapeCSV(string name)
        {
            //TODO fixme
            //return (name?.Substring(0, Math.Min(name.Length, 7)) ?? string.Empty) + "\t";
            return name + "\t";
            //return name + ",";
        }

        private string GetWeaponText(Weapon w)
        {
            //w.Name;
            //w.WeaponType;
            //w.Level;
            string main = $"{w.Name}: Level {w.Level} {w.WeaponType}\n";

            //w.Attributes

            string damage = WeaponDamageText(w);
            //w.ActivationTime;
            //w.FireRate;

            string ammoReload = string.Empty;//w.Ammo;

            //w.AreaOfEffect;
            //w.Effect;
            //w.AlternateModes;

            return
                main +
                damage+
                $""
                ;
        }

        private string WeaponDamageText(Weapon w)
        {
            if (w.Melee != null)
            {
                return WeaponMeleeDamageText(w.Melee);
            }
            if (w.Hitscan != null)
            {
                return WeaponHitscanDamageText(w.Hitscan);
            }
            if (w.Projectile != null)
            {
                return WeaponProjectileDamageText(w.Projectile);
            }
            return string.Empty;
        }

        private string WeaponProjectileDamageText(Projectile p)
        {
            if (p == null) return string.Empty;
            return DamageText(p.HitDamage) + ProjectileText(p);
        }

        private string ProjectileText(Projectile p)
        {
            return ProjectileAccuracyText(p) + ProjectileSplashAccuracyText(p);
            //p.ArmTime;
            //p.Penetrating;
            //p.Propelled;
        }

        private string ProjectileSplashAccuracyText(Projectile p)
        {
            //p.Splash.Radius;
            //p.Speed;
            return "throw new NotImplementedException()";
        }

        private string ProjectileAccuracyText(Projectile p)
        {
            //p.Speed;p.Propelled;p.Penetrating;
            return "throw new NotImplementedException()";
        }

        private string WeaponHitscanDamageText(Hitscan h)
        {
            return DamageText(h.Damage) + FragmentationText(h.Fragmentation);
            //h.Penetrating;
            //h.Recoil;
        }

        private string FragmentationText(Fragmentation f)
        {
            if (f == null) return string.Empty;
            return $"{f.Fragments} {f.FragmentType}s " + AccuracyText(f.Spread);
        }

        private string AccuracyText(decimal spread)
        {
            if (spread == 0) return string.Empty;
            return "throw new NotImplementedException()";
        }

        private string DamageText(Damage damage)
        {
            if (damage == null) return string.Empty;
            return $"{damage.Base}";

            //damage.BuildingModifier;

            //damage.LongRangeRamp;

            //damage.PointBlankRamp;
            //damage.ZeroRangeRamp;
            //damage.Offset;
        }

        private string WeaponMeleeDamageText(Melee m)
        {
            return DamageText(m.Damage) + $" to {m.MaxRange}";
        }
    }
}
