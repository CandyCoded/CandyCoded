// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using EnhancedTouchSupport = UnityEngine.InputSystem.EnhancedTouch.EnhancedTouchSupport;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
#endif

namespace CandyCoded
{

    /// <summary>
    ///     InputManager
    /// </summary>
    public static class InputManager
    {

        public static readonly HashSet<int> activeFingerIds = new HashSet<int>();

        public static int defaultMouseButtonIndex = 0;

#if ENABLE_INPUT_SYSTEM
        public static bool touchSupported => Touchscreen.current != null && touchCount > 0;

        public static ReadOnlyArray<Touch> touches => Touch.activeTouches;

        public static int touchCount => touches.Count;
#else
        public static bool touchSupported => Input.touchSupported && Input.touchCount > 0;

        public static Touch[] touches => Input.touches;

        public static int touchCount => touches.Length;
#endif

#if ENABLE_INPUT_SYSTEM
        [RuntimeInitializeOnLoadMethodAttribute(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Setup()
        {

            if (EnhancedTouchSupport.enabled)
            {
                return;
            }

            EnhancedTouchSupport.Enable();

        }
#endif

        /// <summary>
        ///     Returns true if the user has either pressed the primary mouse button or touched the screen over a specific
        ///     GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera, ref int? currentFingerId,
            out RaycastHit hit)
        {

            var result = touchSupported
                ? GetTouchDown(gameObject, mainCamera, ref currentFingerId, out hit)
                : GetMouseButtonDown(gameObject, mainCamera, out hit);

            if (result && !touchSupported)
            {
                currentFingerId = defaultMouseButtonIndex;
            }
            else if (!result && currentFingerId.HasValue)
            {
                activeFingerIds.Remove(currentFingerId.Value);
            }

            return result;

        }

        /// <summary>
        ///     Returns true if the user has either pressed the primary mouse button or touched the screen over a specific
        ///     GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera, ref int? currentFingerId,
            out RaycastHit2D hit)
        {

            var result = touchSupported
                ? GetTouchDown(gameObject, mainCamera, ref currentFingerId, out hit)
                : GetMouseButtonDown(gameObject, mainCamera, out hit);

            if (result && !touchSupported)
            {
                currentFingerId = defaultMouseButtonIndex;
            }
            else if (!result && currentFingerId.HasValue)
            {
                activeFingerIds.Remove(currentFingerId.Value);
            }

            return result;

        }

        /// <summary>
        ///     Returns true if the user has either pressed the primary mouse button or touched the screen over a specific
        ///     GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <param name="hits">The results of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetInputDown(this GameObject gameObject, ref int? currentFingerId,
            ref List<RaycastResult> hits)
        {

            if (hits == null)
            {
                hits = new List<RaycastResult>();
            }

            var result = touchSupported
                ? GetTouchDown(gameObject, ref currentFingerId, ref hits)
                : GetMouseButtonDown(gameObject, ref hits);

            if (result && !touchSupported)
            {
                currentFingerId = defaultMouseButtonIndex;
            }
            else if (!result && currentFingerId.HasValue)
            {
                activeFingerIds.Remove(currentFingerId.Value);
            }

            return result;

        }

        /// <summary>
        ///     Returns true if the user has either pressed the primary mouse button or touched the screen.
        /// </summary>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <returns>bool</returns>
        public static bool GetInputDown(ref int? currentFingerId)
        {

            var result = touchSupported ? GetTouchDown(ref currentFingerId) : GetMouseButtonDown();

            if (result && !touchSupported)
            {
                currentFingerId = defaultMouseButtonIndex;
            }
            else if (!result && currentFingerId.HasValue)
            {
                activeFingerIds.Remove(currentFingerId.Value);
            }

            return result;

        }

        /// <summary>
        ///     Returns true if the user has either pressed the primary mouse button or touched the screen.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetInputDown()
        {

            return touchSupported ? GetTouchDown() : GetMouseButtonDown();

        }

        /// <summary>
        ///     Returns the position of either the mouse or a specific touch.
        /// </summary>
        /// <param name="currentFingerId">The stored unique finger ID of the touch event.</param>
        /// <returns>Vector3</returns>
        public static Vector3? GetInputPosition(int? currentFingerId)
        {

            return touchSupported ? GetTouchPosition(currentFingerId) : GetMousePosition();

        }

