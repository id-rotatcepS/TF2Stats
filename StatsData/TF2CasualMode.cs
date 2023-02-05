using StatsData.GameFiles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace StatsData
{
    public class TF2CasualMode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        static Scout Scout = new Scout();// { File = "" };
        static Soldier Soldier = new Soldier();// { File = "" };
        static Pyro Pyro = new Pyro();// { File = "" };
        static Demoman Demoman = new Demoman();// { File = "" };
        static Heavy Heavy = new Heavy();// { File = "" };
        static Engineer Engineer = new Engineer();// { File = "" };
        static Medic Medic = new Medic();// { File = "" };
        static Sniper Sniper = new Sniper();// { File = "" };
        static Spy Spy = new Spy();// { File = "" };

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

        // { ItemsID = "1152" }tf_weapon_grapplinghook
        // { ItemsID = "1132" }tf_weapon_spellbook
        // { ItemsID = "25" }tf_weapon_pda_engineer_build tf_weapon_builder: "28"
        // { ItemsID = "26" }tf_weapon_pda_engineer_destroy
        // { ItemsID = "27" }tf_weapon_pda_spy
        // { ItemsID = "1155" } //tf_weapon_passtime_gun jack, I think
        // power up canteen (mvm)"489","1163"

        static Pomson6000 Pomson6000 = new Pomson6000() { ItemsID = "588" };
        static RighteousBison RighteousBison = new RighteousBison() { ItemsID = "442" };

        static FlareGun FlareGun = new FlareGun() { ItemsID = "39" };
        static Detonator Detonator = new Detonator() { ItemsID = "351" };
        static Manmelter Manmelter = new Manmelter() { ItemsID = "595" };
        static ScorchShot ScorchShot = new ScorchShot() { ItemsID = "740" };

        static Huntsman Huntsman = new Huntsman() { ItemsID = "56" };
        static CrusadersCrossbow CrusadersCrossbow = new CrusadersCrossbow() { ItemsID = "305" };
        static RescueRanger RescueRanger = new RescueRanger() { ItemsID = "997" };

        static CharginTarge CharginTarge = new CharginTarge() { ItemsID = "131" };
        static SplendidScreen SplendidScreen = new SplendidScreen() { ItemsID = "406" };
        static TideTurner TideTurner = new TideTurner() { ItemsID = "1099" };

        static BuffBanner BuffBanner = new BuffBanner() { ItemsID = "129" };
        static BatallionsBackup BatallionsBackup = new BatallionsBackup() { ItemsID = "226" };
        static Concheror Concheror = new Concheror() { ItemsID = "354" };

        static ThermalThruster ThermalThruster = new ThermalThruster() { ItemsID = "1179" };
        static Mantreads Mantreads = new Mantreads() { ItemsID = "444" };

        static BASEJumper BASEJumper = new BASEJumper() { ItemsID = "1101" };
        static Gunboats Gunboats = new Gunboats() { ItemsID = "133" };
        static AliBabasWeeBooties AliBabasWeeBooties = new AliBabasWeeBooties() { ItemsID = "405" };
        static Razorback Razorback = new Razorback() { ItemsID = "57" };
        static DarwinsDangerShield DarwinsDangerShield = new DarwinsDangerShield() { ItemsID = "231" };
        static CozyCamper CozyCamper = new CozyCamper() { ItemsID = "642" };

        static Sandvich Sandvich = new Sandvich() { ItemsID = "42" };
        static DalokahsBar DalokahsBar = new DalokahsBar() { ItemsID = "159" };
        static BuffaloSteakSandvich BuffaloSteakSandvich = new BuffaloSteakSandvich() { ItemsID = "311" };
        static SecondBanana SecondBanana = new SecondBanana() { ItemsID = "1190" };

        static BonkAtomicPunch BonkAtomicPunch = new BonkAtomicPunch() { ItemsID = "46" };//guess uses same printname as lunchbox, and mentions spy pda
        static CritACola CritACola = new CritACola() { ItemsID = "163" };

        static FlyingGuillotine FlyingGuillotine = new FlyingGuillotine() { ItemsID = "812" };

        static Jarate Jarate = new Jarate() { ItemsID = "58" };
        static MadMilk MadMilk = new MadMilk() { ItemsID = "222" };
        static GasPasser GasPasser = new GasPasser() { ItemsID = "1180" };

        static EngineerPistol EngineerPistol = new EngineerPistol() { ItemsID = "22" };
        static ShortCircuit ShortCircuit = new ShortCircuit() { ItemsID = "528" };
        static Wrangler Wrangler = new Wrangler() { ItemsID = "140" };

        static ScoutPistol ScoutPistol = new ScoutPistol() { ItemsID = "23" };
        static Winger Winger = new Winger() { ItemsID = "449" };
        static PrettyBoysPocketPistol PrettyBoysPocketPistol = new PrettyBoysPocketPistol() { ItemsID = "773" };

        static RocketLauncher RocketLauncher = new RocketLauncher() { ItemsID = "18" };
        static DirectHit DirectHit = new DirectHit() { ItemsID = "127" };
        static BlackBox BlackBox = new BlackBox() { ItemsID = "228" };
        static LibertyLauncher LibertyLauncher = new LibertyLauncher() { ItemsID = "414" };
        static CowMangler5000 CowMangler5000 = new CowMangler5000() { ItemsID = "441" };
        static BeggarsBazooka BeggarsBazooka = new BeggarsBazooka() { ItemsID = "730" };
        static AirStrike AirStrike = new AirStrike() { ItemsID = "1104" };

        static Shotgun Shotgun = new Shotgun() { ItemsID = "9" };
        // { ItemsID = "12" }//pyro
        // { ItemsID = "10" }//soldier
        // { ItemsID = "11" } // heavy
        static ReserveShooter ReserveShooter = new ReserveShooter() { ItemsID = "415" };
        static PanicAttack PanicAttack = new PanicAttack() { ItemsID = "1153" };
        static FamilyBusiness FamilyBusiness = new FamilyBusiness() { ItemsID = "425" };
        static FrontierJustice FrontierJustice = new FrontierJustice() { ItemsID = "141" };
        static Widowmaker Widowmaker = new Widowmaker() { ItemsID = "527" };

        static Scattergun Scattergun = new Scattergun() { ItemsID = "13" };
        static ForceANature ForceANature = new ForceANature() { ItemsID = "45" };
        static Shortstop Shortstop = new Shortstop() { ItemsID = "220" };
        static SodaPopper SodaPopper = new SodaPopper() { ItemsID = "448" };
        static BabyFacesBlaster BabyFacesBlaster = new BabyFacesBlaster() { ItemsID = "772" };
        static BackScatter BackScatter = new BackScatter() { ItemsID = "1103" };

        static FlameThrower Flamethrower = new FlameThrower() { ItemsID = "21" };
        static BackBurner BackBurner = new BackBurner() { ItemsID = "40" };
        static Degreaser Degreaser = new Degreaser() { ItemsID = "215" };
        static Phlogistinator Phlogistinator = new Phlogistinator() { ItemsID = "594" };
        static DragonsFury DragonsFury = new DragonsFury() { ItemsID = "1178" };

        static GrenadeLauncher GrenadeLauncher = new GrenadeLauncher() { ItemsID = "19" };
        static LochNLoad LochNLoad = new LochNLoad() { ItemsID = "308" };
        static LooseCannon LooseCannon = new LooseCannon() { ItemsID = "996" };
        static IronBomber IronBomber = new IronBomber() { ItemsID = "1151" };

        static StickybombLauncher StickybombLauncher = new StickybombLauncher() { ItemsID = "20" };
        static ScottishResistance ScottishResistance = new ScottishResistance() { ItemsID = "130" };
        static QuickiebombLauncher QuickiebombLauncher = new QuickiebombLauncher() { ItemsID = "1150" };

        static Minigun Minigun = new Minigun() { ItemsID = "15" };
        static Natascha Natascha = new Natascha() { ItemsID = "41" };
        static BrassBeast BrassBeast = new BrassBeast() { ItemsID = "312" };
        static Tomislav Tomislav = new Tomislav() { ItemsID = "424" };
        static HuoLongHeater HuoLongHeater = new HuoLongHeater() { ItemsID = "811" };// "The Huo Long Heatmaker" not "heater"

        static SyringeGun SyringeGun = new SyringeGun() { ItemsID = "17" };
        static Blutsauger Blutsauger = new Blutsauger() { ItemsID = "36" };
        static Overdose Overdose = new Overdose() { ItemsID = "412" };

        static MediGun MediGun = new MediGun() { ItemsID = "29" };
        static Kritzkrieg Kritzkrieg = new Kritzkrieg() { ItemsID = "35" };
        static QuickFix QuickFix = new QuickFix() { ItemsID = "411" };
        static Vaccinator Vaccinator = new Vaccinator() { ItemsID = "998" };

        static SniperRifle SniperRifle = new SniperRifle() { ItemsID = "14" };
        static SydneySleeper SydneySleeper = new SydneySleeper() { ItemsID = "230" };
        static BazaarBargain BazaarBargain = new BazaarBargain() { ItemsID = "402" };
        static Machina Machina = new Machina() { ItemsID = "526" };
        static HitmansHeatmaker HitmansHeatmaker = new HitmansHeatmaker() { ItemsID = "752" };
        static Classic Classic = new Classic() { ItemsID = "1098" };

        static SMG SMG = new SMG() { ItemsID = "16" };
        static CleanersCarbine CleanersCarbine = new CleanersCarbine() { ItemsID = "751" };

        static Revolver Revolver = new Revolver() { ItemsID = "24" };
        static Ambassador Ambassador = new Ambassador() { ItemsID = "61" };
        static LEtranger LEtranger = new LEtranger() { ItemsID = "224" };
        static Enforcer Enforcer = new Enforcer() { ItemsID = "460" };
        static Diamondback Diamondback = new Diamondback() { ItemsID = "525" };

        static Sapper Sapper = new Sapper() { ItemsID = "735" };
        static RedTapeRecorder RedTapeRecorder = new RedTapeRecorder() { ItemsID = "810" };

        static InvisWatch InvisWatch = new InvisWatch() { ItemsID = "30" };
        static Deadringer Deadringer = new Deadringer() { ItemsID = "59" };
        static CloakAndDagger CloakAndDagger = new CloakAndDagger() { ItemsID = "60" };

        static Wrench Wrench = new Wrench() { ItemsID = "7" };
        static SouthernHospitality SouthernHospitality = new SouthernHospitality() { ItemsID = "155" };
        static Jag Jag = new Jag() { ItemsID = "329" };
        static EurekaEffect EurekaEffect = new EurekaEffect() { ItemsID = "589" };

        static Gunslinger Gunslinger = new Gunslinger() { ItemsID = "142" };

        static Knife Knife = new Knife() { ItemsID = "4" };
        static YourEternalReward YourEternalReward = new YourEternalReward() { ItemsID = "225" };
        static ConniversKunai ConniversKunai = new ConniversKunai() { ItemsID = "356" };
        static BigEarner BigEarner = new BigEarner() { ItemsID = "461" };
        static Spycicle Spycicle = new Spycicle() { ItemsID = "649" };

        static Bat Bat = new Bat() { ItemsID = "0" };
        // { ItemsID = "221"} "tf_weapon_fish"
        static Sandman Sandman = new Sandman() { ItemsID = "44" };
        static CandyCane CandyCane = new CandyCane() { ItemsID = "317" };
        static BostonBasher BostonBasher = new BostonBasher() { ItemsID = "325" };
        static SunOnAStick SunOnAStick = new SunOnAStick() { ItemsID = "349" };
        static FanOWar FanOWar = new FanOWar() { ItemsID = "355" };
        static Atomizer Atomizer = new Atomizer() { ItemsID = "450" };
        static WrapAssassin WrapAssassin = new WrapAssassin() { ItemsID = "648" };


        static EscapePlan EscapePlan = new EscapePlan() { ItemsID = "775" };
        static DisciplinaryAction DisciplinaryAction = new DisciplinaryAction() { ItemsID = "447" };
        static HotHand HotHand = new HotHand() { ItemsID = "1181" };
        static PowerJack PowerJack = new PowerJack() { ItemsID = "214" };
        static GlovesOfRunningUrgently GlovesOfRunningUrgently = new GlovesOfRunningUrgently() { ItemsID = "239" };
        static EvictionNotice EvictionNotice = new EvictionNotice() { ItemsID = "426" };

        // stock Melees ...
        // 0:bat
        // { ItemsID = "1" }tf_weapon_bottle
        // { ItemsID = "2" }tf_weapon_fireaxe
        //  { ItemsID = "3" } //tf_weapon_club "machete" probably sniper stock
        // 4: knife
        // { ItemsID = "5" }tf_weapon_fists
        // { ItemsID = "6" }tf_weapon_shovel
        // 7: wrench
        // { ItemsID = "8" }tf_weapon_bonesaw

        static PainTrain PainTrain = new PainTrain() { ItemsID = "154" };
        static HalfZatoichi HalfZatoichi = new HalfZatoichi() { ItemsID = "357" };

        static Equalizer Equalizer = new Equalizer() { ItemsID = "128" };
        static MarketGardener MarketGardener = new MarketGardener() { ItemsID = "416" };
        static Axtinguisher Axtinguisher = new Axtinguisher() { ItemsID = "38" };
        static Homewrecker Homewrecker = new Homewrecker() { ItemsID = "153" };
        static BackScratcher BackScratcher = new BackScratcher() { ItemsID = "326" };
        static SharpenedVolcanoFragment SharpenedVolcanoFragment = new SharpenedVolcanoFragment() { ItemsID = "348" };
        static ThirdDegree ThirdDegree = new ThirdDegree() { ItemsID = "593" };
        static NeonAnnihilator NeonAnnihilator = new NeonAnnihilator() { ItemsID = "813" };
        static Eyelander Eyelander = new Eyelander() { ItemsID = "132" };
        static UllapoolCaber UllapoolCaber = new UllapoolCaber() { ItemsID = "307" };
        static ClaidheamhMor ClaidheamhMor = new ClaidheamhMor() { ItemsID = "327" };
        static PersianPersuader PersianPersuader = new PersianPersuader() { ItemsID = "404" };
        static ScotsmansSkullcutter ScottsmansSkullcutter = new ScotsmansSkullcutter() { ItemsID = "172" };
        static KillingGlovesOfBoxing KillingGlovesOfBoxing = new KillingGlovesOfBoxing() { ItemsID = "43" };
        static WarriorsSpirit WarriorsSpirit = new WarriorsSpirit() { ItemsID = "310" };
        static HolidayPunch HolidayPunch = new HolidayPunch() { ItemsID = "656" };
        static FistsOfSteel FistsOfSteel = new FistsOfSteel() { ItemsID = "331" };
        static Ubersaw Ubersaw = new Ubersaw() { ItemsID = "37" };
        static Vitasaw Vitasaw = new Vitasaw() { ItemsID = "173" };
        static Amputator Amputator = new Amputator() { ItemsID = "304" };
        static SolemnVow SolemnVow = new SolemnVow() { ItemsID = "413" };
        static TribalmansShiv TribalmansShiv = new TribalmansShiv() { ItemsID = "171" };
        static Bushwaka Bushwaka = new Bushwaka() { ItemsID = "232" };
        static Shahanshah Shahanshah = new Shahanshah() { ItemsID = "401" };

        public List<Weapon> Weapons => WeaponsBase;

        public List<Weapon> WeaponsGroup
        {
            get
            {
                List<Weapon> result = //new List<Weapon>(WeaponsBase.ToArray());
                    new List<Weapon>();

                AddGroup<AShotgun>(result, new Shotgun());
                AddGroup<AScattergun>(result, new Scattergun());
                AddGroup<APistol>(result, new ScoutPistol());
                AddGroup<ABolt>(result, new Huntsman());
                AddGroup<AFlameThrowerBase>(result, new FlameThrower());
                AddGroup<AFlareGun>(result, new FlareGun());
                AddGroup<AGrenadeLauncher>(result, new GrenadeLauncher());
                AddGroup<AMinigun>(result, new Minigun());
                AddGroup<ARevolver>(result, new Revolver());
                AddGroup<ARocketLauncher>(result, new RocketLauncher());
                AddGroup<ASMG>(result, new SMG());
                AddGroup<ASniperRifle>(result, new SniperRifle());
                AddGroup<ASyringeGun>(result, new SyringeGun());
                AddGroup<Sword>(result, new Eyelander());
                AddGroup<AStickybombLauncher>(result, new StickybombLauncher());
                AddGroup<ShieldBash>(result, new CharginTarge());
                AddGroup<IndivisibleParticleSmasher>(result, new Pomson6000());
                AddGroup<ThrowableWeapon>(result, new SandmanBall())
                    // bauble is an alternate-only, same as SandmanBall
                    .SeparateModes.AddRange(TF2CasualMode.WrapAssassin.SeparateModes);
                AddGroup<ActiveJumpAssist>(result, new Mantreads());

                AddGroup<AMediGun>(result, new MediGun());
                AddGroup<AKnife>(result, new Knife());
                AddGroup<ABat>(result, new Bat());
                AddGroup<BuildingMaintenance>(result, new Wrench());
                AddGroup<Sword>(result, new Eyelander());

                AddGroup<MeleeWeapon>(result, new PainTrain());

                AddGroup<Sapper>(result, new Sapper());

                //TODO the "other" melee subtypes, non-damage or simple items. unique items

                return result;
            }
        }
        public List<Weapon> StockWeapons
        {
            get
            {
                List<Weapon> result = //new List<Weapon>(WeaponsBase.ToArray());
                    new List<Weapon>();

                result.Add(new Scattergun());
                result.Add(new ScoutPistol());
                result.Add(new Bat());

                result.Add(new RocketLauncher());
                result.Add(new SoldierShotgun());

                result.Add(new FlameThrower());
                result.Add(new PyroShotgun());

                result.Add(new GrenadeLauncher());
                result.Add(new StickybombLauncher());

                result.Add(new Minigun());
                //result.Add(new HeavyShotgun());

                result.Add(new Shotgun());
                result.Add(new EngineerPistol());
                result.Add(new Wrench());
                //PDA

                result.Add(new SyringeGun());
                result.Add(new MediGun());

                result.Add(new SniperRifle());
                result.Add(new SMG());

                result.Add(new Revolver());
                result.Add(new Sapper());
                result.Add(new Knife());
                // disguise kit
                result.Add(new InvisWatch());

                //result.Add(new MeleeWeapon());


                return result;
            }
        }
        private T AddGroup<T>(List<Weapon> result, T sg) where T : Weapon
        {
            //TODO consider sg.SeparateModes
            sg.AlternateModes.Clear();
            sg.AlternateModes.AddRange(WeaponsBase.OfType<T>().Where(s => sg.GetType() != s.GetType()).ToList());
            result.Add(sg);
            return sg;
        }

        public List<Weapon> WeaponsBase
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
            PersianPersuader,
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

        private ObservableCollection<WeaponVM> rows = null;
        public ObservableCollection<WeaponVM> WeaponCollection => rows ?? (rows = CreateWeaponCollection());

        private ObservableCollection<WeaponVM> CreateWeaponCollection()
        {
            ObservableCollection<WeaponVM> rows = new ObservableCollection<WeaponVM>();
            List<Weapon> list = IsWeaponGroups ? this.WeaponsGroup : (IsStockOnly?StockWeapons:Weapons);
            foreach (Weapon w in list)
            {
                rows.Add(new WeaponVM(w));
                if (IsIncludingAlternates && w.AlternateModes != null)
                {
                    foreach (Weapon x in w.AlternateModes)
                    {
                        if (x != null)
                            rows.Add(new WeaponVM(x, w));
                    }
                    foreach (Weapon x in w.SeparateModes)
                    {
                        if (x != null)
                        {
                            rows.Add(new WeaponVM(x, w));//TODO in constructor I passed null here, I don't recall how this is meant to work.
                            foreach (Weapon t in x.AlternateModes)
                            {
                                if (t != null)
                                    rows.Add(new WeaponVM(t, w));
                            }
                        }
                    }
                }
            }
            return rows;
        }

        private bool _IsIncludingAlternates = false;

        public bool IsIncludingAlternates
        {
            get => _IsIncludingAlternates;
            set
            {
                _IsIncludingAlternates = value;
                rows = null;
                NotifyPropertyChanged(nameof(WeaponCollection));
                NotifyPropertyChanged(nameof(Spreadsheet));

            }
        }

        private bool _IsWeaponGroups = false;

        public bool IsWeaponGroups
        {
            get => _IsWeaponGroups;
            set
            {
                _IsWeaponGroups = value;
                _IsStockOnly = false;
                rows = null;
                NotifyPropertyChanged(nameof(WeaponCollection));
                NotifyPropertyChanged(nameof(IsStockOnly));
                NotifyPropertyChanged(nameof(Spreadsheet));

            }
        }

        private bool _IsStockOnly = false;

        public bool IsStockOnly
        {
            get => _IsStockOnly;
            set
            {
                _IsStockOnly = value;
                _IsWeaponGroups = false;
                rows = null;
                NotifyPropertyChanged(nameof(WeaponCollection));
                NotifyPropertyChanged(nameof(IsWeaponGroups));
                NotifyPropertyChanged(nameof(Spreadsheet));
            }
        }

        private bool _IsGameFilesLoaded = false;
        public bool IsGameFilesLoaded
        {
            get => _IsGameFilesLoaded;
            set
            {
                // one-way boolean - we load files and that's it.
                if (_IsGameFilesLoaded) return;
                _IsGameFilesLoaded = value;

                LoadGameFileItems(Weapons);

                NotifyPropertyChanged(nameof(WeaponCollection));
            }
        }

        private static async void LoadGameFileItems(List<Weapon> weapons)
        {
            _ = await NotifyUserAsync("Select Folder of Decoded Game Files, if any.", "Folder containing GCFScape & Vice extracted tf_weapon*.txt files.");
            await LoadItemClasses();// new DirectoryInfo(@"C:\Users\...\Desktop\class stats\TF File Extraction\tf_scripts_ctx_decodes")
            _ = await NotifyUserAsync("Select Folder of items_game.txt File", @"items_game.txt is likely in your steamapps\common\Team Fortress 2\tf\scripts\items\ folder.");
            await LoadItems("items_game.txt");// new FileInfo(@"C:\Users\...\Desktop\class stats\TF File Extraction\steamapps_common_Team Fortress 2_tf_scripts_items\items_game.txt"));
            
            await new SpreadsheetWriter(weapons).Write();

        }

        public static string Spreadsheet { get; internal set; }

        private static async Task<ContentDialogResult> NotifyUserAsync(string title, string content)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            return await noWifiDialog.ShowAsync();
        }

        ////https://stackoverflow.com/questions/37541923/how-to-create-informative-toast-notification-in-uwp-app
        //private static void ShowSystemToastNotification(string title, string stringContent)
        //{
        //    Windows.Data.Xml.Dom.XmlDocument toastXml = CreateToastXmlDocument(title, stringContent);

        //    Windows.UI.Notifications.ToastNotification toast = new Windows.UI.Notifications.ToastNotification(toastXml);
        //    // 4 seconds: expire it as it goes to the system notification list.
        //    toast.ExpirationTime = DateTime.Now.AddSeconds(4);

        //    Windows.UI.Notifications.ToastNotifier toastNotifier = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();
        //    toastNotifier.Show(toast);
        //}
        //private static Windows.Data.Xml.Dom.XmlDocument CreateToastXmlDocument(string title, string stringContent)
        //{
        //    Windows.Data.Xml.Dom.XmlDocument toastXml = Windows.UI.Notifications.ToastNotificationManager.GetTemplateContent(Windows.UI.Notifications.ToastTemplateType.ToastText02);
        //    Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
        //    toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
        //    toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));
        //    Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
        //    Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
        //    audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");
        //    return toastXml;
        //}

        //DirectoryInfo path
        private static async Task LoadItemClasses()
        {
            Windows.UI.Core.CoreCursor oldCursor = Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor;
            try
            {
                Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);

                var folderPicker = new Windows.Storage.Pickers.FolderPicker();
                folderPicker.CommitButtonText = "Load tf_weapon files (ctx decoded to txt) from Here";
                folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
                folderPicker.FileTypeFilter.Add("*");
                StorageFolder folder = await folderPicker.PickSingleFolderAsync();
                if (folder == null) return;
                //Windows.Storage.StorageFolder folder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync(path.FullName);
                IReadOnlyList<StorageFile> files = await folder.GetFilesAsync();
                foreach (StorageFile file in files.Where(IsItemfile))
                {
                    string filename = Path.GetFileNameWithoutExtension(file.Name);
                    string content = await FileIO.ReadTextAsync(file);

                    new ItemClass(filename, content);
                }

                ItemClass.ResolveItemClasses();
            }
            finally
            {
                Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = oldCursor;
            }

        }

        private static bool IsItemfile(StorageFile arg)
        {
            return arg.FileType == ".TXT";
        }

        //FileInfo items_game_txt
        private static async Task LoadItems(string items_game_txt_Name)
        {
            Windows.UI.Core.CoreCursor oldCursor = Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor;
            try
            {
                Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);

                var folderPicker = new Windows.Storage.Pickers.FolderPicker();
                folderPicker.CommitButtonText = "Load items_game.txt from Here";
                folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
                folderPicker.FileTypeFilter.Add("*");
                StorageFolder folder = await folderPicker.PickSingleFolderAsync();
                if (folder == null) return;
                StorageFile file = await folder.GetFileAsync(items_game_txt_Name);
                string fileContent = await FileIO.ReadTextAsync(file);

                GameItem.LoadPrefabsItemsAndResolve(fileContent);
            }
            finally
            {
                Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = oldCursor;
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
            if (w.SeparateModes != null)
                foreach (Weapon w2 in w.SeparateModes)
                {
                    //TODO add separatemodes.alternatemodes, too.
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
