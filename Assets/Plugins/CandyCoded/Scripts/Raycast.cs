/**
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

using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public static class Raycast
    {

        /// <summary>
        /// Creates a raycast that can reflect off certain objects in a layer mask.
        /// </summary>
        /// <param name="startPosition">Vector3 origin of raycast.</param>
        /// <param name="direction">Direction of raycast.</param>
        /// <param name="distance">Distance of raycast.</param>
        /// <param name="layerMask">LayerMask used to determine what the raycast can collide with.</param>
        /// <param name="hits">List of objects raycast collided with.</param>
        /// <returns>Vector3[]</returns>
        public static Vector3[] Reflect(Vector3 startPosition, Vector3 direction, float distance, LayerMask layerMask, out List<RaycastHit> hits)
        {

            hits = new List<RaycastHit>();

            var linePositions = new List<Vector3>
            {
                startPosition
            };

            RaycastHit hitInfo;

            float remainingDistance = distance;

            Vector3 currentDirection = direction;

            while (remainingDistance > 0)
            {

                if (Physics.Raycast(linePositions[linePositions.Count - 1], currentDirection, out hitInfo, remainingDistance, layerMask, QueryTriggerInteraction.Ignore))
                {

                    remainingDistance -= Vector3.Distance(linePositions[linePositions.Count - 1], hitInfo.point);

                    linePositions.Add(hitInfo.point);

                    currentDirection = Vector3.Reflect(currentDirection, hitInfo.normal);

                    hits.Add(hitInfo);

                }
                else
                {

                    linePositions.Add(linePositions[linePositions.Count - 1] + remainingDistance * currentDirection);

                    remainingDistance = 0;

                }

            }

            return linePositions.ToArray();

        }

        /// <summary>
        /// Creates a raycast that can reflect off certain objects in a layer mask.
        /// </summary>
        /// <param name="startPosition">Vector3 origin of raycast.</param>
        /// <param name="direction">Direction of raycast.</param>
        /// <param name="distance">Distance of raycast.</param>
        /// <param name="layerMask">LayerMask used to determine what the raycast can collide with.</param>
        /// <returns>Vector3[]</returns>
        public static Vector3[] Reflect(Vector3 startPosition, Vector3 direction, float distance, LayerMask layerMask)
        {

            List<RaycastHit> hits;

            return Reflect(startPosition, direction, distance, layerMask, out hits);

        }

    }

}
