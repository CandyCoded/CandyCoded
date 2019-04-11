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

        public float MinLimit { get; private set; }
        public float MaxLimit { get; private set; }
        public float StepIncrement { get; private set; }

        public RangedStepSliderAttribute(float min, float max, float step)
        {
            MinLimit = min;
            MaxLimit = max;
            StepIncrement = step;
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

            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, limits.MinLimit, limits.MaxLimit);

            minValue = Mathf.Round(minValue / limits.StepIncrement) * limits.StepIncrement;
            maxValue = Mathf.Round(maxValue / limits.StepIncrement) * limits.StepIncrement;

            property.FindPropertyRelative("min").floatValue = minValue;
            property.FindPropertyRelative("max").floatValue = maxValue;

        }

    }
#endif

}
