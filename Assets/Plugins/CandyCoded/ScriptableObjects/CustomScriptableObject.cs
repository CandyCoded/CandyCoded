#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
{

    public abstract class CustomScriptableObject : ScriptableObject
    {

        public abstract void Reset();

    }

#if UNITY_EDITOR

    [CustomEditor(typeof(CustomScriptableObject), true)]
    public class CustomScriptableObjectEditor : Editor
    {

        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();

            var script = (CustomScriptableObject)target;

            if (GUILayout.Button("Reset"))
            {

                script.Reset();

            }

        }

    }

#endif

}
