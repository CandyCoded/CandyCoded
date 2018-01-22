using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    [System.Serializable]
    public class Vector2AnimationCurve
    {

        public AnimationCurve x = AnimationCurve.Linear(0, 0, 1, 0);
        public AnimationCurve y = AnimationCurve.Linear(0, 0, 1, 0);

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
    public class Vector3AnimationCurve
    {

        public AnimationCurve x = AnimationCurve.Linear(0, 0, 1, 0);
        public AnimationCurve y = AnimationCurve.Linear(0, 0, 1, 0);
        public AnimationCurve z = AnimationCurve.Linear(0, 0, 1, 0);

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
