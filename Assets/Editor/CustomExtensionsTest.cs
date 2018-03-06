using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

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

        Assert.AreNotEqual(numberRange.Shuffle(), numberRange);

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
            Assert.AreEqual(numberRange[i], i);
        }

    }

    [Test]
    public void MaxTimeAnimationCurve()
    {

        AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        Assert.AreEqual(animationCurve.MaxTime(), 1);

        animationCurve = AnimationCurve.Linear(0, 0, 5, 1);

        Assert.AreEqual(animationCurve.MaxTime(), 5);

    }

}
