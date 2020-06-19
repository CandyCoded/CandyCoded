// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
#pragma warning disable S100

// Disables "Methods and properties should be named in camel case" to allow properties to match Vector2, Vector3 and Vector4 structs.

namespace CandyCoded
{

    [Serializable]
    public struct RangedFloat : IEquatable<RangedFloat>
    {

        public float min;

        public float max;

        public float Random()
        {

            return UnityEngine.Random.Range(min, max);

        }

        public bool Equals(RangedFloat other)
        {

            return other.min.Equals(min) && other.max.Equals(max);

        }

    }

    [Serializable]
    public struct Vector2AnimationCurve : IEquatable<Vector2AnimationCurve>
    {

        [SerializeField]
        private AnimationCurve _x;

        public AnimationCurve x
        {
            get => _x;
            set => _x = value;
        }

        [SerializeField]
        private AnimationCurve _y;

        public AnimationCurve y
        {
            get => _y;
            set => _y = value;
        }

        /// <summary>
        ///     Creates a clone of the Vector2AnimationCurve object.
        /// </summary>
        /// <returns>Vector2AnimationCurve</returns>
        public Vector2AnimationCurve Clone()
        {

            return new Vector2AnimationCurve { x = new AnimationCurve(x.keys), y = new AnimationCurve(y.keys) };

        }

        public bool Equals(Vector2AnimationCurve other)
        {

            return other.x.Equals(x) && other.y.Equals(y);

        }

        /// <summary>
        ///     Evaluates both animation curves and generates a Vector2 with the results.
        /// </summary>
        /// <param name="time">The time used to evaluate each animation curve.</param>
        /// <returns>Vector2</returns>
        public Vector2 Evaluate(float time)
        {

            return new Vector2(
                x.Evaluate(time),
                y.Evaluate(time)
            );

        }

        /// <summary>
        ///     Checks the x and y animation curves to see if either of them loop.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLooping()
        {

            return x.IsLooping() || y.IsLooping();

        }

        /// <summary>
        ///     Returns the highest duration time of either the x or y animation curves.
        /// </summary>
        /// <returns>float</returns>
        public float MaxTime()
        {

            return Mathf.Max(
                x.MaxTime(),
                y.MaxTime()
            );

        }

        public static explicit operator Vector3AnimationCurve(Vector2AnimationCurve animationCurve)
        {

            var newAnimationCurve = new Vector3AnimationCurve { x = animationCurve.x, y = animationCurve.y };

            return newAnimationCurve;

        }

    }

    [Serializable]
    public struct Vector3AnimationCurve : IEquatable<Vector3AnimationCurve>
    {

        [SerializeField]
        private AnimationCurve _x;

        public AnimationCurve x
        {
            get => _x;
            set => _x = value;
        }

        [SerializeField]
        private AnimationCurve _y;

        public AnimationCurve y
        {
            get => _y;
            set => _y = value;
        }

        [SerializeField]
        private AnimationCurve _z;

        public AnimationCurve z
        {
            get => _z;
            set => _z = value;
        }

        /// <summary>
        ///     Creates a clone of the Vector3AnimationCurve object.
        /// </summary>
        /// <returns>Vector3AnimationCurve</returns>
        public Vector3AnimationCurve Clone()
        {

            return new Vector3AnimationCurve
            {
                x = new AnimationCurve(x.keys), y = new AnimationCurve(y.keys), z = new AnimationCurve(z.keys)
            };

        }

        public bool Equals(Vector3AnimationCurve other)
        {

            return other.x.Equals(x) && other.y.Equals(y) && other.z.Equals(z);

        }

        /// <summary>
        ///     Evaluates all animation curves and generates a Vector3 with the results.
        /// </summary>
        /// <param name="time">The time used to evaluate each animation curve.</param>
        /// <returns>Vector3</returns>
        public Vector3 Evaluate(float time)
        {

            return new Vector3(
                x.Evaluate(time),
                y.Evaluate(time),
                z.Evaluate(time)
            );

        }

        /// <summary>
        ///     Checks the x, y and z animation curves to see if any of them loop.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLooping()
        {

            return x.IsLooping() || y.IsLooping() || z.IsLooping();

        }

        /// <summary>
        ///     Returns the highest duration time of either the x, y or z animation curves.
        /// </summary>
        /// <returns>float</returns>
        public float MaxTime()
        {

            return Mathf.Max(
                x.MaxTime(),
                y.MaxTime(),
                z.MaxTime()
            );

        }

        public static explicit operator Vector2AnimationCurve(Vector3AnimationCurve animationCurve)
        {

            var newAnimationCurve = new Vector2AnimationCurve { x = animationCurve.x, y = animationCurve.y };

            return newAnimationCurve;

        }

    }

    [Serializable]
    public struct Vector4AnimationCurve : IEquatable<Vector4AnimationCurve>
    {

        [SerializeField]
        private AnimationCurve _x;

        public AnimationCurve x
        {
            get => _x;
            set => _x = value;
        }

        [SerializeField]
        private AnimationCurve _y;

        public AnimationCurve y
        {
            get => _y;
            set => _y = value;
        }

        [SerializeField]
        private AnimationCurve _z;

        public AnimationCurve z
        {
            get => _z;
            set => _z = value;
        }

        [SerializeField]
        private AnimationCurve _w;

        public AnimationCurve w
        {
            get => _w;
            set => _w = value;
        }

        /// <summary>
        ///     Creates a clone of the Vector4AnimationCurve object.
        /// </summary>
        /// <returns>Vector4AnimationCurve</returns>
        public Vector4AnimationCurve Clone()
        {

            return new Vector4AnimationCurve
            {
                x = new AnimationCurve(x.keys),
                y = new AnimationCurve(y.keys),
                z = new AnimationCurve(z.keys),
                w = new AnimationCurve(w.keys)
            };

        }

        public bool Equals(Vector4AnimationCurve other)
        {

            return other.x.Equals(x) && other.y.Equals(y) && other.z.Equals(z) && other.w.Equals(w);

        }

        /// <summary>
        ///     Evaluates all animation curves and generates a Vector4 with the results.
        /// </summary>
        /// <param name="time">The time used to evaluate each animation curve.</param>
        /// <returns>Vector4</returns>
        public Vector4 Evaluate(float time)
        {

            return new Vector4(
                x.Evaluate(time),
                y.Evaluate(time),
                z.Evaluate(time),
                w.Evaluate(time)
            );

        }

        /// <summary>
        ///     Checks the x, y, z and w animation curves to see if any of them loop.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLooping()
        {

            return x.IsLooping() || y.IsLooping() || z.IsLooping() || w.IsLooping();

        }

        /// <summary>
        ///     Returns the highest duration time of either the x, y, z or w animation curves.
        /// </summary>
        /// <returns>float</returns>
        public float MaxTime()
        {

            return Mathf.Max(
                x.MaxTime(),
                y.MaxTime(),
                z.MaxTime(),
                w.MaxTime()
            );

        }

    }

}

#pragma warning restore S100
