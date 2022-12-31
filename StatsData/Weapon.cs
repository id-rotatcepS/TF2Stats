using System.Collections.Generic;
using System.Linq;

namespace StatsData
{
    // Note, we are trying to use decimal most everywhere instead of double to get expected calculation results.
    // "If numbers must add up correctly or balance, use decimal. This includes any financial storage or calculations, scores, or other numbers that people might do by hand.
    //  If the exact value of numbers is not important, use double for speed.This includes graphics, physics or other physical sciences computations where there is already a number of significant digits."
   
    public class Weapon
    {
        public Weapon()
        {
            //            Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Scattergun"),new NeutralAttribute("1"),new NeutralAttribute("Scattergun\n60 damage (96 dps) 175%-53% by range\n10 pellet spread accurate to 36% range\nReloads 6 in 3.2 sec (first in 0.7 sec), 32 carried"),
            //new NeutralAttribute("Double-barreled lever-action shotgun:"),
            //new PositiveAttribute("+17% close range damage bonus"),
            //new PositiveAttribute("\n-30% faster first shot reload"), 
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Pistol"),new NeutralAttribute("1"),new NeutralAttribute("Pistol\n15 damage (100 dps) 147%-53% by range\nRecoil accurate to 61% range\nReloads 12 in 1.2 sec (clip), 36 carried"),
            //new NeutralAttribute("Wielded by the Scout: / Wielded by the Engineer:"),
            //new PositiveAttribute("-8% faster clip reload / +455% max secondary ammo"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Bat"),new NeutralAttribute("1"),new NeutralAttribute("Bat\n35 damage (70 dps)"),
            //new NeutralAttribute("Wielded by the Scout:"),
            //new PositiveAttribute("+60% faster firing speed"),
            //new NegativeAttribute("-47% damage penalty"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Rocket Launcher"),new NeutralAttribute("1"),new NeutralAttribute("Rocket Launcher\n90 explosive damage (113 dps) 124%-53% by range\n Straight projectile accurate to 18%, explosion to 122% range\nReloads 4 in 3.3 sec (first in 0.9 sec), 20 carried"),
            //new NeutralAttribute("Dual-use: Impact or Rocket Jump"),
            //new PositiveAttribute("+11% self push force from rocket jumps"),
            //new NegativeAttribute("Self inflicted blast damage"),
            //new NegativeAttribute("\n-44% self push force on ground"), 
            //new NeutralAttribute("\nExplosive: 50%-100% damage in explosion radius"), 
            //new NeutralAttribute("\nBlasts push enemy stickybombs away"), 
            //new DescriptionAttribute("\nImpact: Explodes on contact with players, buildings, and surfaces<br/>Rocket Jump: Mobility from self-damage"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Shotgun"),new NeutralAttribute("1"),new NeutralAttribute("Shotgun\n60 damage (96 dps) 150%-53% by range\n10 pellet spread accurate to 36% range\nReloads 6 in 3.5 sec (first in 1 sec), 32 carried"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Shovel"),new NeutralAttribute("1"),new NeutralAttribute("Shovel\n65 damage (81 dps)"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Flame Thrower"),new NeutralAttribute("1"),new NeutralAttribute("Flame Thrower\n7 fire damage (81 dps) 200%-0% by range\n Penetrating flames limited to 64% range\n 200 carried"),
            //new NeutralAttribute("Dual-use: Flames or Airblast"),
            //new PositiveAttribute("Extinguishing teammates restores 20 health"),
            //new PositiveAttribute("On Hit: Afterburn for 3-10 seconds by exposure"),
            //new NegativeAttribute("No effect underwater"),
            //new NeutralAttribute("Afterburn: 8 dps, reduces Medi Gun healing and resist shield effects"),
            //new NeutralAttribute("Does not destroy stickybombs"),
            //new DescriptionAttribute("\nFlames: Steady exposure grants up to +100% damage<br/>0.9 second max exposure<br/>Alt-Fire: -20 ammo to release a blast of air that pushes enemies, redirects projectiles, and extinguishes teammates<br/>Deflected projectiles (except stickybombs) deal mini-crits to enemies"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Fire Axe"),new NeutralAttribute("1"),new NeutralAttribute("Fire Axe\n65 damage (81 dps)"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Grenade Launcher"),new NeutralAttribute("1"),new NeutralAttribute("Grenade Launcher\n100 explosive damage (167 dps) \n Arced projectile accurate to 19%, explosion to 133% range\nReloads 4 in 3 sec (first in 1.2 sec), 16 carried"),
            //new NeutralAttribute("Dual-use: Impact or Roller"),
            //new PositiveAttribute("Deals 100% damage at any range"),
            //new NegativeAttribute("Self inflicted blast damage"),
            //new NeutralAttribute("Explosive: 50%-100% damage in explosion radius"),
            //new NeutralAttribute("\nBlast knocks away enemy stickybombs"), 
            //new DescriptionAttribute("\nImpact: Explodes on contact with players and buildings<br/>Roller: -40% damage penalty from surface bounces, 2.3 second fuse"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Stickybomb Launcher"),new NeutralAttribute("1"),new NeutralAttribute("Stickybomb Launcher\n120 explosive damage (200 dps) 120%-50% by range\n Arced projectile accurate to 14%, explosion to 100% range\nReloads 8 in 5.8 sec (first in 1.1 sec), 24 carried"),
            //new NeutralAttribute("Multi-use: Spam/Flak, Trap, or Sticky Jump"),
            //new NegativeAttribute("Self inflicted blast damage"),
            //new NeutralAttribute("\nNo impact damage"), 
            //new NeutralAttribute("\nExplosive: 50%-100% damage in explosion radius"), 
            //new NeutralAttribute("\nBlast knocks away enemy stickybombs"), 
            //new NeutralAttribute("\nAlt-Fire: Detonate all stickybombs"), 
            //new DescriptionAttribute("8 max stickybombs out<br/>Hold primary fire to charge projectile speed<br/>Max charge in 4.0 seconds for +160% accuracy<br/><br/>Spam: 0.7 second minimum arm time to detonate<br/>Flak: -15% fading explosion radius penalty in air<br/>Trap: Bombs armed 5 seconds deal 100% damage at any range<br/>Sticky Jump: High mobility from high self-damage"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Bottle"),new NeutralAttribute("1"),new NeutralAttribute("Bottle\n65 damage (81 dps)"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Minigun"),new NeutralAttribute("1"),new NeutralAttribute("Minigun\n36 damage (360 dps) 150%-53% by range\n4 pellet spread accurate to 30% range\n 200 carried"),
            //new NegativeAttribute("-63% move speed while spun up"),
            //new NegativeAttribute("-15% damage penalty to level 2 sentries"),
            //new NegativeAttribute("-20% damage penalty to level 3 sentries"),
            //new NeutralAttribute("0.87 second deployment spin up"),
            //new NeutralAttribute("-50% fading damage penalty until spun up 1 second"),
            //new NeutralAttribute("Alt-Fire: Spin up without firing"),
            //new DescriptionAttribute("\n\"Sasha,\" an enormous Gatling-style machine gun"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Fists"),new NeutralAttribute("1"),new NeutralAttribute("Fists\n65 damage (81 dps)"),
            //new NeutralAttribute("Alt-Fire: Right cross"),
            //new NeutralAttribute("Kill Taunt: Showdown"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Wrench"),new NeutralAttribute("1"),new NeutralAttribute("Wrench\n65 damage (81 dps)"),
            //new NeutralAttribute("Dual-use: Melee or Maintenance"),
            //new PositiveAttribute("Damages sappers"),
            //new NegativeAttribute("-10% move speed while hauling"),
            //new NeutralAttribute("\nAlt-Fire: Haul own building"), 
            //new DescriptionAttribute("\nMaintenance: Use metal to repair, reload, or upgrade friendly buildings on hit<br/>Speeds up construction of friendly buildings on hit<br/>Cannot repair old damage during redeploy"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("PDA"),new NeutralAttribute("1"),new NeutralAttribute("PDA"),
            //new NeutralAttribute("Selects building to construct"),
            //new PositiveAttribute("Buildings are immune to crits and mini-crits"),
            //new NegativeAttribute("Buildings take 100% damage at any range"),
            //new NeutralAttribute("Cannot pass through own buildings"),
            //new NeutralAttribute("Metal cost: 130 (Sentry), 100 (Dispenser), or 50 (Teleporter)"),
            //new DescriptionAttribute("\nEvery building begins with a solid foundation, showing your mettle, and striking at the heart of the problem"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Syringe Gun"),new NeutralAttribute("1"),new NeutralAttribute("Syringe Gun\n10 damage (100 dps) 120%-50% by range\n Arced projectile accurate to 16% range\nReloads 40 in 1.6 sec (clip), 150 carried"),
            //new NeutralAttribute("Syringes are immune to projectile influencers"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Medi Gun"),new NeutralAttribute("1"),new NeutralAttribute("Medi Gun\n3 healing (24 healing per second) \n Beam limited to 105% range"),
            //new PositiveAttribute("Does not require ammo"),
            //new PositiveAttribute("100% healing at any range"),
            //new PositiveAttribute("Match move speed of faster heal target"),
            //new PositiveAttribute("Overheal target to 150%"),
            //new NegativeAttribute("Lock-on within 88% range only"),
            //new NeutralAttribute("Up to +200% healing rate out of combat"),
            //new DescriptionAttribute("\nHealing charges Über up to 2.5% per second<br/>Random critical hit chance includes damage by heal targets<br/>?Random critical hit chance includes healing done the last 20 seconds?<br/>Alt-Fire: Activate ÜberCharge for 8 seconds of damage invulnerability and no capture rate"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Bonesaw"),new NeutralAttribute("1"),new NeutralAttribute("Bonesaw\n65 damage (81 dps)"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Sniper Rifle"),new NeutralAttribute("1"),new NeutralAttribute("Sniper Rifle\n50 damage (33 dps) \n Accurate at any range\n 25 carried"),
            //new NeutralAttribute("Dual-use: Hipshot or Headshot"),
            //new PositiveAttribute("Deals 100% damage at any range"),
            //new PositiveAttribute("Scoped headshots always critical hit"),
            //new NegativeAttribute("No random critical hits"),
            //new NegativeAttribute("-73% move speed while zoomed"),
            //new NeutralAttribute("Shots pass through teammates"),
            //new DescriptionAttribute("\nAlt-Fire: Zoom in for headshots, charge up to +200% damage<br/>Charge: 1.3 second delay, 3.3 second max charge"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("SMG"),new NeutralAttribute("1"),new NeutralAttribute("SMG\n8 damage (80 dps) 150%-50% by range\nRecoil accurate to 98% range\nReloads 25 in 1.1 sec (clip), 75 carried"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Kukri"),new NeutralAttribute("1"),new NeutralAttribute("Kukri\n65 damage (81 dps)"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Revolver"),new NeutralAttribute("1"),new NeutralAttribute("Revolver\n40 damage (78 dps) 150%-53% by range\nRecoil accurate to 98% range\nReloads 6 in 1.2 sec (clip), 24 carried"),
            //
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Knife"),new NeutralAttribute("1"),new NeutralAttribute("Knife\n40 damage (50 dps)"),
            //new NeutralAttribute("Dual-use: Butterknife or Backstab"),
            //new PositiveAttribute("Backstab: Instant kill"),
            //new PositiveAttribute("Hits at beginning of swing"),
            //new NegativeAttribute("-23% damage penalty"),
            //new NegativeAttribute("No random critical hits"),
            //new NeutralAttribute("Kill Taunt: Fencing"),
            //new DescriptionAttribute("\nAttack an enemy from behind to Backstab them for a one hit kill."),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Disguise Kit"),new NeutralAttribute("1"),new NeutralAttribute("...Cigarette Case?"),
            //new NeutralAttribute("Look and sound like others to the enemy"),
            //new PositiveAttribute("Disguises fool enemy buildings"),
            //new NegativeAttribute("Match move speed of slower disguise"),
            //new NeutralAttribute("Attacking removes your disguise"),
            //new NeutralAttribute("Cannot capture or taunt while disguised"),
            //new NeutralAttribute("Taking damage or bumping enemies may give you away"),
            //new DescriptionAttribute("\nAvoid suspicion by facing away from the enemy or running from your team's bullets to get behind the enemy"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Invis Watch"),new NeutralAttribute("1"),new NeutralAttribute("Invis Watch"),
            //new NeutralAttribute("Full Invisibility cloak and near-invisible to teammates"),
            //new PositiveAttribute("-20% damage resistance and shorter debuffs while cloaked"),
            //new NegativeAttribute("Cannot attack or capture while invisible"),
            //new NegativeAttribute("Cannot be healed by Medi Guns while invisible"),
            //new NeutralAttribute("Alt-Fire: Turn invisible for up to 10 seconds"),
            //new NeutralAttribute("Taking damage or bumping enemies will make you slightly visible"),
            //new DescriptionAttribute("Cloak recharges in 30 seconds<br/>Use dispensers and ammo to recharge faster<br/><br/>Invisibly slip behind enemy lines, running across ammo packs to extend your range"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Sapper"),new NeutralAttribute("1"),new NeutralAttribute("Sapper\n"),
            //new NeutralAttribute("100 sapper health"),
            //new PositiveAttribute("Does not require ammo"),
            //new PositiveAttribute("On Hit: Sap until destroyed"),
            //new PositiveAttribute("Sapper is immune to most damage"),
            //new NegativeAttribute("Only damages buildings"),
            //new NegativeAttribute("-33% damage from spy on sapped sentries"),
            //new DescriptionAttribute("Sap: 25 dps, disables building function<br/>Sap affects both ends of teleporters<br/><br/>Place on enemy buildings to disable and slowly drain away its health<br/>Placing a sapper does not remove your disguise"),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Spellbook Magazine"),new NeutralAttribute("1"),new NeutralAttribute("Spellbook"),
            //new DescriptionAttribute("A vintage edition of Casters Quarterly.<br>Found in the back of a closet, it contains just enough magic to get the job done.<br><br>Equip to enable picking up and casting spells."),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Grappling Hook"),new NeutralAttribute("1"),new NeutralAttribute("Grappling Hook"),
            //new DescriptionAttribute("Optionally can be switched to by pressing slot6<br>and manually fired using primary attack.<br><br>Can only be used in Mannpower Mode or when enabled by the server."),
            //}); 
            //Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("Power Up Canteen"),new NeutralAttribute("1-100"),new NeutralAttribute("Usable Item"),
            //new DescriptionAttribute("Applies a bonus effect for a limited amount of time when used. Must first be filled at an Upgrade Station and can only be filled with one bonus type at a time."),
            //}); 

//            Name = "Scattergun"; Level = 1; WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n60 damage (96 dps) 175%-53% by range\n10 pellet spread accurate to 36% range\nReloads 6 in 3.2 sec (first in 0.7 sec), 32 carried"),
//}); Name = "Pistol"; Level = 1; WeaponType = "Pistol"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n15 damage (100 dps) 147%-53% by range\nRecoil accurate to 61% range\nReloads 12 in 1.2 sec (clip), 36 carried"),
//}); Name = "Bat"; Level = 1; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n35 damage (70 dps)"),
//}); Name = "Rocket Launcher"; Level = 1; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n90 explosive damage (113 dps) 124%-53% by range\n Straight projectile accurate to 18%, explosion to 122% range\nReloads 4 in 3.3 sec (first in 0.9 sec), 20 carried"),
//}); Name = "Shotgun"; Level = 1; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n60 damage (96 dps) 150%-53% by range\n10 pellet spread accurate to 36% range\nReloads 6 in 3.5 sec (first in 1 sec), 32 carried"),
//}); Name = "Shovel"; Level = 1; WeaponType = "Shovel"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
//}); Name = "Flame Thrower"; Level = 1; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n7 fire damage (81 dps) 200%-0% by range\n Penetrating flames limited to 64% range\n 200 carried"),
//new PositiveAttribute("Extinguishing teammates restores 20 health"),
//new DescriptionAttribute("Afterburn reduces Medi Gun healing and resist shield effects.<br>Alt-Fire: Release a blast of air that pushes enemies and projectiles and extinguish teammates that are on fire."),
//}); Name = "Fire Axe"; Level = 1; WeaponType = "Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
//}); Name = "Grenade Launcher"; Level = 1; WeaponType = "Grenade Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n100 explosive damage (167 dps) \n Arced projectile accurate to 19%, explosion to 133% range\nReloads 4 in 3 sec (first in 1.2 sec), 16 carried"),
//}); Name = "Stickybomb Launcher"; Level = 1; WeaponType = "Stickybomb Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n120 explosive damage (200 dps) 120%-50% by range\n Arced projectile accurate to 14%, explosion to 100% range\nReloads 8 in 5.8 sec (first in 1.1 sec), 24 carried"),
//new DescriptionAttribute("Alt-Fire: Detonate all Stickybombs"),
//}); Name = "Bottle"; Level = 1; WeaponType = "Bottle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
//}); Name = "Minigun"; Level = 1; WeaponType = "Minigun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n36 damage (360 dps) 150%-53% by range\n4 pellet spread accurate to 30% range\n 200 carried"),
//}); Name = "Fists"; Level = 1; WeaponType = "Fists"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
//}); Name = "Wrench"; Level = 1; WeaponType = "Wrench"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
//new DescriptionAttribute("Upgrades, repairs and speeds up construction of friendly buildings on hit."),
//}); Name = "PDA"; Level = 1; WeaponType = "PDA"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//}); Name = "Syringe Gun"; Level = 1; WeaponType = "Syringe Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n10 damage (100 dps) 120%-50% by range\n Arced projectile accurate to 16% range\nReloads 40 in 1.6 sec (clip), 150 carried"),
//}); Name = "Medi Gun"; Level = 1; WeaponType = "Medi Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n3 healing (24 healing per second) \n Beam limited to 105% range"),
//}); Name = "Bonesaw"; Level = 1; WeaponType = "Bonesaw"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
//}); Name = "Sniper Rifle"; Level = 1; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n50 damage (33 dps) \n Accurate at any range\n 25 carried"),
//}); Name = "SMG"; Level = 1; WeaponType = "SMG"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n8 damage (80 dps) 150%-50% by range\nRecoil accurate to 98% range\nReloads 25 in 1.1 sec (clip), 75 carried"),
//}); Name = "Kukri"; Level = 1; WeaponType = "Kukri"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n65 damage (81 dps)"),
//}); Name = "Revolver"; Level = 1; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n40 damage (78 dps) 150%-53% by range\nRecoil accurate to 98% range\nReloads 6 in 1.2 sec (clip), 24 carried"),
//}); Name = "Knife"; Level = 1; WeaponType = "Knife"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n40 damage (50 dps)"),
//new DescriptionAttribute("Attack an enemy from behind to Backstab them for a one hit kill."),
//}); Name = "Disguise Kit"; Level = 1; WeaponType = "...Cigarette Case?"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//}); Name = "Invis Watch"; Level = 1; WeaponType = "Invis Watch"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new DescriptionAttribute("Alt-Fire: Turn invisible. Cannot attack while invisible. Bumping in to enemies will make you slightly visible to enemies"),
//}); Name = "Sapper"; Level = 1; WeaponType = "Sapper"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute("\n"),
//new DescriptionAttribute("Place on enemy buildings to disable and slowly drain away its health. Placing a sapper does not remove your disguise"),
//}); Name = "Spellbook Magazine"; Level = 1; WeaponType = "Spellbook"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("This weapon deploys 50% faster"),
//new DescriptionAttribute("A vintage edition of Casters Quarterly.<br>Found in the back of a closet, it contains just enough magic to get the job done.<br><br>Equip to enable picking up and casting spells."),
//}); Name = "Grappling Hook"; Level = 1; WeaponType = "Grappling Hook"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("This weapon holsters 80% faster"),
//new PositiveAttribute("This weapon deploys 100% faster"),
//new NeutralAttribute("Press and hold the Action key<br>to quickly fire a grapple line."),
//new DescriptionAttribute("Optionally can be switched to by pressing slot6<br>and manually fired using primary attack.<br><br>Can only be used in Mannpower Mode or when enabled by the server."),
//}); Name = "Power Up Canteen"; Level = 1 - 100; WeaponType = "Usable Item"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Holds a maximum of 3 charges"),
//new PositiveAttribute("Currently holds 0 charges"),
//new PositiveAttribute("Each charge lasts 5 seconds"),
//new DescriptionAttribute("Applies a bonus effect for a limited amount of time when used. Must first be filled at an Upgrade Station and can only be filled with one bonus type at a time."),
//});
//            Name = "Force-A-Nature"; Level = 10; WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+50% faster firing speed"),
//new PositiveAttribute("Knockback on the target and shooter"),
//new PositiveAttribute("+20% bullets per shot"),
//new NegativeAttribute("-10% damage penalty"),
//new NegativeAttribute("-66% clip size"),
//new DescriptionAttribute("This weapon reloads its entire clip at once"),
//}); Name = "Shortstop"; Level = 1; WeaponType = "Peppergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("When weapon is active:"),
//new NegativeAttribute("Increase in push force taken from damage and airblast"),
//new DescriptionAttribute("Holds a 4-shot clip and reloads its entire clip at once.<br> Alt-Fire to reach and shove someone! <br><br>Mann Co.'s latest in high attitude break-action personal defense."),
//}); Name = "Soda Popper"; Level = 10; WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+50% faster firing speed"),
//new PositiveAttribute("25% faster reload time"),
//new PositiveAttribute("On Hit: Builds Hype"),
//new NegativeAttribute("-66% clip size"),
//new DescriptionAttribute("When Hype is full, Alt-Fire to activate Hype mode for multiple air jumps.<br>This weapon reloads its entire clip at once."),
//}); Name = "Baby Face's Blaster"; Level = 10; WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit: Builds Boost"),
//new PositiveAttribute("Run speed increased with Boost"),
//new NegativeAttribute("-34% clip size"),
//new NegativeAttribute("10% slower move speed on wearer"),
//new NegativeAttribute("Boost reduced on air jumps"),
//new NegativeAttribute("Boost reduced when hit"),
//}); Name = "Back Scatter";/*Level*/WeaponType = "Scattergun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Mini-crits targets when fired at their back from close range"),
//new NegativeAttribute("-34% clip size"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("20% less accurate"),
//}); Name = "Winger"; Level = 15; WeaponType = "Pistol"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+15% damage bonus"),
//new PositiveAttribute("+25% greater jump height when active"),
//new NegativeAttribute("-60% clip size"),
//}); Name = "Pretty Boy's Pocket Pistol"; Level = 10; WeaponType = "Pistol"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("When weapon is active:"),
//new PositiveAttribute("+15% faster firing speed"),
//new PositiveAttribute("On Hit: Gain up to +3 health"),
//new NegativeAttribute("-25% clip size"),
//});
//            Name = "Flying Guillotine";/*Level*/WeaponType = "Cleaver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Throw at your enemies to make them bleed! Long distance hits reduce recharge time"),
//new NegativeAttribute("No random critical hits"),
//}); Name = "Bonk! Atomic Punch"; Level = 5; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new DescriptionAttribute("Drink to become invulnerable for 8 seconds. Cannot attack during this time.<br>Damage absorbed will slow you when the effect ends."),
//}); Name = "Crit-a-Cola"; Level = 5; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("While effect is active: each attack mini-crits and sets Mark-For-Death for 5 seconds."),
//}); Name = "Mad Milk"; Level = 5; WeaponType = "Non-Milk Substance"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Extinguishing teammates reduces cooldown by -20%"),
//new DescriptionAttribute("Players heal 60% of the damage done to an enemy covered with milk.<br>Can be used to extinguish fires."),
//}); 
//            Name = "Holy Mackerel"; Level = 42; WeaponType = "Fish"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new DescriptionAttribute("Getting hit by a fish has got to be humiliating."),
//}); Name = "Sandman"; Level = 15; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Alt-Fire: Launches a ball that slows opponents"),
//new NegativeAttribute("-15 max health on wearer"),
//}); Name = "Candy Cane"; Level = 25; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Kill: A small health pack is dropped"),
//new NegativeAttribute("25% explosive damage vulnerability on wearer"),
//}); Name = "Boston Basher"; Level = 25; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit: Bleed for 5 seconds"),
//new NegativeAttribute("On Miss: Hit yourself. Idiot."),
//}); Name = "Sun-on-a-Stick"; Level = 10; WeaponType = "RIFT Fire Mace"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("100% critical hit vs burning players"),
//new PositiveAttribute("+25% fire damage resistance while deployed"),
//new NegativeAttribute("-25% damage penalty"),
//new DescriptionAttribute("Spiky end goes into other man."),
//}); Name = "Fan O'War"; Level = 5; WeaponType = "Gunbai"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Crits whenever it would normally mini-crit"),
//new PositiveAttribute("On Hit: One target at a time is Marked-For-Death, causing all damage taken to be mini-crits"),
//new NegativeAttribute("-75% damage penalty"),
//new DescriptionAttribute("Winds of Gravel Pit<br />Scout brings on his deadly fan!<br />You are Marked-For-Death"),
//}); Name = "Atomizer"; Level = 10; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Grants Triple Jump while deployed"),
//new PositiveAttribute("Melee attacks mini-crit while airborne."),
//new NegativeAttribute("-15% damage vs players"),
//new NegativeAttribute("This weapon deploys 50% slower"),
//}); Name = "Wrap Assassin"; Level = 15; WeaponType = "Bat"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+25% increase in recharge rate"),
//new PositiveAttribute("Alt-Fire: Launches a festive ornament that shatters causing bleed"),
//new NegativeAttribute("-65% damage penalty"),
//new DescriptionAttribute("These lovely festive ornaments are so beautifully crafted, your enemies are going to want to see them close up. Indulge them by batting those fragile glass bulbs into their eyes at 90 mph."),
//});
//            Name = "Direct Hit"; Level = 1; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+25% damage bonus"),
//new PositiveAttribute("+80% projectile speed"),
//new PositiveAttribute("Mini-crits targets launched airborne by explosions, grapple hooks or rocket packs."),
//new NegativeAttribute("-70% explosion radius"),
//}); Name = "Black Box"; Level = 5; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit: Gain up to +20 health per attack"),
//new NegativeAttribute("-25% clip size"),
//}); Name = "Rocket Jumper"; Level = 1; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+200% max primary ammo on wearer"),
//new PositiveAttribute("No self inflicted blast damage taken"),
//new NegativeAttribute("-100% damage penalty"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("Wearer cannot carry the intelligence briefcase or PASS Time JACK"),
//new DescriptionAttribute("A special rocket launcher for learning <br> rocket jump tricks and patterns. <br> This weapon deals ZERO damage."),
//}); Name = "Liberty Launcher"; Level = 25; WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+25% clip size"),
//new PositiveAttribute("+40% projectile speed"),
//new PositiveAttribute("-25% blast damage from rocket jumps"),
//new NegativeAttribute("-25% damage penalty"),
//}); Name = "Cow Mangler 5000"; Level = 30; WeaponType = "Focused Wave Projector"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Does not require ammo"),
//new PositiveAttribute("Alt-Fire: A charged shot that<br>mini-crits players, sets them on fire<br>and disables buildings for 4 sec"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("Deals only 20% damage to buildings"),
//new NegativeAttribute("Minicrits whenever it would normally crit"),
//}); Name = "Beggar's Bazooka";/*Level*/WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Hold Fire to load up to three rockets"),
//new PositiveAttribute("Release Fire to unleash the barrage"),
//new NegativeAttribute("-20% explosion radius"),
//new NegativeAttribute("+3 degrees random projectile deviation"),
//new NegativeAttribute("Overloading the chamber will cause a misfire"),
//new NegativeAttribute("No ammo from dispensers when active"),
//}); Name = "Air Strike";/*Level*/WeaponType = "Rocket Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("-15% blast damage from rocket jumps"),
//new PositiveAttribute("Increased attack speed and smaller blast radius while blast jumping"),
//new PositiveAttribute("Clip size increased on kill"),
//new NegativeAttribute("-15% damage penalty"),
//new NegativeAttribute("-10% explosion radius"),
//});
//            Name = "Reserve Shooter"; Level = 10; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Mini-crits targets launched airborne by explosions, grapple hooks or rocket packs"),
//new PositiveAttribute("This weapon deploys 20% faster"),
//new NegativeAttribute("-34% clip size"),
//}); Name = "Buff Banner"; Level = 5; WeaponType = "Battle Banner"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new DescriptionAttribute("Provides an offensive buff that causes nearby team members to do mini-crits. Rage increases through damage done."),
//}); Name = "Gunboats"; Level = 10; WeaponType = "Boots"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("-60% blast damage from rocket jumps"),
//}); Name = "Battalion's Backup"; Level = 10; WeaponType = "Battle Banner"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+20 max health on wearer"),
//new DescriptionAttribute("Provides a defensive buff that protects nearby team members from crits, incoming sentry damage by 50% and 35% from all other sources.<br>Rage increases through damage done."),
//}); Name = "Concheror"; Level = 5; WeaponType = "Sashimono"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+4 health regenerated per second on wearer"),
//new DescriptionAttribute("Provides group speed buff<br>with damage done giving health.<br>Gain rage with damage."),
//}); Name = "Mantreads"; Level = 10; WeaponType = "Boots"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("-75% reduction in push force taken from damage"),
//new PositiveAttribute("Deals 3x falling damage to the player you land on"),
//new PositiveAttribute("-75% reduction in airblast vulnerability"),
//new PositiveAttribute("200% increased air control when blast jumping."),
//}); Name = "Righteous Bison"; Level = 30; WeaponType = "Indivisible Particle Smasher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Does not require ammo"),
//new PositiveAttribute("Projectile penetrates enemy targets"),
//new PositiveAttribute("Projectile cannot be deflected"),
//new NegativeAttribute("Deals only 20% damage to buildings"),
//}); Name = "B.A.S.E. Jumper";/*Level*/WeaponType = "Parachute"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new DescriptionAttribute("Press 'JUMP' key in the air to deploy.<br>Deployed Parachutes slow your descent."),
//}); Name = "Panic Attack"; Level = 1 - 99; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+50% bullets per shot"),
//new PositiveAttribute("This weapon deploys 50% faster"),
//new PositiveAttribute("Fires a fixed shot pattern"),
//new NegativeAttribute("-20% damage penalty"),
//new NegativeAttribute("Successive shots become less accurate"),
//}); 
//            Name = "Equalizer"; Level = 10; WeaponType = "Pickaxe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("When weapon is active:"),
//new PositiveAttribute("Damage increases as the user becomes injured"),
//new NegativeAttribute("-90% less healing from Medic sources"),
//}); Name = "Pain Train"; Level = 5; WeaponType = "Makeshift Club"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+1 capture rate on wearer"),
//new NegativeAttribute("10% bullet damage vulnerability on wearer"),
//}); Name = "Half-Zatoichi"; Level = 5; WeaponType = "Katana"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("This weapon has a large melee range and deploys and holsters slower"),
//new PositiveAttribute("Gain 50% of base health on kill"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("Honorbound: Once drawn sheathing deals 50 damage to yourself unless it kills."),
//new NeutralAttribute("Soldiers and Demos<br>Can duel with katanas<br>For a one-hit kill"),
//}); Name = "Disciplinary Action"; Level = 10; WeaponType = "Riding Crop"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit Teammate: Boosts both players' speed for several seconds"),
//new NegativeAttribute("-25% damage penalty"),
//}); Name = "Market Gardener"; Level = 10; WeaponType = "Shovel"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Deals crits while the wielder is rocket jumping"),
//new NegativeAttribute("20% slower firing speed"),
//new NegativeAttribute("No random critical hits"),
//}); Name = "Escape Plan"; Level = 10; WeaponType = "Pickaxe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("When weapon is active:"),
//new PositiveAttribute("Move speed increases as the user becomes injured"),
//new NegativeAttribute("You are marked for death while active, and for short period after switching weapons"),
//new NegativeAttribute("-90% less healing from Medic sources"),
//}); 
//            Name = "Rainblower"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Equip: Visit Pyroland"),
//new PositiveAttribute("Extinguishing teammates restores 20 health"),
//new NegativeAttribute("Only visible in Pyroland"),
//new DescriptionAttribute("Your friends (enemies) will squeal with delight (be consumed with fire) when you cover them in sparkly rainbows (all-consuming fire). (Equips Pyrovision.)"),
//}); Name = "Nostromo Napalmer"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Extinguishing teammates restores 20 health"),
//}); Name = "Backburner"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("100% critical hits from behind"),
//new PositiveAttribute("Extinguishing teammates restores 20 health"),
//new NegativeAttribute("+150% airblast cost"),
//}); Name = "Degreaser"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("This weapon deploys 60% faster"),
//new PositiveAttribute("This weapon holsters 30% faster"),
//new PositiveAttribute("Extinguishing teammates restores 20 health"),
//new NegativeAttribute("-66% afterburn damage penalty"),
//new NegativeAttribute("+25% airblast cost"),
//}); Name = "Phlogistinator"; Level = 10; WeaponType = "Flame Thrower"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Build 'Mmmph' by dealing damage."),
//new PositiveAttribute("Alt-Fire on full 'Mmmph': Taunt to gain crit for several seconds."),
//new PositiveAttribute("Invulnerable while 'Mmmph' taunting."),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("No airblast"),
//new DescriptionAttribute("Being a revolutionary appliance capable of awakening the fire element phlogiston that exists in all combustible creatures, which is to say, all of them."),
//}); Name = "Dragon's Fury"; Level = 1 - 100; WeaponType = "Flame Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("Uses a shared pressure tank for Primary Fire and Alt-Fire.<br/><br/>Primary Fire: Launches a fast moving projectile that briefly ignites enemies<br/><br/>Alt-Fire: Release a blast of air that pushes enemies and projectiles, and extinguishes teammates that are on fire."),
//new PositiveAttribute("Extinguishing teammates restores 20 health"),
//new PositiveAttribute("Deals 300% damage to burning players"),
//new PositiveAttribute("+50% repressurization rate on hit"),
//new NegativeAttribute("-50% repressurization rate on Alt-Fire"),
//new DescriptionAttribute("This powerful, single-shot flamethrower rewards consecutive hits with faster reloads and bonus damage."),
//});
//            Name = "Flare Gun"; Level = 10; WeaponType = "Flare Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("100% critical hit vs burning players"),
//new DescriptionAttribute("This weapon will reload when not active"),
//}); Name = "Detonator"; Level = 10; WeaponType = "Flare Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("100% mini-crits vs burning players"),
//new NegativeAttribute("-25% damage penalty"),
//new NegativeAttribute("+50% damage to self"),
//new DescriptionAttribute("Alt-Fire: Detonate flare.<br>This weapon will reload automatically when not active."),
//}); Name = "Manmelter"; Level = 30; WeaponType = "Indivisible Particle Smasher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+50% projectile speed"),
//new PositiveAttribute("Does not require ammo"),
//new PositiveAttribute("Alt-Fire: Extinguish teammates to gain guaranteed critical hits"),
//new PositiveAttribute("Extinguishing teammates restores 20 health"),
//new NegativeAttribute("No random critical hits"),
//new DescriptionAttribute("This weapon will reload automatically when not active.<br><br>Being a device that flouts conventional scientific consensus that the molecules composing the human body must be arranged \"just so\", and not, for example, across a square-mile radius."),
//}); Name = "Scorch Shot"; Level = 10; WeaponType = "Flare Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("100% mini-crits vs burning players"),
//new PositiveAttribute("Flare knocks back target on hit and explodes when it hits the ground."),
//new PositiveAttribute("Increased knockback on burning players"),
//new NegativeAttribute("-35% self damage force"),
//new NegativeAttribute("-35% damage penalty"),
//new DescriptionAttribute("This weapon will reload automatically when not active."),
//}); Name = "Thermal Thruster"; Level = 1 - 100; WeaponType = "Rocket Pack"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Push enemies back when you land (force and radius based on velocity)"),
//new DescriptionAttribute("Death from above! Fires a short-duration blast that launches the Pyro in the direction they are aiming. Deal 3x falling damage to anyone you land on!"),
//}); Name = "Gas Passer"; Level = 1 - 100; WeaponType = "Gas-Like Substance"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Gas meter builds with damage done and/or time"),
//new NegativeAttribute("Spawning and resupply do not affect the Gas meter"),
//new NegativeAttribute("Gas meter starts empty"),
//new DescriptionAttribute("Creates a horrific visible gas that coats enemies with a flammable material, which then ignites into afterburn if they take damage (even enemy Pyros!)"),
//});
//            Name = "Lollichop"; Level = 1 - 100; WeaponType = "Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Equip: Visit Pyroland"),
//new NegativeAttribute("Only visible in Pyroland"),
//new DescriptionAttribute("Fill (split) your buddies' tummies (skulls) with delicious candy (cold steel) with this oversized sugary treat. (Equips Pyrovision.)"),
//}); Name = "Axtinguisher"; Level = 10; WeaponType = "Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Mini-crits burning targets and extinguishes them."),
//new PositiveAttribute("Damage increases based on remaining duration of afterburn"),
//new PositiveAttribute("Killing blows on burning players grant a speed boost."),
//new NegativeAttribute("-33% damage penalty"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("This weapon holsters 35% slower"),
//}); Name = "Homewrecker"; Level = 5; WeaponType = "Sledgehammer"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+100% damage vs buildings"),
//new PositiveAttribute("Damage removes Sappers"),
//new NegativeAttribute("-25% damage vs players"),
//}); Name = "Powerjack"; Level = 5; WeaponType = "Sledgehammer"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("When weapon is active:"),
//new PositiveAttribute("+15% faster move speed on wearer"),
//new PositiveAttribute("+25 health restored on kill"),
//new NegativeAttribute("20% damage vulnerability on wearer"),
//}); Name = "Back Scratcher"; Level = 10; WeaponType = "Garden Rake"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+25% damage bonus"),
//new PositiveAttribute("+50% health from packs on wearer"),
//new NegativeAttribute("-75% health from healers on wearer"),
//}); Name = "Sharpened Volcano Fragment"; Level = 10; WeaponType = "RIFT Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit: target is engulfed in flames"),
//new NegativeAttribute("-20% damage penalty"),
//new DescriptionAttribute("Improves upon Mother Nature's original design for volcanos by increasing portability. Modern science is unable to explain exactly where the lava is coming from."),
//}); Name = "Third Degree"; Level = 10; WeaponType = "Fire Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("All players connected via Medigun beams are hit"),
//new DescriptionAttribute("Being a boon to tree-fellers, backwoodsmen and atom-splitters the world over, this miraculous matter-hewing device burns each individual molecule as it cleaves it."),
//}); Name = "Neon Annihilator"; Level = 1 - 100; WeaponType = "Sign"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Damage removes Sappers"),
//new PositiveAttribute("100% critical hit vs wet players"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("-20% damage penalty vs players"),
//}); Name = "Hot Hand";/*Level*/WeaponType = "Slap"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Gain a speed boost when you hit an enemy player"),
//new NegativeAttribute("-20% damage penalty"),
//new DescriptionAttribute("This melee slap tells your opponent, and anyone watching the kill feed, that your hand just gave some lucky face the gift of slapping it stupid."),
//});
//            Name = "Loch-n-Load"; Level = 10; WeaponType = "Grenade Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+20% damage vs buildings"),
//new PositiveAttribute("+25% projectile speed"),
//new NegativeAttribute("-25% clip size"),
//new NegativeAttribute("-25% explosion radius"),
//new NegativeAttribute("Launched bombs shatter on surfaces"),
//}); Name = "Ali Baba's Wee Booties"; Level = 10; WeaponType = "Boots"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+25 max health on wearer"),
//new PositiveAttribute("+200% increase in turning control while charging"),
//new PositiveAttribute("+10% faster move speed on wearer (shield required)"),
//new PositiveAttribute("Melee kills refill 25% of your charge meter."),
//}); Name = "Loose Cannon"; Level = 10; WeaponType = "Grenade Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("Cannonballs have a fuse time of 1 second; fuses can be primed to explode earlier by holding down the fire key."),
//new PositiveAttribute("+20% projectile speed"),
//new PositiveAttribute("Cannonballs push players back on impact"),
//new NegativeAttribute("Cannonballs do not explode on impact"),
//new DescriptionAttribute("Double Donk! Bomb explosions after a cannon ball impact will deal mini-crits to impact victims"),
//}); Name = "Iron Bomber"; Level = 1 - 99; WeaponType = "Grenade Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Grenades have very little bounce and roll"),
//new PositiveAttribute("-30% fuse time on grenades"),
//new NegativeAttribute("-15% explosion radius"),
//}); 
//            Name = "Scottish Resistance"; Level = 5; WeaponType = "Stickybomb Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+25% faster firing speed"),
//new PositiveAttribute("+50% max secondary ammo on wearer"),
//new PositiveAttribute("+6 max pipebombs out"),
//new PositiveAttribute("Detonates stickybombs near the crosshair and directly under your feet"),
//new PositiveAttribute("Able to destroy enemy stickybombs"),
//new NegativeAttribute("0.8 sec slower bomb arm time"),
//}); Name = "Chargin' Targe"; Level = 1 - 99; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+50% fire damage resistance on wearer"),
//new PositiveAttribute("+30% explosive damage resistance on wearer"),
//new DescriptionAttribute("Alt-Fire: Charge toward your enemies and remove debuffs. Gain a critical melee strike after impacting an enemy at distance."),
//}); Name = "Sticky Jumper"; Level = 1; WeaponType = "Stickybomb Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+200% max secondary ammo on wearer"),
//new PositiveAttribute("No self inflicted blast damage taken"),
//new NegativeAttribute("-100% damage penalty"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("-6 max stickybombs out"),
//new NegativeAttribute("Wearer cannot carry the intelligence briefcase or PASS Time JACK"),
//new DescriptionAttribute("A special no-damage stickybomb launcher for learning stickybomb jump tricks and patterns."),
//}); Name = "Splendid Screen"; Level = 10; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+20% fire damage resistance on wearer"),
//new PositiveAttribute("+20% explosive damage resistance on wearer"),
//new PositiveAttribute("+70% increase in charge impact damage"),
//new PositiveAttribute("+50% increase in charge recharge rate"),
//new DescriptionAttribute("Alt-Fire: Charge toward your enemies and remove debuffs. Gain a critical melee strike after impacting an enemy."),
//}); Name = "Tide Turner"; Level = 1 - 100; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+15% fire damage resistance on wearer"),
//new PositiveAttribute("+15% explosive damage resistance on wearer"),
//new PositiveAttribute("Full turning control while charging"),
//new PositiveAttribute("Melee kills refill 75% of your charge meter."),
//new NegativeAttribute("Taking damage while shield charging reduces remaining charging time"),
//new DescriptionAttribute("Alt-Fire: Charge toward your enemies and remove debuffs. Gain a mini-crit melee strike after impacting an enemy at distance."),
//}); Name = "Quickiebomb Launcher"; Level = 1 - 99; WeaponType = "Stickybomb Launcher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Able to destroy enemy stickybombs"),
//new PositiveAttribute("-0.2 sec faster bomb arm time"),
//new PositiveAttribute("Max charge time decreased by 70%"),
//new PositiveAttribute("Up to +35% damage based on charge"),
//new NegativeAttribute("-15% damage penalty"),
//new NegativeAttribute("-50% clip size"),
//}); 
//            Name = "Eyelander"; Level = 5; WeaponType = "Sword"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("This weapon has a large melee range and deploys and holsters slower"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("-25 max health on wearer"),
//new DescriptionAttribute("Gives increased speed and health with every head you take."),
//}); Name = "Scotsman's Skullcutter"; Level = 5; WeaponType = "Axe"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("This weapon has a large melee range and deploys and holsters slower"),
//new NeutralAttribute("When weapon is active:"),
//new PositiveAttribute("+20% damage bonus"),
//new NegativeAttribute("15% slower move speed on wearer"),
//}); Name = "Ullapool Caber"; Level = 10; WeaponType = "Stick Bomb"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NegativeAttribute("20% slower firing speed"),
//new NegativeAttribute("This weapon deploys 100% slower"),
//new NegativeAttribute("No random critical hits"),
//new DescriptionAttribute("High-yield Scottish face removal.<br/>A sober person would throw it...<br><br>The first hit will cause an explosion"),
//}); Name = "Claidheamh Mòr"; Level = 5; WeaponType = "Sword"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("When weapon is active:"),
//new NeutralAttribute("This Weapon has a large melee range and deploys and holsters slower"),
//new PositiveAttribute("0.5 sec increase in charge duration"),
//new PositiveAttribute("Melee kills refill 25% of your charge meter."),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("15% damage vulnerability on wearer"),
//}); Name = "Persian Persuader"; Level = 10; WeaponType = "Sword"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("This weapon has a large melee range and deploys and holsters slower"),
//new PositiveAttribute("Ammo boxes collected give Charge"),
//new PositiveAttribute("Melee hits refill 20% of your charge meter."),
//new NegativeAttribute("-80% max primary ammo on wearer"),
//new NegativeAttribute("-80% max secondary ammo on wearer"),
//new NegativeAttribute("No random critical hits"),
//}); 
//            Name = "Natascha"; Level = 5; WeaponType = "Minigun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit: 100% chance to slow target"),
//new PositiveAttribute("-20% damage resistance when below 50% health and spun up"),
//new NegativeAttribute("-25% damage penalty"),
//new NegativeAttribute("30% slower spin up time"),
//}); Name = "Brass Beast"; Level = 5; WeaponType = "Minigun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+20% damage bonus"),
//new PositiveAttribute("-20% damage resistance when below 50% health and spun up"),
//new NegativeAttribute("50% slower spin up time"),
//new NegativeAttribute("-60% slower move speed while deployed"),
//}); Name = "Tomislav"; Level = 5; WeaponType = "Minigun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+20% faster spin up time"),
//new PositiveAttribute("20% more accurate"),
//new PositiveAttribute("Silent Killer: No barrel spin sound"),
//new NegativeAttribute("-20% slower firing speed"),
//}); Name = "Huo-Long Heater"; Level = 1 - 100; WeaponType = "Minigun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Creates a ring of flames while spun up"),
//new PositiveAttribute("25% damage bonus vs burning players"),
//new NegativeAttribute("-10% damage penalty"),
//new NegativeAttribute("Consumes an additional 4 ammo per second while spun up"),
//});
//            Name = "Family Business"; Level = 10; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+33% clip size"),
//new PositiveAttribute("+15% faster firing speed"),
//new NegativeAttribute("-15% damage penalty"),
//}); Name = "Sandvich"; Level = 1; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new DescriptionAttribute("Eat to regain up to 300 health.<br>Alt-fire: Share a Sandvich with a friend (Medium Health Kit)"),
//}); Name = "Dalokohs Bar"; Level = 1; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Adds +50 max health for 30 seconds"),
//new DescriptionAttribute("Eat to gain up to 100 health.<br>Alt-fire: Share chocolate with a friend (Small Health Kit)"),
//}); Name = "Buffalo Steak Sandvich"; Level = 1; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new DescriptionAttribute("After consuming, move speed is increased, attacks mini-crit, and the player may only use melee weapons. Lasts 16 seconds.<br>Alt-fire: Share with a friend (Medium Health Kit)<br><br>Who needs bread?"),
//}); Name = "Second Banana"; Level = 1; WeaponType = "Lunch Box"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+50% increase in charge recharge rate"),
//new NegativeAttribute("-33% healing effect"),
//new DescriptionAttribute("Eat to gain health<br />Alt-fire: Share banana with a friend (Small Health Kit)"),
//}); 
//            Name = "Apoco-Fists"; Level = 10; WeaponType = "Fists"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Killing an enemy with a critical hit will dismember your victim. Painfully."),
//new DescriptionAttribute("Turn every one of your fingers into the Four Horsemen of the Apocalypse! That's over nineteen Horsemen of the Apocalypse per glove! The most Apocalypse we've ever dared attach to one hand!"),
//}); Name = "Killing Gloves of Boxing"; Level = 7; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Kill: 5 seconds of 100% critical chance"),
//new NegativeAttribute("-20% slower firing speed"),
//}); Name = "Gloves of Running Urgently"; Level = 10; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+30% faster move speed on wearer"),
//new NegativeAttribute("This weapon holsters 50% slower"),
//new NegativeAttribute("Maximum health is drained while item is active"),
//}); Name = "Warrior's Spirit"; Level = 10; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("When weapon is active:"),
//new PositiveAttribute("+30% damage bonus"),
//new PositiveAttribute("+50 health restored on kill"),
//new NegativeAttribute("30% damage vulnerability on wearer"),
//}); Name = "Fists of Steel"; Level = 10; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("-40% damage from ranged sources while active"),
//new NegativeAttribute("+100% damage from melee sources while active"),
//new NegativeAttribute("This weapon holsters 100% slower"),
//new NegativeAttribute("-40% maximum overheal on wearer"),
//new NegativeAttribute("-40% health from healers on wearer"),
//}); Name = "Eviction Notice"; Level = 10; WeaponType = "Boxing Gloves"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+40% faster firing speed"),
//new PositiveAttribute("On Hit: Gain a speed boost"),
//new PositiveAttribute("+15% faster move speed on wearer"),
//new NegativeAttribute("-60% damage penalty"),
//new NegativeAttribute("Maximum health is drained while item is active"),
//}); Name = "Holiday Punch"; Level = 10; WeaponType = "Fists"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Critical hit forces victim to laugh"),
//new PositiveAttribute("Always critical hit from behind"),
//new PositiveAttribute("On Hit: Force enemies to laugh who are also wearing this item"),
//new NegativeAttribute("Critical hits do no damage"),
//new DescriptionAttribute("Be the life of the war party with these laugh-inducing punch-mittens."),
//});
//            Name = "Frontier Justice"; Level = 5; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Gain 2 revenge crits for each sentry kill and 1 for each sentry assist when your sentry is destroyed."),
//new NegativeAttribute("-50% clip size"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("Revenge crits are lost on death"),
//}); Name = "Widowmaker"; Level = 5; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On hit: damage dealt is returned as ammo"),
//new PositiveAttribute("No reload necessary"),
//new PositiveAttribute("10% increased damage to your sentry's target"),
//new NegativeAttribute("Per Shot: -30 ammo"),
//new NegativeAttribute("Uses metal for ammo"),
//}); Name = "Pomson 6000"; Level = 10; WeaponType = "Indivisible Particle Smasher"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Does not require ammo"),
//new PositiveAttribute("Projectile cannot be deflected"),
//new PositiveAttribute("On Hit: Victim loses up to 10% Medigun charge"),
//new PositiveAttribute("On Hit: Victim loses up to 20% cloak"),
//new NegativeAttribute("Deals only 20% damage to buildings"),
//new DescriptionAttribute("Being an innovative hand-held irradiating utensil capable of producing rapid pulses of high-amplitude radiation in sufficient quantity as to immolate, maim and otherwise incapacitate the Irish."),
//}); Name = "Rescue Ranger"; Level = 1 - 100; WeaponType = "Shotgun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Alt-Fire: Use 100 metal to pick up your targeted building from long range"),
//new PositiveAttribute("Fires a special bolt that can repair friendly buildings"),
//new NegativeAttribute("-34% clip size"),
//new NegativeAttribute("-50% max primary ammo on wearer"),
//new NegativeAttribute("Self mark for death when hauling buildings"),
//new NegativeAttribute("4-to-1 health-to-metal ratio when repairing buildings"),
//}); Name = "Wrangler"; Level = 5; WeaponType = "Laser Pointer"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new DescriptionAttribute("Take manual control of your Sentry Gun.<br>Wrangled sentries gain a shield that reduces damage and repairs by 66%.<br>Sentries are disabled for 3 seconds after becoming unwrangled."),
//}); Name = "Short Circuit"; Level = 5; WeaponType = "Robot Arm"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Alt-Fire: Launches a projectile-consuming energy ball. Costs 65 metal."),
//new PositiveAttribute("No reload necessary"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("Per Shot: -5 ammo"),
//new NegativeAttribute("Uses metal for ammo"),
//}); 
//            Name = "Gunslinger"; Level = 15; WeaponType = "Robot Arm"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+25 max health on wearer"),
//new PositiveAttribute("Sentry build speed increased by 150%"),
//new PositiveAttribute("Third successful punch in a row always crits."),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("Replaces the Sentry with a Mini-Sentry"),
//}); Name = "Southern Hospitality"; Level = 20; WeaponType = "Wrench"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit: Bleed for 5 seconds"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("20% fire damage vulnerability on wearer"),
//}); Name = "Eureka Effect"; Level = 20; WeaponType = "Wrench"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Press your reload key to choose to teleport to spawn or your exit teleporter"),
//new PositiveAttribute("-50% metal cost when constructing or upgrading teleporters"),
//new NegativeAttribute("Construction hit speed boost decreased by 50%"),
//new NegativeAttribute("20% less metal from pickups and dispensers"),
//new DescriptionAttribute("Being a tool that eliminates exertion by harnessing the electrical discharges of thunder-storms for the vigorous coercion of bolts, nuts, pipes and similar into their rightful places. May also be used to bludgeon."),
//});
//            Name = "Blutsauger"; Level = 5; WeaponType = "Syringe Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit: Gain up to +3 health"),
//new NegativeAttribute("-2 health drained per second on wearer"),
//}); Name = "Crusader's Crossbow"; Level = 15; WeaponType = "Crossbow"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NegativeAttribute("No headshots"),
//new NegativeAttribute("-75% max primary ammo on wearer"),
//new DescriptionAttribute("Fires special bolts that heal teammates and deals damage<br>based on distance traveled<br>This weapon will reload automatically when not active"),
//}); Name = "Overdose"; Level = 5; WeaponType = "Syringe Gun Prototype"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NegativeAttribute("-15% damage penalty"),
//new DescriptionAttribute("While active, movement speed increases based on ÜberCharge percentage to a maximum of +20%"),
//});
//            Name = "Kritzkrieg"; Level = 8; WeaponType = "Medi Gun"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("ÜberCharge grants 100% critical chance"),
//new PositiveAttribute("+25% ÜberCharge rate"),
//}); Name = "Quick-Fix"; Level = 8; WeaponType = "Medi Gun Prototype"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("ÜberCharge increases healing to 300% and grants immunity to movement-impairing effects"),
//new PositiveAttribute("+40% heal rate"),
//new PositiveAttribute("+10% ÜberCharge rate"),
//new NegativeAttribute("50% max overheal"),
//new DescriptionAttribute("Mirror the blast jumps and shield charges of patients."),
//}); Name = "Vaccinator"; Level = 8; WeaponType = "Vaccinator"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+67% Übercharge rate"),
//new PositiveAttribute("Press your reload key to cycle through resist types."),
//new PositiveAttribute("While healing, provides you and your target with a constant 10% resistance to the selected damage type."),
//new NegativeAttribute("-33% ÜberCharge rate on Overhealed patients"),
//new NegativeAttribute("-66% Overheal build rate."),
//new DescriptionAttribute("Übercharge provides a 2.5 second resistance bubble that blocks 75% base damage and 100% crit damage of the selected type to the Medic and Patient."),
//}); 
//            Name = "Ubersaw"; Level = 10; WeaponType = "Bonesaw"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit: 25% ÜberCharge added"),
//new NegativeAttribute("20% slower firing speed"),
//}); Name = "Vita-Saw"; Level = 5; WeaponType = "Bonesaw"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Collect the organs of people you hit"),
//new NegativeAttribute("-10 max health on wearer"),
//new DescriptionAttribute("A percentage of your ÜberCharge level is retained on death, based on the number of organs harvested (15% per). Total ÜberCharge retained on spawn caps at 60%."),
//}); Name = "Amputator"; Level = 15; WeaponType = "Bonesaw"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("When weapon is active:"),
//new PositiveAttribute("+3 health regenerated per second on wearer"),
//new PositiveAttribute("Alt-Fire: Applies a healing effect to all nearby teammates"),
//new NegativeAttribute("-20% damage penalty"),
//}); Name = "Solemn Vow"; Level = 10; WeaponType = "Bust of Hippocrates"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Allows you to see enemy health"),
//new NegativeAttribute("10% slower firing speed"),
//new DescriptionAttribute("'Do no harm.'"),
//}); 
//            Name = "Huntsman"; Level = 10; WeaponType = "Bow"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//}); Name = "Sydney Sleeper"; Level = 1; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+25% charge rate"),
//new PositiveAttribute("On Scoped Hit: Apply Jarate for 2 to 5 seconds based on charge level."),
//new PositiveAttribute("Nature's Call: Scoped headshots always mini-crit and reduce the remaining cooldown of Jarate by 1 second."),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("No headshots"),
//}); Name = "Bazaar Bargain"; Level = 10; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NegativeAttribute("Base charge rate decreased by 50%"),
//new DescriptionAttribute("Each scoped headshot kill increases the weapon's charge rate by 25% up to 200%."),
//}); Name = "Machina"; Level = 5; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Full Charge: +15% damage per shot"),
//new PositiveAttribute("On Full Charge: Projectiles penetrate players"),
//new NegativeAttribute("Cannot fire unless zoomed"),
//new NegativeAttribute("Fires tracer rounds"),
//}); Name = "Hitman's Heatmaker"; Level = 1; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Gain Focus on kills and assists"),
//new PositiveAttribute("Press 'Reload' to activate focus"),
//new PositiveAttribute("In Focus: +25% faster charge and no unscoping"),
//new NegativeAttribute("-20% damage on body shot"),
//new DescriptionAttribute("Heads will roll."),
//}); Name = "Classic"; Level = 1 - 100; WeaponType = "Sniper Rifle"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Charge and fire shots independent of zoom"),
//new NegativeAttribute("No headshots when not fully charged"),
//new NegativeAttribute("-10% damage on body shot"),
//});
//            Name = "Cleaner's Carbine"; Level = 1; WeaponType = "SMG"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Dealing damage fills charge meter."),
//new PositiveAttribute("Secondary fire when charged grants mini-crits for 8 seconds."),
//new NegativeAttribute("-20% clip size"),
//new NegativeAttribute("-25% slower firing speed"),
//new NegativeAttribute("No random critical hits"),
//}); Name = "Jarate"; Level = 5; WeaponType = "Jar Based Karate"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("Coated enemies take mini-crits"),
//new NeutralAttribute("Can be used to extinguish fires."),
//new PositiveAttribute("Extinguishing teammates reduces cooldown by -20%"),
//}); Name = "Razorback"; Level = 10; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Blocks a single backstab attempt"),
//new NegativeAttribute("-100% maximum overheal on wearer"),
//}); Name = "Darwin's Danger Shield"; Level = 10; WeaponType = "Shield"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+50% fire damage resistance on wearer"),
//new PositiveAttribute("Immune to the effects of afterburn."),
//}); Name = "Cozy Camper"; Level = 10; WeaponType = "Backpack"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+4 health regenerated per second on wearer"),
//new PositiveAttribute("No flinching when aiming and fully charged"),
//new PositiveAttribute("Knockback reduced by 20% when aiming"),
//});
//            Name = "Tribalman's Shiv"; Level = 5; WeaponType = "Kukri"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit: Bleed for 6 seconds"),
//new NegativeAttribute("-50% damage penalty"),
//}); Name = "Bushwacka"; Level = 5; WeaponType = "Kukri"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("When weapon is active:"),
//new PositiveAttribute("Crits whenever it would normally mini-crit"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("20% damage vulnerability on wearer"),
//}); Name = "Shahanshah"; Level = 5; WeaponType = "Kukri"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+25% increase in damage when health <50% of max"),
//new NegativeAttribute("-25% decrease in damage when health >50% of max"),
//});
//            Name = "Ambassador"; Level = 5; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Crits on headshot"),
//new NegativeAttribute("-15% damage penalty"),
//new NegativeAttribute("20% slower firing speed"),
//new NegativeAttribute("No random critical hits"),
//new NegativeAttribute("Critical damage is affected by range"),
//}); Name = "L'Etranger"; Level = 5; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+40% cloak duration"),
//new PositiveAttribute("+15 cloak on hit"),
//new NegativeAttribute("-20% damage penalty"),
//}); Name = "Enforcer"; Level = 5; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+20% damage bonus while disguised"),
//new PositiveAttribute("Attacks pierce damage resistance effects and bonuses"),
//new NegativeAttribute("20% slower firing speed"),
//new NegativeAttribute("No random critical hits"),
//}); Name = "Diamondback"; Level = 5; WeaponType = "Revolver"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Gives one guaranteed critical hit for each building destroyed with your sapper attached or backstab kill"),
//new NegativeAttribute("-15% damage penalty"),
//new NegativeAttribute("No random critical hits"),
//}); 
//            Name = "Your Eternal Reward"; Level = 1; WeaponType = "Knife"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Upon a successful backstab against a human target, you rapidly disguise as your victim"),
//new PositiveAttribute("Silent Killer: No attack noise from backstabs"),
//new NegativeAttribute("+33% cloak drain rate"),
//new NegativeAttribute("Normal disguises require (and consume) a full cloak meter"),
//}); Name = "Conniver's Kunai"; Level = 1; WeaponType = "Kunai"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Backstab: Absorbs the health from your victim"),
//new NegativeAttribute("-55 max health on wearer"),
//new DescriptionAttribute("Start off with low health<br />Kill somebody with this knife<br />Steal all of their health"),
//}); Name = "Big Earner"; Level = 1; WeaponType = "Knife"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("+30% cloak on kill"),
//new PositiveAttribute("Gain a speed boost on kill"),
//new NegativeAttribute("-25 max health on wearer"),
//}); Name = "Spy-cicle"; Level = 1; WeaponType = "Knife"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("On Hit by Fire: Fireproof for 1 second and Afterburn immunity for 10 seconds"),
//new NegativeAttribute("Backstab turns victim to ice"),
//new NegativeAttribute("Melts in fire, regenerates in 15 seconds and by picking up ammo"),
//new DescriptionAttribute("It's the perfect gift for the man who has everything: an icicle driven into their back. Even rich people can't buy that in stores."),
//});
//            Name = "Cloak and Dagger"; Level = 5; WeaponType = "Invis Watch"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("Cloak Type: Motion Sensitive"),
//new NeutralAttribute("Alt-Fire: Turn invisible. Cannot attack while invisible. Bumping in to enemies will make you slightly visible to enemies."),
//new NeutralAttribute("Cloak drain rate based on movement speed"),
//new PositiveAttribute("+100% cloak regen rate"),
//new NegativeAttribute("No cloak meter from ammo boxes when invisible"),
//new NegativeAttribute("-35% cloak meter from ammo boxes"),
//}); Name = "Dead Ringer"; Level = 5; WeaponType = "Invis Watch"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new NeutralAttribute("Cloak Type: Feign Death"),
//new NeutralAttribute("Leave a fake corpse on taking damage<br>and temporarily gain invisibility, speed and damage resistance"),
//new PositiveAttribute("+50% cloak regen rate"),
//new PositiveAttribute("+40% cloak duration"),
//new NegativeAttribute("-50% cloak meter when Feign Death is activated"),
//}); Name = "Red-Tape Recorder"; Level = 1 - 100; WeaponType = "Sapper"; Attributes.AddRange(new WeaponAttribute[] { new NeutralAttribute(""),
//new PositiveAttribute("Reverses enemy building construction"),
//new NegativeAttribute("-100% Sapper damage penalty"),
//});
        }

