
![Logo](https://github.com/zutmkr/Studia/blob/master/praca_mag/static/coollogo_com-7011398.png)


# (Pre-Alpha):
###    [TO DO]:
#### Gameplay and options
  * Boss fights every 10 levels of dungeon
  * 2D (isometric?)
  * Procedurally generated dungeons
  * Quests
  * Save game
  * Dungeon editor (?)

#### Code refactor
  * Reuse code of "Dorothy's Dungeon 1"
  * TDD methology (Test Driven Development) - what should be tested?
    * Use Python 'unittest' library
    * Jenkins (?) for Continues Integration
  * Code naming change (Pol -> Eng)
  * PEP8
  * Python ver. 3.6.2
  * Github
        
#### Documentation
  * Game Design Document
  * Test Strategy
        
#### Framework
  * pygame 
    * Low level programming
    * 2D graphic
    * Multiplayer = sockets, Twisted
    * Extensive documentation
    * Old???
  * kivy
    * High level programming
    * Capable for android
    * Easier Twisted for multiplayer
    * Xbox360 controller support
    * Better stock graphic
            
#### Network module
  * LAN Multiplayer
    * Co-op campaign
    * PvP
  * Async movement?
    * Turn based?
    * Real time?
            
#### Translations
  * Polish
  * English

    
#### New player attributes
  * __Damage__ - combination of Strenght, item Damage and item type
  * __Armor__ - will reduce the amount of all damage taken by .% (Monsters and items)
  * __Resist__ - will reduce the amount of specific damage taken by .% (Monsters and items)
        
#### NPCs
  * __Smith__ - can upgrade/disassemble/repair/craft items
    * Give quest - receive random quality weapon/armor 
    * Can upgrade
      * Level 1: __TBD__ 
  * __Healer__ - add Hit Points to character
    * Can upgrade infinitely:
      * Every level: recovers 20HP more
      * Cost: `<gold> * <dungeon_level>`
  * __Shopkeeper__ - will sell/buy items
    * Can upgrade
      * Level 1: __TBD__
    
#### Rework itemization
  * New items type
    * Usable
      * __Tome of Training__ `<item>` - teaches Smith new weapon/armor type
  * Crafting
  * Enchanting
  * Disassembling
  * Upgrading (item level)
  * Adding base items
    * Normal
    * Magic
      * Enhance the player's damage/resist
    * Rare
      * Enhance the player's armor 
    * Unique
      * Speed up learning of a skill
    * Legendary
      * Can learn ultimate skills
      
#### New attributes
  * __Durability__ - numericall indycator on items. When durability go below 1, 
                     the item will be destroyed and can no longer be used by character
  * __Item Level__ - determines base damage, skills and effects
  * __Damage__ - based on item level, strenght and item type
  * __`<skill_name> [0/15AP]`__ - shows the player how many AP points is needed
                                  to learn the skill
                
#### Skills
  * Can be used by player and monsters
  * Skills are learned from weapons, armors and accessories
  * Skill types
    * Physicall
    * Fire Element
    * Ice Element
    * Magic
  * Skill groups
    * Dungeon
      * __Active__ - cast instantly
      * __Passive__ - always active
      * __Hybrid__ - cast instantly but active over time
    * Battle
      * Offensive - deal damage
      * Defensive - reduce damage
      * Passive - always active
      * Hybrid - cast instantly but active over time
