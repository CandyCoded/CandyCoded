using UnityEngine;

namespace CandyCoded {

    public class SelfDestructParticleSystem : MonoBehaviour {

        private ParticleSystem ps;

        void Awake() {

            ps = gameObject.GetComponent<ParticleSystem>();

        }

        void LateUpdate() {

            if (ps && !ps.IsAlive()) {

                Destroy(gameObject);

            }

        }

    }

}
