// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ObservableListTest
{

    private readonly List<int> sampleList = new List<int> { 1, 2, 3, 4, 5 };

    [NUnit.Framework.SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [NUnit.Framework.Test]
    public void CreateObservableList()
    {

        var list = new ObservableList<int>();

        NUnit.Framework.Assert.AreEqual(0, list.Count);

    }

    [NUnit.Framework.Test]
    public void CreateObservableListWithValues()
    {

        var list = new ObservableList<int> { 1, 2, 3, 4, 5 };

        NUnit.Framework.Assert.AreEqual(5, list.Count);

    }

    [NUnit.Framework.Test]
    public void CreateObservableListWithList()
    {

        var list = new ObservableList<int>(sampleList);

        NUnit.Framework.Assert.AreEqual(5, list.Count);

    }

    [NUnit.Framework.Test]
    public void GetObservableListItemValues()
    {

        var list = new ObservableList<int>(sampleList);

        NUnit.Framework.Assert.AreEqual(1, list[0]);
        NUnit.Framework.Assert.AreEqual(2, list[1]);
        NUnit.Framework.Assert.AreEqual(3, list[2]);
        NUnit.Framework.Assert.AreEqual(4, list[3]);
        NUnit.Framework.Assert.AreEqual(5, list[4]);

    }

    [NUnit.Framework.Test]
    public void AddItemToObservableList()
    {

        var list = new ObservableList<int>();

        list.Add(1);

        NUnit.Framework.Assert.AreEqual(1, list[0]);

    }

    [NUnit.Framework.Test]
    public void ClearObservableList()
    {

        var list = new ObservableList<int>();

        list.Add(1);

        NUnit.Framework.Assert.AreEqual(1, list.Count);

        list.Clear();

        NUnit.Framework.Assert.AreEqual(0, list.Count);

    }

    [NUnit.Framework.Test]
    public void ContainsItemInObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        NUnit.Framework.Assert.AreEqual(true, list.Contains(2));
        NUnit.Framework.Assert.AreEqual(false, list.Contains(10));

    }

    [NUnit.Framework.Test]
    public void CopyToArrayWithIndex()
    {

        var list = new ObservableList<int>(sampleList);

        int[] array = new int[10];

        list.CopyTo(array, 2);

        NUnit.Framework.Assert.AreEqual(1, array[2]);
        NUnit.Framework.Assert.AreEqual(2, array[3]);
        NUnit.Framework.Assert.AreEqual(3, array[4]);
        NUnit.Framework.Assert.AreEqual(4, array[5]);
        NUnit.Framework.Assert.AreEqual(5, array[6]);

    }

    [NUnit.Framework.Test]
    public void IndexOfItemInObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        NUnit.Framework.Assert.AreEqual(0, list.IndexOf(1));
        NUnit.Framework.Assert.AreEqual(1, list.IndexOf(2));

    }

    [NUnit.Framework.Test]
    public void InsertItemIntoObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        NUnit.Framework.Assert.AreEqual(1, list[0]);
        NUnit.Framework.Assert.AreEqual(2, list[1]);

        list.Insert(1, 6);

        NUnit.Framework.Assert.AreEqual(1, list[0]);
        NUnit.Framework.Assert.AreEqual(6, list[1]);
        NUnit.Framework.Assert.AreEqual(2, list[2]);

    }

    [NUnit.Framework.Test]
    public void RemoveItemFromObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        NUnit.Framework.Assert.AreEqual(1, list[0]);
        NUnit.Framework.Assert.AreEqual(2, list[1]);

        list.Remove(1);

        NUnit.Framework.Assert.AreEqual(2, list[0]);

    }

    [NUnit.Framework.Test]
    public void RemoveAtFromObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        NUnit.Framework.Assert.AreEqual(1, list[0]);
        NUnit.Framework.Assert.AreEqual(2, list[1]);

        list.RemoveAt(0);

        NUnit.Framework.Assert.AreEqual(2, list[0]);

    }

    [NUnit.Framework.Test]
    public void GetRangeFromObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        var newList = list.GetRange(1, 2);

        NUnit.Framework.Assert.AreEqual(2, newList.Count);

        NUnit.Framework.Assert.AreEqual(2, newList[0]);
        NUnit.Framework.Assert.AreEqual(3, newList[1]);

    }

    [NUnit.Framework.Test]
    public void AddRangeToObservableListWithList()
    {

        var list = new ObservableList<int>();

        NUnit.Framework.Assert.AreEqual(0, list.Count);

        list.AddRange(new List<int> { 1, 2, 3 });

        NUnit.Framework.Assert.AreEqual(3, list.Count);

    }

    [NUnit.Framework.Test]
    public void AddRangeToObservableListWithObservableList()
    {

        var list = new ObservableList<int>();

        NUnit.Framework.Assert.AreEqual(0, list.Count);

        list.AddRange(new ObservableList<int> { 1, 2, 3 });

        NUnit.Framework.Assert.AreEqual(3, list.Count);

    }

    [NUnit.Framework.Test]
    public void RemoveRangeFromObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        list.RemoveRange(1, 2);

        NUnit.Framework.Assert.AreEqual(3, list.Count);

    }

    [NUnit.Framework.Test]
    public void ObservableListShuffle()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreNotEqual(numberRange, numberRange.Shuffle());

    }

    [NUnit.Framework.Test]
    public void ObservableListShuffleWithoutChangingReference()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        numberRange.Shuffle();

        for (int i = 0; i < 10; i += 1)
        {
            NUnit.Framework.Assert.AreEqual(i, numberRange[i]);
        }

    }

    [NUnit.Framework.Test]
    public void ObservableListSlice()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreEqual(2, numberRange.Slice(1, 2).Count);
        NUnit.Framework.Assert.AreEqual(10, numberRange.Count);

    }

    [NUnit.Framework.Test]
    public void ObservableListSliceWithoutIndex()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreEqual(2, numberRange.Slice(2).Count);
        NUnit.Framework.Assert.AreEqual(10, numberRange.Count);

    }

    [NUnit.Framework.Test]
    public void ObservableListSplice()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreEqual(2, numberRange.Splice(1, 2).Count);
        NUnit.Framework.Assert.AreEqual(8, numberRange.Count);

    }

    [NUnit.Framework.Test]
    public void ObservableListSpliceWithoutIndex()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreEqual(2, numberRange.Splice(2).Count);
        NUnit.Framework.Assert.AreEqual(8, numberRange.Count);

    }

}
#endif
