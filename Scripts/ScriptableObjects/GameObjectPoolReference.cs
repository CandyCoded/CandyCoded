// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "GameObjectPoolReference", menuName = "CandyCoded/GameObjectPoolReference")]
    public class GameObjectPoolReference : PoolReference<GameObject>
    {

        [SerializeField]
        internal GameObject _prefab;

        public GameObject prefab
        {
            get => _prefab;
            set => _prefab = value;
        }

        public Transform parentTransform { get; set; }

        protected override GameObject Create()
        {

            var gameObject = Instantiate(_prefab, parentTransform);

            gameObject.SetActive(false);

            return gameObject;

        }

        public GameObject Spawn(Vector3 position, Quaternion rotation)
        {

            var gameObject = Retrieve();

            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;

            gameObject.SetActive(true);

            return gameObject;

        }

    }

}