        public bool UseSimpleOverrides = true;

        public string Name { get; protected set; }
        /// <summary>
        /// ID of the entry in the "items" collection in items_game.txt
        /// </summary>
        public string ItemsID { get; internal set; }
        /// <summary>
        /// Optional notes to explain known differences and issues.
        /// </summary>
        public string Notes { get; protected set; } = "";
        public List<Weapon> AlternateModes { get; protected set; } = new List<Weapon>();

        public decimal FireRate { get; protected set; }
        /// <summary>
        /// most post-click time before damage.
        /// Melee delay, Grenade Fuse, sticky post-trigger time; "zoom charge delay"; huntsman accurate draw time "aim fatigue"; minigun rev "windup time"; banner "taunt duration"
        /// (see Projectile for ArmTime ... but zoom headshot delay is elsewhere)
        /// </summary>
        public decimal ActivationTime { get; protected set; } = 0; // rev up, scope
        /// <summary>
        /// Time required to go from 0% to 100% charge (after any pre-charge activation time)
        /// </summary>
        public decimal ChargeTime { get; protected set; } = 0;

        // Switch times holster/draw

        public Effect Effect
        {
            get => Effects.FirstOrDefault();
            protected set => Effects.Insert(0, value);
        }
        public List<Effect> Effects { get; } = new List<Effect>();

