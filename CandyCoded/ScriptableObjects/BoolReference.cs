using UnityEngine;

[CreateAssetMenu(fileName = "BoolReference", menuName = "CandyCoded/BoolReference")]
public class BoolReference : ScriptableObject
{

    public bool Value;

    [SerializeField]
    private bool _defaultValue;
    public bool DefaultValue
    {
        get { return _defaultValue; }
    }

    public void Reset()
    {

        Value = DefaultValue;

    }

}
