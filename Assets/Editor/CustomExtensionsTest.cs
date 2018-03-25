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

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Assert.IsNull(cube.GetComponent<SampleController>());

        SampleController sampleController = cube.AddOrGetComponent<SampleController>();

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

        AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        animationCurve.EditKeyframeValue(0, 10);

        Assert.AreEqual(10, animationCurve.keys[0].value);

    }

    [Test]
    public void EditKeyframeValueVector3AnimationCurve()
    {

        CandyCoded.Vector3AnimationCurve animationCurve = new CandyCoded.Vector3AnimationCurve();

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

        CandyCoded.Vector2AnimationCurve animationCurve = new CandyCoded.Vector2AnimationCurve();

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

        AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        Assert.IsFalse(animationCurve.IsLooping());

        animationCurve.postWrapMode = WrapMode.Loop;

        Assert.IsTrue(animationCurve.IsLooping());

    }

    [Test]
    public void ListShuffle()
    {

        List<int> numberRange = new List<int>();

        for (int i = 0; i < 10; i += 1)
        {
            numberRange.Add(i);
        }

        Assert.AreNotEqual(numberRange, numberRange.Shuffle());

    }

    [Test]
    public void ListShuffleWithoutChangingReference()
    {

        List<int> numberRange = new List<int>();

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

        List<int> numberRange = new List<int>();

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

        List<int> numberRange = new List<int>();

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

        List<int> numberRange = new List<int>();

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

        List<int> numberRange = new List<int>();

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

        AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        Assert.AreEqual(1, animationCurve.MaxTime());

        animationCurve = AnimationCurve.Linear(0, 0, 5, 1);

        Assert.AreEqual(5, animationCurve.MaxTime());

    }

}
