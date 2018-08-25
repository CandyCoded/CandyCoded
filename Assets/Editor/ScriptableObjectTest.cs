// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEditor.SceneManagement;
using UnityEngine;

public class ScriptableObjectTest
{

    [NUnit.Framework.SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [NUnit.Framework.Test]
    public void BoolReference()
    {

        var boolReference = ScriptableObject.CreateInstance<CandyCoded.BoolReference>();

        boolReference.Value = true;

        NUnit.Framework.Assert.AreEqual(true, boolReference.Value);

        boolReference.Reset();

        NUnit.Framework.Assert.AreEqual(false, boolReference.Value);

    }

    [NUnit.Framework.Test]
    public void FloatReference()
    {

        var floatReference = ScriptableObject.CreateInstance<CandyCoded.FloatReference>();

        floatReference.Value = 1.5f;

        NUnit.Framework.Assert.AreEqual(1.5f, floatReference.Value);

        floatReference.Reset();

        NUnit.Framework.Assert.AreEqual(0.0f, floatReference.Value);

    }

    [NUnit.Framework.Test]
    public void GameObjectReference()
    {

        var gameObjectListReference = ScriptableObject.CreateInstance<CandyCoded.GameObjectListReference>();

        NUnit.Framework.Assert.AreEqual(0, gameObjectListReference.Items.Count);

        gameObjectListReference.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        gameObjectListReference.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));

        NUnit.Framework.Assert.AreEqual(2, gameObjectListReference.Items.Count);

        gameObjectListReference.Reset();

        NUnit.Framework.Assert.AreEqual(0, gameObjectListReference.Items.Count);

    }

    [NUnit.Framework.Test]
    public void IntReference()
    {

        var intReference = ScriptableObject.CreateInstance<CandyCoded.IntReference>();

        intReference.Value = 1;

        NUnit.Framework.Assert.AreEqual(1, intReference.Value);

        intReference.Reset();

        NUnit.Framework.Assert.AreEqual(0, intReference.Value);

    }

    [NUnit.Framework.Test]
    public void StringReference()
    {

        var stringReference = ScriptableObject.CreateInstance<CandyCoded.StringReference>();

        stringReference.Value = "Hello, World";

        NUnit.Framework.Assert.AreEqual("Hello, World", stringReference.Value);

        stringReference.Reset();

        NUnit.Framework.Assert.AreEqual(null, stringReference.Value);

    }

}
#endif