        public AOE AreaOfEffect { get; protected set; } // banner, medic target heal & target maintain
        public Melee Melee { get; protected set; } // melee; medic target hit & activate AOE (but does connect use hitbox or hitscan?)
        public Hitscan Hitscan { get; protected set; }
        public Projectile Projectile { get; protected set; }
        //public decimal Accuracy { get; }
        // public decimal MaxRange {get;} // projectile max lifetimeVsSpeed, AOE, melee,

        public Ammo Ammo { get; protected set; }

        public int Level { get; protected set; }
        public string WeaponType { get; protected set; }
        public List<WeaponAttribute> Attributes { get; } = new List<WeaponAttribute>();
        //https://wiki.teamfortress.com/wiki/Critical_hits#Special_cases
        public bool CanCrit { get; internal set; } = true;
        // for A few things like heal bolts or things that upgrade it to crits
        public bool CanMinicrit { get; internal set; } = true;
    }

    public class Damage
    {
        public const decimal WIKI_LONG_RANGE_RAMP = 0.528m;
        public const decimal NORMAL_LONG_RANGE_RAMP 
            //= .5;
            = WIKI_LONG_RANGE_RAMP;

        public const decimal NORMAL_HITSCAN_ZERO_RANGE_RAMP = 1.5m;
        //TODO new custom value to get get observed values needs discussion (alternatively 1.5 with an offset).
        public const decimal PISTOL_HITSCAN_ZERO_RANGE_RAMP = 1.49m;//NORMAL_HITSCAN_ZERO_RANGE_RAMP;
        public const decimal SCATTERGUN_HITSCAN_ZERO_RANGE_RAMP = 1.75m;
        public const decimal NORMAL_ARCHED_PROJECTILE_ZERO_RANGE_RAMP = 1.2m;
        //TODO new custom value needs to get argued with people - alternatively: 1.25 with an offset, same difference effectively.
        public const decimal NORMAL_ROCKET_PROJECTILE_ZERO_RANGE_RAMP = 1.246m;// had in several places, but not quite high enough for liberty launcher math: 1.24444444444444m;//original simple number: 1.25m;
        public const decimal NORMAL_ENERGY_PROJECTILE_ZERO_RANGE_RAMP = 1.2m;

        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// 0.0625 (30:1) per https://wiki.teamfortress.com/wiki/Talk:Shotgun#Bullet_spread_on_either_this_page_or_the_page_for_the_Scattergun_.28and_potentially_a_lot_of_other_weapon_pages.29_is_WRONG
        /// but the linked image (https://imgur.com/a/ZmWeqe9) says 0.0675 (28:1), same as reddit post!
        /// I think they accidentally conflated it with the firing rate.
        /// I have not done the legwork of extracting and decrypting the tf/scripts files they're talking about.
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// Spread: 0.0675
        /// tf_weapon_soda_popper
        /// tf_weapon_shotgun_soldier
        /// tf_weapon_shotgun_pyro
        /// tf_weapon_shotgun_primary
        /// tf_weapon_shotgun_hwg
        /// tf_weapon_sentry_revenge
        /// tf_weapon_scattergun
        /// tf_weapon_raygun
        /// tf_weapon_pep_brawler_blaster
        /// tf_weapon_drg_pomson
        /// </summary>
        public const decimal SPREAD_SHOTGUN_SCATTERGUN = 0.0675m;
        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// Spread: 0.025
        /// tf_weapon_smg
        /// tf_weapon_revolver
        /// tf_weapon_charged_smg
        /// </summary>
        public const decimal SPREAD_SMG_REVOLVER = 0.025m;
        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// Spread: 0.0
        /// tf_weapon_syringegun_medic
        /// tf_weapon_sniperrifle_decap
        /// tf_weapon_sniperrifle_classic
        /// tf_weapon_sniperrifle
        /// tf_weapon_shotgun_building_rescue
        /// tf_weapon_rocketlauncher_fireball
        /// tf_weapon_rocketlauncher_directhit
        /// tf_weapon_rocketlauncher_airstrike
        /// tf_weapon_rocketlauncher
        /// tf_weapon_pipebomblauncher
        /// tf_weapon_particle_cannon
        /// tf_weapon_laser_pointer
        /// tf_weapon_grenadelauncher
        /// tf_weapon_grapplinghook
        /// tf_weapon_flaregun_revenge
        /// tf_weapon_flaregun
        /// tf_weapon_flamethrower
        /// tf_weapon_crossbow
        /// tf_weapon_compound_bow
        /// tf_weapon_cannon
        /// </summary>
        public const decimal SPREAD_SNIPER = 0;
        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// Spread: 0.04
        /// tf_weapon_pistol_scout
        /// tf_weapon_pistol
        /// tf_weapon_mechanical_arm
        /// tf_weapon_handgun_scout_secondary
        /// tf_weapon_handgun_scout_primary
        /// </summary>
        public const decimal SPREAD_PISTOL = 0.04m;
        /// <summary>
        /// https://www.reddit.com/r/truetf2/comments/1gyb8g/comment/cap37c1
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// Spread: 0.08
        /// tf_weapon_minigun
        /// </summary>
        public const decimal SPREAD_MINIGUN = 0.08m;


