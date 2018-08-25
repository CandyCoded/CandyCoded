// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using System;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RunnerTest
{

    [NUnit.Framework.SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [NUnit.Framework.Test]
    public void RunnerAddCoroutine()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        NUnit.Framework.Assert.AreEqual(1, runner.Coroutines.Count);

    }

    [NUnit.Framework.Test]
    public void RunnerFailsToAddDuplicateCoroutine()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        NUnit.Framework.Assert.Throws<ArgumentException>(() => runner.AddCoroutine("TestCoroutine", TestCoroutine()));

    }

    [NUnit.Framework.Test]
    public void RunnerRemoveCoroutine()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine", TestCoroutine());

        NUnit.Framework.Assert.AreEqual(1, runner.Coroutines.Count);

        runner.RemoveCoroutine("TestCoroutine");

        NUnit.Framework.Assert.AreEqual(0, runner.Coroutines.Count);

    }

    [NUnit.Framework.Test]
    public void RunnerRemoveAllCoroutines()
    {

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var runner = cube.AddComponent<CandyCoded.Runner>();

        runner.AddCoroutine("TestCoroutine1", TestCoroutine());
        runner.AddCoroutine("TestCoroutine2", TestCoroutine());
        runner.AddCoroutine("TestCoroutine3", TestCoroutine());

        NUnit.Framework.Assert.AreEqual(3, runner.Coroutines.Count);

        runner.RemoveAllCoroutines();

        NUnit.Framework.Assert.AreEqual(0, runner.Coroutines.Count);

    }

    IEnumerator TestCoroutine()
    {

        yield return new WaitForSeconds(1f);

    }

}
#endif
