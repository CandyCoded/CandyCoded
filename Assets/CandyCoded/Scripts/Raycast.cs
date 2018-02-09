using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public static class Raycast
    {

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

        public static Vector3[] Reflect(Vector3 startPosition, Vector3 direction, float distance, LayerMask layerMask)
        {

            List<RaycastHit> hits;

            return Reflect(startPosition, direction, distance, layerMask, out hits);

        }

    }

}
