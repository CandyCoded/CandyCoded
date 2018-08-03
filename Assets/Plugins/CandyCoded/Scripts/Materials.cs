/*
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

    public static class Materials
    {

        /// <summary>
        /// Returns an array of materials attached to renderers that are children of the supplied GameObject.
        /// </summary>
        /// <param name="gameObject">Parent GameObject.</param>
        /// <returns>Material[]</returns>
        public static Material[] GetMaterialsInChildren(GameObject gameObject)
        {

            var materials = new List<Material>();

            var renderers = gameObject.GetComponentsInChildren<Renderer>();

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
        public static Color SetColorAlpha(Color color, float alpha)
        {

            color.a = alpha;

            return color;

        }

        /// <summary>
        /// Set the alpha value of a color object.
        /// </summary>
        /// <param name="color">Color object to modify.</param>
        /// <returns>Color</returns>
        public static Color SetColorAlpha(Color color)
        {

            return SetColorAlpha(color, 1);

        }

    }

}
