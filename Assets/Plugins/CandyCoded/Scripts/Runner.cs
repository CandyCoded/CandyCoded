/**
 * The MIT License (MIT)
 *
 * Copyright (c) 2018 Scott Doxey
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

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

            var coroutineKeys = new List<string>(_coroutines.Keys);

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
