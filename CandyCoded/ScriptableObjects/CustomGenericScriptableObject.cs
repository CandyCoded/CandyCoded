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

        public override void Reset()
        {

            Value = DefaultValue;

        }

    }

}
