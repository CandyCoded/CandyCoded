## Getting Started

Once you have imported CandyCoded into your project you can start using it right away. Editor extensions like `EnumMask` are automatically available to all scripts. Functionality like the Animate and Raycast methods are tucked away behind the CandyCoded namespace which can be used either by adding the namespace to a class header or calling the method directly.

Below are a couple of ways to get started with CandyCoded.

### Basic Animations

For this example, we will be animating the position of a GameObject from its start position to a new position.

1. Select the GameObject you would like to animate.
1. Attach a new script (or utilize an existing script) and open it up in your editor of choice.
1. In the `Start()` method add the following code:

    ```csharp
    CandyCoded.Animate.MoveTo(gameObject, new Vector3(10, 10, 10), 1);
    ```

1. Press play and your object will animate from its start position to `Vector3(10, 10, 10)` over the course of one second.

If you would like to control the easing of the animation you can use the struct `CandyCoded.Vector3AnimationCurve` with `CandyCoded.Animate.Position()`.
