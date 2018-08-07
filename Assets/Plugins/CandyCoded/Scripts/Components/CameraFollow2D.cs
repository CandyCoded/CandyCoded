// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace CandyCoded
{

    public class CameraFollow2D : MonoBehaviour
    {

        [Serializable]
        private struct CameraConstraints2D : IEquatable<CameraConstraints2D>
        {
            [Header("Freeze Original Position")]
            public bool freezePositionX;
            public bool freezePositionY;
            [Header("Maintain Original Offset")]
            public bool maintainOffsetX;
            public bool maintainOffsetY;
            [Header("Restrict Viewport to Transform")]
            public Transform boundsTransform;
            [Header("(or)")]
            [Header("Restrict Viewport to Manually Defined Bounds")]
            public Bounds bounds;
            public bool Equals(CameraConstraints2D other)
            {

                bool freezePosition = other.freezePositionX == freezePositionX &&
                    other.freezePositionY == freezePositionY;

                bool maintainOffset = other.maintainOffsetX == maintainOffsetX &&
                    other.maintainOffsetY == maintainOffsetY;

                bool restrictBounds = other.boundsTransform == boundsTransform &&
                    other.bounds == bounds;

                return freezePosition && maintainOffset && restrictBounds;

            }
        }

        [SerializeField]
        private bool _tracking = true;
        public bool Tracking
        {
            get { return _tracking; }
            set { _tracking = value; }
        }

        [SerializeField]
        private Transform _mainTarget;
        public Transform MainTarget
        {
            get { return _mainTarget; }
            set { _mainTarget = value; }
        }

        [SerializeField]
        private float dampRate = 0.3f;

        [SerializeField]
        private CameraConstraints2D constraints;

        [SerializeField]
        private Transform cameraTransform;
        private Vector3 cameraPositionOffset;

        private float cameraOrthographicSize;
        private float cameraExtentHorizontal
        {

            get
            {

                return cameraOrthographicSize * Screen.width / Screen.height;

            }

        }

        private Vector3 velocity = Vector3.zero;

#pragma warning disable S1144
        // Disables "Unused private types or members should be removed" warning method is part of MonoBehaviour.
        private void Awake()
        {

            cameraTransform = Camera.main.transform;
            cameraOrthographicSize = Camera.main.orthographicSize;

            if (MainTarget == null)
            {

                MainTarget = gameObject.transform;

            }

            cameraPositionOffset = new Vector2(
                cameraTransform.position.x - MainTarget.transform.position.x,
                cameraTransform.position.y - MainTarget.transform.position.y
            );

        }

        private void LateUpdate()
        {

            if (Tracking && MainTarget)
            {

                Vector3 newPosition = MainTarget.transform.position;

                newPosition += CalculateOffset();

                newPosition = CalculateBounds(newPosition);

                newPosition = FreezePositions(newPosition);

                cameraTransform.position = Vector3.SmoothDamp(
                    cameraTransform.position,
                    newPosition,
                    ref velocity,
                    dampRate
                );

            }

        }
#pragma warning restore S1144

        public Vector3 CalculateOffset()
        {

            Vector3 offset = Vector3.zero;

            if (constraints.maintainOffsetX)
            {

                offset.x = cameraPositionOffset.x;

            }

            if (constraints.maintainOffsetY)
            {

                offset.y = cameraPositionOffset.y;

            }

            return offset;

        }

        public Vector3 CalculateBounds(Vector3 newPosition)
        {

            Bounds bounds = constraints.bounds;

            if (constraints.boundsTransform)
            {

                bounds = Calculation.ParentBounds(constraints.boundsTransform);

            }

            if (Mathf.Abs(bounds.size.magnitude) >= Single.Epsilon)
            {

                newPosition.x = Mathf.Clamp(newPosition.x, bounds.min.x + cameraExtentHorizontal, bounds.max.x - cameraExtentHorizontal);
                newPosition.y = Mathf.Clamp(newPosition.y, bounds.min.y + cameraOrthographicSize, bounds.max.y - cameraOrthographicSize);

            }

            return newPosition;

        }

        public Vector3 FreezePositions(Vector3 newPosition)
        {

            if (constraints.freezePositionX)
            {

                newPosition.x = cameraTransform.position.x;

            }

            if (constraints.freezePositionY)
            {

                newPosition.y = cameraTransform.position.y;

            }

            newPosition.z = cameraTransform.position.z;

            return newPosition;

        }

    }

}
