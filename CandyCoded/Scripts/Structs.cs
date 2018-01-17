using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    [System.Serializable]
    public struct Vector2AnimationCurve
    {

        public AnimationCurve x;
        public AnimationCurve y;

    }

    [System.Serializable]
    public struct Vector3AnimationCurve
    {

        public AnimationCurve x;
        public AnimationCurve y;
        public AnimationCurve z;

    }

    [System.Serializable]
    public struct Vector4AnimationCurve
    {

        public AnimationCurve x;
        public AnimationCurve y;
        public AnimationCurve z;
        public AnimationCurve w;

    }

}
