// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded
{

    [CreateAssetMenu(fileName = "ObjectPoolReference", menuName = "CandyCoded/ObjectPoolReference")]
    public class ObjectPoolReference : PoolReference<GameObject>
    {

        public Transform parentTransform { get; set; }

        protected override GameObject Create()
        {

            var gameObject = Instantiate(_obj, parentTransform);

            gameObject.SetActive(false);

            return gameObject;

        }

        public GameObject Instantiate(Vector3 position, Quaternion rotation)
        {

            var gameObject = Retrieve();

            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;

            gameObject.SetActive(true);

            return gameObject;

        }

    }

}
