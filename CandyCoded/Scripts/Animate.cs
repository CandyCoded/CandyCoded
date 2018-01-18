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

        public static void FadeCustom(GameObject gameObject, float deltaTime, AnimationCurve animationCurve, CandyCoded.AnimationData animationData)
        {

            animationData.activeTime += deltaTime;

            float globalAlpha = animationCurve.Evaluate(animationData.activeTime);

            foreach (CandyCoded.MaterialData materialData in animationData.materials)
            {

                materialData.material.color = CandyCoded.Materials.SetColorAlpha(materialData.material.color, materialData.startColor.a * globalAlpha);

            }

        }

        public static void FadeCustom(GameObject gameObject, float deltaTime, AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            FadeCustom(gameObject, deltaTime, animationCurve, animationData);

        }

        public static void FadeIn(GameObject gameObject, float deltaTime)
        {

            FadeCustom(gameObject, deltaTime, AnimationCurve.Linear(0, 0, 1, 1));

        }

        public static void FadeOut(GameObject gameObject, float deltaTime)
        {

            FadeCustom(gameObject, deltaTime, AnimationCurve.Linear(0, 1, 1, 0));

        }

        public static void Position(GameObject gameObject, float deltaTime, Vector3 multiplier, AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            gameObject.transform.position = animationData.transformData.position + multiplier * animationCurve.Evaluate(Time.time);

        }

        public static void Scale(GameObject gameObject, float deltaTime, Vector3 multiplier, AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            gameObject.transform.localScale = animationData.transformData.scale + multiplier * animationCurve.Evaluate(Time.time);

        }

        public static void Rotate(GameObject gameObject, float deltaTime, Vector3 multiplier, AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            gameObject.transform.localRotation = Quaternion.Euler(animationData.transformData.rotation * multiplier * animationCurve.Evaluate(Time.time));

        }

        public static void ResetAnimationStartTime(GameObject gameObject)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);
            animationData.ResetAnimationStartTime();

        }

    }

}
