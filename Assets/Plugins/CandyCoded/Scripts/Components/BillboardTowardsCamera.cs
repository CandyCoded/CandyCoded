// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded
{

    public class BillboardTowardsCamera : MonoBehaviour
    {

        [SerializeField]
        private Transform mainCamera;

        private void Awake()
        {

            if (mainCamera == null)
            {

                mainCamera = Camera.main.transform;

            }

        }

        private void Update()
        {

            gameObject.transform.LookAt(gameObject.transform.position + mainCamera.rotation * Vector3.forward);

        }

    }

}
