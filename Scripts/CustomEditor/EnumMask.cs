// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
{

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(Enum))]
#endif

    // ReSharper disable once RequiredBaseTypesIsNotInherited
    public class EnumMaskAttribute : PropertyAttribute
    {

    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(EnumMaskAttribute))]
    public class EnumMaskDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            var enumValue = (Enum)fieldInfo.GetValue(property.serializedObject.targetObject);

            EditorGUI.BeginProperty(position, label, property);

            var enumNew = EditorGUI.EnumFlagsField(position, label, enumValue);

            property.intValue = (int)Convert.ChangeType(enumNew, enumValue.GetType());

            EditorGUI.EndProperty();

        }

    }
#endif

}
