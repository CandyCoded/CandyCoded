using UnityEditor;
using UnityEngine;

namespace CandyCoded
{

    public abstract class CustomScriptableObject : ScriptableObject
    {

        public abstract void Reset();

    }

    [CustomEditor(typeof(CustomScriptableObject), true)]
    public class CustomScriptableObjectEditor : Editor
    {

        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();

            CustomScriptableObject script = (CustomScriptableObject) target;

            if (GUILayout.Button("Reset"))
            {

                script.Reset();

            }

        }

    }

}
