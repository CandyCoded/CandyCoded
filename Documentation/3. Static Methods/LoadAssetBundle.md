### LoadAssetBundle

#### FromUrl

**Loading Scenes**

```csharp
StartCoroutine(CandyCoded.LoadAssetBundle.FromUrl(
    "http://localhost:8000/samplescene",
    "Assets/Scenes/SampleScene.unity",
    LoadSceneMode.Additive
));
```

**Loading GameObjects**

```csharp
StartCoroutine(CandyCoded.LoadAssetBundle.FromUrl(
    "http://localhost:8000/sampleobjects",
    "Cube"
));
```
