// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

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
