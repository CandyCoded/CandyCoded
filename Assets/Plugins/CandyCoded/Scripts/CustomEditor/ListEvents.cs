// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

#pragma warning disable S3903
// Disables "Types should be defined in named namespaces" warning as component should be available at all times.

[AttributeUsage(AttributeTargets.Event)]
public class ListEventsAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomEditor(typeof(MonoBehaviour), true)]
public class ListEventsDrawer : Editor
{

    private readonly string eventListHeaderTemplate = "Event Listeners for {0}";
    private readonly string eventListItemTemplate = "- {0}";
    private readonly string eventListNoItemsTemplate = "No methods have been subscribed to this event.";
    private readonly int spaceBeforeEventListHeight = 10;
    private readonly int spaceAfterEventListHeight = 10;

    private Dictionary<string, Vector2> scrollPositions = new Dictionary<string, Vector2>();

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        if (EditorApplication.isPlaying)
        {

            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var events = target.GetType().GetEvents(bindingFlags);

            foreach (var ev in events)
            {

                if (Attribute.IsDefined(ev, typeof(ListEventsAttribute)))
                {

                    GUILayout.Space(spaceBeforeEventListHeight);
                    GUILayout.Label(string.Format(eventListHeaderTemplate, ObjectNames.NicifyVariableName(ev.Name)), EditorStyles.boldLabel);

                    if (!scrollPositions.ContainsKey(ev.Name))
                    {

                        scrollPositions.Add(ev.Name, Vector2.zero);

                    }

                    scrollPositions[ev.Name] = GUILayout.BeginScrollView(scrollPositions[ev.Name]);

                    var methods = GetSubscribedMethodsToEvent((MulticastDelegate)target.GetType().GetField(ev.Name, bindingFlags).GetValue(target));

                    if (methods.Count > 0)
                    {

                        foreach (var method in methods)
                        {

                            GUILayout.Label(string.Format(eventListItemTemplate, method));

                        }

                    }
                    else
                    {

                        GUILayout.Label(eventListNoItemsTemplate, EditorStyles.centeredGreyMiniLabel);

                    }

                    GUILayout.EndScrollView();
                    GUILayout.Space(spaceAfterEventListHeight);

                }

            }

        }

    }

    public static List<string> GetSubscribedMethodsToEvent(MulticastDelegate multicastDelegate)
    {

        if (multicastDelegate != null)
        {

            return multicastDelegate.GetInvocationList().Select(i => string.Format("{0}.{1}", i.Method.DeclaringType.FullName, i.Method.Name)).ToList();

        }

        return new List<string>();

    }

}
#endif

#pragma warning restore S3903
