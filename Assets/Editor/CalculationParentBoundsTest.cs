using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class CalculationParentBoundsTest
{

    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [Test]
    public void BoundsCalculatedOnMultipleChildrenObjects()
    {

        GameObject parentGameObject = new GameObject("ParentGameObject");

        GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = Vector3.back * 2;
        cube1.transform.parent = parentGameObject.transform;

        GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = Vector3.left * 2;
        cube2.transform.parent = parentGameObject.transform;

        GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3.transform.position = Vector3.right;
        cube3.transform.parent = parentGameObject.transform;

        Bounds bounds = CandyCoded.Calculation.ParentBounds(parentGameObject);

        Assert.AreEqual(bounds.center.x, -0.5f);
        Assert.AreEqual(bounds.center.y, 0);
        Assert.AreEqual(bounds.center.z, -1.0f);

        Assert.AreEqual(bounds.min.x, -2.5f);
        Assert.AreEqual(bounds.min.y, -0.5f);
        Assert.AreEqual(bounds.min.z, -2.5f);

        Assert.AreEqual(bounds.max.x, 1.5f);
        Assert.AreEqual(bounds.max.y, 0.5f);
        Assert.AreEqual(bounds.max.z, 0.5f);

        Assert.AreEqual(bounds.size.x, 4.0f);
        Assert.AreEqual(bounds.size.y, 1.0f);
        Assert.AreEqual(bounds.size.z, 3.0f);

    }

}
