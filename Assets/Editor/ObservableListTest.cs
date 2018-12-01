// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;

public class ObservableListTest
{

    public class AddEvent : TestSetup
    {

        [UnityTest]
        public IEnumerator SetupAddEventAndListenForResponse()
        {

            var testList = new ObservableList<int>();

            int? addedItem = null;

            testList.AddEvent += (int item) => { addedItem = item; };

            testList.Add(1);

            yield return null;

            Assert.IsTrue(addedItem.HasValue);
            Assert.AreEqual(1, addedItem.Value);

        }

    }

    public class ClearEvent : TestSetup
    {

        [UnityTest]
        public IEnumerator SetupClearEventAndListenForResponse()
        {

            var testList = new ObservableList<int> { 1, 2, 3, 4, 5 };

            int numberOfItemsInList = testList.Count;

            testList.ClearEvent += () => { numberOfItemsInList = testList.Count; };

            testList.Clear();

            yield return null;

            Assert.AreEqual(0, numberOfItemsInList);

        }

    }

    public class RemoveEvent : TestSetup
    {

        [UnityTest]
        public IEnumerator SetupRemoveEventWithItemAndListenForResponse()
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
        public IEnumerator SetupRemoveEventWithIndexAndListenForResponse()
        {

            var testList = new ObservableList<int> { 1, 2, 3, 4, 5 };

            int? itemRemoved = null;

            testList.RemoveEvent += (int item) => { itemRemoved = item; };

            testList.RemoveAt(1);

            yield return null;

            Assert.IsTrue(itemRemoved.HasValue);
            Assert.AreEqual(2, itemRemoved.Value);

        }

    }

    public class Get : TestSetup
    {

        [Test]
        public void GetItemValuesWithIndex()
        {

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
            Assert.AreEqual(4, list[3]);
            Assert.AreEqual(5, list[4]);

        }

    }

    public class Constructor : TestSetup
    {

        [Test]
        public void CreateEmpty()
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

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            Assert.AreEqual(5, list.Count);

        }

    }

    public class Add : TestSetup
    {

        [Test]
        public void AddItem()
        {

            var list = new ObservableList<int>
        {
            1
        };

            list.Add(2);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);

        }

    }

    public class Clear : TestSetup
    {

        [Test]
        public void ClearList()
        {

            var list = new ObservableList<int>
        {
            1
        };

            Assert.AreEqual(1, list.Count);

            list.Clear();

            Assert.AreEqual(0, list.Count);

        }

    }

    public class Contains : TestSetup
    {

        [Test]
        public void ContainsItem()
        {

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            Assert.AreEqual(true, list.Contains(2));
            Assert.AreEqual(false, list.Contains(10));

        }

    }

    public class CopyTo : TestSetup
    {

        [Test]
        public void CopyToArrayWithIndex()
        {

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            var array = new int[10];

            list.CopyTo(array, 2);

            Assert.AreEqual(1, array[2]);
            Assert.AreEqual(2, array[3]);
            Assert.AreEqual(3, array[4]);
            Assert.AreEqual(4, array[5]);
            Assert.AreEqual(5, array[6]);

        }

    }

    public class IndexOf : TestSetup
    {

        [Test]
        public void IndexOfItem()
        {

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(1, list.IndexOf(2));

        }

    }

    public class Insert : TestSetup
    {

        [Test]
        public void InsertItem()
        {

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);

            list.Insert(1, 6);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(6, list[1]);
            Assert.AreEqual(2, list[2]);

        }

    }

    public class Remove : TestSetup
    {

        [Test]
        public void RemoveItem()
        {

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);

            list.Remove(1);

            Assert.AreEqual(2, list[0]);

        }

    }

    public class RemoveAt : TestSetup
    {

        [Test]
        public void RemoveItemAtIndex()
        {

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);

            list.RemoveAt(0);

            Assert.AreEqual(2, list[0]);

        }

    }

    public class GetRange : TestSetup
    {

        [Test]
        public void GetRangeWithIndexes()
        {

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            var newList = list.GetRange(1, 2);

            Assert.AreEqual(2, newList.Count);

            Assert.AreEqual(2, newList[0]);
            Assert.AreEqual(3, newList[1]);

        }

    }

    public class AddRange : TestSetup
    {

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

    }

    public class RemoveRange : TestSetup
    {

        [Test]
        public void RemoveRangeFromList()
        {

            var list = new ObservableList<int>(new List<int> { 1, 2, 3, 4, 5 });

            list.RemoveRange(0, 3);

            Assert.AreEqual(new ObservableList<int> { 4, 5 }, list);

        }

    }

    public class Random : TestSetup
    {

        [Test]
        public void ReturnRandomItem()
        {

            var testList = new ObservableList<int> { 1, 2, 3, 4, 5 };

            var randomItemFromList = testList.Random();

            Assert.IsTrue(testList.Contains(randomItemFromList));

        }

    }

    public class Shuffle : TestSetup
    {

        [Test]
        public void ShuffleValues()
        {

            var numberRange = new ObservableList<int>();

            for (var i = 0; i < 10; i += 1)
            {
                numberRange.Add(i);
            }

            Assert.AreNotEqual(numberRange, numberRange.Shuffle());

        }

        [Test]
        public void ShuffleValuesWithoutChangingReference()
        {

            var numberRange = new ObservableList<int>();

            for (var i = 0; i < 10; i += 1)
            {
                numberRange.Add(i);
            }

            numberRange.Shuffle();

            for (var i = 0; i < 10; i += 1)
            {
                Assert.AreEqual(i, numberRange[i]);
            }

        }

    }

    public class Slice : TestSetup
    {

        [Test]
        public void SliceItemsFromList()
        {

            var numberRange = new ObservableList<int>();

            for (var i = 0; i < 10; i += 1)
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

            for (var i = 0; i < 10; i += 1)
            {
                numberRange.Add(i);
            }

            Assert.AreEqual(2, numberRange.Slice(2).Count);
            Assert.AreEqual(10, numberRange.Count);

        }

    }

    public class Splice : TestSetup
    {

        [Test]
        public void SpliceItemsOutOfList()
        {

            var numberRange = new ObservableList<int>();

            for (var i = 0; i < 10; i += 1)
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

            for (var i = 0; i < 10; i += 1)
            {
                numberRange.Add(i);
            }

            Assert.AreEqual(2, numberRange.Splice(2).Count);
            Assert.AreEqual(8, numberRange.Count);

        }

    }

    [Ignore("NotImplemented")]
    public class ToList : TestSetup
    {


    }

}
#endif
