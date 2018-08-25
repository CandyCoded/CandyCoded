// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

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

        const float DEFAULT_SCREENSHAKE_DURATION = 0.5f;
        const float DEFAULT_SCREENSHAKE_INTENSITY = 0.2f;

        private float currentIntensity;
        private float currentDuration;

        private ScreenshakeDirections currentDirection = ScreenshakeDirections.All;

        private GameObject wrapperObject;

#pragma warning disable S1144
        // Disables "Unused private types or members should be removed" warning as method is part of MonoBehaviour.
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

#pragma warning disable S131, IDE0010
                // Disables "Add missing case" warning as value can only be one of three enum values.
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
#pragma warning restore S131, IDE0010

                currentDuration = Mathf.Max(currentDuration - Time.unscaledDeltaTime, 0);

            }

            wrapperObject.transform.position = shakePosition;

        }
#pragma warning restore S1144

        /// <summary>
        /// Initiates a screen shake animation.
        /// </summary>
        /// <param name="duration">Duration of the screen shake animation.</param>
        /// <param name="intensity">Intensity of the screen shake animation.</param>
        /// <param name="direction">Direction of the screen shake animation. See <see cref="ScreenshakeDirections"/></param>
        /// <returns>void</returns>
        public void Shake(float duration, float intensity, ScreenshakeDirections direction)
        {

            currentIntensity = intensity;
            currentDuration = duration;
            currentDirection = direction;

        }

        /// <summary>
        /// Initiates a screen shake animation.
        /// </summary>
        /// <param name="duration">Duration of the screen shake animation.</param>
        /// <param name="intensity">Intensity of the screen shake animation.</param>
        /// <returns>void</returns>
        public void Shake(float duration, float intensity)
        {

            Shake(duration, intensity, ScreenshakeDirections.All);

        }

        /// <summary>
        /// Initiates a screen shake animation.
        /// </summary>
        /// <param name="duration">Duration of the screen shake animation.</param>
        /// <returns>void</returns>
        public void Shake(float duration)
        {

            Shake(duration, DEFAULT_SCREENSHAKE_INTENSITY, ScreenshakeDirections.All);

        }

        /// <summary>
        /// Initiates a screen shake animation.
        /// </summary>
        /// <returns>void</returns>
        public void Shake()
        {

            Shake(DEFAULT_SCREENSHAKE_DURATION, DEFAULT_SCREENSHAKE_INTENSITY, ScreenshakeDirections.All);

        }

    }

}
