// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "ObjectPoolReference", menuName = "CandyCoded/ObjectPoolReference")]
    public class ObjectPoolReference : CustomScriptableObject
    {

#pragma warning disable CS0649
        [SerializeField]
        private GameObject prefab;
#pragma warning restore CS0649

        [SerializeField]
        private int minObjects = 10;

        private readonly List<GameObject> activeGameObjects = new List<GameObject>();
        private readonly Queue<GameObject> inactiveGameObjects = new Queue<GameObject>();

        public void PopulatePool()
        {

            if (!prefab)
            {

                return;

            }

            for (var i = 0; i < minObjects; i += 1)
            {

                var gameObject = Instantiate(prefab);

                gameObject.SetActive(false);

                inactiveGameObjects.Enqueue(gameObject);

            }

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

            for (var i = 0; i < activeGameObjects.Count; i += 1)
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

    }

}