        // based on source code leak from 2017 https://youtu.be/UFtZMIWt0WI?t=32
        // x (forward), y (right), z (up) relative to class's eyes.  Note each class has different view heights (z).
        // crouched: rockets, flares, cowmangler, bison: z is set to 8
        public static readonly decimal OFFSET_1_ROCKETS_FLARES =23.5m;//,12, -3
        //cowm bison, pomson; huntsman, crossbow, rescue ranger, grappling hoook
        public static readonly decimal OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE = 23.5m;//,8,-3
        public static readonly decimal OFFSET_3_GRENADE_STICKY_JARS = 23.5m;//,8, -6 // I had 16 for grenade & sticky but I dont' know why
        // technically this set is different values based on player's origin, not eyes
        public static readonly decimal OFFSET_4_BALLS_CLEAVER = 32;//,0, -15
        public static readonly decimal OFFSET_5_SYRINGES = 16;//,6, -8
        public static readonly decimal OFFSET_6_FLAMETHROWER = 0; //12,0
        public static readonly decimal OFFSET_7_ORIGINAL = 23.5m;//0, -3
        public static readonly decimal OFFSET_8_LUNCHBOX_TOSS = 0;//0, -8  (corrected to 0 x in description vs. 8 in video)
        // not known:
        public static readonly decimal OFFSET_DRAGONSFURY = OFFSET_6_FLAMETHROWER; // I had 0
        // not known:
        public static readonly decimal OFFSET_ORB = OFFSET_2_ENERGY_COWMANGLER_ARROWLIKE;
        // gas passer I assume is a "jar"

