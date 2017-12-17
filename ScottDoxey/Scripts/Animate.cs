using UnityEngine;

namespace ScottDoxey {

    public static class Animate {

        public static void FadeIn(GameObject gameObject, float currentTime, AnimationCurve animationCurve = null) {

            if (animationCurve == null) {

                animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

            }

            Material[] materials = ScottDoxey.Materials.GetMaterialsInChildren(gameObject);

            ScottDoxey.Materials.SetMaterialsToBlendMode(materials, ScottDoxey.StandardShader.BlendMode.Fade);

            float globalAlpha = animationCurve.Evaluate(currentTime);

            foreach (Material material in materials) {

                material.color = ScottDoxey.Materials.SetColorAlpha(material.color, globalAlpha);

            }

        }

        public static void FadeOut(GameObject gameObject, float currentTime, AnimationCurve animationCurve = null) {

            if (animationCurve == null) {

                animationCurve = AnimationCurve.Linear(0, 1, 1, 0);

            }

            Material[] materials = ScottDoxey.Materials.GetMaterialsInChildren(gameObject);

            ScottDoxey.Materials.SetMaterialsToBlendMode(materials, ScottDoxey.StandardShader.BlendMode.Fade);

            float globalAlpha = animationCurve.Evaluate(currentTime);

            foreach (Material material in materials) {

                material.color = ScottDoxey.Materials.SetColorAlpha(material.color, globalAlpha);

            }

        }

    }

}
