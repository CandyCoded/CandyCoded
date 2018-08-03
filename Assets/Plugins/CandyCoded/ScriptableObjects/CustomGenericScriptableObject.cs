/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2018 Scott Doxey
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

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
