// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "ObjectPoolReference", menuName = "CandyCoded/ObjectPoolReference")]
    public class ObjectPoolReference : CustomScriptableObject
    {

#pragma warning disable CS0649
        [SerializeField]
        private GameObject _prefab;
#pragma warning restore CS0649

        public GameObject prefab
        {
            get => _prefab;
            set => _prefab = value;
        }

        [SerializeField]
        private int _minObjects = 10;

        public int minObjects
        {
            get => _minObjects;
            set => _minObjects = value;
        }

        private readonly List<GameObject> _activeGameObjects = new List<GameObject>();

        public ReadOnlyCollection<GameObject> activeGameObjects => _activeGameObjects.AsReadOnly();

        private readonly Queue<GameObject> _inactiveGameObjects = new Queue<GameObject>();

        public ReadOnlyCollection<GameObject> inactiveGameObjects => _inactiveGameObjects.ToList().AsReadOnly();

        public void PopulatePool(Transform parentTransform)
        {

            if (!_prefab)
            {

                return;

            }

            for (var i = 0; i < _minObjects; i += 1)
            {

                var gameObject = Instantiate(_prefab, parentTransform);

                gameObject.SetActive(false);

                _inactiveGameObjects.Enqueue(gameObject);

            }

        }

        public void PopulatePool()
        {

            PopulatePool(null);

        }

        public void Release(GameObject gameObject)
        {

            if (_activeGameObjects.Contains(gameObject))
            {

                _activeGameObjects.Remove(gameObject);

            }

            if (!_inactiveGameObjects.Contains(gameObject))
            {

                gameObject.SetActive(false);

                _inactiveGameObjects.Enqueue(gameObject);

            }

        }

        public void ReleaseAllActiveObjects()
        {

            while (_activeGameObjects.Count > 0)
            {

                if (_activeGameObjects[0])
                {

                    Release(_activeGameObjects[0]);

                }

            }

        }

        public override void Reset()
        {

            for (var i = 0; i < _activeGameObjects.Count; i += 1)
            {

                if (_activeGameObjects[i])
                {

                    Destroy(_activeGameObjects[i]);

                }

            }

            _activeGameObjects.Clear();

            while (_inactiveGameObjects.Count > 0)
            {

                var gameObject = _inactiveGameObjects.Dequeue();

                if (gameObject)
                {

                    Destroy(gameObject);

                }

            }

        }

        public GameObject Spawn(Vector3 position, Quaternion rotation)
        {

            if (!_prefab)
            {

                return null;

            }

            GameObject gameObject;

            if (_inactiveGameObjects.Count > 0)
            {

                gameObject = _inactiveGameObjects.Dequeue();
                gameObject.transform.position = position;
                gameObject.transform.rotation = rotation;
                gameObject.SetActive(true);

            }
            else
            {

                gameObject = Instantiate(_prefab, position, rotation);

            }

            _activeGameObjects.Add(gameObject);

            return gameObject;

        }

        public GameObject Spawn(Vector3 position)
        {

            if (!_prefab)
            {

                return null;

            }

            return Spawn(position, Quaternion.identity);

        }

        public GameObject Spawn()
        {

            if (!_prefab)
            {

                return null;

            }

            return Spawn(Vector3.zero, Quaternion.identity);

        }

    }

}
