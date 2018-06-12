using UnityEngine;

namespace CandyCoded
{

    public abstract class CustomGenericScriptableObject<T> : CustomScriptableObject
    {

        public delegate void EventHandler(T updatedValue);
        public event EventHandler UpdateEvent;
        public event EventHandler ResetEvent;

        [SerializeField]
        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {

                _value = value;

                if (UpdateEvent != null)
                {
                    UpdateEvent(_value);
                }

            }
        }

        [SerializeField]
        private T _defaultValue;
        public T DefaultValue
        {
            get { return _defaultValue; }
        }

        /// <summary>
        /// Resets the scriptable object value back to its default value.
        /// </summary>
        /// <returns>void</returns>
        public override void Reset()
        {

            _value = DefaultValue;

            if (ResetEvent != null)
            {
                ResetEvent(_value);
            }

        }

    }

}
