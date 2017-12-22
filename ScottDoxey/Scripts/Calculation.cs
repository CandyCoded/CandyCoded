using UnityEngine;

namespace CandyCoded {

    public static class Calculation {

        public static Bounds ParentBounds(GameObject parentGameObject) {

            Vector3 center = Vector3.zero;
            Vector3 min = Vector3.zero;
            Vector3 max = Vector3.zero;

            Bounds bounds = new Bounds(center, Vector3.zero);

            Renderer[] renderers = parentGameObject.GetComponentsInChildren<Renderer>();

            foreach (Renderer renderer in renderers) {

                Bounds childBounds = renderer.bounds;

                min = Vector3.Min(min, childBounds.min);
                max = Vector3.Max(max, childBounds.max);

                center = max - min;

            }

            bounds.SetMinMax(min, max);

            return bounds;

        }

    }

}
