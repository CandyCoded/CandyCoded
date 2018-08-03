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

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
{

    public class Gizmo : MonoBehaviour
    {

        private enum GizmoTypes
        {
            Cube,
            Line,
            Sphere
        }

        [SerializeField]
        private GizmoTypes type = GizmoTypes.Cube;

        private Color color = Color.green;
        private Vector3 offset = Vector3.zero;
        private Vector3 size = Vector3.one;
        private Vector3 endPosition = Vector3.zero;
        private bool relativeEndPosition = true;
        private float radius = 1.0f;

        private void OnDrawGizmos()
        {

            Gizmos.color = color;

            switch (type)
            {

                case GizmoTypes.Cube:
                    Gizmos.DrawWireCube(gameObject.transform.position + offset, size);
                    break;

                case GizmoTypes.Line:
                    if (relativeEndPosition)
                    {

                        Gizmos.DrawLine(gameObject.transform.position + offset, gameObject.transform.position + offset + endPosition);

                    }
                    else
                    {

                        Gizmos.DrawLine(gameObject.transform.position + offset, endPosition);

                    }
                    break;

                case GizmoTypes.Sphere:
                    Gizmos.DrawWireSphere(gameObject.transform.position + offset, radius);
                    break;

            }

        }

#if UNITY_EDITOR

        [CustomEditor(typeof(Gizmo))]
        public class GizmoEditor : Editor
        {

            public override void OnInspectorGUI()
            {

                DrawDefaultInspector();

                var script = (Gizmo)target;

                switch (script.type)
                {

                    case GizmoTypes.Cube:
                        script.color = EditorGUILayout.ColorField("Color", script.color);
                        script.offset = EditorGUILayout.Vector3Field("Offset", script.offset);
                        script.size = EditorGUILayout.Vector3Field("Size", script.size);
                        break;

                    case GizmoTypes.Line:
                        script.color = EditorGUILayout.ColorField("Color", script.color);
                        script.offset = EditorGUILayout.Vector3Field("Offset", script.offset);
                        script.endPosition = EditorGUILayout.Vector3Field("End Position", script.endPosition);
                        script.relativeEndPosition = EditorGUILayout.Toggle("Relative End Position", script.relativeEndPosition);
                        break;

                    case GizmoTypes.Sphere:
                        script.color = EditorGUILayout.ColorField("Color", script.color);
                        script.offset = EditorGUILayout.Vector3Field("Offset", script.offset);
                        script.radius = EditorGUILayout.FloatField("Radius", script.radius);
                        break;

                }

            }

        }

#endif

    }

}
