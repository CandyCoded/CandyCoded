using System.Linq;
using UnityEngine;

// ReSharper disable SuspiciousTypeConversion.Global

namespace CandyCoded.Interfaces
{

    public static class InterfaceEvents
    {

        public static void PauseAllPausableObjects()
        {

            var pausableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();

            foreach (var pausableObject in pausableObjects)
            {

                pausableObject.Pause();

            }

        }

        public static void ResumeAllPausableObjects()
        {

            var pausableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<IPauseable>();

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
