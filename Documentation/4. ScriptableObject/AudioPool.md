### AudioPool

The GameObjectPool ScriptableObject is used to play sounds effects without needing to reference AudioSource components manually. It can also randomly pick from an array of similar sound effects and randomly choose a volume and pitch based on a predefined range.

Start by creating a new AudioPoolReference ScriptableObject from **Assets** > **Create** > **CandyCoded** > **AudioPoolReference**.

Enter the number of sound effects you want to manage into the `AudioDataArray` property. Drag and drop the audio files you want to manage into the `Clips` array of each `AudioData` object. And if you want the volume and pitch to vary per sound effect, specify a range using the range sliders.

![](https://i.imgur.com/uFZsxnm.png)

#### Play

Plays an audio clip stored in the audio data array by name with a dynamically pooled AudioSource.

```csharp
audioPoolReference.Play("fire");
```

Plays an audio clip stored in the audio data array by name with a specified AudioSource component.

```csharp
audioPoolReference.Play("fire", audioSource);
```
