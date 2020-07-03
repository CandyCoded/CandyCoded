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
