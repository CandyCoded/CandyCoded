/**
 * The MIT License (MIT)
 *
 * Copyright (c) 2018 Scott Doxey
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

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

                return other.freezePositionX == freezePositionX &&
                    other.freezePositionY == freezePositionY &&
                    other.freezePositionZ == freezePositionZ &&
                    other.maintainOffsetX == maintainOffsetX &&
                    other.maintainOffsetY == maintainOffsetY &&
                    other.maintainOffsetZ == maintainOffsetZ;

            }
        }

        [SerializeField]
        private bool _tracking = true;
        public bool tracking
        {
            get { return _tracking; }
            set { _tracking = value; }
        }

        [SerializeField]
        private bool _rotating = true;
        public bool rotating
        {
            get { return _rotating; }
            set { _rotating = value; }
        }

        [SerializeField]
        private Transform _mainTarget;
        public Transform mainTarget
        {
            get { return _mainTarget; }
            set { _mainTarget = value; }
        }

        [SerializeField]
        private Transform _secondaryTarget;
        public Transform secondaryTarget
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

        private void Awake()
        {

            if (cameraTransform == null)
            {

                cameraTransform = Camera.main.transform;

            }

            if (mainTarget == null)
            {

                mainTarget = gameObject.transform;

            }

            tempSecondaryTarget = new GameObject("SecondayTarget (temp)");
            tempSecondaryTarget.transform.position = gameObject.transform.position + gameObject.transform.forward;
            tempSecondaryTarget.transform.parent = mainTarget;

            lookAtPosition = tempSecondaryTarget.transform.position;

            cameraPositionOffset = new Vector3(
                cameraTransform.position.x - mainTarget.transform.position.x,
                cameraTransform.position.y - mainTarget.transform.position.y,
                cameraTransform.position.z - mainTarget.transform.position.z
            );

        }

        private void LateUpdate()
        {

            if (tracking && mainTarget)
            {

                Vector3 newPosition = mainTarget.transform.position;

                Transform secondaryTargetTransform = tempSecondaryTarget.transform;

                if (secondaryTarget)
                {

                    secondaryTargetTransform = secondaryTarget;

                }

                if (rotating)
                {

                    newPosition = mainTarget.position + (cameraPositionOffset.magnitude * (mainTarget.position - secondaryTargetTransform.position).normalized);

                    newPosition.y = mainTarget.position.y;

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

                cameraTransform.position = Vector3.SmoothDamp(
                    cameraTransform.position,
                    newPosition,
                    ref velocity,
                    dampRate
                );

                if (rotating)
                {

                    lookAtPosition = Vector3.Lerp(lookAtPosition, secondaryTargetTransform.position, rotateSpeed * Time.deltaTime);

                    cameraTransform.LookAt(lookAtPosition);

                }

            }

        }

    }

}
