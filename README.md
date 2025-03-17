# Umbra

## Overview
**Umbra** is a stealth-based 2D game where players control a character with the ability to switch between physical and shadow forms. Utilizing strategic movement, environmental puzzles, and evasion mechanics, players must navigate levels while avoiding enemy detection.

The game emphasizes stealth, environmental awareness, and creative problem-solving. Players can phase through walls in shadow form and interact with the environment to progress.

---

## Game Design Flow

### 1. **Player Movement**
- Basic 2D top-down movement using WASD/Arrow keys.
- Smooth transition between physical and shadow forms.
- Unique interactions tied to each form (e.g., shadow form allows passing through certain obstacles).

### 2. **Core Mechanics**
- **Stealth Vision Cones:** Enemies have defined vision cones and patrol patterns.
- **Pressure Plates & Triggers:** Certain objects (e.g., boxes) can be pushed onto pressure plates to open doors or deactivate hazards.
- **Keys & Locked Doors:** Keys must be collected to unlock specific doors.
- **Environmental Hazards:** Traps and obstacles force strategic use of forms.

### 3. **Enemy AI**
- Enemies patrol along predefined paths.
- Field-of-view vision detection triggers Game Over when the player is seen.
- Enemy pause and pursuit behavior upon spotting the player.

### 4. **UI & Game States**
- Main menu, pause menu, and game over screen implemented.
- Clear feedback when player is detected.
- Simple HUD showing collected keys/cards.

---

## Features
- **Two Distinct Player Forms:** Switch between physical and shadow form at will.
- **Enemy Patrol & Vision System:** Dynamic enemy AI with adjustable patrol paths and field-of-view.
- **Environmental Interactions:** Pushable objects, pressure plates, keys, and doors.
- **Sound Effects & Animations:** Door opening sounds, enemy alerts, and polished visual feedback.
- **Game Over & Restart System:** Seamless restart without breaking movement/physics.

---

## Controls
| Action                        | Input                 |
|------------------------------|----------------------|
| Move                         | WASD / Arrow Keys     |
| Switch Form                  | Spacebar (or assigned key) |
| Interact (Push/Pickup)       | E (or assigned key)   |
| Pause Menu                   | Escape               |

---

## Team Roles
| Team Member             | Role                                      |
|-------------------------|-------------------------------------------|
| William Moulton         | Level Designer / Environmental Artist     |
| Jean Carlos Lin Lai     | Level Designer / Environmental Artist     |
| Wanis Alshaari          | Enemy AI & Mechanics Programmer           |
| Louis Rodriguez-Rivera  | Player Designer & Mechanics Programmer    |

---
## Installation & Running
1. Clone the repository:
   ```
   git clone https://github/wrmoulton/Umbra.git
   ```
   
2. Open the project in Unity **(Developed with version 2022.3.55f1)**.
   
3. Press Play to start the game.
