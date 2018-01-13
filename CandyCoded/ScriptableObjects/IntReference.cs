using UnityEngine;

[CreateAssetMenu(fileName = "IntReference", menuName = "CandyCoded/IntReference")]
public class IntReference : ScriptableObject
{

    public int Value;

    [SerializeField]
    private int _defaultValue;
    public int DefaultValue
    {
        get { return _defaultValue; }
    }

    public void Reset()
    {

        Value = DefaultValue;

    }

}
