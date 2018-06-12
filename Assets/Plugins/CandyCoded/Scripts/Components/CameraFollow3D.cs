using System;
using UnityEngine;

namespace CandyCoded
{

    public class CameraFollow3D : MonoBehaviour
    {

        [Serializable]
        private struct CameraConstraints : IEquatable<CameraConstraints>
        {
            [Header("Freeze Original Position")]
            public bool freezePositionX;
            public bool freezePositionY;
            public bool freezePositionZ;
            [Header("Maintain Original Offset")]
            public bool maintainOffsetX;
            public bool maintainOffsetY;
            public bool maintainOffsetZ;
            public bool Equals(CameraConstraints other)
            {

                return other.freezePositionX == freezePositionX &&
                            other.freezePositionY == freezePositionY &&
                            other.freezePositionZ == freezePositionZ &&
                            other.maintainOffsetX == maintainOffsetX &&
                            other.maintainOffsetY == maintainOffsetY &&
                            other.maintainOffsetZ == maintainOffsetZ;

            }
        }

        public bool tracking = true;
        public bool rotating = true;

        public Transform cameraTransform;
        public Transform mainTarget;
        public Transform secondaryTarget;

        public float dampRate = 0.3f;
        public float rotateSpeed = 5f;

        [SerializeField]
        private CameraConstraints constraints;

        private Vector3 cameraPositionOffset;

        private Vector3 velocity = Vector3.zero;

        private Vector3 lookAtPosition;
        private GameObject tempSecondaryTarget;

        private void Awake()
        {

            if (cameraTransform == null)
            {

                cameraTransform = Camera.main.transform;

            }

            if (mainTarget == null)
            {

                mainTarget = gameObject.transform;

            }

            tempSecondaryTarget = new GameObject("SecondayTarget (temp)");
            tempSecondaryTarget.transform.position = gameObject.transform.position + gameObject.transform.forward;
            tempSecondaryTarget.transform.parent = mainTarget;

            lookAtPosition = tempSecondaryTarget.transform.position;

            cameraPositionOffset = new Vector3(
                cameraTransform.position.x - mainTarget.transform.position.x,
                cameraTransform.position.y - mainTarget.transform.position.y,
                cameraTransform.position.z - mainTarget.transform.position.z
            );

        }

        private void LateUpdate()
        {

            if (tracking && mainTarget)
            {

                Vector3 newPosition = mainTarget.transform.position;

                Transform secondaryTargetTransform = tempSecondaryTarget.transform;

                if (secondaryTarget)
                {

                    secondaryTargetTransform = secondaryTarget;

                }

                if (rotating)
                {

                    newPosition = mainTarget.position + (cameraPositionOffset.magnitude * (mainTarget.position - secondaryTargetTransform.position).normalized);

                    newPosition.y = mainTarget.position.y;

                }
                else
                {

                    if (constraints.maintainOffsetX) { newPosition.x += cameraPositionOffset.x; }
                    if (constraints.maintainOffsetZ) { newPosition.z += cameraPositionOffset.z; }

                }

                if (constraints.maintainOffsetY) { newPosition.y += cameraPositionOffset.y; }

                if (constraints.freezePositionX) { newPosition.x = cameraTransform.position.x; }
                if (constraints.freezePositionY) { newPosition.y = cameraTransform.position.y; }
                if (constraints.freezePositionZ) { newPosition.z = cameraTransform.position.z; }

                cameraTransform.position = Vector3.SmoothDamp(
                    cameraTransform.position,
                    newPosition,
                    ref velocity,
                    dampRate
                );

                if (rotating)
                {

                    lookAtPosition = Vector3.Lerp(lookAtPosition, secondaryTargetTransform.position, rotateSpeed * Time.deltaTime);

                    cameraTransform.LookAt(lookAtPosition);

                }

            }

        }

    }

}
