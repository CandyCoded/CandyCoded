#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
{

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangedFloat))]
#endif
    public class RangedStepSliderAttribute : PropertyAttribute
    {

        public float minLimit { get; private set; }
        public float maxLimit { get; private set; }
        public float stepIncrement { get; private set; }

        public RangedStepSliderAttribute(float min, float max, float step)
        {
            minLimit = min;
            maxLimit = max;
            stepIncrement = step;
        }

    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(RangedStepSliderAttribute))]
    public class RangedStepSliderDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            var limits = attribute as RangedStepSliderAttribute;

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
