### SaveManager

#### SaveData

Save serializable object to a local file.

```csharp
var listOfNumbers = new List<int>{ 1, 2, 3, 4, 5 };

SaveManager.SaveData(listOfNumbers, "List.dat");
```

#### LoadData

Load serializable object from a local file.

```csharp
var listOfNumbers = SaveManager.LoadData<List<int>>("List.dat");
```

#### DeleteData

Delete a local file.

```csharp
SaveManager.DeleteData("List.dat");
```
