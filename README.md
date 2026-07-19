
# Pirate's Treasure Hunt

A 2D top-down pirate adventure game developed in Unity where the player explores islands, battles enemy ships, follows treasure clues, and searches for hidden treasure.

---

## Features

- Top-down pirate ship navigation
- Left and right broadside cannon combat
- Enemy AI with island-based detection
- Ship health system
- Treasure hunt with progressive clues
- Multiple islands to explore
- Minimap
- Main Menu and Game Over screens
- Tilemap-based world

---

## Gameplay

The player controls a pirate ship sailing through a sea filled with islands.

Enemy ships patrol islands and begin chasing the player when they enter their detection range. The player must defeat enemy ships, uncover clues, and finally discover the hidden treasure chest.

---

## Controls

| Key | Action |
|------|--------|
| W | Move Forward |
| S | Move Backward |
| A | Rotate Left |
| D | Rotate Right |
| Left Mouse Button | Fire Left Cannons |
| Right Mouse Button | Fire Right Cannons |

---

## Technologies Used

- Unity 6
- C#
- Unity Tilemap System
- Rigidbody2D Physics
- TextMeshPro
- Unity UI System

---

## Project Structure

```
Assets
│
├── Scenes
│   ├── MainMenu
│   ├── Game
│   └── GameOver
│
├── Scripts
│   ├── ShipMovement
│   ├── PlayerShipController
│   ├── EnemyAI
│   ├── ShipsCannon
│   ├── CannonBall
│   ├── ShipHealth
│   ├── TreasureManager
│   ├── IslandTrigger
│   ├── EnemySpawner
│   └── CameraFollow
│
├── Sprites
├── Prefabs
├── Tilemaps
└── UI
```

---

## Enemy AI

Enemy ships:

- Guard islands
- Detect nearby players
- Chase the player
- Position themselves sideways
- Fire broadside cannons
- Sink when health reaches zero

---

## Treasure System

The treasure hunt consists of:

1. Sail to Skull Island
2. Defeat enemy guards
3. Receive the next clue
4. Travel to Coral Island
5. Find the final Treasure Cove
6. Open the treasure chest

---

## Future Improvements

- Better enemy pathfinding around islands
- Different enemy ship types
- Cannon smoke effects
- Ocean particle effects
- Dynamic music
- Coin collection
- Upgrade system
- Boss pirate ship
- Save system

---

## Author

Developed as a Game Development Club assignment using Unity and C#.
