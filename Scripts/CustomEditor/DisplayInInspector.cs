using System;
using System.Collections;
#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
#endif
using UnityEngine;

[AttributeUsage(AttributeTargets.Method)]
public class DisplayInInspectorAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomEditor(typeof(MonoBehaviour), true)]
public class DisplayInInspectorDrawer : Editor
{

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        MemberInfo[] methods = target.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (MemberInfo method in methods)
        {

            if (Attribute.IsDefined(method, typeof(DisplayInInspectorAttribute)))
            {

                if (GUILayout.Button(ObjectNames.NicifyVariableName(method.Name)))
                {

                    MethodInfo info = (MethodInfo)method;

                    if (info.ReturnType == typeof(IEnumerator))
                    {

                        ((MonoBehaviour)target).StartCoroutine(method.Name);

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
