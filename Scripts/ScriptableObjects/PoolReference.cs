// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CandyCoded
{

    /// <summary>
    /// PoolReference
    /// </summary>
    public abstract class PoolReference<T> : ScriptableObject
    {

        [SerializeField]
        internal int _minObjects = 10;

        internal readonly HashSet<T> _activeObjects = new HashSet<T>();

        internal readonly Queue<T> _inactiveObjects = new Queue<T>();

        public int minObjects
        {
            get => _minObjects;
            set => _minObjects = value;
        }

        public IReadOnlyCollection<T> activeObjects => _activeObjects;

        public IReadOnlyCollection<T> inactiveObjects => _inactiveObjects;

        protected abstract T Create();

        /// <summary>
        ///     Populates pool with objects generated via the Create method.
        /// </summary>
        /// <returns>void</returns>
        public void Populate()
        {

            for (var i = 0; i < _minObjects; i += 1)
            {

                _inactiveObjects.Enqueue(Create());

            }

        }

        /// <summary>
        ///     Retrieves an object from the pool if available. If no objects are available, a new one is created and returned.
        /// </summary>
        /// <returns>
        ///     <typeparamref name="T" />
        /// </returns>
        public T Retrieve()
        {

            var activeObject = _inactiveObjects.Count > 0 ? _inactiveObjects.Dequeue() : Create();

            _activeObjects.Add(activeObject);

            return activeObject;

        }

        /// <summary>
        ///     Releases an object back into the object pool.
        /// </summary>
        /// <returns>void</returns>
        public virtual void Release(T item)
        {

            if (!_activeObjects.Contains(item) || _inactiveObjects.Contains(item))
            {
                return;
            }

            _activeObjects.Remove(item);

            _inactiveObjects.Enqueue(item);

        }

        /// <summary>
        ///     Releases all objects back into the object pool.
        /// </summary>
        /// <returns>void</returns>
        public void ReleaseAllObjects()
        {

            foreach (var item in _activeObjects.ToList())
            {

                Release(item);

            }

        }

    }

}
