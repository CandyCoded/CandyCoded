// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

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

        public object value { get; internal set; }

        public void SetStringValue(string value)
        {

            this.value = value;

        }

        public void SetIntValue(int value)
        {

            this.value = value;

        }

        public void SetFloatValue(float value)
        {

            this.value = value;

        }

        public void SetBoolValue(bool value)
        {

            this.value = value;

        }

    }

}
