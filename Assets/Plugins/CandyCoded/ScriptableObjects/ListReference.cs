// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

#pragma warning disable S1694
    // Disables "An abstract class should have both abstract and concrete methods" warning as class must extend CustomScriptableObject.
    public abstract class ListReference<T> : CustomScriptableObject
    {

        [SerializeField]
        private List<T> _items = new List<T>();
        public List<T> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// Adds an item to the list attached to the scriptable object.
        /// </summary>
        /// <param name="item">Item to add to the list.</param>
        /// <returns>void</returns>
        public void Add(T item)
        {

            if (!_items.Contains(item))
            {

                _items.Add(item);

            }

        }

        /// <summary>
        /// Removes an item from the list attached to the scriptable object.
        /// </summary>
        /// <param name="item">Item to remove from the list.</param>
        /// <returns>bool</returns>
        public bool Remove(T item)
        {

            return _items.Remove(item);

        }

        /// <summary>
        /// Clears the list attached to the scriptable object.
        /// </summary>
        /// <returns>void</returns>
        public void Clear()
        {

            _items.Clear();

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
#pragma warning restore S1694

}
