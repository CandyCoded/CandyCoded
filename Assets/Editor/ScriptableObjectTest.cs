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

using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ScriptableObjectTest
{

    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [Test]
    public void BoolReference()
    {

        var boolReference = ScriptableObject.CreateInstance<CandyCoded.BoolReference>();

        boolReference.Value = true;

        Assert.AreEqual(true, boolReference.Value);

        boolReference.Reset();

        Assert.AreEqual(false, boolReference.Value);

    }

    [Test]
    public void FloatReference()
    {

        var floatReference = ScriptableObject.CreateInstance<CandyCoded.FloatReference>();

        floatReference.Value = 1.5f;

        Assert.AreEqual(1.5f, floatReference.Value);

        floatReference.Reset();

        Assert.AreEqual(0.0f, floatReference.Value);

    }

    [Test]
    public void GameObjectReference()
    {

        var gameObjectListReference = ScriptableObject.CreateInstance<CandyCoded.GameObjectListReference>();

        Assert.AreEqual(0, gameObjectListReference.Items.Count);

        gameObjectListReference.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        gameObjectListReference.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));

        Assert.AreEqual(2, gameObjectListReference.Items.Count);

        gameObjectListReference.Reset();

        Assert.AreEqual(0, gameObjectListReference.Items.Count);

    }

    [Test]
    public void IntReference()
    {

        var intReference = ScriptableObject.CreateInstance<CandyCoded.IntReference>();

        intReference.Value = 1;

        Assert.AreEqual(1, intReference.Value);

        intReference.Reset();

        Assert.AreEqual(0, intReference.Value);

    }

    [Test]
    public void StringReference()
    {

        var stringReference = ScriptableObject.CreateInstance<CandyCoded.StringReference>();

        stringReference.Value = "Hello, World";

        Assert.AreEqual("Hello, World", stringReference.Value);

        stringReference.Reset();

        Assert.AreEqual(null, stringReference.Value);

    }

}
