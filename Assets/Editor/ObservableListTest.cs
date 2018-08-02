using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ObservableListTest
{

    private readonly List<int> sampleList = new List<int> { 1, 2, 3, 4, 5 };

    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [Test]
    public void CreateObservableList()
    {

        var list = new ObservableList<int>();

        Assert.AreEqual(0, list.Count);

    }

    [Test]
    public void CreateObservableListWithValues()
    {

        var list = new ObservableList<int> { 1, 2, 3, 4, 5 };

        Assert.AreEqual(5, list.Count);

    }

    [Test]
    public void CreateObservableListWithList()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(5, list.Count);

    }

    [Test]
    public void GetObservableListItemValues()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(2, list[1]);
        Assert.AreEqual(3, list[2]);
        Assert.AreEqual(4, list[3]);
        Assert.AreEqual(5, list[4]);

    }

    [Test]
    public void AddItemToObservableList()
    {

        var list = new ObservableList<int>();

        list.Add(1);

        Assert.AreEqual(1, list[0]);

    }

    [Test]
    public void ClearObservableList()
    {

        var list = new ObservableList<int>();

        list.Add(1);

        Assert.AreEqual(1, list.Count);

        list.Clear();

        Assert.AreEqual(0, list.Count);

    }

    [Test]
    public void ContainsItemInObservableList()
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
    public void IndexOfItemInObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(0, list.IndexOf(1));
        Assert.AreEqual(1, list.IndexOf(2));

    }

    [Test]
    public void InsertItemIntoObservableList()
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
    public void RemoveItemFromObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(2, list[1]);

        list.Remove(1);

        Assert.AreEqual(2, list[0]);

    }

    [Test]
    public void RemoveAtFromObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(2, list[1]);

        list.RemoveAt(0);

        Assert.AreEqual(2, list[0]);

    }

    [Test]
    public void GetRangeFromObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        var newList = list.GetRange(1, 2);

        Assert.AreEqual(2, newList.Count);

        Assert.AreEqual(2, newList[0]);
        Assert.AreEqual(3, newList[1]);

    }

    [Test]
    public void AddRangeToObservableListWithList()
    {

        var list = new ObservableList<int>();

        Assert.AreEqual(0, list.Count);

        list.AddRange(new List<int> { 1, 2, 3 });

        Assert.AreEqual(3, list.Count);

    }

    [Test]
    public void AddRangeToObservableListWithObservableList()
    {

        var list = new ObservableList<int>();

        Assert.AreEqual(0, list.Count);

        list.AddRange(new ObservableList<int> { 1, 2, 3 });

        Assert.AreEqual(3, list.Count);

    }

    [Test]
    public void RemoveRangeFromObservableList()
    {

        var list = new ObservableList<int>(sampleList);

        list.RemoveRange(1, 2);

        Assert.AreEqual(3, list.Count);

    }

    [Test]
    public void ObservableListShuffle()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreNotEqual(numberRange, numberRange.Shuffle());

    }

    [Test]
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
            Assert.AreEqual(i, numberRange[i]);
        }

    }

    [Test]
    public void ObservableListSlice()
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
    public void ObservableListSliceWithoutIndex()
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
    public void ObservableListSplice()
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
    public void ObservableListSpliceWithoutIndex()
    {

        var numberRange = new ObservableList<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreEqual(2, numberRange.Splice(2).Count);
        Assert.AreEqual(8, numberRange.Count);

    }

}
