using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public class Runner : MonoBehaviour
    {

        public Dictionary<string, Coroutine> coroutines = new Dictionary<string, Coroutine>();

        /// <summary>
        /// Starts and adds a coroutine to a list.
        /// </summary>
        /// <param name="coroutineKey">Unique key to store coroutine with.</param>
        /// <param name="routine">IEnumerator to start coroutine with.</param>
        /// <returns>void</returns>
        public Coroutine AddCoroutine(string coroutineKey, IEnumerator routine)
        {

            coroutines.Add(coroutineKey, StartCoroutine(routine));

            return coroutines[coroutineKey];

        }

        /// <summary>
        /// Stops coroutine and removes it from the list.
        /// </summary>
        /// <param name="coroutineKey">Key coroutine is stored with.</param>
        /// <returns>void</returns>
        public void RemoveCoroutine(string coroutineKey)
        {

            if (coroutines.ContainsKey(coroutineKey))
            {

                StopCoroutine(coroutines[coroutineKey]);

                coroutines.Remove(coroutineKey);

            }

        }

        /// <summary>
        /// Stops all coroutines and removes them from the list.
        /// </summary>
        /// <returns>void</returns>
        public void RemoveAllCoroutines()
        {

            List<string> coroutineKeys = new List<string>(coroutines.Keys);

            foreach (string coroutineKey in coroutineKeys)
            {

                StopCoroutine(coroutines[coroutineKey]);

                coroutines.Remove(coroutineKey);

            }

        }

    }

}
