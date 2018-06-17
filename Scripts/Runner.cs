using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public class Runner : MonoBehaviour
    {

        public delegate void OneShotFunc();

        private Dictionary<string, Coroutine> _coroutines = new Dictionary<string, Coroutine>();
        public Dictionary<string, Coroutine> Coroutines
        {
            get
            {
                return _coroutines;
            }
        }

        /// <summary>
        /// Starts and adds a coroutine to a list.
        /// </summary>
        /// <param name="coroutineKey">Unique key to store coroutine with.</param>
        /// <param name="routine">IEnumerator to start coroutine with.</param>
        /// <returns>Coroutine</returns>
        public Coroutine AddCoroutine(string coroutineKey, IEnumerator routine)
        {

            _coroutines.Add(coroutineKey, StartCoroutine(routine));

            return _coroutines[coroutineKey];

        }

        /// <summary>
        /// Stops coroutine and removes it from the list.
        /// </summary>
        /// <param name="coroutineKey">Key coroutine was originally stored with.</param>
        /// <returns>void</returns>
        public void RemoveCoroutine(string coroutineKey)
        {

            if (_coroutines.ContainsKey(coroutineKey))
            {

                StopCoroutine(_coroutines[coroutineKey]);

                _coroutines.Remove(coroutineKey);

            }

        }

        /// <summary>
        /// Stops all coroutines and removes them from the list.
        /// </summary>
        /// <returns>void</returns>
        public void RemoveAllCoroutines()
        {

            List<string> coroutineKeys = new List<string>(_coroutines.Keys);

            foreach (string coroutineKey in coroutineKeys)
            {

                StopCoroutine(_coroutines[coroutineKey]);

            }

            _coroutines.Clear();

        }

        /// <summary>
        /// Wraps an anonymous method in an IEnumerator. Continues after the defined number of seconds.
        /// </summary>
        /// <param name="oneShotFunc">An anonymous method with no parameters.</param>
        /// <param name="delayInSeconds">Seconds to wait after calling the anonymous method.</param>
        /// <returns>IEnumerator</returns>
        public static IEnumerator OneShot(OneShotFunc oneShotFunc, float delayInSeconds)
        {

            oneShotFunc();

            yield return new WaitForSeconds(delayInSeconds);

        }

        /// <summary>
        /// Wraps an anonymous method in an IEnumerator. Continues on the next frame.
        /// </summary>
        /// <param name="oneShotFunc">An anonymous method with no parameters.</param>
        /// <returns>IEnumerator</returns>
        public static IEnumerator OneShot(OneShotFunc oneShotFunc)
        {

            oneShotFunc();

            yield return null;

        }

    }

}
