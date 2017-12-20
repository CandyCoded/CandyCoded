using UnityEngine;

namespace ScottDoxey {

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

        public Transform mainTarget;

        public float dampRate = 0.3f;

        public CameraConstraints constraints;

        private Transform cameraTransform;

        private Vector3 cameraOffset = Vector3.zero;

        private Vector3 velocity = Vector3.zero;

        void Awake() {

            cameraTransform = Camera.main.transform;

            if (mainTarget == null) {

                mainTarget = gameObject.transform;

            }

            cameraOffset = new Vector3(
                cameraTransform.position.x - mainTarget.transform.position.x,
                cameraTransform.position.y - mainTarget.transform.position.y,
                cameraTransform.position.z - mainTarget.transform.position.z
            );

        }

        void Update() {

            if (mainTarget) {

                Vector3 newPosition = mainTarget.transform.position;

                if (constraints.FreezePositionX) newPosition.x = cameraTransform.position.x;
                if (constraints.FreezePositionY) newPosition.y = cameraTransform.position.y;
                if (constraints.FreezePositionZ) newPosition.z = cameraTransform.position.z;

                if (constraints.MaintainOffsetX) newPosition.x += cameraOffset.x;
                if (constraints.MaintainOffsetY) newPosition.y += cameraOffset.y;
                if (constraints.MaintainOffsetZ) newPosition.z += cameraOffset.z;

                cameraTransform.position = Vector3.SmoothDamp(
                    cameraTransform.position,
                    newPosition,
                    ref velocity,
                    dampRate
                );

            }

        }

    }

}
