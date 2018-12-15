### List

#### Permutations

Returns a list of all possible combinations for a list of items.

```csharp
List<int> list = new List<int> { 1, 2, 3 };
List<List<int>> listOfCombinations = list.Permutations();
```

| Index | Value   |
| ----- | ------- |
| 0     | 1       |
| 1     | 2       |
| 2     | 1, 2    |
| 3     | 3       |
| 4     | 1, 3    |
| 5     | 2, 3    |
| 6     | 1, 2, 3 |

#### Random

Returns a random item from a List.

```csharp
List<float> list = new List<float>() { 1, 2, 3, 4, 5 };
float randomItemFromList = list.Random();
```

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
