### Screenshot

#### Save

Save a screenshot to the applications persistent data path (device specific) with a random file name.

```csharp
var screenshotFilePath = Screenshot.Save();

Debug.Log($"Saved screenshot to {screenshotFilePath}");
```

Save a higher resolution screenshot by passing a multiplier to the method.

```csharp
var screenshotFilePath = Screenshot.Save(2);

Debug.Log($"Saved screenshot to {screenshotFilePath}");
```

#### SaveTransparent

Save a transparent screenshot to the applications persistent data path (device specific) with a random file name.

```csharp
var screenshotFilePath = Screenshot.SaveTransparent();

Debug.Log($"Saved screenshot to {screenshotFilePath}");
```

```csharp
var screenshotFilePath = Screenshot.SaveTransparent(secondaryCamera);

Debug.Log($"Saved screenshot to {screenshotFilePath}");
```
