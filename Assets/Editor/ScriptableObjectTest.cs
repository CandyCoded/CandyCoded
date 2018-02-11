using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

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

        CandyCoded.BoolReference boolReference = ScriptableObject.CreateInstance<CandyCoded.BoolReference>();

        boolReference.Value = true;

        Assert.AreEqual(boolReference.Value, true);

        boolReference.Reset();

        Assert.AreEqual(boolReference.Value, false);

    }

    [Test]
    public void FloatReference()
    {

        CandyCoded.FloatReference floatReference = ScriptableObject.CreateInstance<CandyCoded.FloatReference>();

        floatReference.Value = 1.5f;

        Assert.AreEqual(floatReference.Value, 1.5f);

        floatReference.Reset();

        Assert.AreEqual(floatReference.Value, 0.0f);

    }

    [Test]
    public void IntReference()
    {

        CandyCoded.IntReference intReference = ScriptableObject.CreateInstance<CandyCoded.IntReference>();

        intReference.Value = 1;

        Assert.AreEqual(intReference.Value, 1);

        intReference.Reset();

        Assert.AreEqual(intReference.Value, 0);

    }

    [Test]
    public void StringReference()
    {

        CandyCoded.StringReference stringReference = ScriptableObject.CreateInstance<CandyCoded.StringReference>();

        stringReference.Value = "Hello, World";

        Assert.AreEqual(stringReference.Value, "Hello, World");

        stringReference.Reset();

        Assert.AreEqual(stringReference.Value, null);

    }

    [Test]
    public void GameObjectReference()
    {

        CandyCoded.GameObjectListReference gameObjectListReference = ScriptableObject.CreateInstance<CandyCoded.GameObjectListReference>();

        Assert.AreEqual(gameObjectListReference.Items.Count, 0);

        gameObjectListReference.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        gameObjectListReference.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));

        Assert.AreEqual(gameObjectListReference.Items.Count, 2);

        gameObjectListReference.Reset();

        Assert.AreEqual(gameObjectListReference.Items.Count, 0);

    }

}
