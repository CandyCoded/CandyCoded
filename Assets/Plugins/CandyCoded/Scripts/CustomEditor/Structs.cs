using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    [System.Serializable]
    public struct Vector2AnimationCurve
    {

        public AnimationCurve x;
        public AnimationCurve y;

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

        public static explicit operator Vector3AnimationCurve(Vector2AnimationCurve animationCurve)
        {

            Vector3AnimationCurve newAnimationCurve = new Vector3AnimationCurve
            {
                x = animationCurve.x,
                y = animationCurve.y
            };

            return newAnimationCurve;

        }

    }

    [System.Serializable]
    public struct Vector3AnimationCurve
    {

        public AnimationCurve x;
        public AnimationCurve y;
        public AnimationCurve z;

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

        public static explicit operator Vector2AnimationCurve(Vector3AnimationCurve animationCurve)
        {

            Vector2AnimationCurve newAnimationCurve = new Vector2AnimationCurve
            {
                x = animationCurve.x,
                y = animationCurve.y
            };

            return newAnimationCurve;

        }

    }

}