        /// <summary>
        ///     Returns true if the user has either released the primary mouse button or ended a touch on the screen over a
        ///     specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="currentFingerId">The stored unique finger ID of the touch event.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetInputUp(this GameObject gameObject, Camera mainCamera, ref int? currentFingerId,
            out RaycastHit hit)
        {

            hit = new RaycastHit();

            if (touchSupported && !currentFingerId.HasValue)
            {
                return false;
            }

            var result = touchSupported
                ? GetTouchUp(gameObject, mainCamera, ref currentFingerId, out hit)
                : GetMouseButtonUp(gameObject, mainCamera, out hit);

            if (result && currentFingerId.HasValue)
            {
                activeFingerIds.Remove(currentFingerId.Value);

                currentFingerId = null;
            }

            return result;

        }

        /// <summary>
        ///     Returns true if the user has either released the primary mouse button or ended a touch on the screen over a
        ///     specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="currentFingerId">The stored unique finger ID of the touch event.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetInputUp(this GameObject gameObject, Camera mainCamera, ref int? currentFingerId,
            out RaycastHit2D hit)
        {

            hit = new RaycastHit2D();

            if (touchSupported && !currentFingerId.HasValue)
            {
                return false;
            }

            var result = touchSupported
                ? GetTouchUp(gameObject, mainCamera, ref currentFingerId, out hit)
                : GetMouseButtonUp(gameObject, mainCamera, out hit);

            if (result && currentFingerId.HasValue)
            {
                activeFingerIds.Remove(currentFingerId.Value);

                currentFingerId = null;
            }

            return result;

        }

        /// <summary>
        ///     Returns true if the user has either released the primary mouse button or ended a touch on the screen over a
        ///     specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="currentFingerId">The stored unique finger ID of the touch event.</param>
        /// <param name="hits">The results of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetInputUp(this GameObject gameObject, ref int? currentFingerId,
            ref List<RaycastResult> hits)
        {

            if (hits == null)
            {
                hits = new List<RaycastResult>();
            }

            if (touchSupported && !currentFingerId.HasValue)
            {
                return false;
            }

            var result = touchSupported
                ? GetTouchUp(gameObject, ref currentFingerId, ref hits)
                : GetMouseButtonUp(gameObject, ref hits);

            if (result && currentFingerId.HasValue)
            {
                activeFingerIds.Remove(currentFingerId.Value);

                currentFingerId = null;
            }

            return result;

        }

        /// <summary>
        ///     Returns true if the user has either released the primary mouse button or ended a touch on the screen.
        /// </summary>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <returns>bool</returns>
        public static bool GetInputUp(ref int? currentFingerId)
        {

            if (touchSupported && !currentFingerId.HasValue)
            {
                return false;
            }

            var result = touchSupported ? GetTouchUp(ref currentFingerId) : GetMouseButtonUp();

            if (result && currentFingerId.HasValue)
            {
                activeFingerIds.Remove(currentFingerId.Value);

                currentFingerId = null;
            }

            return result;

        }

        /// <summary>
        ///     Returns true if the user has either released the primary mouse button or ended a touch on the screen.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetInputUp()
        {

            return touchSupported ? GetTouchUp() : GetMouseButtonUp();

        }

        /// <summary>
        ///     Returns true if the user has pressed the primary mouse button over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetMouseButtonDown(this GameObject gameObject, Camera mainCamera, out RaycastHit hit)
        {

            hit = new RaycastHit();

            var mousePosition = GetMousePosition();

            if (!mousePosition.HasValue)
            {
                return false;
            }

            return GetMouseButtonDown() && RaycastToGameObject(gameObject, mainCamera, mousePosition.Value, out hit);

        }

        /// <summary>
        ///     Returns true if the user has pressed the primary mouse button over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetMouseButtonDown(this GameObject gameObject, Camera mainCamera, out RaycastHit2D hit)
        {

            hit = new RaycastHit2D();

            var mousePosition = GetMousePosition();

            if (!mousePosition.HasValue)
            {
                return false;
            }

            return GetMouseButtonDown() && RaycastToGameObject(gameObject, mainCamera, mousePosition.Value, out hit);

        }

        /// <summary>
        ///     Returns true if the user has pressed the primary mouse button over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="hits">The results of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetMouseButtonDown(this GameObject gameObject, ref List<RaycastResult> hits)
        {

            if (hits == null)
            {
                hits = new List<RaycastResult>();
            }

            var mousePosition = GetMousePosition();

            if (!mousePosition.HasValue)
            {
                return false;
            }

            return GetMouseButtonDown() && RaycastToGameObject(gameObject, mousePosition.Value, ref hits);

        }

        /// <summary>
        ///     Returns true if the user has pressed the primary mouse button.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetMouseButtonDown()
        {

#if ENABLE_INPUT_SYSTEM
            return defaultMouseButtonIndex == 0
                ? Mouse.current.leftButton.wasPressedThisFrame
                : Mouse.current.rightButton.wasPressedThisFrame;
#else
            return Input.GetMouseButtonDown(defaultMouseButtonIndex);
#endif

        }

        /// <summary>
        ///     Returns true if the user has released the primary mouse button over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetMouseButtonUp(this GameObject gameObject, Camera mainCamera, out RaycastHit hit)
        {

            hit = new RaycastHit();

            var mousePosition = GetMousePosition();

            if (!mousePosition.HasValue)
            {
                return false;
            }

            return GetMouseButtonUp() && RaycastToGameObject(gameObject, mainCamera, mousePosition.Value, out hit);

        }

        /// <summary>
        ///     Returns true if the user has released the primary mouse button over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetMouseButtonUp(this GameObject gameObject, Camera mainCamera, out RaycastHit2D hit)
        {

            hit = new RaycastHit2D();

            var mousePosition = GetMousePosition();

            if (!mousePosition.HasValue)
            {
                return false;
            }

            return GetMouseButtonUp() && RaycastToGameObject(gameObject, mainCamera, mousePosition.Value, out hit);

        }

        /// <summary>
        ///     Returns true if the user has released the primary mouse button over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="hits">The results of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetMouseButtonUp(this GameObject gameObject, ref List<RaycastResult> hits)
        {

            if (hits == null)
            {
                hits = new List<RaycastResult>();
            }

            var mousePosition = GetMousePosition();

            if (!mousePosition.HasValue)
            {
                return false;
            }

            return GetMouseButtonUp() && RaycastToGameObject(gameObject, mousePosition.Value, ref hits);

        }

        /// <summary>
        ///     Returns true if the user has released the primary mouse button.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetMouseButtonUp()
        {

#if ENABLE_INPUT_SYSTEM
            return defaultMouseButtonIndex == 0
                ? Mouse.current.leftButton.wasReleasedThisFrame
                : Mouse.current.rightButton.wasReleasedThisFrame;
#else
            return Input.GetMouseButtonUp(defaultMouseButtonIndex);
#endif

        }

        /// <summary>
        ///     Returns the position of the mouse.
        /// </summary>
        /// <returns>Vector3</returns>
        public static Vector3? GetMousePosition()
        {

#if ENABLE_INPUT_SYSTEM
            return Mouse.current.position.ReadValue();
#else
            return Input.mousePosition;
#endif

        }

        /// <summary>
        ///     Returns the active touch based on a unique finger ID and a TouchPhase enum filter.
        /// </summary>
        /// <param name="fingerId">The stored unique finger ID of the touch event.</param>
        /// <param name="touchPhasesFilter">TouchPhase enums used to filter.</param>
        /// <returns>Touch</returns>
        public static Touch? GetActiveTouch(int fingerId, params TouchPhase[] touchPhasesFilter)
        {

            if (!touchSupported || touchCount <= 0)
            {
                return null;
            }

            foreach (var touch in touches)
            {

                if (touch.GetTouchId().Equals(fingerId) && touchPhasesFilter.Contains(touch.phase))
                {

                    return touch;

                }

            }

            return null;

        }

        /// <summary>
        ///     Returns the active touch based on a TouchPhase enum filter.
        /// </summary>
        /// <param name="touchPhasesFilter">TouchPhase enums used to filter.</param>
        /// <returns>Touch</returns>
        public static Touch? GetActiveTouch(params TouchPhase[] touchPhasesFilter)
        {

            if (!touchSupported || touchCount <= 0)
            {
                return null;
            }

            foreach (var touch in touches)
            {

                if (touchPhasesFilter.Contains(touch.phase))
                {

                    return touch;

                }

            }

            return null;

        }

        /// <summary>
        ///     Returns the active touch based on a unique finger ID.
        /// </summary>
        /// <param name="fingerId">The stored unique finger ID of the touch event.</param>
        /// <returns>Touch</returns>
        public static Touch? GetActiveTouch(int fingerId)
        {

            if (!touchSupported || touchCount <= 0)
            {
                return null;
            }

            foreach (var touch in touches)
            {

                if (touch.GetTouchId().Equals(fingerId))
                {

                    return touch;

                }

            }

            return null;

        }

        /// <summary>
        ///     Returns true if the user has touched the screen over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetTouchDown(this GameObject gameObject, Camera mainCamera, ref int? currentFingerId,
            out RaycastHit hit)
        {

            hit = new RaycastHit();

            if (!touchSupported || touchCount <= 0)
            {
                return false;
            }

            foreach (var touch in touches)
            {

                if (currentFingerId.HasValue ||
                    activeFingerIds.Contains(touch.GetTouchId()) ||
                    !touch.phase.Equals(TouchPhase.Began) && !touch.phase.Equals(TouchPhase.Moved) ||
                    !RaycastToGameObject(gameObject, mainCamera, touch.GetTouchPosition(), out hit))
                {
                    continue;
                }

                currentFingerId = touch.GetTouchId();

                activeFingerIds.Add(currentFingerId.Value);

                return true;

            }

            return false;

        }

        /// <summary>
        ///     Returns true if the user has touched the screen over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetTouchDown(this GameObject gameObject, Camera mainCamera, ref int? currentFingerId,
            out RaycastHit2D hit)
        {

            hit = new RaycastHit2D();

            if (!touchSupported || touchCount <= 0)
            {
                return false;
            }

            foreach (var touch in touches)
            {

                if (currentFingerId.HasValue ||
                    activeFingerIds.Contains(touch.GetTouchId()) ||
                    !touch.phase.Equals(TouchPhase.Began) && !touch.phase.Equals(TouchPhase.Moved) ||
                    !RaycastToGameObject(gameObject, mainCamera, touch.GetTouchPosition(), out hit))
                {
                    continue;
                }

                currentFingerId = touch.GetTouchId();

                activeFingerIds.Add(currentFingerId.Value);

                return true;

            }

            return false;

        }

        /// <summary>
        ///     Returns true if the user has touched the screen over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <param name="hits">The results of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetTouchDown(this GameObject gameObject, ref int? currentFingerId,
            ref List<RaycastResult> hits)
        {

            if (hits == null)
            {
                hits = new List<RaycastResult>();
            }

            if (!touchSupported || touchCount <= 0)
            {
                return false;
            }

            foreach (var touch in touches)
            {

                if (currentFingerId.HasValue ||
                    activeFingerIds.Contains(touch.GetTouchId()) ||
                    !touch.phase.Equals(TouchPhase.Began) && !touch.phase.Equals(TouchPhase.Moved) ||
                    !RaycastToGameObject(gameObject, touch.GetTouchPosition(), ref hits))
                {
                    continue;
                }

                currentFingerId = touch.GetTouchId();

                activeFingerIds.Add(currentFingerId.Value);

                return true;

            }

            return false;

        }

        /// <summary>
        ///     Returns true if the user has touched the screen.
        /// </summary>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <returns>bool</returns>
        public static bool GetTouchDown(ref int? currentFingerId)
        {

            var touch = GetActiveTouch(TouchPhase.Began);

            if (!touch.HasValue)
            {
                return false;
            }

            currentFingerId = touch.Value.GetTouchId();

            activeFingerIds.Add(currentFingerId.Value);

            return true;

        }

        /// <summary>
        ///     Returns true if the user has touched the screen.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetTouchDown()
        {

            var touch = GetActiveTouch(TouchPhase.Began);

            return touch.HasValue;

        }

        /// <summary>
        ///     Returns a unique ID associated to a specific touch.
        /// </summary>
        /// <param name="touch">Reference to a specific touch.</param>
        /// <returns>int</returns>
        public static int GetTouchId(this Touch touch)
        {

#if ENABLE_INPUT_SYSTEM
            return touch.finger.index;
#else
            return touch.fingerId;
#endif

        }

        /// <summary>
        ///     Returns the position of a specific touch.
        /// </summary>
        /// <param name="currentFingerId">The stored unique finger ID of the touch.</param>
        /// <returns>Vector3</returns>
        public static Vector3? GetTouchPosition(int? currentFingerId)
        {

            if (!currentFingerId.HasValue)
            {
                return null;
            }

            var touch = GetActiveTouch(currentFingerId.Value);

            return touch?.GetTouchPosition();

        }

        /// <summary>
        ///     Returns the position of a specific touch.
        /// </summary>
        /// <param name="touch">Reference to a specific touch.</param>
        /// <returns>Vector3</returns>
        public static Vector3 GetTouchPosition(this Touch touch)
        {

#if ENABLE_INPUT_SYSTEM
            return touch.screenPosition;
#else
            return touch.position;
#endif

        }

        /// <summary>
        ///     Returns true if the user has ended a touch on the screen over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="currentFingerId">The stored unique finger ID of the touch event.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetTouchUp(this GameObject gameObject, Camera mainCamera, ref int? currentFingerId,
            out RaycastHit hit)
        {

            hit = new RaycastHit();

            if (!currentFingerId.HasValue)
            {
                return false;
            }

            var touch = GetActiveTouch(currentFingerId.Value, TouchPhase.Ended, TouchPhase.Canceled);

            return touch.HasValue &&
                   RaycastToGameObject(gameObject, mainCamera, touch.Value.GetTouchPosition(), out hit);

        }

        /// <summary>
        ///     Returns true if the user has ended a touch on the screen over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="currentFingerId">The stored unique finger ID of the touch event.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetTouchUp(this GameObject gameObject, Camera mainCamera, ref int? currentFingerId,
            out RaycastHit2D hit)
        {

            hit = new RaycastHit2D();

            if (!currentFingerId.HasValue)
            {
                return false;
            }

            var touch = GetActiveTouch(currentFingerId.Value, TouchPhase.Ended, TouchPhase.Canceled);

            return touch.HasValue &&
                   RaycastToGameObject(gameObject, mainCamera, touch.Value.GetTouchPosition(), out hit);

        }

        /// <summary>
        ///     Returns true if the user has ended a touch on the screen over a specific GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="currentFingerId">The stored unique finger ID of the touch event.</param>
        /// <param name="hits">The results of the raycast.</param>
        /// <returns>bool</returns>
        public static bool GetTouchUp(this GameObject gameObject, ref int? currentFingerId,
            ref List<RaycastResult> hits)
        {

            if (hits == null)
            {
                hits = new List<RaycastResult>();
            }

            if (!currentFingerId.HasValue)
            {
                return false;
            }

            var touch = GetActiveTouch(currentFingerId.Value, TouchPhase.Ended, TouchPhase.Canceled);

            return touch.HasValue &&
                   RaycastToGameObject(gameObject, touch.Value.GetTouchPosition(), ref hits);

        }

        /// <summary>
        ///     Returns true if the user has ended a touch on the screen.
        /// </summary>
        /// <param name="currentFingerId">The stored unique finger ID of the touch event.</param>
        /// <returns>bool</returns>
        public static bool GetTouchUp(int? currentFingerId)
        {

            if (!currentFingerId.HasValue)
            {
                return false;
            }

            var touch = GetActiveTouch(currentFingerId.Value, TouchPhase.Ended, TouchPhase.Canceled);

            return touch.HasValue;

        }

        /// <summary>
        ///     Returns true if the user has ended a touch on the screen.
        /// </summary>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <returns>bool</returns>
        public static bool GetTouchUp(ref int? currentFingerId)
        {

            var touch = GetActiveTouch(TouchPhase.Ended, TouchPhase.Canceled);

            return touch.HasValue;

        }

        /// <summary>
        ///     Returns true if the user has ended a touch on the screen.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetTouchUp()
        {

            var touch = GetActiveTouch(TouchPhase.Ended, TouchPhase.Canceled);

            return touch.HasValue;

        }

        /// <summary>
        ///     Returns true if a position collides with a GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="position">Vector3 used to test raycast.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool RaycastToGameObject(GameObject gameObject, Camera mainCamera, Vector3 position,
            out RaycastHit hit)
        {

            var ray = mainCamera.ScreenPointToRay(position);

            return Physics.Raycast(ray, out hit, Mathf.Infinity, gameObject.GetLayerMask()) &&
                   hit.transform.IsChildOf(gameObject.transform);

        }

        /// <summary>
        ///     Returns true if a position collides with a GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="mainCamera">Current active camera.</param>
        /// <param name="position">Vector3 used to test raycast.</param>
        /// <param name="hit">The result of the raycast.</param>
        /// <returns>bool</returns>
        public static bool RaycastToGameObject(GameObject gameObject, Camera mainCamera, Vector3 position,
            out RaycastHit2D hit)
        {

            var ray = mainCamera.ScreenPointToRay(position);

            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, gameObject.GetLayerMask());

            return hit && hit.transform.IsChildOf(gameObject.transform);

        }

        /// <summary>
        ///     Returns true if a position collides with a GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to test.</param>
        /// <param name="position">Vector3 used to test raycast.</param>
        /// <param name="hits">The results of the raycast.</param>
        /// <returns>bool</returns>
        public static bool RaycastToGameObject(GameObject gameObject, Vector3 position, ref List<RaycastResult> hits)
        {

            if (hits == null)
            {
                hits = new List<RaycastResult>();
            }

            var pointerEventData = new PointerEventData(EventSystem.current) { position = position };

            EventSystem.current.RaycastAll(pointerEventData, hits);

            return hits.Count > 0 && hits[0].gameObject.transform.IsChildOf(gameObject.transform);

        }

    }

}
