### List

#### Shuffle

Creates a new copy of a list and shuffles the values.

```csharp
List<float> list = new List<float>();
List<float> shuffledList = list.Shuffle();
```

#### Slice

Returns a shallow copy of a portion of a list.

```csharp
List<float> list = new List<float>();
List<float> specificItems = list.Slice(0, 1);
```

#### Splice

Removes and returns a shallow copy of a portion of a list.

```csharp
List<float> list = new List<float>();
List<float> removedItems = list.Splice(0, 1);
```
