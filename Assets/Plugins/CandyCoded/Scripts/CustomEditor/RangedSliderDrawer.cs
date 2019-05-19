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

        private const int labelRectWidth = 50;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var limits = attribute as RangedSliderAttribute;

            var minValue = property.FindPropertyRelative("min").floatValue;
            var maxValue = property.FindPropertyRelative("max").floatValue;

            if (limits == null)
            {
                return;
            }

            var prefixLabel = EditorGUI.PrefixLabel(position, label);
            var rectHeight = EditorGUI.GetPropertyHeight(property);

            var minLabelRect = new Rect(prefixLabel.x, prefixLabel.y, labelRectWidth, rectHeight);
            var sliderRect = new Rect(minLabelRect.xMax, prefixLabel.y, prefixLabel.width - labelRectWidth * 2, rectHeight);
            var maxLabelRect = new Rect(sliderRect.xMax, prefixLabel.y, labelRectWidth, rectHeight);

            EditorGUI.LabelField(minLabelRect, minValue.ToString("F2"), new GUIStyle(GUI.skin.label) { alignment = TextAnchor.UpperLeft });

            EditorGUI.BeginChangeCheck();
            EditorGUI.MinMaxSlider(sliderRect, ref minValue, ref maxValue, limits.MinLimit, limits.MaxLimit);

            if (EditorGUI.EndChangeCheck())
            {
                property.FindPropertyRelative("min").floatValue = minValue;
                property.FindPropertyRelative("max").floatValue = maxValue;
            }

            EditorGUI.LabelField(maxLabelRect, maxValue.ToString("F2"), new GUIStyle(GUI.skin.label) { alignment = TextAnchor.UpperRight });

        }

    }
#endif

}
