// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded
{

#pragma warning disable S1694

    // Disables "An abstract class should have both abstract and concrete methods" warning as class must extend CustomScriptableObject.
    public abstract class CustomGenericScriptableObject<T> : CustomScriptableObject
    {

        public delegate void EventHandler(T updatedValue);

#pragma warning disable CS0649
        [SerializeField]
        private T _defaultValue;
#pragma warning restore CS0649

        [SerializeField]
        private T _value;

        public T Value
        {
            get => _value;
            set
            {

                _value = value;

                UpdateEvent?.Invoke(_value);

            }
        }

        public T DefaultValue => _defaultValue;

        /// <summary>
        ///     Resets the scriptable object value back to its default value.
        /// </summary>
        /// <returns>void</returns>
        public override void Reset()
        {

            _value = DefaultValue;

            ResetEvent?.Invoke(_value);

        }

        public event EventHandler UpdateEvent;

        public event EventHandler ResetEvent;

    }
#pragma warning restore S1694

}
