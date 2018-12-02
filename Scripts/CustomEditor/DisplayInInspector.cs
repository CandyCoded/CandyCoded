// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections;
#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
#endif
using UnityEngine;

#pragma warning disable S3903
// Disables "Types should be defined in named namespaces" warning as component should be available at all times.

[AttributeUsage(AttributeTargets.Method)]
public class DisplayInInspectorAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomEditor(typeof(MonoBehaviour), true)]
public class DisplayInInspectorDrawer : Editor
{

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        var members = target.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var member in members)
        {

            if (Attribute.IsDefined(member, typeof(DisplayInInspectorAttribute)))
            {

                if (GUILayout.Button(ObjectNames.NicifyVariableName(member.Name)))
                {

                    var info = (MethodInfo)member;

                    if (info.ReturnType == typeof(IEnumerator))
                    {

                        ((MonoBehaviour)target).StartCoroutine(member.Name);

                    }
                    else
                    {

                        info.Invoke(target, null);

                    }

                }

            }

        }

    }

}
#endif

#pragma warning restore S3903
