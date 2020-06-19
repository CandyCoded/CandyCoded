// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded
{

    public static class Calculation
    {

        /// <summary>
        ///     Generates a bounds object based on the position and size of the child GameObjects.
        /// </summary>
        /// <param name="gameObject">Parent GameObject to run calculation on.</param>
        /// <returns>Bounds</returns>
        public static Bounds ParentBounds(GameObject gameObject)
        {

            Vector3? min = null;
            Vector3? max = null;

            var bounds = new Bounds();

            var renderers = gameObject.GetComponentsInChildren<Renderer>();

            foreach (var renderer in renderers)
            {

                var childBounds = renderer.bounds;

                min = min.HasValue ? Vector3.Min(min.Value, childBounds.min) : childBounds.min;

                max = max.HasValue ? Vector3.Max(max.Value, childBounds.max) : childBounds.max;

            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (min.HasValue && max.HasValue)
            {

                bounds.SetMinMax(min.Value, max.Value);

            }

            return bounds;

        }

        /// <summary>
        ///     Generates a bounds object based on the position and size of the child GameObjects.
        /// </summary>
        /// <param name="transform">Parent transform to run calculation on.</param>
        /// <returns>Bounds</returns>
        public static Bounds ParentBounds(Transform transform)
        {

            return ParentBounds(transform.gameObject);

        }

    }

}
