// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEditor.SceneManagement;
using UnityEngine;

public class CalculationTest
{

    [NUnit.Framework.SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [NUnit.Framework.Test]
    public void BoundsCalculatedOnMultipleChildrenObjects()
    {

        var parentGameObject = new GameObject("ParentGameObject");
        parentGameObject.transform.position = new Vector3(5f, 5f, 5f);

        var cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = Vector3.back * 2;
        cube1.transform.parent = parentGameObject.transform;

        var cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = Vector3.left * 2;
        cube2.transform.parent = parentGameObject.transform;

        var cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3.transform.position = Vector3.right;
        cube3.transform.parent = parentGameObject.transform;

        var bounds = CandyCoded.Calculation.ParentBounds(parentGameObject);

        NUnit.Framework.Assert.AreEqual(new Vector3(-0.5f, 0, -1.0f), bounds.center);
        NUnit.Framework.Assert.AreEqual(new Vector3(-2.5f, -0.5f, -2.5f), bounds.min);
        NUnit.Framework.Assert.AreEqual(new Vector3(1.5f, 0.5f, 0.5f), bounds.max);
        NUnit.Framework.Assert.AreEqual(new Vector3(4.0f, 1.0f, 3.0f), bounds.size);

    }

}
#endif
