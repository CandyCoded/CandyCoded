## Getting Started

Once you have imported CandyCoded into your project you can start using it right away. Components like the Gizmo and Screenshake can be found via the Add Component button in the Inspector. Editor extensions like `DisplayInInspector` and `EnumMask` are automatically available to all scripts. Functionality like the Animate and Raycast methods are tucked away behind the CandyCoded namespace which can be used either by adding the namespace to a class header or calling the method directly.

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

### ScreenShake

In this example, we will be shaking the screen whenever a method is called.

1. Select the main camera in the scene.
1. Click Add Component, type `ScreenShake` and select the script.
1. Select a GameObject that will cause the screen to shake.
1. Attach a new script (or utilize an existing script) and open it up in your editor of choice.
1. Create a new private variable on the class called `screenShake` with a type of `CandyCoded.ScreenShake`.
1. In `Awake()` or `Start()` set the `screenShake` variable with the following code:
    ```csharp
    private void Awake()
    {

        screenShake = Camera.main.GetComponent<CandyCoded.ScreenShake>();

    }
    ```
1. Create a new method for firing the shake event:
    ```csharp
    private void FireWeaponShake()
    {

        screenShake.Shake(0.5f, 0.2f);

    }
    ```
1. In the `Update()` method add the following code to fire the shake event method:
    ```csharp
    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            FireWeaponShake();

        }

    }
    ```
1. Press play and when you press either the Left Mouse Button or the Left Ctrl the screen will shake!
