using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CalculationTest
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

        Assert.AreEqual(bounds.center, new Vector3(-0.5f, 0, -1.0f));
        Assert.AreEqual(bounds.min, new Vector3(-2.5f, -0.5f, -2.5f));
        Assert.AreEqual(bounds.max, new Vector3(1.5f, 0.5f, 0.5f));
        Assert.AreEqual(bounds.size, new Vector3(4.0f, 1.0f, 3.0f));

    }

}
