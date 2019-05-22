using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace CandyCoded
{

    public abstract class PoolReference<T> : ScriptableObject
    {

        [SerializeField]
        internal T _obj;

        public T obj
        {
            get => _obj;
            set => _obj = value;
        }

        [SerializeField]
        internal int _minObjects = 10;

        public int minObjects
        {
            get => _minObjects;
            set => _minObjects = value;
        }

        internal readonly List<T> _activeObjects = new List<T>();

        public ReadOnlyCollection<T> activeObjects => _activeObjects.AsReadOnly();

        internal readonly Queue<T> _inactiveObjects = new Queue<T>();

        public ReadOnlyCollection<T> inactiveObjects => _inactiveObjects.ToList().AsReadOnly();

        protected abstract T Create();

        public void Populate()
        {

            for (var i = 0; i < _minObjects; i += 1)
            {

                _inactiveObjects.Enqueue(Create());

            }

        }

        public T Retrieve()
        {

            T activeObject;

            if (_inactiveObjects.Count > 0)
            {

                activeObject = _inactiveObjects.Dequeue();

            }
            else
            {

                activeObject = Create();

            }

            _activeObjects.Add(activeObject);

            return activeObject;

        }

        public void Release(T item)
        {

            if (!_activeObjects.Contains(item) || !_inactiveObjects.Contains(item))
            {

                return;

            }

            _activeObjects.Remove(item);

            _inactiveObjects.Enqueue(item);

        }

        public void ReleaseAllObjects()
        {

            while (_activeObjects.Count > 0)
            {

                if (_activeObjects[0] != null)
                {

                    Release(_activeObjects[0]);

                }

            }

        }

    }

}
