using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "ObjectPoolReference", menuName = "CandyCoded/ObjectPoolReference")]
    public class ObjectPoolReference : CustomScriptableObject
    {

        public GameObject prefab;

        public float minObjects = 10;
        public float maxObjects = 1000;

        [SerializeField]
        private List<GameObject> activeGameObjects = new List<GameObject>();

        [SerializeField]
        private List<GameObject> inactiveGameObjects = new List<GameObject>();

        public void PopulatePool()
        {

            if (!prefab) return;

            for (int i = 0; i < minObjects; i += 1)
            {

                GameObject gameObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);

                gameObject.SetActive(false);

                inactiveGameObjects.Add(gameObject);

            }

        }

        public GameObject Instantiate(Vector3 position, Quaternion rotation)
        {

            if (!prefab) return null;

            GameObject gameObject = null;

            if (inactiveGameObjects.Count > 0)
            {

                gameObject = inactiveGameObjects[0];
                gameObject.transform.position = position;
                gameObject.transform.rotation = rotation;
                gameObject.SetActive(true);

                inactiveGameObjects.RemoveAt(0);

            }
            else if (inactiveGameObjects.Count + activeGameObjects.Count < maxObjects)
            {

                gameObject = Instantiate(prefab, position, rotation);

            }

            if (gameObject)
            {

                activeGameObjects.Add(gameObject);

            }

            return gameObject;

        }

        public GameObject Instantiate(Vector3 position)
        {

            return Instantiate(position, Quaternion.identity);

        }

        public GameObject Instantiate()
        {

            return Instantiate(Vector3.zero, Quaternion.identity);

        }

        public void Destroy(GameObject gameObject)
        {

            if (activeGameObjects.Contains(gameObject))
            {

                activeGameObjects.Remove(gameObject);

            }

            if (!inactiveGameObjects.Contains(gameObject))
            {

                inactiveGameObjects.Add(gameObject);

            }

            gameObject.SetActive(false);

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

            for (int i = 0; i < inactiveGameObjects.Count; i += 1)
            {

                if (inactiveGameObjects[i])
                {

                    Object.Destroy(inactiveGameObjects[i]);

                }

            }

            inactiveGameObjects.Clear();

        }

        private void OnDisable()
        {

            Reset();

        }

    }

}
