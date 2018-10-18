// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine.TestTools;

public class ObservableListTest
{

    private readonly List<int> sampleList = new List<int> { 1, 2, 3, 4, 5 };

    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [Test]
    public void Create()
    {

        var list = new ObservableList<int>();

        Assert.AreEqual(0, list.Count);

    }

    [Test]
    public void CreateWithValues()
    {

        var list = new ObservableList<int> { 1, 2, 3, 4, 5 };

        Assert.AreEqual(5, list.Count);

    }

    [Test]
    public void CreateWithList()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(5, list.Count);

    }

    [Test]
    public void GetItemValues()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(2, list[1]);
        Assert.AreEqual(3, list[2]);
        Assert.AreEqual(4, list[3]);
        Assert.AreEqual(5, list[4]);

    }

    [Test]
    public void AddItem()
    {

        var list = new ObservableList<int>();

        list.Add(1);

        Assert.AreEqual(1, list[0]);

    }

    [Test]
    public void Clear()
    {

        var list = new ObservableList<int>();

        list.Add(1);

        Assert.AreEqual(1, list.Count);

        list.Clear();

        Assert.AreEqual(0, list.Count);

    }

    [Test]
    public void ContainsItem()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(true, list.Contains(2));
        Assert.AreEqual(false, list.Contains(10));

    }

    [Test]
    public void CopyToArrayWithIndex()
    {

        var list = new ObservableList<int>(sampleList);

        int[] array = new int[10];

        list.CopyTo(array, 2);

        Assert.AreEqual(1, array[2]);
        Assert.AreEqual(2, array[3]);
        Assert.AreEqual(3, array[4]);
        Assert.AreEqual(4, array[5]);
        Assert.AreEqual(5, array[6]);

    }

    [Test]
    public void IndexOfItem()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(0, list.IndexOf(1));
        Assert.AreEqual(1, list.IndexOf(2));

    }

    [Test]
    public void InsertItem()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(2, list[1]);

        list.Insert(1, 6);

        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(6, list[1]);
        Assert.AreEqual(2, list[2]);

    }

    [Test]
    public void RemoveItem()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(2, list[1]);

        list.Remove(1);

        Assert.AreEqual(2, list[0]);

    }

    [Test]
    public void RemoveAtIndex()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(2, list[1]);

        list.RemoveAt(0);

        Assert.AreEqual(2, list[0]);

    }

    [Test]
    public void GetRange()
    {

        var list = new ObservableList<int>(sampleList);

        var newList = list.GetRange(1, 2);

        Assert.AreEqual(2, newList.Count);

        Assert.AreEqual(2, newList[0]);
        Assert.AreEqual(3, newList[1]);

    }

    [Test]
    public void AddRangeWithList()
    {

        var list = new ObservableList<int>();

        Assert.AreEqual(0, list.Count);

        list.AddRange(new List<int> { 1, 2, 3 });

        Assert.AreEqual(3, list.Count);

    }

    [Test]
    public void AddRangeWithObservableList()
    {

        var list = new ObservableList<int>();

        Assert.AreEqual(0, list.Count);

        list.AddRange(new ObservableList<int> { 1, 2, 3 });

        Assert.AreEqual(3, list.Count);

    }

    [Test]
    public void RemoveRange()
    {

        var list = new ObservableList<int>(sampleList);

        list.RemoveRange(0, 3);

        Assert.AreEqual(new ObservableList<int> { 4, 5 }, list);

    }

    [Test]
    public void Shuffle()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreNotEqual(numberRange, numberRange.Shuffle());

    }

    [Test]
    public void ShuffleWithoutChangingReference()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        numberRange.Shuffle();

        for (int i = 0; i < 10; i += 1)
        {
            Assert.AreEqual(i, numberRange[i]);
        }

    }

    [Test]
    public void Slice()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreEqual(2, numberRange.Slice(1, 2).Count);
        Assert.AreEqual(10, numberRange.Count);

    }

    [Test]
    public void SliceWithoutIndex()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreEqual(2, numberRange.Slice(2).Count);
        Assert.AreEqual(10, numberRange.Count);

    }

    [Test]
    public void Splice()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreEqual(2, numberRange.Splice(1, 2).Count);
        Assert.AreEqual(8, numberRange.Count);

    }

    [Test]
    public void SpliceWithoutIndex()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreEqual(2, numberRange.Splice(2).Count);
        Assert.AreEqual(8, numberRange.Count);

    }

    [UnityTest]
    public IEnumerator AddEvent()
    {

        var testList = new ObservableList<int>();

        int? addedItem = null;

        testList.AddEvent += (int item) => { addedItem = item; };

        testList.Add(1);

        yield return null;

        Assert.IsTrue(addedItem.HasValue);
        Assert.AreEqual(1, addedItem.Value);

    }

    [UnityTest]
    public IEnumerator ClearEvent()
    {

        var testList = new ObservableList<int> { 1, 2, 3, 4, 5 };

        int numberOfItemsInList = testList.Count;

        testList.ClearEvent += () => { numberOfItemsInList = testList.Count; };

        testList.Clear();

        yield return null;

        Assert.AreEqual(0, numberOfItemsInList);

    }

    [UnityTest]
    public IEnumerator RemoveEventWithItem()
    {

        var testList = new ObservableList<int> { 1, 2, 3, 4, 5 };

        int? itemRemoved = null;

        testList.RemoveEvent += (int item) => { itemRemoved = item; };

        testList.Remove(2);

        yield return null;

        Assert.IsTrue(itemRemoved.HasValue);
        Assert.AreEqual(2, itemRemoved.Value);

    }

    [UnityTest]
    public IEnumerator RemoveEventWithIndex()
    {

        var testList = new ObservableList<int> { 1, 2, 3, 4, 5 };

        int? itemRemoved = null;

        testList.RemoveEvent += (int item) => { itemRemoved = item; };

        testList.RemoveAt(1);

        yield return null;

        Assert.IsTrue(itemRemoved.HasValue);
        Assert.AreEqual(2, itemRemoved.Value);

    }

    [Test]
    public void BrokenTest()
    {

        ObservableList<int> list = new ObservableList<int> { 1, 2, 3, 4, 5 };
        ObservableList<int> newList = new ObservableList<int>();

        newList = list.GetRange(2, 2);

        Assert.AreEqual(new List<int> { 3, 4 }, newList);

        newList.AddRange(new ObservableList<int> { 4, 5, 6 });

        Assert.AreEqual(new List<int> { 3, 4, 4, 5, 6 }, newList);

        newList.RemoveRange(0, 3);

        Assert.AreEqual(new ObservableList<int> { 5, 6 }, newList);

    }

}
#endif
