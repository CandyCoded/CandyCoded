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

        private readonly string eventListHeaderTemplate = "Event Listeners for {0} ({1})";
        private readonly string eventListItemTemplate = "- {0}";
        private readonly string eventListNoItemsTemplate = "No methods have been subscribed to this event.";
        private readonly string noContentTemplate = "Select a GameObject with scripts that contain public events.";
        private readonly int spaceBeforeEventListHeight = 10;
        private readonly int spaceAfterEventListHeight = 10;

        private Dictionary<string, Vector2> scrollPositions = new Dictionary<string, Vector2>();

        private readonly BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        [MenuItem("Window/CandyCoded/Event Profiler")]
        public static void ShowWindow()
        {

            GetWindow(typeof(EventProfiler), false, "Event Profiler", true);

        }

        private void OnGUI()
        {

            if (Selection.activeGameObject)
            {

                var scripts = Selection.activeGameObject.GetComponents<MonoBehaviour>();

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

        private void HandleSelectionChanged()
        {

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

        private void DrawEvents(EventInfo ev, List<string> methods)
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

        public static List<string> GetSubscribedMethodsToEvent(MulticastDelegate multicastDelegate)
        {

            if (multicastDelegate != null)
            {

                return multicastDelegate.GetInvocationList().Select(i => string.Format("{0}.{1}", i.Method.DeclaringType.FullName, i.Method.Name)).ToList();

            }

            return new List<string>();

        }

    }

}
