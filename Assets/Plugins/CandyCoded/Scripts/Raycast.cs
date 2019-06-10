// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

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

            var linePositions = new List<Vector3> { startPosition };

            var remainingDistance = distance;

            var currentDirection = direction;

            while (remainingDistance > 0)
            {

                if (Physics.Raycast(linePositions[linePositions.Count - 1], currentDirection, out var hitInfo, remainingDistance, layerMask, QueryTriggerInteraction.Ignore))
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

            return Reflect(startPosition, direction, distance, layerMask, out _);

        }

    }

}
