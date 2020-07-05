// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded.Experimental
{

    [AddComponentMenu("CandyCoded / Forms / Form Field")]
    public class FormField : MonoBehaviour
    {

#pragma warning disable CS0649
        [SerializeField]
        private string _name;
#pragma warning restore CS0649

        public new string name => _name;

        public string value { get; internal set; }

        public void SetValue(string value)
        {

            this.value = value;

        }

        public void SetValue(int value)
        {

            this.value = value.ToString();

        }

    }

}
