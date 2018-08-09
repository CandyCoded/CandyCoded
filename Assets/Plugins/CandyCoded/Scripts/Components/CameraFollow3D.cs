// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace CandyCoded
{

    public class CameraFollow3D : MonoBehaviour
    {

        [Serializable]
        private struct CameraConstraints3D : IEquatable<CameraConstraints3D>
        {
            [Header("Freeze Original Position")]
            public bool freezePositionX;
            public bool freezePositionY;
            public bool freezePositionZ;
            [Header("Maintain Original Offset")]
            public bool maintainOffsetX;
            public bool maintainOffsetY;
            public bool maintainOffsetZ;
            public bool Equals(CameraConstraints3D other)
            {

                bool freezePosition = other.freezePositionX == freezePositionX &&
                    other.freezePositionY == freezePositionY &&
                    other.freezePositionZ == freezePositionZ;

                bool maintainOffset = other.maintainOffsetX == maintainOffsetX &&
                    other.maintainOffsetY == maintainOffsetY &&
                    other.maintainOffsetZ == maintainOffsetZ;

                return freezePosition && maintainOffset;

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
        private bool _rotating = true;
        public bool Rotating
        {
            get { return _rotating; }
            set { _rotating = value; }
        }

        [SerializeField]
        private Transform _mainTarget;
        public Transform MainTarget
        {
            get { return _mainTarget; }
            set { _mainTarget = value; }
        }

        [SerializeField]
        private Transform _secondaryTarget;
        public Transform SecondaryTarget
        {
            get { return _secondaryTarget; }
            set { _secondaryTarget = value; }
        }

        [SerializeField]
        private float dampRate = 0.3f;

        [SerializeField]
        private float rotateSpeed = 5f;

        [SerializeField]
        private CameraConstraints3D constraints;

        [SerializeField]
        private Transform cameraTransform;
        private Vector3 cameraPositionOffset;

        private Vector3 velocity = Vector3.zero;

        private Vector3 lookAtPosition;
        private GameObject tempSecondaryTarget;

#pragma warning disable S1144
        // Disables "Unused private types or members should be removed" warning as method is part of MonoBehaviour.
        private void Awake()
        {

            if (cameraTransform == null)
            {

                cameraTransform = Camera.main.transform;

            }

            if (MainTarget == null)
            {

                MainTarget = gameObject.transform;

            }

            tempSecondaryTarget = new GameObject("SecondayTarget (temp)");
            tempSecondaryTarget.transform.position = gameObject.transform.position + gameObject.transform.forward;
            tempSecondaryTarget.transform.parent = MainTarget;

            lookAtPosition = tempSecondaryTarget.transform.position;

            cameraPositionOffset = new Vector3(
                cameraTransform.position.x - MainTarget.position.x,
                cameraTransform.position.y - MainTarget.position.y,
                cameraTransform.position.z - MainTarget.position.z
            );

        }

        private void LateUpdate()
        {

            if (Tracking && MainTarget)
            {

                Vector3 newPosition = MainTarget.position;

                newPosition = CalculateOffset(newPosition);

                newPosition = FreezePositions(newPosition);

                cameraTransform.position = Vector3.SmoothDamp(
                    cameraTransform.position,
                    newPosition,
                    ref velocity,
                    dampRate
                );

                if (Rotating)
                {

                    lookAtPosition = Vector3.Lerp(lookAtPosition, tempSecondaryTarget.transform.position, rotateSpeed * Time.deltaTime);

                    cameraTransform.LookAt(lookAtPosition);

                }

            }

        }
#pragma warning restore S1144

        public Vector3 CalculateOffset(Vector3 newPosition)
        {

            if (Rotating)
            {

                Vector3 tempPosition = newPosition + (cameraPositionOffset.magnitude * (newPosition - tempSecondaryTarget.transform.position).normalized);

                newPosition.x = tempPosition.x;
                newPosition.y = MainTarget.position.y;
                newPosition.z = tempPosition.z;

            }
            else
            {

                if (constraints.maintainOffsetX)
                {

                    newPosition.x += cameraPositionOffset.x;

                }

                if (constraints.maintainOffsetZ)
                {

                    newPosition.z += cameraPositionOffset.z;

                }

            }

            if (constraints.maintainOffsetY)
            {

                newPosition.y += cameraPositionOffset.y;

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

            if (constraints.freezePositionZ)
            {

                newPosition.z = cameraTransform.position.z;

            }

            return newPosition;

        }

    }

}
