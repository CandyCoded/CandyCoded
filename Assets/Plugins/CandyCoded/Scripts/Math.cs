/*
* The MIT License (MIT)
*
* Copyright (c) 2018 Scott Doxey
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

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
