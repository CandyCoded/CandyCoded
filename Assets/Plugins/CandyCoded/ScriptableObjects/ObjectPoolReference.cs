using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "ObjectPoolReference", menuName = "CandyCoded/ObjectPoolReference")]
    public class ObjectPoolReference : CustomScriptableObject
    {

        public GameObject prefab;

        public int minObjects = 10;

        private List<GameObject> activeGameObjects = new List<GameObject>();
        private Queue<GameObject> inactiveGameObjects = new Queue<GameObject>();

        public void PopulatePool()
        {

            if (!prefab) return;

            for (int i = 0; i < minObjects; i += 1)
            {

                GameObject gameObject = Instantiate(prefab);

                gameObject.SetActive(false);

                inactiveGameObjects.Enqueue(gameObject);

            }

        }

        public GameObject Spawn(Vector3 position, Quaternion rotation)
        {

            if (!prefab) return null;

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

            return Spawn(position, Quaternion.identity);

        }

        public GameObject Spawn()
        {

            return Spawn(Vector3.zero, Quaternion.identity);

        }

        public void Destroy(GameObject gameObject)
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

        public void DestoryAllActiveObjects()
        {

            while (activeGameObjects.Count > 0)
            {

                if (activeGameObjects[0])
                {

                    Destroy(activeGameObjects[0]);

                }

            }

        }

        public override void Reset()
        {

            for (int i = 0; i < activeGameObjects.Count; i += 1)
            {

                if (activeGameObjects[i])
                {

                    Object.Destroy(activeGameObjects[i]);

                }

            }

            activeGameObjects.Clear();

            while (inactiveGameObjects.Count > 0)
            {

                GameObject gameObject = inactiveGameObjects.Dequeue();

                if (gameObject)
                {

                    Object.Destroy(gameObject);

                }

            }

        }

    }

}