        // made up to fit my theories:
        public static readonly decimal OFFSET_HITSCAN = 30;
        public static readonly decimal OFFSET_HITSCAN_MINIGUN = OFFSET_HITSCAN;
        public static readonly decimal OFFSET_HITSCAN_SHOTGUN = OFFSET_HITSCAN;
        public static readonly decimal OFFSET_HITSCAN_SCATTERGUN = OFFSET_HITSCAN;
        public static readonly decimal OFFSET_HITSCAN_REVOLVER = OFFSET_HITSCAN;
        public static readonly decimal OFFSET_HITSCAN_PISTOL = OFFSET_HITSCAN;//22?
        public static readonly decimal OFFSET_HITSCAN_SMG = OFFSET_HITSCAN;

        public static readonly decimal OFFSET_HITSCAN_MELEE = OFFSET_HITSCAN;

        public static readonly decimal OFFSET_HITSCAN_SHORTCIRCUIT = OFFSET_HITSCAN;

        // don't really care:
        public static readonly decimal OFFSET_MEDIGUN = OFFSET_6_FLAMETHROWER;
        public static readonly decimal OFFSET_SHIELDBASH = OFFSET_6_FLAMETHROWER;
        public static readonly decimal OFFSET_STOMP = OFFSET_6_FLAMETHROWER;
        public static readonly decimal OFFSET_HITSCAN_SNIPER = OFFSET_HITSCAN;

