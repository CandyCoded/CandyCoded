### Math

#### Clerp

Interpolates circularly between either two numbers or Vector3 objects by a given value.

This method corrects rotations going the long way around.

```csharp
float updatedRotationX = CandyCoded.Math.Clerp(currentRotationX, newRotationX, 1);
```

```csharp
Vector3 updatedRotation = CandyCoded.Math.Clerp(currentRotation, newRotation, 1);
```
