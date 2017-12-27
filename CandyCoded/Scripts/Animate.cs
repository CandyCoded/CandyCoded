using UnityEngine;

namespace CandyCoded {

    public static class Animate {

        public static void FadeCustom(GameObject gameObject, float currentTime, AnimationCurve animationCurve, CandyCoded.AnimationData animationData) {

            float globalAlpha = animationCurve.Evaluate(currentTime);

            foreach (CandyCoded.MaterialData materialData in animationData.materials) {

                materialData.material.color = CandyCoded.Materials.SetColorAlpha(materialData.material.color, materialData.startColor.a * globalAlpha);

            }

        }

        public static void FadeCustom(GameObject gameObject, float currentTime, AnimationCurve animationCurve) {

            CandyCoded.AnimationData animationData = gameObject.GetComponent<CandyCoded.AnimationData>();

            if (animationData == null) {
                animationData = gameObject.AddComponent<CandyCoded.AnimationData>();
            }

            FadeCustom(gameObject, currentTime, animationCurve, animationData);

        }

        public static void FadeIn(GameObject gameObject, float currentTime) {

            FadeCustom(gameObject, currentTime, AnimationCurve.Linear(0, 0, 1, 1));

        }

        public static void FadeOut(GameObject gameObject, float currentTime) {

            FadeCustom(gameObject, currentTime, AnimationCurve.Linear(0, 1, 1, 0));

        }

    }

}