        public Damage(decimal baseDamage)
        {
            Base = baseDamage;
        }
        public decimal Base { get;  } // building damage

        //public DamageType DamageType { get;  set; } // bullet/fire/etc.
        // push modifier
        // self push modifier

        public decimal ZeroRangeRamp { get;  set; } = 1.0m; // theoretical, not practical?
        public decimal Offset { get;  set; } = 0;
        //public decimal PointBlankRamp => ZeroRangeRamp;//FIXME theoretical ramp that applies offset.
        public decimal LongRangeRamp { get;  set; } = 1.0m;

        public decimal BuildingModifier { get;  set; } = 1.0m;


        // mangler (no crits, downgrade): |CH={{#expr:1.25*1.35/3.0}}|CL={{#expr:1.0*1.35/3.0}}
        // short circuit (no crits): |CH={{#expr:1.12/3.0}}|CM={{#expr:1.0/3.0}}|CL=0.0|ML=0.0
        // sc alt (no crits): |CH={{#expr:1.0/3.0}}|CM={{#expr:1.0/3.0}}|CL={{#expr:1.0/3.0}}
        // fanowar (no minicrits, upgrade): |MH={{#expr:1/1.35*3}}
        // (bushwacka upgrades, also)

        // ball: |H=1.0 |L=1.5 |ML=1.5 |CL=1.5    
        // -> guillotine: |ML=1.0|CL=1.0
        // bolt->rescueranger (normal): |MH=1.5|ML=1.0|CH=1.0|CL=1.0
        // bolt->crossbow (time as range with crits applied): |MH=.75|ML=1.5|CH=.75|CL=1.5

