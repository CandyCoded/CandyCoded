// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded
{

    public class SelfDestructParticleSystem : MonoBehaviour
    {

        [SerializeField]
        private ParticleSystem ps;

#pragma warning disable S1144
        // Disables "Unused private types or members should be removed" warning as method is part of MonoBehaviour.
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
#pragma warning restore S1144

    }

}
