using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public abstract class ListReference<T> : CustomScriptableObject
    {

        public List<T> Items = new List<T>();

        public int Count
        {
            get { return Items.Count; }
        }

        /// <summary>
        /// Adds an item to the list attached to the scriptable object.
        /// </summary>
        /// <param name="item">Object to add to the list.</param>
        /// <returns>void</returns>
        public void Add(T item)
        {

            if (!Items.Contains(item))
            {

                Items.Add(item);

            }

        }

        /// <summary>
        /// Removes an item from the list attached to the scriptable object.
        /// </summary>
        /// <param name="item">Object to remove from the list.</param>
        /// <returns>bool</returns>
        public bool Remove(T item)
        {

            return Items.Remove(item);

        }

        /// <summary>
        /// Clears the list attached to the scriptable object.
        /// </summary>
        /// <returns>void</returns>
        public void Clear()
        {

            Items.Clear();

        }

        /// <summary>
        /// Clears the list attached to the scriptable object.
        /// </summary>
        /// <returns>void</returns>
        public override void Reset()
        {

            Clear();

        }

    }

}
