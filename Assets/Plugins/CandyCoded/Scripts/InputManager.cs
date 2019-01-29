// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Linq;
using UnityEngine;

namespace CandyCoded
{

    public static class InputManager
    {

        public static bool TouchActive
        {
            get
            {
                return Input.touchSupported && Input.touchCount > 0;
            }
        }

        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId, out RaycastHit hit)
        {

            currentFingerId = 0;

            if (TouchActive)
            {

                return GetTouchDown(gameObject, mainCamera, out currentFingerId, out hit);

            }

            return GetMouseButtonDown(gameObject, mainCamera, out hit);

        }

        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId, out RaycastHit2D hit)
        {

            currentFingerId = 0;

            if (TouchActive)
            {

                return GetTouchDown(gameObject, mainCamera, out currentFingerId, out hit);

            }

            return GetMouseButtonDown(gameObject, mainCamera, out hit);

        }

        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId)
        {

            return GetInputDown(gameObject, mainCamera, out currentFingerId, out RaycastHit hit);

        }

        public static bool GetInputDown(this GameObject gameObject, Camera mainCamera)
        {

            return GetInputDown(gameObject, mainCamera, out int currentFingerId, out RaycastHit hit);

        }

        public static bool GetInputHeld(int currentFingerId)
        {

            if (TouchActive)
            {

                return GetTouchHeld(currentFingerId);

            }

            return GetMouseButtonHeld();

        }

        public static Vector3? GetInputPosition(int currentFingerId)
        {

            if (TouchActive)
            {

                return GetTouchPosition(currentFingerId);

            }

            return GetMousePosition();

        }

        public static bool GetInputUp(int currentFingerId)
        {

            if (TouchActive)
            {

                return GetTouchUp(currentFingerId);

            }

            return GetMouseButtonUp();

        }

        public static bool GetMouseButtonDown(this GameObject gameObject, Camera mainCamera, out RaycastHit hit)
        {

            hit = new RaycastHit();

            if (Input.GetMouseButtonDown(0))
            {

                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                return Physics.Raycast(ray, out hit, Mathf.Infinity, gameObject.GetLayerMask()) && hit.transform.gameObject.Equals(gameObject);

            }

            return false;

        }

        public static bool GetMouseButtonDown(this GameObject gameObject, Camera mainCamera, out RaycastHit2D hit)
        {

            hit = new RaycastHit2D();

            if (Input.GetMouseButtonDown(0))
            {

                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, gameObject.GetLayerMask());

                return hit && hit.transform.gameObject.Equals(gameObject);

            }

            return false;

        }

        public static bool GetMouseButtonDown(this GameObject gameObject, Camera mainCamera)
        {

            return GetMouseButtonDown(gameObject, mainCamera, out RaycastHit hit);

        }

        public static bool GetMouseButtonHeld()
        {

            return Input.GetMouseButton(0);

        }

        public static bool GetMouseButtonUp()
        {

            return Input.GetMouseButtonUp(0);

        }

        public static Vector3? GetMousePosition()
        {

            return Input.mousePosition;

        }

        public static bool GetTouchDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId, out RaycastHit hit)
        {

            currentFingerId = 0;

            hit = new RaycastHit();

            if (!TouchActive)
            {

                return false;

            }

            for (var i = 0; i < Input.touchCount; i += 1)
            {

                var touch = Input.GetTouch(i);

                if (touch.phase.Equals(TouchPhase.Began))
                {

                    Ray ray = mainCamera.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, gameObject.GetLayerMask()) && hit.transform.gameObject.Equals(gameObject))
                    {

                        currentFingerId = touch.fingerId;

                        return true;

                    }

                }

            }

            return false;

        }

        public static bool GetTouchDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId, out RaycastHit2D hit)
        {

            currentFingerId = 0;

            hit = new RaycastHit2D();

            if (!TouchActive)
            {

                return false;

            }

            for (var i = 0; i < Input.touchCount; i += 1)
            {

                var touch = Input.GetTouch(i);

                if (touch.phase.Equals(TouchPhase.Began))
                {

                    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                    hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, gameObject.GetLayerMask());

                    if (hit && hit.transform.gameObject.Equals(gameObject))
                    {

                        currentFingerId = touch.fingerId;

                        return true;

                    }

                }

            }

            return false;

        }

        public static bool GetTouchDown(this GameObject gameObject, Camera mainCamera, out int currentFingerId)
        {

            return GetTouchDown(gameObject, mainCamera, out currentFingerId, out RaycastHit hit);

        }

        public static bool GetTouchHeld(int currentFingerId)
        {

            return TestTouchState(currentFingerId, TouchPhase.Moved, TouchPhase.Stationary);

        }

        public static Vector3? GetTouchPosition(int currentFingerId)
        {

            if (!TouchActive)
            {

                return null;

            }

            for (var i = 0; i < Input.touchCount; i += 1)
            {

                var touch = Input.GetTouch(i);

                if (touch.fingerId.Equals(currentFingerId))
                {

                    return touch.position;

                }

            }

            return null;

        }

        public static bool GetTouchUp(int currentFingerId)
        {

            return TestTouchState(currentFingerId, TouchPhase.Ended, TouchPhase.Canceled);

        }

        public static bool TestTouchState(int currentFingerId, params TouchPhase[] touchPhases)
        {

            if (!TouchActive)
            {

                return false;

            }

            for (var i = 0; i < Input.touchCount; i += 1)
            {

                var touch = Input.GetTouch(i);

                if (touch.fingerId.Equals(currentFingerId))
                {

                    return touchPhases.Contains(touch.phase);

                }

            }

            return false;

        }

    }

}
