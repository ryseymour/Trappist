# Trappist: browser edition

A playable browser version of Trappist, built from this repo's Unity project. Open `index.html` in any modern browser (it loads Three.js from jsDelivr, so it needs a connection). No build step.

## What comes from the original project

- **Maps.** The wilds, Nottingwood and the Outlaw Camp are read pixel for pixel from `Sprites/Level01.test.psd`, `Town.Nottingwood.test.psd` and `Camp.PlayerOutlaw.test.psd`, using the same colour-to-prefab legend as `ThreeDLevelGenerator` (roads, river, ash trees, pines, rocks, walls, cottages, the tavern and the store).
- **Buildings and who is inside them.** Castle, Guard Tower, Hunter's Lodge, Store, Tavern and House come from `Scriptables/Towns/Building/*.asset`.
- **Characters and dialogue.** Cole, Bob, Tina, the Merchant, the Collector and the Bad Guy come from `Scripts/CharacterProfile`, with their lines from `Scripts/ScriptableDialogue` ("Can you defeat two bosses?", "It's Dangerous to go alone! How about I join you?", "Are you looking to barter?", "Are you ready to battle?").
- **Quests.** The chest, switch and rubble test (`Tom.Intro`), Get the Sword (`Collect Quest`, turned in to Tina) and Kill the Boss (`Kill Quest`, two Boss1 kills, turned in at the Guard Tower whose NPC fires `FightStartTwo`).
- **Battles.** Turn order sorted by Speed as in `BattleManager.SpeedTracker`, the Stab / Electric Bolt / Heal / Freeze / Poison abilities, target selection with the arrow keys and Enter, and the Escape button. The party is Da Player (Game Developer) and Tina (the Sidekick battler shares her sprite). Enemies are Super Bad Guy and Super Boss 1 Guy.
- **Overworld behaviour.** Click to move with A* pathfinding, drag to pan and scroll to zoom (`OWcamera`), and enemies that walk between waypoints and pause for three seconds (`EnemyMover`).

## What was filled in

The Unity project was mid-build, so some things were placeholders. Those were finished here:

- Battle numbers were rebalanced (enemies had 3 HP) and XP, levels and gold were added.
- Placeholder text ("dafasdfsdaf", "This is a test scene") was rewritten in the same voice. The Collector and "Quest Finish" NPCs became the Collector and the Sheriff.
- The Sheriff turning on you at the Guard Tower is a reading of `QuestFinish.asset` calling `FightStartTwo`. It's the finale here.
- The store sells Water plus the gear whose sprites were already in the project (Leather Armor, Gloves, Ring, Amulet, Bow).
- Your tent at the Outlaw Camp heals the party and saves. Progress also autosaves to the browser.
- Pixel sprites were redrawn at the original 12x16-ish scale, since the originals were letter placeholders ("P", "BOSS").
