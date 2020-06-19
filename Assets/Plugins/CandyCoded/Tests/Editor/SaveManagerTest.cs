// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace CandyCoded.Tests
{

    public class SaveManagerTest : TestSetup
    {

        private const string listPathFileName = "List.dat";

        private const string observableListPathFileName = "ObservableList.dat";

        private static string listPath => Path.Combine(Application.persistentDataPath, listPathFileName);

        private static string observableListPath =>
            Path.Combine(Application.persistentDataPath, observableListPathFileName);

        [SetUp]
        [TearDown]
        public static void DeleteFiles()
        {

            FileUtil.DeleteFileOrDirectory(listPath);
            FileUtil.DeleteFileOrDirectory(observableListPath);

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

            SaveManager.SaveData(listOfNumbers, listPath);

            var newListOfNumbers = SaveManager.LoadData<List<int>>(listPath);

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

            SaveManager.SaveData(listOfNumbers, observableListPathFileName);

            var newListOfNumbers = SaveManager.LoadData<ObservableList<int>>(observableListPathFileName);

            Assert.AreEqual(listOfNumbers, newListOfNumbers);

        }

        [Test]
        public void SaveAndDeleteList()
        {

            var listOfNumbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            SaveManager.SaveData(listOfNumbers, listPathFileName);

            Assert.IsTrue(File.Exists(listPath));

            SaveManager.DeleteData(listPathFileName);

            Assert.IsFalse(File.Exists(listPath));

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

            SaveManager.SaveData(listOfNumbers, listPathFileName, Application.persistentDataPath);

            var newListOfNumbers = SaveManager.LoadData<List<int>>(listPathFileName, Application.persistentDataPath);

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

            SaveManager.SaveData(listOfNumbers, observableListPathFileName, Application.persistentDataPath);

            var newListOfNumbers =
                SaveManager.LoadData<ObservableList<int>>(observableListPathFileName, Application.persistentDataPath);

            Assert.AreEqual(listOfNumbers, newListOfNumbers);

        }

        [Test]
        public void SaveAndDeleteListWithAbsolutePaths()
        {

            var listOfNumbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            SaveManager.SaveData(listOfNumbers, listPathFileName, Application.persistentDataPath);

            Assert.IsTrue(File.Exists(listPath));

            SaveManager.DeleteData("List.dat", Application.persistentDataPath);

            Assert.IsFalse(File.Exists(listPath));

        }

    }

}
#endif
