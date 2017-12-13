using UnityEngine;

namespace ScottDoxey {

    public class Gizmo : MonoBehaviour {

        public enum TYPE {
            GIZMO_NONE,
            GIZMO_SPHERE
        }

        public TYPE type = TYPE.GIZMO_NONE;

        public Color color = Color.green;
        public Vector3 vector = Vector3.zero;
        public float size = 0.2f;

        void OnDrawGizmos() {

            Gizmos.color = color;

            if (type == TYPE.GIZMO_SPHERE) {

                Gizmos.DrawWireSphere(gameObject.transform.position + vector, size);

            }

        }

    }

}
