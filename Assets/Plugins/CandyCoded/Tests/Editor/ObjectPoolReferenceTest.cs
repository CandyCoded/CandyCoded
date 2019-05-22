// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine.TestTools;
#if UNITY_EDITOR || UNITY_STANDALONE
using System.Collections;
using NUnit.Framework;
using UnityEngine;

namespace CandyCoded.Tests
{

    public class ObjectPoolReferenceTest : TestSetup
    {

        [Test]
        public void PopulatePool()
        {

            var objectPoolReference = ScriptableObject.CreateInstance<ObjectPoolReference>();

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            objectPoolReference.obj = cube;

            objectPoolReference.minObjects = 100;

            objectPoolReference.Populate();

            Assert.AreEqual(100, objectPoolReference.inactiveObjects.Count);

        }

        [Test]
        public void ReleaseObject()
        {

            var objectPoolReference = ScriptableObject.CreateInstance<ObjectPoolReference>();

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            objectPoolReference.obj = cube;

            objectPoolReference.Populate();

            Assert.AreEqual(10, objectPoolReference.inactiveObjects.Count);

        }

        [Test]
        public void RetrieveObjects()
        {

            var objectPoolReference = ScriptableObject.CreateInstance<ObjectPoolReference>();

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            objectPoolReference.obj = cube;

            objectPoolReference.Populate();

            Assert.AreEqual(10, objectPoolReference.inactiveObjects.Count);

            for (var i = 0; i < 10; i += 1)
            {

                var gameObject = objectPoolReference.Retrieve();

            }

            Assert.AreEqual(10, objectPoolReference.activeObjects.Count);
            Assert.AreEqual(0, objectPoolReference.inactiveObjects.Count);

        }

        [Test]
        public void ExpandPool()
        {

            var objectPoolReference = ScriptableObject.CreateInstance<ObjectPoolReference>();

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            objectPoolReference.obj = cube;

            objectPoolReference.Populate();

            Assert.AreEqual(10, objectPoolReference.inactiveObjects.Count);

            for (var i = 0; i < 100; i += 1)
            {

                var gameObject = objectPoolReference.Retrieve();

            }

            Assert.AreEqual(100, objectPoolReference.activeObjects.Count);
            Assert.AreEqual(0, objectPoolReference.inactiveObjects.Count);

        }

    }

}
#endif
