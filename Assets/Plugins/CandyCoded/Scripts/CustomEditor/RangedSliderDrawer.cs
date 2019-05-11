#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
{

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangedFloat))]
#endif
    public class RangedSliderAttribute : PropertyAttribute
    {

        public float MinLimit { get; }

        public float MaxLimit { get; }

        public RangedSliderAttribute(float min, float max)
        {
            MinLimit = min;
            MaxLimit = max;
        }

    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangedSliderAttribute))]
    public class RangeSliderDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            var limits = attribute as RangedSliderAttribute;

            var minValue = property.FindPropertyRelative("min").floatValue;
            var maxValue = property.FindPropertyRelative("max").floatValue;

            label.tooltip = $"[{minValue}, {maxValue}]";

            if (limits != null)
            {
                EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, limits.MinLimit, limits.MaxLimit);
            }

            property.FindPropertyRelative("min").floatValue = minValue;
            property.FindPropertyRelative("max").floatValue = maxValue;

        }

    }
#endif

}
