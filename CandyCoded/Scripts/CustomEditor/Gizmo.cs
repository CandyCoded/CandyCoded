#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CandyCoded {

    public enum GIZMO_TYPE {
        None,
        Sphere,
        Cube
    }

    public class Gizmo : MonoBehaviour {

        public GIZMO_TYPE type = GIZMO_TYPE.None;

        [HideInInspector]
        public Color color = Color.green;
        [HideInInspector]
        public Vector3 position = Vector3.zero;
        [HideInInspector]
        public Vector3 size = Vector3.one;
        [HideInInspector]
        public float radius = 1.0f;

        void OnDrawGizmos() {

            Gizmos.color = color;

            switch (type) {

                case GIZMO_TYPE.Sphere:
                    Gizmos.DrawWireSphere(gameObject.transform.position + position, radius);
                    break;

                case GIZMO_TYPE.Cube:
                    Gizmos.DrawWireCube(gameObject.transform.position + position, size);
                    break;

            }

        }

    }

    [UnityEditor.CustomEditor(typeof(Gizmo))]
    public class GizmoEditor : UnityEditor.Editor {

        public override void OnInspectorGUI() {

            DrawDefaultInspector();

            Gizmo script = (Gizmo) target;

            switch (script.type) {

                case GIZMO_TYPE.Sphere:
                    script.color = EditorGUILayout.ColorField("Color", script.color);
                    script.position = EditorGUILayout.Vector3Field("Position", script.position);
                    script.radius = EditorGUILayout.FloatField("Radius", script.radius);
                    break;

                case GIZMO_TYPE.Cube:
                    script.color = EditorGUILayout.ColorField("Color", script.color);
                    script.position = EditorGUILayout.Vector3Field("Position", script.position);
                    script.size = EditorGUILayout.Vector3Field("Size", script.size);
                    break;

            }

        }

    }

}
#endif
