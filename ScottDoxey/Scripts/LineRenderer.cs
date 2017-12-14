namespace ScottDoxey {

    public static class LineRenderer {

        public static Vector3[] Reflect(Vector3 startPosition, Vector3 direction, float distance, LayerMask layerMask) {

            List<Vector3> linePositions = new List<Vector3>();

            linePositions.Add(startPosition);

            RaycastHit hitInfo;

            float remainingDistance = distance;

            while (remainingDistance > 0) {

                if (Physics.Raycast(linePositions[linePositions.Count - 1], direction, out hitInfo, remainingDistance, layerMask, QueryTriggerInteraction.Ignore)) {

                    remainingDistance -= Vector3.Distance(linePositions[linePositions.Count - 1], hitInfo.point);

                    linePositions.Add(hitInfo.point);

                    direction = Vector3.Reflect(direction, hitInfo.normal);

                } else {

                    linePositions.Add(linePositions[linePositions.Count - 1] + remainingDistance * direction);

                    remainingDistance = 0;

                }

            }

            return linePositions.ToArray();

        }

    }

}
