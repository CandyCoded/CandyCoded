// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded
{

    public static class InputManager
    {

        public static bool GetMouseButtonDown(this GameObject gameObject, Camera mainCamera, LayerMask layerMask)
        {

            bool isMouseDown = false;

            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit hit;

                if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask) &&
                    hit.transform.gameObject == gameObject)
                {

                    isMouseDown = true;

                }

            }

            return isMouseDown;

        }

        public static bool GetTouchDown(this GameObject gameObject, Camera mainCamera, LayerMask layerMask, out int currentFingerId)
        {

            currentFingerId = 0;

            bool hasTouchBegin = false;

            if (!Input.touchSupported || Input.touchCount == 0)
            {

                return hasTouchBegin;

            }

            for (int i = 0; i < Input.touchCount; i += 1)
            {

                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began)
                {

                    RaycastHit hit;

                    if (Physics.Raycast(mainCamera.ScreenPointToRay(touch.position), out hit, Mathf.Infinity, layerMask) &&
                        hit.transform.gameObject == gameObject)
                    {

                        hasTouchBegin = true;

                        currentFingerId = touch.fingerId;

                    }

                }

            }

            return hasTouchBegin;

        }

        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera, LayerMask layerMask, out int currentFingerId)
        {

            bool isMouseDown = GetMouseButtonDown(gameObject, mainCamera, layerMask);

            bool hasTouchBegin = GetTouchDown(gameObject, mainCamera, layerMask, out currentFingerId);

            return isMouseDown || hasTouchBegin;

        }

        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera, LayerMask layerMask)
        {

            int currentFingerId;

            bool isMouseDown = GetMouseButtonDown(gameObject, mainCamera, layerMask);

            bool hasTouchBegin = GetTouchDown(gameObject, mainCamera, layerMask, out currentFingerId);

            return isMouseDown || hasTouchBegin;

        }

        public static Vector3? GetMousePosition()
        {

            Vector3? inputPosition = null;

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
            {

                inputPosition = Input.mousePosition;

            }

            return inputPosition;

        }

        public static Vector3? GetTouchPosition(int currentFingerId)
        {

            Vector3? inputPosition = null;

            if (!Input.touchSupported || Input.touchCount == 0)
            {

                return inputPosition;

            }

            for (int i = 0; i < Input.touchCount; i += 1)
            {

                Touch touch = Input.GetTouch(i);

                if (touch.fingerId == currentFingerId)
                {

                    inputPosition = touch.position;

                }

            }

            return inputPosition;

        }

        public static Vector3? GetInputPosition(int currentFingerId)
        {

            Vector3? inputPosition = GetMousePosition();

            if (Input.touchSupported && Input.touchCount > 0)
            {

                inputPosition = GetTouchPosition(currentFingerId);

            }

            return inputPosition;

        }

        public static bool GetMouseButtonHeld()
        {

            return Input.GetMouseButton(0);

        }

        public static bool GetTouchHeld(int currentFingerId)
        {

            bool isTouchHeld = TestTouchState(currentFingerId, TouchPhase.Moved, TouchPhase.Stationary);

            return isTouchHeld;

        }

        public static bool GetInputHeld(int currentFingerId)
        {

            bool isMouseHeld = GetMouseButtonHeld();

            bool isTouchHeld = GetTouchHeld(currentFingerId);

            return isMouseHeld || isTouchHeld;

        }

        public static bool GetMouseButtonUp()
        {

            bool isMouseUp = Input.GetMouseButtonUp(0);

            return isMouseUp;

        }

        public static bool GetTouchUp(int currentFingerId)
        {

            bool hasTouchEnded = TestTouchState(currentFingerId, TouchPhase.Ended, TouchPhase.Canceled);

            return hasTouchEnded;

        }

        public static bool GetInputUp(int currentFingerId)
        {

            bool isMouseUp = GetMouseButtonUp();

            bool hasTouchEnded = GetTouchUp(currentFingerId);

            return isMouseUp || hasTouchEnded;

        }

        public static bool TestTouchState(int currentFingerId, params TouchPhase[] touchPhases)
        {

            bool doesCurrentStateMatch = false;

            if (!Input.touchSupported || Input.touchCount == 0)
            {

                return doesCurrentStateMatch;

            }

            for (int i = 0; i < Input.touchCount; i += 1)
            {

                Touch touch = Input.GetTouch(i);

                if (touch.fingerId == currentFingerId)
                {

                    for (int j = 0; j < touchPhases.Length; j += 1)
                    {

                        doesCurrentStateMatch = doesCurrentStateMatch || touch.phase == touchPhases[j];

                    }

                }

            }

            return doesCurrentStateMatch;

        }

    }

}
