using UnityEngine;

namespace CandyCoded {

    public class ScreenShake : MonoBehaviour {

        private float currentIntensity = 0;
        private float currentDuraton = 0;

        private GameObject wrapperObject;

        void Awake() {

            wrapperObject = new GameObject("ScreenShakeWrapper");

            gameObject.transform.parent = wrapperObject.transform;

        }

        void Update() {

            if (currentDuraton > 0) {

                Vector3 shakePosition = Random.insideUnitSphere * currentIntensity;

                wrapperObject.transform.position = shakePosition;

                currentDuraton = Mathf.Max(currentDuraton - Time.deltaTime, 0);

            } else {

                wrapperObject.transform.position = Vector3.zero;

            }

        }

        public void Shake(float duration = 0.5f, float intensity = 0.2f) {

            currentIntensity = intensity;
            currentDuraton = duration;

        }

    }

}
