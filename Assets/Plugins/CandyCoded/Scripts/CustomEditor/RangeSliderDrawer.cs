#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
{

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangedFloat))]
#endif
    public class RangeSliderAttribute : PropertyAttribute
    {

        public float minLimit;
        public float maxLimit;

        public RangeSliderAttribute(float min, float max)
        {
            minLimit = min;
            maxLimit = max;
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

            property.FindPropertyRelative("min").floatValue = minValue;
            property.FindPropertyRelative("max").floatValue = maxValue;

        }

    }
#endif

}
