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

            objectPoolReference.prefab = cube;

            objectPoolReference.minObjects = 100;

            objectPoolReference.PopulatePool();

            Assert.AreEqual(100, objectPoolReference.inactiveGameObjects.Count);

        }

    }

}
#endif
