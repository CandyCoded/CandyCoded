// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using NUnit.Framework;
using UnityEngine;

namespace CandyCoded.Tests
{

    public class GameObjectPoolReferenceTest : TestSetup
    {

        [Test]
        public void PopulatePool()
        {

            var objectPoolReference = ScriptableObject.CreateInstance<GameObjectPoolReference>();

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            objectPoolReference.prefab = cube;

            objectPoolReference.minObjects = 100;

            objectPoolReference.Populate();

            Assert.AreEqual(100, objectPoolReference.inactiveObjects.Count);

        }

        [Test]
        public void ReleaseObject()
        {

            var objectPoolReference = ScriptableObject.CreateInstance<GameObjectPoolReference>();

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            objectPoolReference.prefab = cube;

            objectPoolReference.Populate();

            Assert.AreEqual(10, objectPoolReference.inactiveObjects.Count);

            var gameObject = objectPoolReference.Retrieve();

            Assert.AreEqual(1, objectPoolReference.activeObjects.Count);
            Assert.AreEqual(9, objectPoolReference.inactiveObjects.Count);

            objectPoolReference.Release(gameObject);

            Assert.AreEqual(0, objectPoolReference.activeObjects.Count);
            Assert.AreEqual(10, objectPoolReference.inactiveObjects.Count);

        }

        [Test]
        public void ReleaseAllObjects()
        {

            var objectPoolReference = ScriptableObject.CreateInstance<GameObjectPoolReference>();

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            objectPoolReference.prefab = cube;

            objectPoolReference.Populate();

            Assert.AreEqual(10, objectPoolReference.inactiveObjects.Count);

            for (var i = 0; i < 10; i += 1)
            {

                objectPoolReference.Retrieve();

            }

            Assert.AreEqual(10, objectPoolReference.activeObjects.Count);
            Assert.AreEqual(0, objectPoolReference.inactiveObjects.Count);

            objectPoolReference.ReleaseAllObjects();

            Assert.AreEqual(0, objectPoolReference.activeObjects.Count);
            Assert.AreEqual(10, objectPoolReference.inactiveObjects.Count);

        }

        [Test]
        public void RetrieveObjects()
        {

            var objectPoolReference = ScriptableObject.CreateInstance<GameObjectPoolReference>();

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            objectPoolReference.prefab = cube;

            objectPoolReference.Populate();

            Assert.AreEqual(10, objectPoolReference.inactiveObjects.Count);

            for (var i = 0; i < 10; i += 1)
            {

                objectPoolReference.Retrieve();

            }

            Assert.AreEqual(10, objectPoolReference.activeObjects.Count);
            Assert.AreEqual(0, objectPoolReference.inactiveObjects.Count);

        }

        [Test]
        public void ExpandPool()
        {

            var objectPoolReference = ScriptableObject.CreateInstance<GameObjectPoolReference>();

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            objectPoolReference.prefab = cube;

            objectPoolReference.Populate();

            Assert.AreEqual(10, objectPoolReference.inactiveObjects.Count);

            for (var i = 0; i < 100; i += 1)
            {

                objectPoolReference.Retrieve();

            }

            Assert.AreEqual(100, objectPoolReference.activeObjects.Count);
            Assert.AreEqual(0, objectPoolReference.inactiveObjects.Count);

        }

    }

}
#endif
