using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public class Runner : MonoBehaviour
    {

        public Dictionary<string, Coroutine> coroutines = new Dictionary<string, Coroutine>();

        public Coroutine AddCoroutine(string coroutineKey, IEnumerator routine)
        {

            coroutines.Add(coroutineKey, StartCoroutine(routine));

            return coroutines[coroutineKey];

        }

        public void RemoveCoroutine(string coroutineKey)
        {

            if (coroutines.ContainsKey(coroutineKey))
            {

                StopCoroutine(coroutines[coroutineKey]);

                coroutines.Remove(coroutineKey);

            }

        }

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
