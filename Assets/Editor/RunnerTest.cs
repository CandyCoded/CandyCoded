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
