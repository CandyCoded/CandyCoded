// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
