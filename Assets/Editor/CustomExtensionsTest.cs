// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SampleController : MonoBehaviour
{

}

public class CustomExtensionsTest
{

    [NUnit.Framework.SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [NUnit.Framework.Test]
    public void AddOrGetComponent()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        NUnit.Framework.Assert.IsNull(cube.GetComponent<SampleController>());

        var sampleController = cube.AddOrGetComponent<SampleController>();

        NUnit.Framework.Assert.IsNotNull(cube.GetComponent<SampleController>());

        NUnit.Framework.Assert.AreEqual(sampleController, cube.GetComponent<SampleController>());

    }

    [NUnit.Framework.Test]
    public void LayerMaskContains()
    {

        LayerMask layerMask = ~0;

        NUnit.Framework.Assert.IsTrue(layerMask.Contains(LayerMask.NameToLayer("Default")));
        NUnit.Framework.Assert.IsTrue(layerMask.Contains(1));
        NUnit.Framework.Assert.IsTrue(layerMask.Contains(0 | 1));

        layerMask = 0;

        NUnit.Framework.Assert.IsFalse(layerMask.Contains(LayerMask.NameToLayer("UI")));
        NUnit.Framework.Assert.IsFalse(layerMask.Contains(1));
        NUnit.Framework.Assert.IsFalse(layerMask.Contains(0 | 1));

    }

    [NUnit.Framework.Test]
    public void BitwiseContains()
    {

        int bitwiseMask = 0 | 1;

        NUnit.Framework.Assert.IsTrue(bitwiseMask.Contains(1));
        NUnit.Framework.Assert.IsFalse(bitwiseMask.Contains(2));

    }

    [NUnit.Framework.Test]
    public void EditKeyframeValueAnimationCurve()
    {

        var animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        animationCurve.EditKeyframeValue(0, 10);

        NUnit.Framework.Assert.AreEqual(10, animationCurve.keys[0].value);

    }

    [NUnit.Framework.Test]
    public void EditKeyframeValueVector3AnimationCurve()
    {

        var animationCurve = new CandyCoded.Vector3AnimationCurve();

        animationCurve.x = AnimationCurve.Linear(0, 0, 1, 1);
        animationCurve.y = AnimationCurve.Linear(0, 0, 1, 1);
        animationCurve.z = AnimationCurve.Linear(0, 0, 1, 1);

        animationCurve.EditKeyframeValue(0, new Vector3(10, 15, 20));

        NUnit.Framework.Assert.AreEqual(10, animationCurve.x.keys[0].value);
        NUnit.Framework.Assert.AreEqual(15, animationCurve.y.keys[0].value);
        NUnit.Framework.Assert.AreEqual(20, animationCurve.z.keys[0].value);

        NUnit.Framework.Assert.AreEqual(1, animationCurve.x.keys[1].value);
        NUnit.Framework.Assert.AreEqual(1, animationCurve.y.keys[1].value);
        NUnit.Framework.Assert.AreEqual(1, animationCurve.z.keys[1].value);

    }

    [NUnit.Framework.Test]
    public void EditKeyframeValueVector2AnimationCurve()
    {

        var animationCurve = new CandyCoded.Vector2AnimationCurve();

        animationCurve.x = AnimationCurve.Linear(0, 0, 1, 1);
        animationCurve.y = AnimationCurve.Linear(0, 0, 1, 1);

        animationCurve.EditKeyframeValue(0, new Vector2(10, 15));

        NUnit.Framework.Assert.AreEqual(10, animationCurve.x.keys[0].value);
        NUnit.Framework.Assert.AreEqual(15, animationCurve.y.keys[0].value);

        NUnit.Framework.Assert.AreEqual(1, animationCurve.x.keys[1].value);
        NUnit.Framework.Assert.AreEqual(1, animationCurve.y.keys[1].value);

    }

    [NUnit.Framework.Test]
    public void IsLoopingAnimationCurve()
    {

        var animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        NUnit.Framework.Assert.IsFalse(animationCurve.IsLooping());

        animationCurve.postWrapMode = WrapMode.Loop;

        NUnit.Framework.Assert.IsTrue(animationCurve.IsLooping());

    }

    [NUnit.Framework.Test]
    public void ListShuffle()
    {

        var numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreNotEqual(numberRange, numberRange.Shuffle());

    }

    [NUnit.Framework.Test]
    public void ListShuffleWithoutChangingReference()
    {

        var numberRange = new List<int>();

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
    public void ListSlice()
    {

        var numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreEqual(2, numberRange.Slice(1, 2).Count);
        NUnit.Framework.Assert.AreEqual(10, numberRange.Count);

    }

    [NUnit.Framework.Test]
    public void ListSliceWithoutIndex()
    {

        var numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreEqual(2, numberRange.Slice(2).Count);
        NUnit.Framework.Assert.AreEqual(10, numberRange.Count);

    }

    [NUnit.Framework.Test]
    public void ListSplice()
    {

        var numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreEqual(2, numberRange.Splice(1, 2).Count);
        NUnit.Framework.Assert.AreEqual(8, numberRange.Count);

    }

    [NUnit.Framework.Test]
    public void ListSpliceWithoutIndex()
    {

        var numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        NUnit.Framework.Assert.AreEqual(2, numberRange.Splice(2).Count);
        NUnit.Framework.Assert.AreEqual(8, numberRange.Count);

    }

    [NUnit.Framework.Test]
    public void MaxTimeAnimationCurve()
    {

        var animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        NUnit.Framework.Assert.AreEqual(1, animationCurve.MaxTime());

        animationCurve = AnimationCurve.Linear(0, 0, 5, 1);

        NUnit.Framework.Assert.AreEqual(5, animationCurve.MaxTime());

    }

}
#endif
