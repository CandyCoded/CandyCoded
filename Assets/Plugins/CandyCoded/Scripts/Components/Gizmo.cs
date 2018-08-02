#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
{

    public class Gizmo : MonoBehaviour
    {

        private enum GIZMO_TYPE
        {
            None,
            Cube,
            Line,
            Sphere
        }

        [SerializeField]
        private GIZMO_TYPE type = GIZMO_TYPE.None;

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

                case GIZMO_TYPE.Cube:
                    Gizmos.DrawWireCube(gameObject.transform.position + offset, size);
                    break;

                case GIZMO_TYPE.Line:
                    if (relativeEndPosition)
                    {

                        Gizmos.DrawLine(gameObject.transform.position + offset, gameObject.transform.position + offset + endPosition);

                    }
                    else
                    {

                        Gizmos.DrawLine(gameObject.transform.position + offset, endPosition);

                    }
                    break;

                case GIZMO_TYPE.Sphere:
                    Gizmos.DrawWireSphere(gameObject.transform.position + offset, radius);
                    break;

                case GIZMO_TYPE.None:
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

                    case GIZMO_TYPE.Cube:
                        script.color = EditorGUILayout.ColorField("Color", script.color);
                        script.offset = EditorGUILayout.Vector3Field("Offset", script.offset);
                        script.size = EditorGUILayout.Vector3Field("Size", script.size);
                        break;

                    case GIZMO_TYPE.Line:
                        script.color = EditorGUILayout.ColorField("Color", script.color);
                        script.offset = EditorGUILayout.Vector3Field("Offset", script.offset);
                        script.endPosition = EditorGUILayout.Vector3Field("End Position", script.endPosition);
                        script.relativeEndPosition = EditorGUILayout.Toggle("Relative End Position", script.relativeEndPosition);
                        break;

                    case GIZMO_TYPE.Sphere:
                        script.color = EditorGUILayout.ColorField("Color", script.color);
                        script.offset = EditorGUILayout.Vector3Field("Offset", script.offset);
                        script.radius = EditorGUILayout.FloatField("Radius", script.radius);
                        break;

                    case GIZMO_TYPE.None:
                        break;

                }

            }

        }

#endif

    }

}
