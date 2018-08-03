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

    public static class Calculation
    {

        /// <summary>
        /// Generates a bounds object based on the position and size of the child GameObjects.
        /// </summary>
        /// <param name="gameObject">Parent GameObject to run calculation on.</param>
        /// <returns>Bounds</returns>
        public static Bounds ParentBounds(GameObject gameObject)
        {

            Vector3? min = null;
            Vector3? max = null;

            var bounds = new Bounds();

            var renderers = gameObject.GetComponentsInChildren<Renderer>();

            foreach (Renderer renderer in renderers)
            {

                Bounds childBounds = renderer.bounds;

                if (min.HasValue)
                {

                    min = Vector3.Min(min.Value, childBounds.min);

                }
                else
                {

                    min = childBounds.min;

                }

                if (max.HasValue)
                {

                    max = Vector3.Max(max.Value, childBounds.max);

                }
                else
                {

                    max = childBounds.max;

                }

            }

            if (min.HasValue && max.HasValue)
            {

                bounds.SetMinMax(min.Value, max.Value);

            }

            return bounds;

        }

        /// <summary>
        /// Generates a bounds object based on the position and size of the child GameObjects.
        /// </summary>
        /// <param name="transform">Parent transform to run calculation on.</param>
        /// <returns>Bounds</returns>
        public static Bounds ParentBounds(Transform transform)
        {

            return ParentBounds(transform.gameObject);

        }

    }

}
