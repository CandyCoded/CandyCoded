using UnityEngine;

[CreateAssetMenu(fileName = "FloatReference", menuName = "CandyCoded/FloatReference")]
public class FloatReference : ScriptableObject
{

    public float Value;

    [SerializeField]
    private float _defaultValue;
    public float DefaultValue
    {
        get { return _defaultValue; }
    }

    public void Reset()
    {

        Value = DefaultValue;

    }

}
