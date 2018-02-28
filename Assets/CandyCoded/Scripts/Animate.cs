using System.Collections;
using UnityEngine;

namespace CandyCoded
{

    public static class Animate
    {

        public static CandyCoded.AnimationData GetAnimationData(GameObject gameObject)
        {

            CandyCoded.AnimationData animationData = gameObject.GetComponent<CandyCoded.AnimationData>();

            if (animationData == null)
            {

                animationData = gameObject.AddComponent<CandyCoded.AnimationData>();

            }

            return animationData;

        }

        public static IEnumerator Position(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            float elapsedTime = 0;
            float maxTime = animationCurve.maxTime;

            while (elapsedTime < maxTime)
            {

                CandyCoded.Animate.Position(gameObject, animationCurve, elapsedTime, animationData);

                elapsedTime += Time.deltaTime;

                yield return null;

            }

        }

        public static void Position(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = GetAnimationData(gameObject);

            gameObject.transform.localPosition = animationCurve.Evaluate(deltaTime);

        }

    }

}
