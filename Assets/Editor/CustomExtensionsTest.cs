/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2018 Scott Doxey
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SampleController : MonoBehaviour
{

}

public class CustomExtensionsTest
{

    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [Test]
    public void AddOrGetComponent()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Assert.IsNull(cube.GetComponent<SampleController>());

        var sampleController = cube.AddOrGetComponent<SampleController>();

        Assert.IsNotNull(cube.GetComponent<SampleController>());

        Assert.AreEqual(sampleController, cube.GetComponent<SampleController>());

    }

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

        var animationCurve = new CandyCoded.Vector3AnimationCurve();

        animationCurve.x = AnimationCurve.Linear(0, 0, 1, 1);
        animationCurve.y = AnimationCurve.Linear(0, 0, 1, 1);
        animationCurve.z = AnimationCurve.Linear(0, 0, 1, 1);

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

        var animationCurve = new CandyCoded.Vector2AnimationCurve();

        animationCurve.x = AnimationCurve.Linear(0, 0, 1, 1);
        animationCurve.y = AnimationCurve.Linear(0, 0, 1, 1);

        animationCurve.EditKeyframeValue(0, new Vector2(10, 15));

        Assert.AreEqual(10, animationCurve.x.keys[0].value);
        Assert.AreEqual(15, animationCurve.y.keys[0].value);

        Assert.AreEqual(1, animationCurve.x.keys[1].value);
        Assert.AreEqual(1, animationCurve.y.keys[1].value);

    }

    [Test]
    public void IsLoopingAnimationCurve()
    {

        var animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        Assert.IsFalse(animationCurve.IsLooping());

        animationCurve.postWrapMode = WrapMode.Loop;

        Assert.IsTrue(animationCurve.IsLooping());

    }

    [Test]
    public void ListShuffle()
    {

        var numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreNotEqual(numberRange, numberRange.Shuffle());

    }

    [Test]
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
            Assert.AreEqual(i, numberRange[i]);
        }

    }

    [Test]
    public void ListSlice()
    {

        var numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
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

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreEqual(2, numberRange.Slice(2).Count);
        Assert.AreEqual(10, numberRange.Count);

    }

    [Test]
    public void ListSplice()
    {

        var numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
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

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreEqual(2, numberRange.Splice(2).Count);
        Assert.AreEqual(8, numberRange.Count);

    }

    [Test]
    public void MaxTimeAnimationCurve()
    {

        var animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        Assert.AreEqual(1, animationCurve.MaxTime());

        animationCurve = AnimationCurve.Linear(0, 0, 5, 1);

        Assert.AreEqual(5, animationCurve.MaxTime());

    }

}
