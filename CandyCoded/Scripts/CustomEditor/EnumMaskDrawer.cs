using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnumMaskAttribute))]
public class EnumMaskDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        Enum startValue = (Enum) fieldInfo.GetValue(property.serializedObject.targetObject);

        EditorGUI.BeginProperty(position, label, property);

        Enum newValue = EditorGUI.EnumFlagsField(position, label, startValue);

        property.intValue = (int) Convert.ChangeType(newValue, startValue.GetType());

        EditorGUI.EndProperty();

    }

}
