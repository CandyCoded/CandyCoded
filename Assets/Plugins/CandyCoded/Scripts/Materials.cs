using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public static class Materials
    {

        /// <summary>
        /// Returns an array of materials attached to renderers that are children of the supplied game object.
        /// </summary>
        /// <param name="gameObject">Parent game object.</param>
        /// <returns>Material[]</returns>
        public static Material[] GetMaterialsInChildren(GameObject gameObject)
        {

            List<Material> materials = new List<Material>();

            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();

            foreach (Renderer renderer in renderers)
            {

                foreach (Material material in renderer.materials)
                {

                    materials.Add(material);

                }

            }

            return materials.ToArray();

        }

        /// <summary>
        /// Set the alpha value of a color object.
        /// </summary>
        /// <param name="color">Color object to modify.</param>
        /// <param name="alpha">New alpha value.</param>
        /// <returns>Color</returns>
        public static Color SetColorAlpha(Color color, float alpha = 1)
        {

            color.a = alpha;

            return color;

        }

    }

}
