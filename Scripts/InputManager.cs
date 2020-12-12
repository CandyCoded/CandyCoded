// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Linq;
using UnityEngine;

namespace CandyCoded
{

    public static class InputManager
    {

        public static int _defaultMouseButtonIndex = 0;

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

            if (Input.touchSupported)
            {

                return GetTouchDown(gameObject, mainCamera, ref currentFingerId, out hit);

            }

            var result = GetMouseButtonDown(gameObject, mainCamera, out hit);

            if (!result)
            {
                return false;
            }

            currentFingerId = _defaultMouseButtonIndex;

            return true;

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

            if (Input.touchSupported)
            {

                return GetTouchDown(gameObject, mainCamera, ref currentFingerId, out hit);

            }

            var result = GetMouseButtonDown(gameObject, mainCamera, out hit);

            if (!result)
            {
                return false;
            }

            currentFingerId = _defaultMouseButtonIndex;

            return true;

        }

        /// <summary>
        ///     Returns true if the user has either pressed the primary mouse button or touched the screen.
        /// </summary>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <returns>bool</returns>
        public static bool GetInputDown(ref int? currentFingerId)
        {

            if (Input.touchSupported)
            {

                return GetTouchDown(ref currentFingerId);

            }

            var result = GetMouseButtonDown();

            if (!result)
            {
                return false;
            }

            currentFingerId = _defaultMouseButtonIndex;

            return true;

        }

        /// <summary>
        ///     Returns true if the user has either pressed the primary mouse button or touched the screen.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetInputDown()
        {

            return Input.touchSupported ? GetTouchDown() : GetMouseButtonDown();

        }

        /// <summary>
        ///     Returns the position of either the mouse or a specific touch.
        /// </summary>
        /// <param name="currentFingerId">The stored unique finger ID of the touch event.</param>
        /// <returns>Vector3</returns>
        public static Vector3? GetInputPosition(int? currentFingerId)
        {

            return Input.touchSupported ? GetTouchPosition(currentFingerId) : GetMousePosition();

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

            if (!currentFingerId.HasValue)
            {
                return false;
            }

            if (Input.touchSupported)
            {

                return GetTouchUp(gameObject, mainCamera, ref currentFingerId, out hit);

            }

            var result = GetMouseButtonUp(gameObject, mainCamera, out hit);

            if (!result)
            {
                return false;
            }

            currentFingerId = null;

            return true;

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

            if (!currentFingerId.HasValue)
            {
                return false;
            }

            if (Input.touchSupported)
            {

                return GetTouchUp(gameObject, mainCamera, ref currentFingerId, out hit);

            }

            var result = GetMouseButtonUp(gameObject, mainCamera, out hit);

            if (!result)
            {
                return false;
            }

            currentFingerId = null;

            return true;

        }

        /// <summary>
        ///     Returns true if the user has either released the primary mouse button or ended a touch on the screen.
        /// </summary>
        /// <param name="currentFingerId">A variable used to store the unique finger ID of a touch event.</param>
        /// <returns>bool</returns>
        public static bool GetInputUp(ref int? currentFingerId)
        {

            if (!currentFingerId.HasValue)
            {
                return false;
            }

            if (Input.touchSupported)
            {

                return GetTouchUp(ref currentFingerId);

            }

            var result = GetMouseButtonUp();

            if (!result)
            {
                return false;
            }

            currentFingerId = null;

            return true;

        }

        /// <summary>
        ///     Returns true if the user has either released the primary mouse button or ended a touch on the screen.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetInputUp()
        {

            return Input.touchSupported ? GetTouchUp() : GetMouseButtonUp();

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

            return Input.GetMouseButtonDown(_defaultMouseButtonIndex) &&
                   RaycastToGameObject(gameObject, mainCamera, Input.mousePosition, out hit);

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

            return Input.GetMouseButtonDown(_defaultMouseButtonIndex) &&
                   RaycastToGameObject(gameObject, mainCamera, Input.mousePosition, out hit);

        }

        /// <summary>
        ///     Returns true if the user has pressed the primary mouse button.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetMouseButtonDown()
        {

            return Input.GetMouseButtonDown(_defaultMouseButtonIndex);

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

            return Input.GetMouseButtonUp(_defaultMouseButtonIndex) &&
                   RaycastToGameObject(gameObject, mainCamera, Input.mousePosition, out hit);

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

            return Input.GetMouseButtonUp(_defaultMouseButtonIndex) &&
                   RaycastToGameObject(gameObject, mainCamera, Input.mousePosition, out hit);

        }

        /// <summary>
        ///     Returns true if the user has released the primary mouse button.
        /// </summary>
        /// <returns>bool</returns>
        public static bool GetMouseButtonUp()
        {

            return Input.GetMouseButtonUp(_defaultMouseButtonIndex);

        }

        /// <summary>
        ///     Returns the position of the mouse.
        /// </summary>
        /// <returns>Vector3</returns>
        public static Vector3? GetMousePosition()
        {

            return Input.mousePosition;

        }

        /// <summary>
        ///     Returns the active touch based on a unique finger ID and a TouchPhase enum filter.
        /// </summary>
        /// <param name="fingerId">The stored unique finger ID of the touch event.</param>
        /// <param name="touchPhasesFilter">TouchPhase enums used to filter.</param>
        /// <returns>Touch</returns>
        public static Touch? GetActiveTouch(int fingerId, params TouchPhase[] touchPhasesFilter)
        {

            if (!Input.touchSupported || Input.touchCount <= 0)
            {
                return null;
            }

            foreach (var touch in Input.touches)
            {

                if (touch.fingerId.Equals(fingerId) && touchPhasesFilter.Contains(touch.phase))
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

            if (!Input.touchSupported || Input.touchCount <= 0)
            {
                return null;
            }

            foreach (var touch in Input.touches)
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

            if (!Input.touchSupported || Input.touchCount <= 0)
            {
                return null;
            }

            foreach (var touch in Input.touches)
            {

                if (touch.fingerId.Equals(fingerId))
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

            if (!Input.touchSupported || Input.touchCount <= 0)
            {
                return false;
            }

            foreach (var touch in Input.touches)
            {

                if (!touch.phase.Equals(TouchPhase.Began) ||
                    !RaycastToGameObject(gameObject, mainCamera, touch.position, out hit))
                {
                    continue;
                }

                currentFingerId = touch.fingerId;

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

            if (!Input.touchSupported || Input.touchCount <= 0)
            {
                return false;
            }

            foreach (var touch in Input.touches)
            {

                if (!touch.phase.Equals(TouchPhase.Began) ||
                    !RaycastToGameObject(gameObject, mainCamera, touch.position, out hit))
                {
                    continue;
                }

                currentFingerId = touch.fingerId;

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

            currentFingerId = touch.Value.fingerId;

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

            return touch?.position;

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

            return touch.HasValue && RaycastToGameObject(gameObject, mainCamera, touch.Value.position, out hit);

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

            return touch.HasValue && RaycastToGameObject(gameObject, mainCamera, touch.Value.position, out hit);

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

            if (!touch.HasValue)
            {
                return false;
            }

            currentFingerId = touch.Value.fingerId;

            return true;

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

    }

}
