using UnityEngine;

[CreateAssetMenu(fileName = "StringReference", menuName = "CandyCoded/StringReference")]
public class StringReference : ScriptableObject
{

    public string Value;

    [SerializeField]
    private string _defaultValue;
    public string DefaultValue
    {
        get { return _defaultValue; }
    }

    public void Reset()
    {

        Value = DefaultValue;

    }

}
