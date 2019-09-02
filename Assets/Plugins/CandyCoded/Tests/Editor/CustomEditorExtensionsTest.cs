// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace CandyCoded.Tests
{

    public class CustomEditorExtensionsTest
    {

        public class FindOrCreateGameObjectFromAssetMenuTest : TestSetup
        {

            private const string gameObjectName = "Cube";
            private const string gameObjectMenuPath = "GameObject/3D Object/Cube";

            [Test]
            public void FindOrCreate3DCubeGameObject()
            {

                var gameObject = GameObject.Find(gameObjectName);

                Assert.IsNull(gameObject);

                gameObject = CustomEditorExtensions.FindOrCreateGameObjectFromAssetMenu(gameObjectName, gameObjectMenuPath);

                Assert.IsNotNull(gameObject);

                gameObject = GameObject.Find(gameObjectName);

                Assert.IsNotNull(gameObject);

            }

        }

        public class FindOrCreatePrefabFromAssetMenuTest : TestSetup
        {

            private const string gameObjectName = "Cube";
            private const string gameObjectMenuPath = "GameObject/3D Object/Cube";
            private const string gameObjectPrefabPath = "Assets/Cube.prefab";

            [SetUp, TearDown]
            public static void DeleteFiles()
            {

                FileUtil.DeleteFileOrDirectory(gameObjectPrefabPath);

            }

            [Test]
            public void FindOrCreate3DCubePrefab()
            {

                var asset = AssetDatabase.LoadAssetAtPath<GameObject>(gameObjectPrefabPath);

                Assert.IsNull(asset);

                asset = CustomEditorExtensions.FindOrCreatePrefabFromAssetMenu(gameObjectName, gameObjectMenuPath, gameObjectPrefabPath);

                Assert.IsNotNull(asset);

                asset = AssetDatabase.LoadAssetAtPath<GameObject>(gameObjectPrefabPath);

                Assert.IsNotNull(asset);

            }

        }

        public class FindOrCreateScriptableObjectAtPathTest : TestSetup
        {

            private const string scriptableObjectAssetPath = "Assets/TestScriptableObject.asset";

            [SetUp, TearDown]
            public static void DeleteFiles()
            {

                FileUtil.DeleteFileOrDirectory(scriptableObjectAssetPath);

            }

            [Test]
            public void FindOrCreateScriptableObject()
            {

                var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(scriptableObjectAssetPath);

                Assert.IsNull(asset);

                asset = CustomEditorExtensions.FindOrCreateScriptableObjectAtPath<ScriptableObject>(scriptableObjectAssetPath);

                Assert.IsNotNull(asset);

                asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(scriptableObjectAssetPath);

                Assert.IsNotNull(asset);

            }

        }

    }

}
#endif
