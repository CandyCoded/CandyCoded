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

        public static void Position(GameObject gameObject, float deltaTime, Vector3AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            animationData.activeTime += deltaTime;

            gameObject.transform.position = animationCurve.Evaluate(animationData.activeTime);

        }

        public static void Position(GameObject gameObject, float deltaTime, Vector2AnimationCurve animationCurve)
        {

            Position(gameObject, deltaTime, (Vector3AnimationCurve) animationCurve);

        }

        public static void PositionRelative(GameObject gameObject, float deltaTime, Vector3AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            animationData.activeTime += deltaTime;

            gameObject.transform.position = animationData.transformData.position + animationCurve.Evaluate(animationData.activeTime);

        }

        public static void PositionRelative(GameObject gameObject, float deltaTime, Vector2AnimationCurve animationCurve)
        {

            PositionRelative(gameObject, deltaTime, (Vector3AnimationCurve) animationCurve);

        }

        public static void Scale(GameObject gameObject, float deltaTime, Vector3AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            animationData.activeTime += deltaTime;

            gameObject.transform.localScale = animationCurve.Evaluate(animationData.activeTime);

        }

        public static void Scale(GameObject gameObject, float deltaTime, Vector2AnimationCurve animationCurve)
        {

            Scale(gameObject, deltaTime, (Vector3AnimationCurve) animationCurve);

        }

        public static void ScaleRelative(GameObject gameObject, float deltaTime, Vector3AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            animationData.activeTime += deltaTime;

            gameObject.transform.localScale = animationData.transformData.scale + animationCurve.Evaluate(animationData.activeTime);

        }

        public static void ScaleRelative(GameObject gameObject, float deltaTime, Vector2AnimationCurve animationCurve)
        {

            ScaleRelative(gameObject, deltaTime, (Vector3AnimationCurve) animationCurve);

        }

        public static void Rotate(GameObject gameObject, float deltaTime, Vector3AnimationCurve animationCurve)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);

            animationData.activeTime += deltaTime;

            gameObject.transform.localRotation = Quaternion.Euler(animationCurve.Evaluate(animationData.activeTime));

        }

        public static void Rotate(GameObject gameObject, float deltaTime, Vector2AnimationCurve animationCurve)
        {

            Rotate(gameObject, deltaTime, (Vector3AnimationCurve) animationCurve);

        }

        public static void ResetAnimationStartTime(GameObject gameObject)
        {

            CandyCoded.AnimationData animationData = GetAnimationData(gameObject);
            animationData.ResetAnimationStartTime();

        }

    }

}
