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

    public struct ExtendedMethodInfo
    {

        public MethodInfo methodInfo;

        public GameObject gameObject;

        public string label
        {
            get
            {
                if (methodInfo == null || methodInfo.ReflectedType == null)
                {

                    return null;

                }

                return $"{gameObject.name} > {methodInfo.ReflectedType.Name}.{methodInfo.Name}";
            }
        }

    }

    public class EventProfiler : EditorWindow
    {

        private const string eventListHeaderTemplate = "Event Listeners for {0} ({1})";

        private const string eventListItemTemplate = "{0}. {1}";

        private const string eventListNoItemsTemplate = "No methods have subscribed to this event.";

        private const string noContentTemplate = "Select a GameObject with scripts that contain events.";

        private const int spaceBeforeEventListHeight = 10;

        private const int spaceAfterEventListHeight = 10;

        private const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        private readonly Dictionary<string, Vector2> scrollPositions = new Dictionary<string, Vector2>();

        private bool _isInspectorLocked;

        private GameObject _currentActiveGameObject;

        private Texture2D _prefabIcon;

        [MenuItem("Window/CandyCoded/Event Profiler")]
        public static void ShowWindow()
        {

            GetWindow(typeof(EventProfiler), false, "Event Profiler", true);

        }

        private void Update()
        {

            if (EditorApplication.isPlaying && !EditorApplication.isPaused)
            {

                Repaint();

            }

        }

#pragma warning disable S100

        // Disables "Methods and properties should be named in camel case" warning as those methods are defined by Unity.

        private void OnGUI()
        {

            var eventsFound = false;

            if (_currentActiveGameObject)
            {

                var scripts = _currentActiveGameObject.GetComponents<MonoBehaviour>();

                if (scripts.Length > 0)
                {

                    foreach (var script in scripts)
                    {

                        var events = script.GetType().GetEvents(bindingFlags);

                        foreach (var ev in events)
                        {

                            var field = script.GetType().GetField(ev.Name, bindingFlags);

                            if (field == null)
                            {

                                continue;

                            }

                            var methods = GetSubscribedMethodsToEvent((MulticastDelegate)field.GetValue(script));

                            DrawEvents(ev, methods);

                            eventsFound = true;

                        }

                    }

                }

            }

            if (!eventsFound)
            {

                GUILayout.Label(noContentTemplate, EditorStyles.helpBox);

            }

        }

        // ReSharper disable once UnusedMember.Local
        private void ShowButton(Rect rect)
        {

            var lockIcon = (GUIStyle)"IN LockButton";

            _isInspectorLocked = GUI.Toggle(rect, _isInspectorLocked, GUIContent.none, lockIcon);

        }

        private void DrawEvents(MemberInfo ev, IReadOnlyList<ExtendedMethodInfo> methods)
        {

            GUILayout.Space(spaceBeforeEventListHeight);

            GUILayout.Label(
                string.Format(eventListHeaderTemplate, ObjectNames.NicifyVariableName(ev.Name), methods.Count),
                EditorStyles.boldLabel);

            if (!scrollPositions.ContainsKey(ev.Name))
            {

                scrollPositions.Add(ev.Name, Vector2.zero);

            }

            scrollPositions[ev.Name] = GUILayout.BeginScrollView(scrollPositions[ev.Name]);

            if (methods.Count > 0)
            {

                for (var i = 0; i < methods.Count; i += 1)
                {

                    GUILayout.BeginHorizontal();

                    if (GUILayout.Button(_prefabIcon, EditorStyles.label,
                        GUILayout.Width(EditorGUIUtility.singleLineHeight),
                        GUILayout.Height(EditorGUIUtility.singleLineHeight)))
                    {

                        Selection.activeGameObject = methods[i].gameObject;

                        EditorGUIUtility.PingObject(Selection.activeGameObject);

                    }

                    if (GUILayout.Button(string.Format(eventListItemTemplate, i + 1, methods[i].label),
                        EditorStyles.label))
                    {

                        Selection.activeGameObject = methods[i].gameObject;

                        EditorGUIUtility.PingObject(Selection.activeGameObject);

                    }

                    GUILayout.EndHorizontal();

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

                return multicastDelegate.GetInvocationList().Select(i =>
                        new ExtendedMethodInfo
                        {
                            gameObject = ((MonoBehaviour)i.Target).gameObject, methodInfo = i.Method
                        })
                    .ToList();

            }

            return new List<ExtendedMethodInfo>();

        }

#pragma warning restore S100

#pragma warning disable S1144

        // Disables "Unused private types or members should be removed" warning as those methods are defined by Unity.

#pragma warning disable S2325

        // Disables "Methods and properties that don't access instance data should be static" warning as those methods are defined by Unity.

        private void HandleSelectionChanged()
        {

            if (!_isInspectorLocked)
            {

                _currentActiveGameObject = Selection.activeGameObject;

            }

            Repaint();

        }

        private void OnEnable()
        {

            _prefabIcon = EditorGUIUtility.FindTexture("Prefab Icon");

            Selection.selectionChanged += HandleSelectionChanged;

        }

        private void OnDisable()
        {

            Selection.selectionChanged -= HandleSelectionChanged;

        }

#pragma warning restore S2325

#pragma warning restore S1144

    }

}

#endif
