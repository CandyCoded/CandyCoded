// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using CandyCoded.Experimental;

namespace CandyCoded.Tests
{

    public class SaveManagerTest : TestSetup
    {

        [SetUp]
        public static void DeleteFiles()
        {

            FileUtil.DeleteFileOrDirectory(string.Concat(Application.persistentDataPath, Path.DirectorySeparatorChar, "List.dat"));
            FileUtil.DeleteFileOrDirectory(string.Concat(Application.persistentDataPath, Path.DirectorySeparatorChar, "ObservableList.dat"));

        }

        [Test]
        public void SaveAndLoadList()
        {

            var listOfNumbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            SaveManager.SaveData(listOfNumbers, "List.dat");

            var newListOfNumbers = SaveManager.LoadData<List<int>>("List.dat");

            Assert.AreEqual(listOfNumbers, newListOfNumbers);

        }

        [Test]
        public void SaveAndLoadObservableList()
        {

            var listOfNumbers = new ObservableList<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            SaveManager.SaveData(listOfNumbers, "ObservableList.dat");

            var newListOfNumbers = SaveManager.LoadData<ObservableList<int>>("ObservableList.dat");

            Assert.AreEqual(listOfNumbers, newListOfNumbers);

        }

        [Test]
        public void SaveAndLoadListWithAbsolutePaths()
        {

            var listOfNumbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            SaveManager.SaveData(listOfNumbers, "List.dat", Application.persistentDataPath);

            var newListOfNumbers = SaveManager.LoadData<List<int>>("List.dat", Application.persistentDataPath);

            Assert.AreEqual(listOfNumbers, newListOfNumbers);

        }

        [Test]
        public void SaveAndLoadObservableListWithAbsolutePaths()
        {

            var listOfNumbers = new ObservableList<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            SaveManager.SaveData(listOfNumbers, "ObservableList.dat", Application.persistentDataPath);

            var newListOfNumbers = SaveManager.LoadData<ObservableList<int>>("ObservableList.dat", Application.persistentDataPath);

            Assert.AreEqual(listOfNumbers, newListOfNumbers);

        }

    }

}
#endif
