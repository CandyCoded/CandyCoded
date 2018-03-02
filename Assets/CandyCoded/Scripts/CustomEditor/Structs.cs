using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    [System.Serializable]
    public struct Vector2AnimationCurve
    {

        public AnimationCurve x;
        public AnimationCurve y;

        public bool IsLooping()
        {

            return x.IsLooping() || y.IsLooping();

        }

        public float MaxTime()
        {

            return Mathf.Max(
                x.MaxTime(),
                y.MaxTime()
            );

        }

        public Vector2 Evaluate(float time)
        {

            return new Vector2(
                x.Evaluate(time),
                y.Evaluate(time)
            );

        }

        public static explicit operator Vector3AnimationCurve(Vector2AnimationCurve animationCurve)
        {

            Vector3AnimationCurve newAnimationCurve = new Vector3AnimationCurve();

            newAnimationCurve.x = animationCurve.x;
            newAnimationCurve.y = animationCurve.y;

            return newAnimationCurve;

        }

    }

    [System.Serializable]
    public struct Vector3AnimationCurve
    {

        public AnimationCurve x;
        public AnimationCurve y;
        public AnimationCurve z;

        public bool IsLooping()
        {

            return x.IsLooping() || y.IsLooping() || z.IsLooping();

        }

        public float MaxTime()
        {

            return Mathf.Max(
                x.MaxTime(),
                y.MaxTime(),
                z.MaxTime()
            );

        }

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

            Vector2AnimationCurve newAnimationCurve = new Vector2AnimationCurve();

            newAnimationCurve.x = animationCurve.x;
            newAnimationCurve.y = animationCurve.y;

            return newAnimationCurve;

        }

    }

}
