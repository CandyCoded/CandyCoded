#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
{

    public enum GIZMO_TYPE
    {
        None,
        Cube,
        Line,
        Sphere
    }

    public class Gizmo : MonoBehaviour
    {

        public GIZMO_TYPE type = GIZMO_TYPE.None;

        [HideInInspector]
        public Color color = Color.green;
        [HideInInspector]
        public Vector3 offset = Vector3.zero;
        [HideInInspector]
        public Vector3 size = Vector3.one;
        [HideInInspector]
        public Vector3 target = Vector3.zero;
        [HideInInspector]
        public float radius = 1.0f;

        private void OnDrawGizmos()
        {

            Gizmos.color = color;

            switch (type)
            {

                case GIZMO_TYPE.Cube:
                    Gizmos.DrawWireCube(gameObject.transform.position + offset, size);
                    break;

                case GIZMO_TYPE.Line:
                    Gizmos.DrawLine(gameObject.transform.position + offset, target);
                    break;

                case GIZMO_TYPE.Sphere:
                    Gizmos.DrawWireSphere(gameObject.transform.position + offset, radius);
                    break;

                case GIZMO_TYPE.None:
                    break;

            }

        }

    }

#if UNITY_EDITOR

    [UnityEditor.CustomEditor(typeof(Gizmo))]
    public class GizmoEditor : Editor
    {

        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();

            Gizmo script = (Gizmo)target;

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
                    script.target = EditorGUILayout.Vector3Field("Target", script.target);
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
