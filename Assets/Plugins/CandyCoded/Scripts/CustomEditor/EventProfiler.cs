// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace CandyCoded
{

    public class EventProfiler : EditorWindow
    {

        public struct ExtendedMethodInfo
        {

            public MethodInfo methodInfo;
            public GameObject gameObject;
            public string label
            {

                get
                {

                    return string.Format("{0} > {1}.{2}", gameObject.name, methodInfo.ReflectedType.Name, methodInfo.Name);

                }

            }

        }

        private readonly string eventListHeaderTemplate = "Event Listeners for {0} ({1})";
        private readonly string eventListItemTemplate = "{0}. {1}";
        private readonly string eventListNoItemsTemplate = "No methods have been subscribed to this event.";
        private readonly string noContentTemplate = "Select a GameObject with scripts that contain public events.";
        private readonly int spaceBeforeEventListHeight = 10;
        private readonly int spaceAfterEventListHeight = 10;

        private readonly BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        private Dictionary<string, Vector2> scrollPositions = new Dictionary<string, Vector2>();

        private bool inspectorLocked;

        private GameObject currentActiveGameObject;

        [MenuItem("Window/CandyCoded/Event Profiler")]
        public static void ShowWindow()
        {

            GetWindow(typeof(EventProfiler), false, "Event Profiler", true);

        }

#pragma warning disable S100
        // Disables "Methods and properties should be named in camel case" warning as those methods are defined by Unity.

        private void OnGUI()
        {

            if (currentActiveGameObject)
            {

                var scripts = currentActiveGameObject.GetComponents<MonoBehaviour>();

                if (scripts.Length > 0)
                {

                    foreach (var script in scripts)
                    {

                        var events = script.GetType().GetEvents(bindingFlags);

                        foreach (var ev in events)
                        {

                            var methods = GetSubscribedMethodsToEvent((MulticastDelegate)script.GetType().GetField(ev.Name, bindingFlags).GetValue(script));

                            DrawEvents(ev, methods);

                        }

                    }

                }
                else
                {

                    GUILayout.Label(noContentTemplate, EditorStyles.helpBox);

                }

            }
            else
            {

                GUILayout.Label(noContentTemplate, EditorStyles.helpBox);

            }

        }

        private void ShowButton(Rect rect)
        {

            var icon = (GUIStyle)"IN LockButton";

            if (GUI.Toggle(rect, inspectorLocked, GUIContent.none, icon))
            {

                inspectorLocked = !inspectorLocked;

            }

        }

#pragma warning restore S100

#pragma warning disable S1144
        // Disables "Unused private types or members should be removed" warning as those methods are defined by Unity.

#pragma warning disable S2325
        // Disables "Methods and properties that don't access instance data should be static" warning as those methods are defined by Unity.

        private void HandleSelectionChanged()
        {

            if (!inspectorLocked)
            {

                currentActiveGameObject = Selection.activeGameObject;

            }

            Repaint();

        }

        private void OnEnable()
        {

            Selection.selectionChanged += HandleSelectionChanged;

        }

        private void OnDisable()
        {

            Selection.selectionChanged -= HandleSelectionChanged;

        }

#pragma warning restore S2325

#pragma warning restore S1144

        private void DrawEvents(EventInfo ev, List<ExtendedMethodInfo> methods)
        {

            GUILayout.Space(spaceBeforeEventListHeight);
            GUILayout.Label(string.Format(eventListHeaderTemplate, ObjectNames.NicifyVariableName(ev.Name), methods.Count), EditorStyles.boldLabel);

            if (!scrollPositions.ContainsKey(ev.Name))
            {

                scrollPositions.Add(ev.Name, Vector2.zero);

            }

            scrollPositions[ev.Name] = GUILayout.BeginScrollView(scrollPositions[ev.Name]);

            if (methods.Count > 0)
            {

                for (var i = 0; i < methods.Count; i += 1)
                {

                    if (GUILayout.Button(string.Format(eventListItemTemplate, i + 1, methods[i].label), EditorStyles.label))
                    {

                        Selection.activeGameObject = methods[i].gameObject;

                    }

                }

            }
            else
            {

                GUILayout.Label(eventListNoItemsTemplate, EditorStyles.centeredGreyMiniLabel);

            }

            GUILayout.EndScrollView();
            GUILayout.Space(spaceAfterEventListHeight);

        }

        public static List<ExtendedMethodInfo> GetSubscribedMethodsToEvent(MulticastDelegate multicastDelegate)
        {

            if (multicastDelegate != null)
            {

                return multicastDelegate.GetInvocationList().Select(i => new ExtendedMethodInfo
                {
                    gameObject = ((MonoBehaviour)i.Target).gameObject,
                    methodInfo = i.Method
                }).ToList();

            }

            return new List<ExtendedMethodInfo>();

        }

    }

}

#endif
