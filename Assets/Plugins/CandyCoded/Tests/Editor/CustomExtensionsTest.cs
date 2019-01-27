// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CandyCoded;

public class CustomExtensionsTest : TestSetup
{

    public class AddOrGetComponent : TestSetup
    {

        [Test]
        public void AddOrGetRigidbodyComponent()
        {

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Assert.IsNull(cube.GetComponent<Rigidbody>());

            var sampleController = cube.AddOrGetComponent<Rigidbody>();

            Assert.IsNotNull(cube.GetComponent<Rigidbody>());

            Assert.AreEqual(sampleController, cube.GetComponent<Rigidbody>());

        }

    }

    public class Compare : TestSetup
    {

        [Test]
        public void CompareTransformsParentToGameObject()
        {

            var parentGameObject = new GameObject("ParentGameObject");
            var childGameObject = new GameObject("ChildGameObject");
            childGameObject.transform.SetParent(parentGameObject.transform);

            Assert.IsTrue(childGameObject.transform.parent.Compare(parentGameObject.transform));

        }

        [Test]
        public void CompareTransformsNullParentToGameObject()
        {

            var parentGameObject = new GameObject("ParentGameObject");
            var childGameObject = new GameObject("ChildGameObject");

            Assert.IsFalse(childGameObject.transform.parent.Compare(parentGameObject.transform));

        }

        [Test]
        public void CompareTransformsNullParentToGameObjectNullParent()
        {

            var parentGameObject = new GameObject("ParentGameObject");
            var childGameObject = new GameObject("ChildGameObject");

            Assert.IsTrue(childGameObject.transform.parent.Compare(parentGameObject.transform.parent));

        }

    }

    public class Contains : TestSetup
    {

        [Test]
        public void LayerMaskContains()
        {

            LayerMask layerMask = ~0;

            Assert.IsTrue(layerMask.Contains(LayerMask.NameToLayer("Default")));
            Assert.IsTrue(layerMask.Contains(1));
            Assert.IsTrue(layerMask.Contains(0 | 1));

            layerMask = 0;

            Assert.IsFalse(layerMask.Contains(LayerMask.NameToLayer("UI")));
            Assert.IsFalse(layerMask.Contains(1));
            Assert.IsFalse(layerMask.Contains(0 | 1));

        }

        [Test]
        public void BitwiseContains()
        {

            int bitwiseMask = 0 | 1;

            Assert.IsTrue(bitwiseMask.Contains(1));
            Assert.IsFalse(bitwiseMask.Contains(2));

        }

    }

    public class EditKeyframeValue : TestSetup
    {

        [Test]
        public void EditKeyframeValueAnimationCurve()
        {

            var animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

            animationCurve.EditKeyframeValue(0, 10);

            Assert.AreEqual(10, animationCurve.keys[0].value);

        }

        [Test]
        public void EditKeyframeValueVector3AnimationCurve()
        {

            var animationCurve = new Vector3AnimationCurve
            {
                x = AnimationCurve.Linear(0, 0, 1, 1),
                y = AnimationCurve.Linear(0, 0, 1, 1),
                z = AnimationCurve.Linear(0, 0, 1, 1)
            };

            animationCurve.EditKeyframeValue(0, new Vector3(10, 15, 20));

            Assert.AreEqual(10, animationCurve.x.keys[0].value);
            Assert.AreEqual(15, animationCurve.y.keys[0].value);
            Assert.AreEqual(20, animationCurve.z.keys[0].value);

            Assert.AreEqual(1, animationCurve.x.keys[1].value);
            Assert.AreEqual(1, animationCurve.y.keys[1].value);
            Assert.AreEqual(1, animationCurve.z.keys[1].value);

        }

        [Test]
        public void EditKeyframeValueVector2AnimationCurve()
        {

            var animationCurve = new Vector2AnimationCurve
            {
                x = AnimationCurve.Linear(0, 0, 1, 1),
                y = AnimationCurve.Linear(0, 0, 1, 1)
            };

            animationCurve.EditKeyframeValue(0, new Vector2(10, 15));

            Assert.AreEqual(10, animationCurve.x.keys[0].value);
            Assert.AreEqual(15, animationCurve.y.keys[0].value);

            Assert.AreEqual(1, animationCurve.x.keys[1].value);
            Assert.AreEqual(1, animationCurve.y.keys[1].value);

        }

    }

