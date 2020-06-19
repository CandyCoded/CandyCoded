// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Linq;
using UnityEngine;

// ReSharper disable SuspiciousTypeConversion.Global

namespace CandyCoded.Interfaces
{

    public static class InterfaceEvents
    {

        public static void PauseAllPausableObjects()
        {

            var pausableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();

            foreach (var pausableObject in pausableObjects)
            {

                pausableObject.Pause();

            }

        }

        public static void ResumeAllPausableObjects()
        {

            var pausableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();

            foreach (var pausableObject in pausableObjects)
            {

                pausableObject.Resume();

            }

        }

        public static void TurnOffAllToggleableObjects()
        {

            var toggleableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<IToggleable>();

            foreach (var toggleableObject in toggleableObjects)
            {

                toggleableObject.Off();

            }

        }

        public static void TurnOnAllToggleableObjects()
        {

            var toggleableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<IToggleable>();

            foreach (var toggleableObject in toggleableObjects)
            {

                toggleableObject.On();

            }

        }

    }

}
