using System.Collections;
using UnityEngine;

namespace CandyCoded
{

    [System.Serializable]
    public struct CameraConstraints3D
    {
        [Header("Freeze Original Position")]
        public bool freezePositionX;
        public bool freezePositionY;
        public bool freezePositionZ;
        [Header("Maintain Origin Offset")]
        public bool maintainOffsetX;
        public bool maintainOffsetY;
        public bool maintainOffsetZ;
    }

    public class CameraFollow3D : MonoBehaviour
    {

        public bool tracking = true;
        public bool rotating = true;

        public Transform mainTarget;
        public Transform secondaryTarget;

        public float dampRate = 0.3f;

        public CameraConstraints3D constraints;

        private Transform cameraTransform;
        private float cameraOrthographicSize;

        private Vector3 cameraPositionOffset = Vector3.zero;

        private Vector3 velocity = Vector3.zero;

        private GameObject tempSecondaryTarget;

        private void Awake()
        {

            cameraTransform = Camera.main.transform;
            cameraOrthographicSize = Camera.main.orthographicSize;

            if (mainTarget == null)
            {

                mainTarget = gameObject.transform;

            }

            if (secondaryTarget == null)
            {

                tempSecondaryTarget = new GameObject("SecondayTarget");
                tempSecondaryTarget.transform.position = gameObject.transform.forward;
                tempSecondaryTarget.transform.parent = mainTarget;

                secondaryTarget = tempSecondaryTarget.transform;

            }

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

                if (rotating && secondaryTarget)
                {

                    newPosition = mainTarget.position + (cameraPositionOffset.magnitude * (mainTarget.position - secondaryTarget.position).normalized);

                    newPosition.y = mainTarget.position.y;

                }
                else
                {

                    if (constraints.maintainOffsetX) newPosition.x += cameraPositionOffset.x;
                    if (constraints.maintainOffsetZ) newPosition.z += cameraPositionOffset.z;

                }

                if (constraints.maintainOffsetY) newPosition.y += cameraPositionOffset.y;

                if (constraints.freezePositionX) newPosition.x = cameraTransform.position.x;
                if (constraints.freezePositionY) newPosition.y = cameraTransform.position.y;
                if (constraints.freezePositionZ) newPosition.z = cameraTransform.position.z;

                cameraTransform.position = Vector3.SmoothDamp(
                    cameraTransform.position,
                    newPosition,
                    ref velocity,
                    dampRate
                );

                if (rotating && secondaryTarget)
                {

                    cameraTransform.LookAt(secondaryTarget);

                }

            }

        }

    }

}
