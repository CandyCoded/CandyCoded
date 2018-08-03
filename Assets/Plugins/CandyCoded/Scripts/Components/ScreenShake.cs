using UnityEngine;

namespace CandyCoded
{

    public enum ScreenshakeDirections
    {
        All,
        Horizontal,
        Vertical
    }

    public class ScreenShake : MonoBehaviour
    {

        private float currentIntensity;
        private float currentDuration;

        private ScreenshakeDirections currentDirection = ScreenshakeDirections.All;

        private GameObject wrapperObject;

        private void Awake()
        {

            wrapperObject = new GameObject("ScreenShakeWrapper");

            gameObject.transform.parent = wrapperObject.transform;

        }

        private void Update()
        {

            Vector3 shakePosition = Vector3.zero;

            if (currentDuration > 0)
            {

                switch (currentDirection)
                {

                    case ScreenshakeDirections.All:
                        shakePosition = Random.insideUnitCircle * currentIntensity;
                        break;

                    case ScreenshakeDirections.Horizontal:
                        shakePosition = new Vector3(Random.Range(-1, 1), 0, 0) * currentIntensity;
                        break;

                    case ScreenshakeDirections.Vertical:
                        shakePosition = new Vector3(0, Random.Range(-1, 1), 0) * currentIntensity;
                        break;

                }

                currentDuration = Mathf.Max(currentDuration - Time.unscaledDeltaTime, 0);

            }

            wrapperObject.transform.position = shakePosition;

        }

        /// <summary>
        /// Initiates a screen shake animation.
        /// </summary>
        /// <param name="duration">Duration of the screen shake animation.</param>
        /// <param name="intensity">Intensity of the screen shake animation.</param>
        /// <param name="direction">Direction of the screen shake animation. See <see cref="ScreenshakeDirections"/></param>
        /// <returns>void</returns>
        public void Shake(float duration = 0.5f, float intensity = 0.2f, ScreenshakeDirections direction = ScreenshakeDirections.All)
        {

            currentIntensity = intensity;
            currentDuration = duration;
            currentDirection = direction;

        }

    }

}
