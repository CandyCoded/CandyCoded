// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded
{

    public class SelfDestructParticleSystem : MonoBehaviour
    {

        [SerializeField]
        private ParticleSystem ps;

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
