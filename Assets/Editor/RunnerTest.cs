// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

public class RunnerTest : TestSetup
{

    [Test]
    public void AddCoroutine()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.AreEqual(1, runner.Coroutines.Count);

    }

    [Test]
    public void FailsToAddDuplicateCoroutine()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.Throws<ArgumentException>(() => runner.AddCoroutine("TestCoroutine", TestCoroutine()));

    }

    [Test]
    public void RemoveCoroutine()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.AreEqual(1, runner.Coroutines.Count);

        runner.RemoveCoroutine("TestCoroutine");

        Assert.AreEqual(0, runner.Coroutines.Count);

    }

    [Test]
    public void RemoveCoroutineOnNullValue()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        Assert.AreEqual(1, runner.Coroutines.Count);

        runner.Coroutines["TestCoroutine"] = null;

        runner.RemoveCoroutine("TestCoroutine");

        Assert.AreEqual(0, runner.Coroutines.Count);

    }

    [Test]
    public void RemoveAllCoroutines()
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

    private IEnumerator TestCoroutine()
    {

        yield return new WaitForSeconds(1f);

    }

}
#endif
