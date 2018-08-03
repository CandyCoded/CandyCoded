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

    public static class Debugger
    {

        /// <summary>
        /// Draws an array of vectors with Unity's Debug.DrawLine method.
        /// </summary>
        /// <param name="points">Array of Vector3 objects to render lines with.</param>
        /// <param name="color">Color of lines.</param>
        /// <param name="duration">Duration lines remains visible.</param>
        /// <param name="depthTest">Should lines be obscured with objects closer to camera?</param>
        /// <returns>void</returns>
        public static void DrawLines(Vector3[] points, Color color, float duration, bool depthTest)
        {

            for (int i = 0; i < points.Length - 1; i += 1)
            {

                Debug.DrawLine(points[i], points[i + 1], color, duration, depthTest);

            }

        }

        /// <summary>
        /// Draws an array of vectors with Unity's Debug.DrawLine method.
        /// </summary>
        /// <param name="points">Array of Vector3 objects to render lines with.</param>
        /// <param name="color">Color of lines.</param>
        /// <param name="duration">Duration lines remains visible.</param>
        /// <returns>void</returns>
        public static void DrawLines(Vector3[] points, Color color, float duration)
        {

            DrawLines(points, color, duration, true);

        }

        /// <summary>
        /// Draws an array of vectors with Unity's Debug.DrawLine method.
        /// </summary>
        /// <param name="points">Array of Vector3 objects to render lines with.</param>
        /// <param name="color">Color of lines.</param>
        /// <returns>void</returns>
        public static void DrawLines(Vector3[] points, Color color)
        {

            DrawLines(points, color, 0, true);

        }

        /// <summary>
        /// Draws a list of vectors with Unity's Debug.DrawLine method.
        /// </summary>
        /// <param name="points">List of Vector3 objects to render lines with.</param>
        /// <param name="color">Color of lines.</param>
        /// <param name="duration">Duration lines remains visible.</param>
        /// <param name="depthTest">Should lines be obscured with objects closer to camera?</param>
        /// <returns>void</returns>
        public static void DrawLines(List<Vector3> points, Color color, float duration = 0.0f, bool depthTest = true)
        {

            DrawLines(points.ToArray(), color, duration, depthTest);

        }

        /// <summary>
        /// Draws an array of vectors with Unity's Debug.DrawLine method.
        /// </summary>
        /// <param name="points">Array of Vector3 objects to render lines with.</param>
        /// <returns>void</returns>
        public static void DrawLines(Vector3[] points)
        {

            DrawLines(points, Color.white);

        }

        /// <summary>
        /// Draws a list of vectors with Unity's Debug.DrawLine method.
        /// </summary>
        /// <param name="points">List of Vector3 objects to render lines with.</param>
        /// <returns>void</returns>
        public static void DrawLines(List<Vector3> points)
        {

            DrawLines(points.ToArray(), Color.white);

        }

    }

}
