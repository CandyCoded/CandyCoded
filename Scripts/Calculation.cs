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

            Bounds bounds = new Bounds();

            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();

            foreach (Renderer renderer in renderers)
            {

                Bounds childBounds = renderer.bounds;

                if (!min.HasValue)
                {

                    min = childBounds.min;

                }
                else
                {

                    min = Vector3.Min(min.Value, childBounds.min);

                }

                if (!max.HasValue)
                {

                    max = childBounds.max;

                }
                else
                {

                    max = Vector3.Max(max.Value, childBounds.max);

                }

            }

            bounds.SetMinMax(min.Value, max.Value);

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
