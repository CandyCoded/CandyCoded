#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CandyCoded {

    public class CustomEditor {

        [MenuItem("CandyCoded/Font Scaling Fix")]
        private static void FontScalingFix() {

            GameObject target = Selection.activeGameObject;

            RectTransform transform = target.GetComponent<RectTransform>();
            Text text = target.GetComponent<Text>();

            int scale = 5;

            if (text == null) {

                EditorUtility.DisplayDialog("CandyCoded", "Select a GameObject with a Text Component", "Ok");

                return;

            }

            Undo.RecordObject(text, "Increased font size");

            text.fontSize = text.fontSize * scale;

            EditorUtility.SetDirty(text);

            Undo.RecordObject(transform, "Decreased transform size and scale");

            transform.sizeDelta = transform.sizeDelta * scale;
            transform.localScale = transform.localScale / scale;

            EditorUtility.SetDirty(transform);

        }

    }

}

#endif
