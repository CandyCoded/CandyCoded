#if UNITY_EDITOR
using System;
using UnityEditor;
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

[CustomPropertyDrawer(typeof(EnumMaskAttribute))]
public class EnumMaskDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        Enum enumValue = (Enum) fieldInfo.GetValue(property.serializedObject.targetObject);

        EditorGUI.BeginProperty(position, label, property);

        Enum enumNew = EditorGUI.EnumFlagsField(position, label, enumValue);

        property.intValue = (int) Convert.ChangeType(enumNew, enumValue.GetType());

        EditorGUI.EndProperty();

    }

}
#endif
