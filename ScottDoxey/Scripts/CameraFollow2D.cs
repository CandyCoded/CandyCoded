using UnityEngine;

namespace ScottDoxey {

    public class CameraFollow2D : MonoBehaviour {

        public Transform target;

        private Camera mainCamera;

        private readonly float dampRate = 0.3f;

        private Vector3 velocity = Vector3.zero;

        void Awake() {

            mainCamera = Camera.main;

            if (target == null) {

                target = gameObject.transform;

            }

        }

        void Update() {

            if (target) {

                mainCamera.transform.position = Vector3.SmoothDamp(
                    mainCamera.transform.position, new Vector3(
                        target.transform.position.x,
                        target.transform.position.y,
                        mainCamera.transform.position.z
                    ),
                    ref velocity,
                    dampRate
                );

            }

        }

    }

}
