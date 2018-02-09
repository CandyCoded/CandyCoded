using UnityEngine;

namespace CandyCoded
{

    public class SelfDestructParticleSystem : MonoBehaviour
    {

        private ParticleSystem ps;

        private void Awake()
        {

            ps = gameObject.GetComponent<ParticleSystem>();

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
