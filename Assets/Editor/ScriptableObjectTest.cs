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

        CandyCoded.BoolReference boolReference = ScriptableObject.CreateInstance<CandyCoded.BoolReference>();

        boolReference.Value = true;

        Assert.AreEqual(true, boolReference.Value);

        boolReference.Reset();

        Assert.AreEqual(false, boolReference.Value);

    }

    [Test]
    public void FloatReference()
    {

        CandyCoded.FloatReference floatReference = ScriptableObject.CreateInstance<CandyCoded.FloatReference>();

        floatReference.Value = 1.5f;

        Assert.AreEqual(1.5f, floatReference.Value);

        floatReference.Reset();

        Assert.AreEqual(0.0f, floatReference.Value);

    }

    [Test]
    public void GameObjectReference()
    {

        CandyCoded.GameObjectListReference gameObjectListReference = ScriptableObject.CreateInstance<CandyCoded.GameObjectListReference>();

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

        CandyCoded.IntReference intReference = ScriptableObject.CreateInstance<CandyCoded.IntReference>();

        intReference.Value = 1;

        Assert.AreEqual(1, intReference.Value);

        intReference.Reset();

        Assert.AreEqual(0, intReference.Value);

    }

    [Test]
    public void StringReference()
    {

        CandyCoded.StringReference stringReference = ScriptableObject.CreateInstance<CandyCoded.StringReference>();

        stringReference.Value = "Hello, World";

        Assert.AreEqual("Hello, World", stringReference.Value);

        stringReference.Reset();

        Assert.AreEqual(null, stringReference.Value);

    }

}
