using UnityEngine;

namespace CandyCoded
{

    public class SelfDestructParticleSystem : MonoBehaviour
    {

        public ParticleSystem ps;

        private void Awake()
        {

            if (ps == null)
            {

                ps = gameObject.GetComponent<ParticleSystem>();

            }

        }

        private void LateUpdate()
        {

            if (ps && !ps.IsAlive())
            {

                Destroy(gameObject);

            }

        }

    }

}