        // ambassador: |CH=1.0|CL=0.528|MH=1.5|ML=0.528
        // flamethrower: |H=2.0 |CL=0|CH=2.0|ML=0

        // for ambassador (headshots - it's complicated) and flamethrowers (crossbow, too, but that's handled with hang time as a "charged" alternate)
        public bool CritIncludesRamp { get; set; } = false;

        //TODO probably better off with a crit calculator object that can be overridden for special weapons like the cowmangler.

        public decimal MinicritZeroRangeRamp => ZeroRangeRamp;
        
        public decimal MinicritLongRangeRamp => CritIncludesRamp
            ? LongRangeRamp
            : 1.0m;

        public decimal CritZeroRangeRamp => CritIncludesRamp
            ? ZeroRangeRamp
            : 1.0m;
        
        public decimal CritLongRangeRamp => CritIncludesRamp
            ? LongRangeRamp
            : 1.0m;

    }

    public class Melee
    {
        // origin? but verified in src leak weapon_dodbasemelee.cpp:
        //Vector vecSrc	= pPlayer->Weapon_ShootPosition();
        //Vector vecEnd = vecSrc + vForward * 48;
        public static readonly decimal DEFAULT_RANGE = 48;

        public Damage Damage { get; set; }
        /// <summary>
        /// TODO store this documentation and these values somewhere other than Melee class
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// Range: 0
        /// tf_weapon_shotgun_building_rescue
        /// tf_weapon_rocketlauncher_fireball
        /// tf_weapon_rocketlauncher_directhit
        /// tf_weapon_rocketlauncher_airstrike
        /// tf_weapon_rocketlauncher
        /// tf_weapon_particle_cannon
        /// tf_weapon_grapplinghook
        /// tf_weapon_flamethrower
        /// tf_weapon_crossbow
        /// 
        /// Range: 8192
        /// tf_weapon_syringegun_medic
        /// tf_weapon_soda_popper
        /// tf_weapon_sniperrifle_decap
        /// tf_weapon_sniperrifle_classic
        /// tf_weapon_sniperrifle
        /// tf_weapon_smg
        /// tf_weapon_shotgun_soldier
        /// tf_weapon_shotgun_pyro
        /// tf_weapon_shotgun_primary
        /// tf_weapon_shotgun_hwg
        /// tf_weapon_sentry_revenge
        /// tf_weapon_scattergun
        /// tf_weapon_raygun
        /// tf_weapon_pep_brawler_blaster
        /// tf_weapon_minigun
        /// tf_weapon_laser_pointer
        /// tf_weapon_handgun_scout_primary
        /// tf_weapon_flaregun_revenge
        /// tf_weapon_flaregun
        /// tf_weapon_drg_pomson
        /// tf_weapon_compound_bow
        /// tf_weapon_charged_smg
        /// 
        /// Range: 4096
        /// tf_weapon_revolver
        /// tf_weapon_pistol_scout
        /// tf_weapon_pistol
        /// tf_weapon_handgun_scout_secondary
        /// 
        /// Range: 450
        /// tf_weapon_medigun
        /// 
        /// Range: 256
        /// tf_weapon_mechanical_arm
        /// </summary>
        public decimal MaxRange { get; set; } = DEFAULT_RANGE;
    }

