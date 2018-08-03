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

    [Serializable]
    public struct Vector2AnimationCurve : IEquatable<Vector2AnimationCurve>
    {

        [SerializeField]
        private AnimationCurve _x;
        public AnimationCurve x
        {
            get { return _x; }
            set { _x = value; }
        }

        [SerializeField]
        private AnimationCurve _y;
        public AnimationCurve y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Creates a clone of the Vector2AnimationCurve object.
        /// </summary>
        /// <returns>Vector2AnimationCurve</returns>
        public Vector2AnimationCurve Clone()
        {

            return new Vector2AnimationCurve
            {
                x = new AnimationCurve(x.keys),
                    y = new AnimationCurve(y.keys)
            };

        }

        /// <summary>
        /// Checks the x and y animation curves to see if either of them loop.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLooping()
        {

            return x.IsLooping() || y.IsLooping();

        }

        /// <summary>
        /// Returns the highest duration time of either the x or y animation curves.
        /// </summary>
        /// <returns>float</returns>
        public float MaxTime()
        {

            return Mathf.Max(
                x.MaxTime(),
                y.MaxTime()
            );

        }

        /// <summary>
        /// Evalues both animation curves and generates a Vector2 with the results.
        /// </summary>
        /// <param name="time">The time to evaluate each animation curve with.</param>
        /// <returns>Vector2</returns>
        public Vector2 Evaluate(float time)
        {

            return new Vector2(
                x.Evaluate(time),
                y.Evaluate(time)
            );

        }

        public bool Equals(Vector2AnimationCurve other)
        {

            return other.x == x && other.y == y;

        }

        public static explicit operator Vector3AnimationCurve(Vector2AnimationCurve animationCurve)
        {

            var newAnimationCurve = new Vector3AnimationCurve
            {
                x = animationCurve.x,
                y = animationCurve.y
            };

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
            get { return _x; }
            set { _x = value; }
        }

        [SerializeField]
        private AnimationCurve _y;
        public AnimationCurve y
        {
            get { return _y; }
            set { _y = value; }
        }

        [SerializeField]
        private AnimationCurve _z;
        public AnimationCurve z
        {
            get { return _z; }
            set { _z = value; }
        }

        /// <summary>
        /// Creates a clone of the Vector3AnimationCurve object.
        /// </summary>
        /// <returns>Vector3AnimationCurve</returns>
        public Vector3AnimationCurve Clone()
        {

            return new Vector3AnimationCurve
            {
                x = new AnimationCurve(x.keys),
                    y = new AnimationCurve(y.keys),
                    z = new AnimationCurve(z.keys)
            };

        }

        /// <summary>
        /// Checks the x, y and z animation curves to see if any of them loop.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLooping()
        {

            return x.IsLooping() || y.IsLooping() || z.IsLooping();

        }

        /// <summary>
        /// Returns the highest duration time of either the x, y or z animation curves.
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

        /// <summary>
        /// Evalues all animation curves and generates a Vector3 with the results.
        /// </summary>
        /// <param name="time">The time to evaluate each animation curve with.</param>
        /// <returns>Vector3</returns>
        public Vector3 Evaluate(float time)
        {

            return new Vector3(
                x.Evaluate(time),
                y.Evaluate(time),
                z.Evaluate(time)
            );

        }

        public bool Equals(Vector3AnimationCurve other)
        {

            return other.x == x && other.y == y && other.z == z;

        }

        public static explicit operator Vector2AnimationCurve(Vector3AnimationCurve animationCurve)
        {

            var newAnimationCurve = new Vector2AnimationCurve
            {
                x = animationCurve.x,
                y = animationCurve.y
            };

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
            get { return _x; }
            set { _x = value; }
        }

        [SerializeField]
        private AnimationCurve _y;
        public AnimationCurve y
        {
            get { return _y; }
            set { _y = value; }
        }

        [SerializeField]
        private AnimationCurve _z;
        public AnimationCurve z
        {
            get { return _z; }
            set { _z = value; }
        }

        [SerializeField]
        private AnimationCurve _w;
        public AnimationCurve w
        {
            get { return _w; }
            set { _w = value; }
        }

        /// <summary>
        /// Creates a clone of the Vector4AnimationCurve object.
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

        /// <summary>
        /// Checks the x, y, z and w animation curves to see if any of them loop.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLooping()
        {

            return x.IsLooping() || y.IsLooping() || z.IsLooping() || w.IsLooping();

        }

        /// <summary>
        /// Returns the highest duration time of either the x, y, z or w animation curves.
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

        /// <summary>
        /// Evalues all animation curves and generates a Vector4 with the results.
        /// </summary>
        /// <param name="time">The time to evaluate each animation curve with.</param>
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

        public bool Equals(Vector4AnimationCurve other)
        {

            return other.x == x && other.y == y && other.z == z && other.w == w;

        }

    }

}