    [Ignore("NotImplemented")]
    public class GetChildrenByName : TestSetup
    {


    }

    public class GetLayerMask : TestSetup
    {

        [Test]
        public void GetLayerMaskFromGameObject()
        {

            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.layer = LayerMask.NameToLayer("UI");

            LayerMask layerMask = LayerMask.GetMask(LayerMask.LayerToName(gameObject.layer));

            var calculatedLayerMask = gameObject.GetLayerMask();

            Assert.AreEqual(layerMask.value, calculatedLayerMask.value);

        }

    }

    public class IsLoopingAnimationCurve : TestSetup
    {

        [Test]
        public void IsLoopingAnimationCurveOnAnimationCurve()
        {

            var animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

            Assert.IsFalse(animationCurve.IsLooping());

            animationCurve.postWrapMode = WrapMode.Loop;

            Assert.IsTrue(animationCurve.IsLooping());

        }

    }

    [Ignore("NotImplemented")]
    public class LookAt2D : TestSetup
    {


    }

    public class MaxTime : TestSetup
    {

        [Test]
        public void MaxTimeAnimationCurve()
        {

            var animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

            Assert.AreEqual(1, animationCurve.MaxTime());

            animationCurve = AnimationCurve.Linear(0, 0, 5, 1);

            Assert.AreEqual(5, animationCurve.MaxTime());

        }

    }

    public class Permutations : TestSetup
    {

        [Test]
        public void PermutationsFromList()
        {

            var list = new List<int> { 1, 2, 3 };

            var listOfCombinations = list.Permutations();

            Assert.AreEqual(7, listOfCombinations.Count);

            Assert.AreEqual(new List<int> { 1 }, listOfCombinations[0]);
            Assert.AreEqual(new List<int> { 2 }, listOfCombinations[1]);
            Assert.AreEqual(new List<int> { 1, 2 }, listOfCombinations[2]);
            Assert.AreEqual(new List<int> { 3 }, listOfCombinations[3]);
            Assert.AreEqual(new List<int> { 1, 3 }, listOfCombinations[4]);
            Assert.AreEqual(new List<int> { 2, 3 }, listOfCombinations[5]);
            Assert.AreEqual(new List<int> { 1, 2, 3 }, listOfCombinations[6]);

        }

    }

    public class Random : TestSetup
    {

        [Test]
        public void RandomItemFromArray()
        {

            var array = new float[] { 1, 2, 3, 4, 5 };
            var randomItemFromArray = array.Random();

            Assert.IsTrue(array.Contains(randomItemFromArray));

        }

        [Test]
        public void RandomItemFromList()
        {

            var list = new List<float> { 1, 2, 3, 4, 5 };
            var randomItemFromList = list.Random();

            Assert.IsTrue(list.Contains(randomItemFromList));

        }

    }

    public class Shuffle : TestSetup
    {

        [Test]
        public void ListShuffle()
        {

            var numberRange = new List<int>();

            for (var i = 0; i < 10; i += 1)
            {
                numberRange.Add(i);
            }

            Assert.AreNotEqual(numberRange, numberRange.Shuffle());

        }

        [Test]
        public void ListShuffleWithoutChangingReference()
        {

            var numberRange = new List<int>();

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
        public void ListSlice()
        {

            var numberRange = new List<int>();

            for (var i = 0; i < 10; i += 1)
            {
                numberRange.Add(i);
            }

            Assert.AreEqual(2, numberRange.Slice(1, 2).Count);
            Assert.AreEqual(10, numberRange.Count);

        }

        [Test]
        public void ListSliceWithoutIndex()
        {

            var numberRange = new List<int>();

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
        public void ListSplice()
        {

            var numberRange = new List<int>();

            for (var i = 0; i < 10; i += 1)
            {
                numberRange.Add(i);
            }

            Assert.AreEqual(2, numberRange.Splice(1, 2).Count);
            Assert.AreEqual(8, numberRange.Count);

        }

        [Test]
        public void ListSpliceWithoutIndex()
        {

            var numberRange = new List<int>();

            for (var i = 0; i < 10; i += 1)
            {
                numberRange.Add(i);
            }

            Assert.AreEqual(2, numberRange.Splice(2).Count);
            Assert.AreEqual(8, numberRange.Count);

        }

    }

}
#endif
