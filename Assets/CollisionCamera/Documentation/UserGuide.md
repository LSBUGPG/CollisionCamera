# Collision Camera User Guide

This document explains how to use the behaviours in this package to create a third person camera that follows a player object at a distance accounting for collision with geometry and the player object itself.

## Behaviours

- [`CollisionSweep`]
- [`DistanceFade`]
- [`SmoothFollow`]

### CollisionSweep

This behaviour tries to move the object the given distance away from a target. It uses a [`Rigidbody.SweepTest`] of the object's [`Collider`] to prevent this object from moving through obstructions. The behaviour requires that the object it is attached to has a kinematic [`Rigidbody`]. The updated position of this object can be used as a target. The [`Collider`] on this object should be smaller than the size of the target to prevent it pushing through things that the target is close to.

**Intended use**: to place and orient an invisible object at the ideal viewing position for the camera following a target.

### DistanceFade

This behaviour uses the distance to a target object to fade out its Renderer. It smoothly transitions between fully opaque at the `startFade` distance and beyond to fully transparent at the 'endFade' distance or nearer. This behaviour requires an object with a [`Renderer`] that has as its [`Renderer.material`] a [`Material`] with a transparent shader that uses its main [`Color`]'s [alpha] value to fade.

**Intended use**: to fade the player object away if the camera gets to close.

### SmoothFollow

This behaviour smoothly moves the object to the given target's position and orientation. It uses Unity's smooth damping functions for smoothing. It moves into position in `positionTime` seconds, and orients itself in `rotationTime` seconds.

**Intended use**: place on a camera object and set it to target an object containing the [`CollisionSweep`] behaviour.

## Example Scenes

The `Examples` folder contains a number of Unity scenes set up for testing the behaviours in this package.

- [`ThirdPersonCameraTest`]
- [`CollisionSweepTest`]
- [`DistanceFadeTest`]
- [`MovementTest`]
- [`SmoothFollowTest`]

### ThirdPersonCameraTest

This test demonstrates the intended use of the behaviours in this package. It contains blue sphere representing the player and has a floor and two walls. The player is controlled using Unity's horizontal and vertical axis inputs to move and the mouse to rotate.

The player object has the [`DistanceFade`] behaviour attached, with the camera set as its target. It also has an example `FadeMaterial` attached which uses the `StandardMaterial` shader with the `Fade` `RenderingMode`.

The `CameraTargetPosition` object is an invisible sphere with a radius slightly smaller than the player. It has the [`CollisionSweep`] behaviour attached.

The `Main Camera` object in this scene is the default `Camera` created by Unity but with the [`SmoothFollow`] script attached and targeting the `CameraTargetPosition` object.

### CollisionSweepTest

This test demonstrates just the [`CollisionSweep`] behaviour. It contains a floor, two walls, a green sphere representing the target objects and a red sphere showing the swept position. To demonstrate, run the scene and manipulate the green sphere's position and orientation in the `Scene View`. The red sphere should find a position behind the green sphere but should not go through a wall or the floor to do so.

### DistanceFadeTest

This test demonstrates just the [`DistanceFade`] behaviour. It contains a blue sphere representing the position of the player and a red sphere representing the position of the camera. To demonstrate, run the scene and move either sphere closer or further away. The blue sphere should fade as the distance between these spheres changes.

### SmoothFollowTest

This test demonstrates just the [`SmoothFollow`] behaviour. It contains a blue sphere representing the target position and a red sphere representing the following object. To demonstrate, run the scene and move or rotate the blue sphere to see the red sphere follow.

### MovementTest

This test demonstrates the movement and rotation scripts used in the [`ThirdPersonCameraTest`] scene. These scripts are included for demonstration purposes only.

[`ThirdPersonCameraTest`]: #ThirdPersonCameraTest
[`CollisionSweepTest`]: #CollisionSweepTest
[`DistanceFadeTest`]: #DistanceFadeTest
[`MovementTest`]: #MovementTest
[`SmoothFollowTest`]: #SmoothFollowTest
[`CollisionSweep`]: #CollisionSweep
[`DistanceFade`]: #DistanceFade
[`SmoothFollow`]: #SmoothFollow
[`Color`]: https://docs.unity3d.com/ScriptReference/Color.html
[alpha]: https://docs.unity3d.com/ScriptReference/Color-a.html
[`Renderer`]: https://docs.unity3d.com/ScriptReference/Renderer.html
[`Renderer.material`]: https://docs.unity3d.com/ScriptReference/Renderer-material.html
[`Material`]: https://docs.unity3d.com/ScriptReference/Material.html
[`Rigidbody`]: https://docs.unity3d.com/ScriptReference/Rigidbody.html
[`Rigidbody.SweepTest`]: https://docs.unity3d.com/ScriptReference/Rigidbody.SweepTest.html
[`Collider`]: https://docs.unity3d.com/ScriptReference/Collider.html
