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

#pragma warning disable S2933
        // Disables "Fields that are only assigned in the constructor should be "readonly"" warning as properties are modified via separate script.
        private Color color = Color.green;
        private Vector3 offset = Vector3.zero;
        private Vector3 size = Vector3.one;
        private Vector3 endPosition = Vector3.zero;
        private bool relativeEndPosition = true;
        private float radius = 1.0f;
#pragma warning restore S2933

#pragma warning disable S1144
        // Disables "Unused private types or members should be removed" warning as method is part of MonoBehaviour.
        private void OnDrawGizmos()
        {

            Gizmos.color = color;

#pragma warning disable S131, IDE0010
            // Disables "Add missing case" warning as value can only be one of three enum values.
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
#pragma warning restore S131, IDE0010

        }
#pragma warning restore S1144

#if UNITY_EDITOR

        [CustomEditor(typeof(Gizmo))]
        public class GizmoEditor : Editor
        {

            public override void OnInspectorGUI()
            {

                DrawDefaultInspector();

                var script = (Gizmo)target;

#pragma warning disable S131, IDE0010
                // Disables "Add missing case" warning as value can only be one of three enum values.
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
#pragma warning restore S131, IDE0010

            }

        }

#endif

    }

}
