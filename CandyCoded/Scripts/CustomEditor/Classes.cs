using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    [System.Serializable]
    public class Vector2AnimationCurve
    {

        public AnimationCurve x = AnimationCurve.Linear(0, 0, 1, 1);
        public AnimationCurve y = AnimationCurve.Linear(0, 0, 1, 1);

        public Vector2 Evaluate(float time)
        {

            return new Vector2(
                x.Evaluate(time),
                y.Evaluate(time)
            );

        }

    }

    [System.Serializable]
    public class Vector3AnimationCurve
    {

        public AnimationCurve x = AnimationCurve.Linear(0, 0, 1, 1);
        public AnimationCurve y = AnimationCurve.Linear(0, 0, 1, 1);
        public AnimationCurve z = AnimationCurve.Linear(0, 0, 1, 1);

        public Vector3 Evaluate(float time)
        {

            return new Vector3(
                x.Evaluate(time),
                y.Evaluate(time),
                z.Evaluate(time)
            );

        }

    }

}
