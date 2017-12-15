using UnityEngine;

namespace ScottDoxey {

    public static class Calculation {

        public static Bounds ParentBounds(GameObject parentGameObject) {

            Vector3 center = Vector3.zero;
            Vector3 min = Vector3.zero;
            Vector3 max = Vector3.zero;

            Bounds bounds = new Bounds(center, Vector3.zero);

            for (int i = 0; i < parentGameObject.transform.childCount; i++) {

                GameObject child = parentGameObject.transform.GetChild(i).gameObject;

                Bounds childBounds = child.GetComponentInChildren<Renderer>().bounds;

                min = Vector3.Min(min, childBounds.min);
                max = Vector3.Max(max, childBounds.max);

                center = max - min;

            }

            bounds.SetMinMax(min, max);

            return bounds;

        }

    }

}
