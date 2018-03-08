using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public static class Debugger
    {

        public static void DrawLines(Vector3[] points, Color color, float duration = 0.0f, bool depthTest = true)
        {

            for (int i = 0; i < points.Length - 1; i += 1)
            {

                UnityEngine.Debug.DrawLine(points[i], points[i + 1], color, duration, depthTest);

            }

        }

        public static void DrawLines(List<Vector3> points, Color color, float duration = 0.0f, bool depthTest = true)
        {

            DrawLines(points.ToArray(), color, duration, depthTest);

        }

        public static void DrawLines(Vector3[] points)
        {

            DrawLines(points, Color.white);

        }

        public static void DrawLines(List<Vector3> points)
        {

            DrawLines(points.ToArray(), Color.white);

        }

    }

}
