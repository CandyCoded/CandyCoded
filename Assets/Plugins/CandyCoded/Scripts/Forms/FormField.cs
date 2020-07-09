// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using UnityEngine.UI;

namespace CandyCoded.Experimental
{

    [AddComponentMenu("CandyCoded / Forms / Form Field")]
    public class FormField : MonoBehaviour
    {

        private const string FIELD_NAME_PREFIX = "Field_";

        private static int _fieldCount;

#pragma warning disable CS0649
        [SerializeField]
        private string _name;
#pragma warning restore CS0649

        public new string name
        {
            get
            {
                if (_name == "")
                {

                    _name = $"{FIELD_NAME_PREFIX}{++_fieldCount}";

                }

                return _name;
            }
        }

        private object _value;

        public object value
        {
            get
            {

                if (gameObject.TryGetComponent<InputField>(out var inputField))
                {

                    return inputField.text;

                }

                if (gameObject.TryGetComponent<Toggle>(out var toggle))
                {

                    return toggle.isOn;

                }

                if (gameObject.TryGetComponent<Dropdown>(out var dropdown))
                {

                    return dropdown.value;

                }

                if (gameObject.TryGetComponent<Slider>(out var slider))
                {

                    return slider.value;

                }

                return _value;

            }
        }

        public void SetStringValue(string value)
        {

            _value = value;

        }

        public void SetIntValue(int value)
        {

            _value = value;

        }

        public void SetFloatValue(float value)
        {

            _value = value;

        }

        public void SetBoolValue(bool value)
        {

            _value = value;

        }

    }

}
