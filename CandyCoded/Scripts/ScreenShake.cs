using UnityEngine;

namespace CandyCoded {

    public enum SCREENSHAKE_DIRECTION {
        All,
        Horizontal,
        Vertical
    }

    public class ScreenShake : MonoBehaviour {

        private float currentIntensity = 0;
        private float currentDuraton = 0;
        private SCREENSHAKE_DIRECTION currentDirection = SCREENSHAKE_DIRECTION.All;

        private GameObject wrapperObject;

        void Awake() {

            wrapperObject = new GameObject("ScreenShakeWrapper");

            gameObject.transform.parent = wrapperObject.transform;

        }

        void Update() {

            Vector3 shakePosition = Vector3.zero;

            if (currentDuraton > 0) {

                if (currentDirection == SCREENSHAKE_DIRECTION.All) {

                    shakePosition = Random.insideUnitCircle * currentIntensity;

                } else if (currentDirection == SCREENSHAKE_DIRECTION.Horizontal) {

                    shakePosition = new Vector3(Random.Range(-1, 1), 0, 0) * currentIntensity;

                } else if (currentDirection == SCREENSHAKE_DIRECTION.Vertical) {

                    shakePosition = new Vector3(0, Random.Range(-1, 1), 0) * currentIntensity;

                }

                currentDuraton = Mathf.Max(currentDuraton - Time.deltaTime, 0);

            }

            wrapperObject.transform.position = shakePosition;

        }

        public void Shake(float duration = 0.5f, float intensity = 0.2f, SCREENSHAKE_DIRECTION direction = SCREENSHAKE_DIRECTION.All) {

            currentIntensity = intensity;
            currentDuraton = duration;
            currentDirection = direction;

        }

    }

}
