
![Logo](https://github.com/zutmkr/Studia/blob/master/praca_mag/static/coollogo_com-7011398.png)


## (Pre-Alpha):
####    [TO DO]:
    + Code refactor
        ++ TDD methology (Test Driven Development) - what should be tested?
            +++ use Python 'unittest' library
        ++ Code naming change (Pol -> Eng)
        ++ PEP8
        ++ Python ver. 3.6.2
        
    + Add documentation
        ++ Game Design Document
        ++ Test Strategy
        
    + Select framework
        ++ pygame 
            +++ low level programming
            +++ 2D graphic
            +++ multiplayer = sockets, Twisted
            +++ old???
        ++ kivy
            +++ high level programming
            +++ capable for android
            +++ easier Twisted for multiplayer
            +++ Xbox360 controller support
            +++ better stock graphic
            
    + Develop a network module
        ++ LAN Multiplayer
            +++ Co-op campaign
            +++ PvP
        ++ Async movement
            +++ Turn based?
            
    + Translations (Pl, En, De) 
    
    + New player attributes
        ++ Damage - combination of Strenght item Damage and item type
        ++ Armor - will reduce the amount of all damage taken by .% (Monsters and items)
        ++ Resist - will reduce the amount of specific damage taken by .% (Monsters and items)
        
    + New NPC
        ++ Smith - can upgrade/repair/craft items
        ++ ...
        
    + Adding translations and unlocking the LANGUAGE option 
    
    + Rework itemization
        ++ Crafting
        ++ Enchanting
        ++ Disassembling
        ++ Upgrading (item level)
        ++ Adding base items
            +++ Normal
            +++ Magic
                ++++ enhance the player's damage/resist
            +++ Rare
                ++++ enhance the player's armor 
            +++ Unique
                ++++ speed up learning of a skill
            +++ Legendary
                ++++ can learn ultimate skills
        ++ New attributes
            +++ Durability - numericall indycator on items. When durability go below 1,
                the item will be destroyed and can no longer be used by character.
                
    + Skills can be used by player and monsters
        ++ Skill types
            +++ Physicall
            +++ Fire Element
            +++ Ice Element
            +++ Magic
        ++ Skill groups
            +++ Active - cast instantly
            +++ Passive - always active
            +++ Hybrid - cast instantly and delivers over time
        ++ Skills are learned from weapons, armors and accessories
        
    + Boss fights every 5 levels of dungeon
