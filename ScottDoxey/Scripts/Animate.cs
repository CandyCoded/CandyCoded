using UnityEngine;

namespace ScottDoxey {

    public static class Animate {

        public static void FadeCustom(GameObject gameObject, float currentTime, AnimationCurve animationCurve) {

            Material[] materials = ScottDoxey.Materials.GetMaterialsInChildren(gameObject);

            ScottDoxey.Materials.SetMaterialsToBlendMode(materials, ScottDoxey.StandardShader.BlendMode.Fade);

            float globalAlpha = animationCurve.Evaluate(currentTime);

            foreach (Material material in materials) {

                material.color = ScottDoxey.Materials.SetColorAlpha(material.color, globalAlpha);

            }

        }

        public static void FadeIn(GameObject gameObject, float currentTime) {

            FadeCustom(gameObject, currentTime, AnimationCurve.Linear(0, 0, 1, 1));

        }

        public static void FadeOut(GameObject gameObject, float currentTime) {

            FadeCustom(gameObject, currentTime, AnimationCurve.Linear(0, 1, 1, 0));

        }

    }

}
