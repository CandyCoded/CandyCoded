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
        public static void DrawLines(Vector3[] points, Color color, float duration = 0.0f, bool depthTest = true)
        {

            for (int i = 0; i < points.Length - 1; i += 1)
            {

                Debug.DrawLine(points[i], points[i + 1], color, duration, depthTest);

            }

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
