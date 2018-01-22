using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(Enum))]
#endif
public class EnumMaskAttribute : PropertyAttribute { }

#if UNITY_EDITOR
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
