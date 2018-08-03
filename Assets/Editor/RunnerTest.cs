// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RunnerTest
{

    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [Test]
    public void RunnerAddCoroutine()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.AreEqual(1, runner.Coroutines.Count);

    }

    [Test]
    public void RunnerFailsToAddDuplicateCoroutine()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.Throws<ArgumentException>(() => runner.AddCoroutine("TestCoroutine", TestCoroutine()));

    }

    [Test]
    public void RunnerRemoveCoroutine()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.AreEqual(1, runner.Coroutines.Count);

        runner.RemoveCoroutine("TestCoroutine");

        Assert.AreEqual(0, runner.Coroutines.Count);

    }

    [Test]
    public void RunnerRemoveAllCoroutines()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine1", TestCoroutine());
        runner.AddCoroutine("TestCoroutine2", TestCoroutine());
        runner.AddCoroutine("TestCoroutine3", TestCoroutine());

        Assert.AreEqual(3, runner.Coroutines.Count);

        runner.RemoveAllCoroutines();

        Assert.AreEqual(0, runner.Coroutines.Count);

    }

    IEnumerator TestCoroutine()
    {

        yield return new WaitForSeconds(1f);

    }

}
