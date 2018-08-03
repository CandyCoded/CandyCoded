/**
 * The MIT License (MIT)
 *
 * Copyright (c) 2018 Scott Doxey
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "ObjectPoolReference", menuName = "CandyCoded/ObjectPoolReference")]
    public class ObjectPoolReference : CustomScriptableObject
    {

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        private int minObjects = 10;

        private List<GameObject> activeGameObjects = new List<GameObject>();
        private Queue<GameObject> inactiveGameObjects = new Queue<GameObject>();

        public void PopulatePool()
        {

            if (!prefab)
            {

                return;

            }

            for (int i = 0; i < minObjects; i += 1)
            {

                var gameObject = Instantiate(prefab);

                gameObject.SetActive(false);

                inactiveGameObjects.Enqueue(gameObject);

            }

        }

        public GameObject Spawn(Vector3 position, Quaternion rotation)
        {

            if (!prefab)
            {

                return null;

            }

            GameObject gameObject = null;

            if (inactiveGameObjects.Count > 0)
            {

                gameObject = inactiveGameObjects.Dequeue();
                gameObject.transform.position = position;
                gameObject.transform.rotation = rotation;
                gameObject.SetActive(true);

            }
            else
            {

                gameObject = Instantiate(prefab, position, rotation);

            }

            activeGameObjects.Add(gameObject);

            return gameObject;

        }

        public GameObject Spawn(Vector3 position)
        {

            if (!prefab)
            {

                return null;

            }

            return Spawn(position, Quaternion.identity);

        }

        public GameObject Spawn()
        {

            if (!prefab)
            {

                return null;

            }

            return Spawn(Vector3.zero, Quaternion.identity);

        }

        public void Release(GameObject gameObject)
        {

            if (activeGameObjects.Contains(gameObject))
            {

                activeGameObjects.Remove(gameObject);

            }

            if (!inactiveGameObjects.Contains(gameObject))
            {

                gameObject.SetActive(false);

                inactiveGameObjects.Enqueue(gameObject);

            }

        }

        public void ReleaseAllActiveObjects()
        {

            while (activeGameObjects.Count > 0)
            {

                if (activeGameObjects[0])
                {

                    Release(activeGameObjects[0]);

                }

            }

        }

        public override void Reset()
        {

            for (int i = 0; i < activeGameObjects.Count; i += 1)
            {

                if (activeGameObjects[i])
                {

                    Destroy(activeGameObjects[i]);

                }

            }

            activeGameObjects.Clear();

            while (inactiveGameObjects.Count > 0)
            {

                var gameObject = inactiveGameObjects.Dequeue();

                if (gameObject)
                {

                    Destroy(gameObject);

                }

            }

        }

    }

}
