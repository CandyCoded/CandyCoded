using UnityEngine;

public class EnumMaskAttribute : PropertyAttribute
{

    public string name;

    public EnumMaskAttribute() { }

    public EnumMaskAttribute(string name)
    {

        this.name = name;

    }

}
