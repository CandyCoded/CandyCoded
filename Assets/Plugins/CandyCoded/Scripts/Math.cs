// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded
{

    public static class Math
    {

        /// <summary>
        /// Interpolates circularly between either two numbers by a given value.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="value">The interpolation value between the two floats.</param>
        /// <returns>float</returns>
        public static float Clerp(float start, float end, float value)
        {

            float max = 360;
            float half = max / 2;
            float diff = end - start;

            if (diff < -half)
            {
                return start + ((max - start) + end) * value;
            }

            if (diff > half)
            {
                return start - ((max - end) + start) * value;
            }

            return start + (end - start) * value;

        }

        /// <summary>
        /// Interpolates circularly between either two Vector3 objects by a given value.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="value">The interpolation value between the two Vector3 objects.</param>
        /// <returns>Vector3</returns>
        public static Vector3 Clerp(Vector3 start, Vector3 end, float value)
        {

            return new Vector3(
                Clerp(start.x, end.x, value),
                Clerp(start.y, end.y, value),
                Clerp(start.z, end.z, value)
            );

        }

    }

}
