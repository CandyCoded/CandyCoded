using System.Collections;
using UnityEngine;

namespace CandyCoded
{

    public static class Animate
    {

        public delegate void AnimationFunc(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null);

        public static CandyCoded.AnimationData GetAnimationData(GameObject gameObject)
        {

            CandyCoded.AnimationData animationData = gameObject.GetComponent<CandyCoded.AnimationData>();

            if (animationData == null)
            {

                animationData = gameObject.AddComponent<CandyCoded.AnimationData>();

            }

            return animationData;

        }

        public static IEnumerator Loop(GameObject gameObject, Vector3AnimationCurve animationCurve, AnimationFunc animationFunc)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            float elapsedTime = 0;
            float maxTime = animationCurve.maxTime;

            while (elapsedTime < maxTime)
            {

                animationFunc(gameObject, animationCurve, elapsedTime);

                elapsedTime += Time.deltaTime;

                yield return null;

            }

        }

        public static void Position(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = GetAnimationData(gameObject);

            gameObject.transform.localPosition = animationCurve.Evaluate(deltaTime);

        }

        public static void PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = GetAnimationData(gameObject);

            gameObject.transform.localPosition = animationData.transformData.position + animationCurve.Evaluate(deltaTime);

        }

        public static void Rotate(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = GetAnimationData(gameObject);

            gameObject.transform.localRotation = Quaternion.Euler(animationCurve.Evaluate(deltaTime));

        }

        public static void Scale(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = GetAnimationData(gameObject);

            gameObject.transform.localScale = animationCurve.Evaluate(deltaTime);

        }

        public static void ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float deltaTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = GetAnimationData(gameObject);

            gameObject.transform.localScale = animationData.transformData.scale + animationCurve.Evaluate(deltaTime);

        }

    }

}
