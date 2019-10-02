using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace CandyCoded
{

    public abstract class PoolReference<T> : ScriptableObject
    {

        [SerializeField]
        internal int _minObjects = 10;

        public int minObjects
        {
            get => _minObjects;
            set => _minObjects = value;
        }

        internal readonly HashSet<T> _activeObjects = new HashSet<T>();

        public IReadOnlyCollection<T> activeObjects => _activeObjects;

        internal readonly Queue<T> _inactiveObjects = new Queue<T>();

        public ReadOnlyCollection<T> inactiveObjects => _inactiveObjects.ToList().AsReadOnly();

        protected abstract T Create();

        /// <summary>
        /// Populates pool with objects generated via the Create method.
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
        /// Retrieves an object from the pool if available. If no objects are available, a new one is created and returned.
        /// </summary>
        /// <returns><typeparamref name="T"/></returns>
        public T Retrieve()
        {

            var activeObject = _inactiveObjects.Count > 0 ? _inactiveObjects.Dequeue() : Create();

            _activeObjects.Add(activeObject);

            return activeObject;

        }

        /// <summary>
        /// Releases an object back into the object pool.
        /// </summary>
        /// <returns>void</returns>
        public void Release(T item)
        {

            if (_activeObjects.Contains(item) && !_inactiveObjects.Contains(item))
            {

                _activeObjects.Remove(item);

                _inactiveObjects.Enqueue(item);

            }

        }

        /// <summary>
        /// Releases all objects back into the object pool.
        /// </summary>
        /// <returns>void</returns>
        public void ReleaseAllObjects()
        {

            foreach (T item in (IEnumerable)_inactiveObjects)
            {

                Release(item);

            }

            _inactiveObjects.TrimExcess();

        }

    }

}
