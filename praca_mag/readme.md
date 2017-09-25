
![Logo](https://github.com/zutmkr/Studia/blob/master/praca_mag/static/coollogo_com-7011398.png)


## (Pre-Alpha):
####    [TO DO]:
    1. Gameplay and options    
      1. Boss fights every 10 levels of dungeon
      2. 2D (isometric?)
      3. Procedurally generated dungeons
      4. Quests
      5. Save game
      6. Dungeon editor (?)
      7. ... 
        
    + Code refactor
        ++ Reuse code of "Dorothy's Dungeon 1"
        ++ TDD methology (Test Driven Development) - what should be tested?
            +++ Use Python 'unittest' library
            +++ Jenkins (?) for Continues Integration
        ++ Code naming change (Pol -> Eng)
        ++ PEP8
        ++ Python ver. 3.6.2
        ++ Github
        
    + Documentation
        ++ Game Design Document
        ++ Test Strategy
        
    + Framework
        ++ pygame 
            +++ Low level programming
            +++ 2D graphic
            +++ Multiplayer = sockets, Twisted
            +++ Extensive documentation
            +++ Old???
        ++ kivy
            +++ High level programming
            +++ Capable for android
            +++ Easier Twisted for multiplayer
            +++ Xbox360 controller support
            +++ Better stock graphic
            
    + Network module
        ++ LAN Multiplayer
            +++ Co-op campaign
            +++ PvP
        ++ Async movement?
            +++ Turn based?
            +++ Real time?
            
    + Translations (Pl, En, De) 
    
    + New player attributes
        ++ Damage - combination of Strenght, item Damage and item type
        ++ Armor - will reduce the amount of all damage taken by .% (Monsters and items)
        ++ Resist - will reduce the amount of specific damage taken by .% (Monsters and items)
        
    + NPCs
        ++ Smith - can upgrade/disassemble/repair/craft items
            +++ Give quest - receive random quality weapon/armor 
            +++ Can upgrade
                ++++ Level 1: TBD 
        ++ Healer - add Hit Points to character
            +++ Can upgrade infinitely:
                ++++ Every level: recovers 20HP more
                ++++ Cost: <gold> * <dungeon_level>
        ++ Shopkeeper - will sell/buy items
            +++ Can upgrade
                ++++ Level 1: TBD
    
    + Rework itemization
        ++ New items type
            +++ Usable
                ++++ Tome of Training <item> - teaches Smith new weapon/armor type
        ++ Crafting
        ++ Enchanting
        ++ Disassembling
        ++ Upgrading (item level)
        ++ Adding base items
            +++ Normal
            +++ Magic
                ++++ Enhance the player's damage/resist
            +++ Rare
                ++++ Enhance the player's armor 
            +++ Unique
                ++++ Speed up learning of a skill
            +++ Legendary
                ++++ Can learn ultimate skills
        ++ New attributes
            +++ Durability - numericall indycator on items. When durability go below 1,
                the item will be destroyed and can no longer be used by character.
            +++ Item Level - determines base damage, skills and effects
            +++ Damage - based on item level, strenght and item type
            +++ <skill_name> [0/15AP] - shows the player how many AP points is needed
                                        to learn the skill
                
    + Skills can be used by player and monsters
        ++ Skill types
            +++ Physicall
            +++ Fire Element
            +++ Ice Element
            +++ Magic
        ++ Skill groups
            +++ Dungeon
                ++++ Active - cast instantly
                ++++ Passive - always active
                ++++ Hybrid - cast instantly but active over time
            +++ Battle
                ++++ Offensive - deal damage
                ++++ Defensive - reduce damage
                ++++ Passive - always active
                ++++ Hybrid - cast instantly but active over time
        ++ Skills are learned from weapons, armors and accessories
