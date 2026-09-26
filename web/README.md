# Trappist: browser edition

A playable browser version of Trappist, built from this repo's Unity project. Serve the `web/` folder (for example `python3 -m http.server` inside it) and open `index.html` in any modern browser. It loads Three.js from jsDelivr, so it needs a connection. `models.js` holds the original FBX models packed as base64; regenerate it with `python3 web/build-models.py` from the repo root.

## What comes from the original project

- **Maps.** The wilds, Nottingwood and the Outlaw Camp are read pixel for pixel from `Sprites/Level01.test.psd`, `Town.Nottingwood.test.psd` and `Camp.PlayerOutlaw.test.psd`, using the same colour-to-prefab legend as `ThreeDLevelGenerator` (roads, river, ash trees, pines, rocks, walls, cottages, the tavern and the store).
- **Buildings and who is inside them.** Castle, Guard Tower, Hunter's Lodge, Store, Tavern and House come from `Scriptables/Towns/Building/*.asset`. Clicking one opens an interior room with its NPCs, as `BuildingInteraction` and `InsideManager` did, built on `Room1fbx.fbx`.
- **3D models.** The party and NPCs use the board-piece character from `character.pieces_R.fbx`, tinted per character like the SkinTone materials on the character prefabs. Cottages, the tavern, the castle and both tree types are the project's own FBX models.
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
- The letter placeholder sprites ("P", "BOSS") were replaced with portraits rendered from the 3D character models, with small hats, hoods and horns added to tell characters apart.
- Interiors were furnished to match each building (a throne room, a bar, shop shelves, a lodge fireplace, wanted posters in the tower), since the Unity rooms were empty.
