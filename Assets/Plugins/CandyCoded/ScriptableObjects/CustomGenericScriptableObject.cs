using UnityEngine;

namespace CandyCoded
{

    public abstract class CustomGenericScriptableObject<T> : CustomScriptableObject
    {

        public T Value;

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

            Value = DefaultValue;

        }

    }

}
