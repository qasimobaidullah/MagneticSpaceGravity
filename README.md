# MagneticSpaceGravity
# Unity 3D - Player Movement, Gravity, and Magnetism

## Overview

This Unity 3D project demonstrates player movement influenced by gravity and magnetism from light sources, with customizable parameters, joystick control, and a rolling-down hill effect prototype. The project focuses on dynamic player interactions using Unity physics components and allows users to visualize forces applied to the player body.

### Key Features

- **Player Movement**: Controlled through Unity's joystick input, allowing smooth movement on the x-axis with custom gravity.
- **Gravity**: Custom gravity vector (0, 2, 0) applied only to the x-axis, enabling specific movement behavior.
- **Magnetism**: Light sources act as magnets, pulling the player towards them based on proximity. Magnet strength and radius are adjustable through public variables.
- **Hill Rolling Effect**: A hill prototype for testing rolling mechanics, where the player rolls down when affected by gravitational force.
- **Force Visualization**: Use of Gizmos to visualize the forces applied to the player for debugging and adjustment.
- **Jump Feature**: Optional jump feature activated by a bool variable, allowing the player to jump and fall due to gravity.

---

## Requirements

- **Unity Version**: 2021.3 or later
- **Joystick Pack**: Install the Joystick Pack from the Unity Asset Store for mobile control functionality.

---

## Setup

1. Clone this repository to your local machine.
2. Open the project in Unity.
3. Install the [Unity Joystick Pack](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631) from the Unity Asset Store.
4. Open the `MainScene` to start working with the project.

---

## Scripts

### 1. **PlayerController.cs**

Manages player movement, magnet pull/push ability, and jump functionality.

- **Public Variables**:
  - `speed`: Controls movement speed.
  - `jumpForce`: Amount of upward force for the jump.
  - `isJumping`: Bool to enable or disable the jump feature.
  - `magnetPullStrength`: Strength of magnetism applied by the light sources.
  - `gravity`: Custom gravity vector applied to the player.

### 2. **CameraFollow.cs**

Ensures the camera smoothly follows the player's movement across the scene.

- **Public Variables**:
  - `cameraDistance`: The distance between the player and the camera.

### 3. **MagnetController.cs**

Handles the magnetic pull from light sources, affecting the player's position when in range.

- **Public Variables**:
  - `radius`: The range within which the magnet pulls the player.
  - `pullStrength`: Adjustable strength of the magnetism.

### 4. **ForceVisualisation.cs**

Visualizes the forces (gravity and magnetism) applied to the player using Unity Gizmos, aiding in debugging and fine-tuning.

---

## How to Use

1. Adjust the public variables directly in the Unity Inspector to manipulate gravity, magnetism, and movement behavior.
2. Play the scene and use the on-screen joystick to control the player's movement.
3. Watch the player's interaction with magnetic light sources, and use Gizmos for force visualization.
4. Use the jump feature by toggling the `isJumping` bool.

---

## Controls

- **Joystick**: Use to move the player on the x-axis.
- **Jump**: Toggle `isJumping` to enable the jump.

---

## Visual Debugging

The `ForceVisualisation.cs` script will display the gravitational and magnetic forces applied to the player in the Scene view. Use this to debug and adjust the strength and radius of magnetic forces.

---

## License

This project is licensed under the MIT License - see the LICENSE file for details.