    public class Hitscan
    {
        // melee range

        public Fragmentation Fragmentation { get; set; }
        public Damage Damage { get; set; }
        public Recoil Recoil { get; set; }
        public bool Penetrating { get; set; } = false;

        public AOE Splash { get; set; }
    }

    public class Effect// bleed/afterburn/sap/milk/minicrit length max/min, type
    {
        public string Name { get; set; }
        public Damage Damage { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
        public decimal DamageRate { get; set; }
        //public DamageType DamageType { get;  set; }
    }

    //"The bleeding and afterburn mechanics do not crit, but will mini-crit if the attacking player is mini-crit boosted or if the target is under a mini-crit debuff."
    public class AfterburnEffect : Effect
    {
        public AfterburnEffect(decimal time)
            : this(time, time)
        {
        }

        public AfterburnEffect(decimal time, decimal time2)
        {
            Name = "Afterburn";
            //if (time2 == time)
            //    Name = $"Afterburn({time} s)";
            //else
            //    Name = $"Afterburn({time} - {time2} s)";
            Minimum = time;
            Maximum = time2;

            Damage = new Damage(4);
            DamageRate = 0.5m;
        }
    }

    //"The bleeding and afterburn mechanics do not crit, but will mini-crit if the attacking player is mini-crit boosted or if the target is under a mini-crit debuff."
    public class BleedEffect : Effect
    {
        public BleedEffect(decimal time)
        {
            //Name = $"Bleeding({time} s)";
            Name = "Bleeding";

            Minimum = time;
            Maximum = time;

            Damage = new Damage(4);
            DamageRate = 0.5m;
        }
    }
    /// <summary>
    ///   Effects that apply to buildings, not players.  Usually effects don't effect buildings.
    /// </summary>
    public class BuildingEffect : Effect
    {

    }

    public class AOE
    {
        /// <summary>
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// DamageRadius: 200
        /// tf_weapon_spellbook
        /// tf_weapon_jar_milk
        /// tf_weapon_jar_gas
        /// tf_weapon_jar
        /// tf_weapon_cleaver
        /// 
        /// DamageRadius: 146
        /// tf_weapon_pipebomblauncher
        /// tf_weapon_grenadelauncher
        /// tf_weapon_cannon
        /// </summary>
        public const decimal DEFAULT_SPLASH = 146;//Hu
        //"...a small blast radius which damages and ignites nearby enemy players..."
        //July 2, 2015 Patch #1 (Gun Mettle Update)
        // Increased the blast radius from flares from 92Hu to 110Hu.
        public const decimal FLARE_SPLASH = 110m;
        /// <summary>
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// DamageRadius: 146
        /// tf_weapon_pipebomblauncher
        /// tf_weapon_grenadelauncher
        /// tf_weapon_cannon
        /// </summary>
        public const decimal EXPLOSIVE_SPLASH = DEFAULT_SPLASH;
        /// <summary>
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// DamageRadius: 200
        /// tf_weapon_spellbook
        /// tf_weapon_jar_milk
        /// tf_weapon_jar_gas
        /// tf_weapon_jar
        /// tf_weapon_cleaver
        /// </summary>
        public const decimal EFFECT_SPLASH = 200m;
        public const decimal DEFAULT_BANNER = 450; // basis? none? this (450) is the connect range of the medigun
        public AOE() : this(DEFAULT_SPLASH)
        {

        }
        public AOE(decimal radius)
        {
            //TODO does game force rounding of this number? if so, round here.  Direct Hit wiki uses a round HU number instead of the calculated one.
            Radius = radius;
        }
        public decimal Radius { get; }
    }
    public class BannerAOE : AOE
    {
        public BannerAOE() 
            : base(AOE.DEFAULT_BANNER) 
        { }
    }
    public class Projectile
    {
        public Projectile(decimal speed)
        {
            Speed = speed;
        }
        public Damage HitDamage { get; set; }
        public AOE Splash { get; set; }

        /// <summary>
        /// 
        /// I extracted and decrypted the tf_weapon ctx files myself using GCFScape & VICE.
        /// Range: 8192
        /// tf_weapon_syringegun_medic
        /// tf_weapon_soda_popper
        /// tf_weapon_sniperrifle_decap
        /// tf_weapon_sniperrifle_classic
        /// tf_weapon_sniperrifle
        /// tf_weapon_smg
        /// tf_weapon_shotgun_soldier
        /// tf_weapon_shotgun_pyro
        /// tf_weapon_shotgun_primary
        /// tf_weapon_shotgun_hwg
        /// tf_weapon_sentry_revenge
        /// tf_weapon_scattergun
        /// tf_weapon_raygun
        /// tf_weapon_pep_brawler_blaster
        /// tf_weapon_minigun
        /// tf_weapon_laser_pointer
        /// tf_weapon_handgun_scout_primary
        /// tf_weapon_flaregun_revenge
        /// tf_weapon_flaregun
        /// tf_weapon_drg_pomson
        /// tf_weapon_compound_bow
        /// tf_weapon_charged_smg
        /// 
        /// Range: 0
        /// tf_weapon_shotgun_building_rescue
        /// tf_weapon_rocketlauncher_fireball
        /// tf_weapon_rocketlauncher_directhit
        /// tf_weapon_rocketlauncher_airstrike
        /// tf_weapon_rocketlauncher
        /// tf_weapon_particle_cannon
        /// tf_weapon_grapplinghook
        /// tf_weapon_flamethrower
        /// tf_weapon_crossbow
        /// 
        /// Range: 4096
        /// tf_weapon_revolver
        /// tf_weapon_pistol_scout
        /// tf_weapon_pistol
        /// tf_weapon_handgun_scout_secondary
        /// 
        /// Range: 450
        /// tf_weapon_medigun
        /// 
        /// Range: 256
        /// tf_weapon_mechanical_arm
        /// </summary>
        public decimal MaxRangeTime { get; set; } = 0;
        public decimal Spread { get; set; } = 0;

        public decimal Speed { get; }
        //size
        public bool Propelled { get; set; } = false; // rockets vs. arched // or PhysicsType to include flame puffs
        public decimal ArmTime { get; set; } = 0;
        public bool Penetrating { get; set; } = false;
        /// <summary>
        /// Whether airblast/orb affect it
        /// </summary>
        public bool Influenceable { get; set; } = true;
    }

    public class Fragmentation
    {
        public Fragmentation(decimal spread)
        {
            Spread = spread;
        }
        public int Fragments { get;  set; } = 1;
        public decimal Spread { get; }
        public string FragmentType { get;  set; } = "pellet";
        // int centerFragments
        // spread pattern
    }
    public class Recoil
    {
        public static readonly decimal DEFAULT_RECOVERY = 1.25m;
        public Recoil(decimal spread)
        {
            Spread = spread;
        }
        public decimal Recovery { get; set; } = DEFAULT_RECOVERY;
        public decimal Spread { get;  }
    }

    public class Ammo // /Recharge
    {
        public const int INFINITE_AMMO = -1;
        public const int NO_LOAD = -1;

        public Ammo(int load, int carry)
        {
            Loaded = load;
            Carried = carry;
            AmmoUsed = 1;
        }
        public Ammo(int carry)
            :this(NO_LOAD, carry)
        {
        }

        public int InitialLoaded { get; set; } = -1;
        public int Loaded { get; set; }
        public int Carried { get; set; }

        public decimal AmmoUseInterval { get; set; }
        public int AmmoUsed { get; set; }

        public decimal Reload { get; set; } // or recharge
        public decimal ReloadFirst { get; set; }
        public decimal ReloadAdditional { get; set; }

        public string ReloadUsing { get; set; } // or Recharge type "Time/Damage"
        public string AmmoType { get; set; }
        public string FireType { get; set; }
    }

    public abstract class WeaponAttribute
    {
        protected WeaponAttribute(string text)
        {
            Text = text;
        }
        public string Text { get; private set; }
    }
    public class NegativeAttribute : WeaponAttribute
    {
        public NegativeAttribute(string text) : base(text) { }
    }
    public class PositiveAttribute : WeaponAttribute
    {
        public PositiveAttribute(string text) : base(text) { }

    }
    public class NeutralAttribute : WeaponAttribute
    {
        public NeutralAttribute(string text) : base(text) { }
    }
    public class DescriptionAttribute : WeaponAttribute
    {
        public DescriptionAttribute(string text) : base(text) { }
    }
}