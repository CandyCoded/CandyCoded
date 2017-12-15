using UnityEngine;

namespace ScottDoxey {

    public class SelfDestructParticleSystem : MonoBehaviour {

        private ParticleSystem ps;

        void Awake() {

            ps = gameObject.GetComponent<ParticleSystem>();

        }

        void Update() {

            if (!ps.IsAlive()) {

                Destroy(gameObject);

            }

        }

    }

}
