using UnityEngine;

namespace CandyCoded
{

    public class SelfDestructParticleSystem : MonoBehaviour
    {

        public new ParticleSystem particleSystem;

        private void Awake()
        {

            if (particleSystem == null)
            {

                particleSystem = gameObject.GetComponent<ParticleSystem>();

            }

        }

        private void LateUpdate()
        {

            if (particleSystem && !particleSystem.IsAlive())
            {

                Destroy(gameObject);

            }

        }

    }

}
