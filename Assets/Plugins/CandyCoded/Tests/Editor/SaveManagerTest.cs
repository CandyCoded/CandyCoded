// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using CandyCoded;
using CandyCoded.Experimental;

public class SaveManagerTest : TestSetup
{

    [Test]
    public void SaveAndLoadList()
    {

        var listOfNumbers = new List<int> { 1, 2, 3, 4, 5 };

        SaveManager.SaveData(listOfNumbers, Application.persistentDataPath + Path.DirectorySeparatorChar + "List.dat");

        var newListOfNumbers = SaveManager.LoadData<List<int>>(Application.persistentDataPath + Path.DirectorySeparatorChar + "List.dat");

        Assert.AreEqual(listOfNumbers, newListOfNumbers);

    }

    [Test]
    public void SaveAndLoadObservableList()
    {

        var listOfNumbers = new ObservableList<int> { 1, 2, 3, 4, 5 };

        SaveManager.SaveData(listOfNumbers, Application.persistentDataPath + Path.DirectorySeparatorChar + "ObservableList.dat");

        var newListOfNumbers = SaveManager.LoadData<ObservableList<int>>(Application.persistentDataPath + Path.DirectorySeparatorChar + "ObservableList.dat");

        Assert.AreEqual(listOfNumbers, newListOfNumbers);

    }

}
#endif
