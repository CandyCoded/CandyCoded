using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
{

    [Serializable]
    public struct RangedFloat
    {
        public float min;
        public float max;
        public float Random()
        {

            return UnityEngine.Random.Range(min, max);

        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangedFloat))]
#endif
    public class RangeSliderAttribute : PropertyAttribute
    {

        public float minLimit;
        public float maxLimit;
        public float stepIncrement;

        public RangeSliderAttribute(float min = 0, float max = 1, float step = 0.1f)
        {
            minLimit = min;
            maxLimit = max;
            stepIncrement = step;
        }

    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangeSliderAttribute))]
    public class RangeSliderDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            var limits = attribute as RangeSliderAttribute;

            var minValue = property.FindPropertyRelative("min").floatValue;
            var maxValue = property.FindPropertyRelative("max").floatValue;

            label.tooltip = string.Format("[{0}, {1}]", minValue, maxValue);

            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, limits.minLimit, limits.maxLimit);

            minValue = Mathf.Round(minValue / limits.stepIncrement) * limits.stepIncrement;
            maxValue = Mathf.Round(maxValue / limits.stepIncrement) * limits.stepIncrement;

            property.FindPropertyRelative("min").floatValue = minValue;
            property.FindPropertyRelative("max").floatValue = maxValue;

        }

    }
#endif

}
