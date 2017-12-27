using UnityEngine;

namespace CandyCoded {

    [System.Serializable]
    public class CameraConstraints {
        public bool FreezePositionX;
        public bool FreezePositionY;
        public bool FreezePositionZ;
        [Space(10)]
        public bool MaintainOffsetX;
        public bool MaintainOffsetY;
        public bool MaintainOffsetZ;
    }

    public class CameraFollow : MonoBehaviour {

        public bool tracking = true;

        public Transform mainTarget;
        public Transform secondaryTarget;

        public float dampRate = 0.3f;
        public float rotateSpeed = 5f;

        public CameraConstraints constraints;

        private Transform cameraTransform;

        private Vector3 cameraPositionOffset = Vector3.zero;
        private Quaternion cameraRotationOffset = Quaternion.identity;

        private Vector3 velocity = Vector3.zero;

        private Transform tempCamera;

        void Awake() {

            tempCamera = new GameObject("Camera (temp)").transform;

            cameraTransform = Camera.main.transform;

            if (mainTarget == null) {

                mainTarget = gameObject.transform;

            }

            cameraPositionOffset = new Vector3(
                cameraTransform.position.x - mainTarget.transform.position.x,
                cameraTransform.position.y - mainTarget.transform.position.y,
                cameraTransform.position.z - mainTarget.transform.position.z
            );

            cameraRotationOffset = cameraTransform.rotation;

            tempCamera.position = cameraTransform.position;
            tempCamera.rotation = cameraTransform.rotation;

        }

        void LateUpdate() {

            if (tracking && mainTarget) {

                Vector3 newPosition = mainTarget.transform.position;

                if (constraints.MaintainOffsetX) newPosition.x += cameraPositionOffset.x;
                if (constraints.MaintainOffsetY) newPosition.y += cameraPositionOffset.y;
                if (constraints.MaintainOffsetZ) newPosition.z += cameraPositionOffset.z;

                if (constraints.FreezePositionX) newPosition.x = cameraTransform.position.x;
                if (constraints.FreezePositionY) newPosition.y = cameraTransform.position.y;
                if (constraints.FreezePositionZ) newPosition.z = cameraTransform.position.z;

                tempCamera.position = newPosition;
                tempCamera.rotation = cameraRotationOffset;

                if (secondaryTarget) {

                    float angle = Vector3.Angle(secondaryTarget.position - mainTarget.position, Vector3.forward);

                    float sign = Mathf.Sign(Vector3.Cross(mainTarget.position - secondaryTarget.position, Vector3.forward).normalized.y);

                    tempCamera.RotateAround(mainTarget.position, Vector3.up, angle * sign);

                }

                cameraTransform.position = Vector3.SmoothDamp(
                    cameraTransform.position,
                    tempCamera.position,
                    ref velocity,
                    dampRate
                );

                cameraTransform.rotation = Quaternion.Lerp(
                    cameraTransform.rotation,
                    tempCamera.rotation,
                    rotateSpeed * Time.deltaTime
                );

            }

        }

    }

}
