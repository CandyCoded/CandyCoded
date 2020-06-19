// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CandyCoded
{

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangedFloat))]
#endif

    // ReSharper disable once RequiredBaseTypesIsNotInherited
    public class RangedSliderAttribute : PropertyAttribute
    {

        public RangedSliderAttribute(float min, float max)
        {
            MinLimit = min;
            MaxLimit = max;
        }

        public float MinLimit { get; }

        public float MaxLimit { get; }

    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangedSliderAttribute))]
    public class RangeSliderDrawer : PropertyDrawer
    {

        private const int labelRectWidth = 50;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var limits = attribute as RangedSliderAttribute;

            var minValue = property.FindPropertyRelative("min").floatValue;
            var maxValue = property.FindPropertyRelative("max").floatValue;

            if (Equals(limits, null))
            {
                return;
            }

            var prefixLabel = EditorGUI.PrefixLabel(position, label);

            var prevIndentLevel = EditorGUI.indentLevel;

            EditorGUI.indentLevel = 0;

            var minLabelRect = new Rect(prefixLabel.x, prefixLabel.y, labelRectWidth, position.height);

            var sliderRect = new Rect(minLabelRect.xMax, prefixLabel.y, prefixLabel.width - labelRectWidth * 2,
                position.height);

            var maxLabelRect = new Rect(sliderRect.xMax, prefixLabel.y, labelRectWidth, position.height);

            EditorGUI.LabelField(minLabelRect, minValue.ToString("F2"),
                new GUIStyle(GUI.skin.label) { alignment = TextAnchor.UpperLeft });

            EditorGUI.BeginChangeCheck();
            EditorGUI.MinMaxSlider(sliderRect, ref minValue, ref maxValue, limits.MinLimit, limits.MaxLimit);

            if (EditorGUI.EndChangeCheck())
            {
                property.FindPropertyRelative("min").floatValue = minValue;
                property.FindPropertyRelative("max").floatValue = maxValue;
            }

            EditorGUI.LabelField(maxLabelRect, maxValue.ToString("F2"),
                new GUIStyle(GUI.skin.label) { alignment = TextAnchor.UpperRight });

            EditorGUI.indentLevel = prevIndentLevel;

        }

    }
#endif

}
