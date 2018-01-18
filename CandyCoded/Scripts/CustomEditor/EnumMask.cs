using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Enum))]
public class EnumMaskAttribute : PropertyAttribute { }

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
