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

            List<Vector3> linePositions = new List<Vector3>();

            linePositions.Add(startPosition);

            RaycastHit hitInfo;

            float remainingDistance = distance;

            while (remainingDistance > 0)
            {

                if (Physics.Raycast(linePositions[linePositions.Count - 1], direction, out hitInfo, remainingDistance, layerMask, QueryTriggerInteraction.Ignore))
                {

                    remainingDistance -= Vector3.Distance(linePositions[linePositions.Count - 1], hitInfo.point);

                    linePositions.Add(hitInfo.point);

                    direction = Vector3.Reflect(direction, hitInfo.normal);

                    hits.Add(hitInfo);

                }
                else
                {

                    linePositions.Add(linePositions[linePositions.Count - 1] + remainingDistance * direction);

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
