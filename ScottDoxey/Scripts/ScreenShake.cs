using UnityEngine;

namespace ScottDoxey {

    public class ScreenShake : MonoBehaviour {

        private Vector3 originalPosition;

        private float currentIntensity = 0;
        private float currentDuraton = 0;

        private GameObject wrapperObject;

        void Awake() {

            wrapperObject = new GameObject("ScreenShakeCameraWrapper");

            gameObject.transform.parent = wrapperObject.transform;

            originalPosition = gameObject.transform.position;

        }

        void Update() {

            if (currentDuraton > 0) {

                wrapperObject.transform.position = originalPosition + Random.insideUnitSphere * currentIntensity;

                currentDuraton = Mathf.Max(currentDuraton - Time.deltaTime, 0);

            } else {

                wrapperObject.transform.position = originalPosition;

            }

        }

        public void Shake(float duration = 1.0f, float intensity = 0.2f) {

            currentIntensity = intensity;
            currentDuraton = duration;

        }

    }

}
