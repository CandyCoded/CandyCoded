using System.Collections.Generic;

namespace CandyCoded
{

    public abstract class ListReference<T> : CustomScriptableObject
    {

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

}
