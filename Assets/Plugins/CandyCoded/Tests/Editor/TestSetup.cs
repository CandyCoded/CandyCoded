// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using NUnit.Framework;
using UnityEditor.SceneManagement;

namespace CandyCoded.Tests
{

    public class TestSetup
    {

        protected TestSetup()
        {

        }

        [SetUp]
        protected static void ResetScene()
        {

            EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);

        }

    }

}
