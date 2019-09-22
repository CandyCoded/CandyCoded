### SaveManager

#### SaveData

Save serializable object to a local file. Default directory file is saved in is the `Application.persistentDataPath`.

```csharp
var listOfNumbers = new List<int>{ 1, 2, 3, 4, 5 };

SaveManager.SaveData(listOfNumbers, "List.dat");
```

To change the directory, call `SaveData` with an additional parameter.

```csharp
var listOfNumbers = new List<int>{ 1, 2, 3, 4, 5 };

var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Documents/MyCoolGame");

SaveManager.SaveData(listOfNumbers, "List.dat", directory);
```

#### LoadData

Load serializable object from a local file. Default directory file is loaded from is the `Application.persistentDataPath`.

```csharp
var listOfNumbers = SaveManager.LoadData<List<int>>("List.dat");
```

To change the directory, call `LoadData` with an additional parameter.

```csharp
var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Documents/MyCoolGame");

var listOfNumbers = SaveManager.LoadData<List<int>>("List.dat", directory);
```

#### DeleteData

Delete a local file. Default directory file is deleted from is the `Application.persistentDataPath`.

```csharp
SaveManager.DeleteData("List.dat");
```

To change the directory, call `DeleteData` with an additional parameter.

```csharp
var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Documents/MyCoolGame");

SaveManager.DeleteData("List.dat", directory);
```
