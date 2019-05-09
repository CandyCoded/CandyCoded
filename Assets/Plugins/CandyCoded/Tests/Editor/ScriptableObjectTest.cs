// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR || UNITY_STANDALONE
using NUnit.Framework;
using UnityEngine;

namespace CandyCoded.Tests
{

    public class ScriptableObjectTest : TestSetup
    {

        [Test]
        public void BoolReference()
        {

            var boolReference = ScriptableObject.CreateInstance<BoolReference>();

            boolReference.Value = true;

            Assert.AreEqual(true, boolReference.Value);

            boolReference.Reset();

            Assert.AreEqual(false, boolReference.Value);

        }

        [Test]
        public void FloatReference()
        {

            var floatReference = ScriptableObject.CreateInstance<FloatReference>();

            floatReference.Value = 1.5f;

            Assert.AreEqual(1.5f, floatReference.Value);

            floatReference.Reset();

            Assert.AreEqual(0.0f, floatReference.Value);

        }

        [Test]
        public void GameObjectReference()
        {

            var gameObjectListReference = ScriptableObject.CreateInstance<GameObjectListReference>();

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

            var intReference = ScriptableObject.CreateInstance<IntReference>();

            intReference.Value = 1;

            Assert.AreEqual(1, intReference.Value);

            intReference.Reset();

            Assert.AreEqual(0, intReference.Value);

        }

        [Test]
        public void StringReference()
        {

            var stringReference = ScriptableObject.CreateInstance<StringReference>();

            stringReference.Value = "Hello, World";

            Assert.AreEqual("Hello, World", stringReference.Value);

            stringReference.Reset();

            Assert.AreEqual(null, stringReference.Value);

        }

    }

}
#endif
