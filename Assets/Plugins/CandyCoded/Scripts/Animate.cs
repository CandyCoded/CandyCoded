using System.Collections;
using UnityEngine;

namespace CandyCoded
{

    public static class Animate
    {

        private delegate void AnimationFunc(float elapsedTime);

        private static IEnumerator Loop(GameObject gameObject, string coroutineKey, bool isLooping, float maxTime, AnimationFunc animationFunc)
        {

            Runner runner = gameObject.AddOrGetComponent<Runner>();

            float elapsedTime = 0;

            while (isLooping || elapsedTime < maxTime)
            {

                animationFunc(elapsedTime);

                if (isLooping)
                {

                    elapsedTime = elapsedTime + Time.deltaTime;

                }
                else
                {

                    elapsedTime = Mathf.Min(elapsedTime + Time.deltaTime, maxTime);

                }

                yield return null;

            }

            animationFunc(elapsedTime);

            runner.RemoveCoroutine(coroutineKey);

        }

        private static Coroutine StartCoroutine(GameObject gameObject, string coroutineKey, IEnumerator routine)
        {

            Runner runner = gameObject.AddOrGetComponent<Runner>();

            runner.RemoveCoroutine(coroutineKey);

            return runner.AddCoroutine(coroutineKey, routine);

        }

        public static Coroutine Fade(GameObject gameObject, AnimationCurve animationCurve)
        {

            AnimationData animationData = gameObject.AddOrGetComponent<AnimationData>();

            return StartCoroutine(gameObject, "Fade",
                Loop(gameObject, "Fade", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (float elapsedTime) => Fade(animationCurve, elapsedTime, animationData)));

        }

        public static void Fade(AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null)
        {

            float globalAlpha = animationCurve.Evaluate(elapsedTime);

            foreach (CandyCoded.MaterialData materialData in animationData.materials)
            {

                materialData.material.color = CandyCoded.Materials.SetColorAlpha(materialData.material.color, materialData.startColor.a * globalAlpha);

            }

        }

        public static void Fade(GameObject gameObject, float from, float to, float duration = 1.0f)
        {

            AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, from, duration, to);

            Fade(gameObject, animationCurve);

        }

        public static Coroutine Position(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "Position",
                Loop(gameObject, "Position", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (float elapsedTime) => Position(gameObject, animationCurve, elapsedTime)));

        }

        public static void Position(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime)
        {

            gameObject.transform.localPosition = animationCurve.Evaluate(elapsedTime);

        }

        public static Coroutine PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            AnimationData animationData = gameObject.AddOrGetComponent<AnimationData>();

            return StartCoroutine(gameObject, "PositionRelative",
                Loop(gameObject, "PositionRelative", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (float elapsedTime) => PositionRelative(gameObject, animationCurve, elapsedTime, animationData)));

        }

        public static void PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = gameObject.AddOrGetComponent<AnimationData>();

            gameObject.transform.localPosition = animationData.transformData.position + animationCurve.Evaluate(elapsedTime);

        }

        public static void MoveTo(GameObject gameObject, Vector3 newPosition, float duration = 1.0f)
        {

            Vector3AnimationCurve animationCurve = new Vector3AnimationCurve();

            Vector3 currentPosition = gameObject.transform.position;

            animationCurve.x = AnimationCurve.EaseInOut(0, currentPosition.x, duration, newPosition.x);
            animationCurve.y = AnimationCurve.EaseInOut(0, currentPosition.y, duration, newPosition.y);
            animationCurve.z = AnimationCurve.EaseInOut(0, currentPosition.z, duration, newPosition.z);

            Position(gameObject, animationCurve);

        }

        public static Coroutine Rotation(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "Rotation",
                Loop(gameObject, "Rotation", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (float elapsedTime) => Rotation(gameObject, animationCurve, elapsedTime)));

        }

        public static void Rotation(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime)
        {

            gameObject.transform.localRotation = Quaternion.Euler(animationCurve.Evaluate(elapsedTime));

        }

        public static void RotateTo(GameObject gameObject, Vector3 newRotation, float duration = 1.0f)
        {

            Vector3AnimationCurve animationCurve = new Vector3AnimationCurve();

            Vector3 currentRotation = gameObject.transform.localRotation.eulerAngles;

            animationCurve.x = AnimationCurve.EaseInOut(0, currentRotation.x, duration, newRotation.x);
            animationCurve.y = AnimationCurve.EaseInOut(0, currentRotation.y, duration, newRotation.y);
            animationCurve.z = AnimationCurve.EaseInOut(0, currentRotation.z, duration, newRotation.z);

            Rotation(gameObject, animationCurve);

        }

        public static Coroutine Scale(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "Scale",
                Loop(gameObject, "Scale", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (float elapsedTime) => Scale(gameObject, animationCurve, elapsedTime)));

        }

        public static void Scale(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime)
        {

            gameObject.transform.localScale = animationCurve.Evaluate(elapsedTime);

        }

        public static Coroutine ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            AnimationData animationData = gameObject.AddOrGetComponent<AnimationData>();

            return StartCoroutine(gameObject, "ScaleRelative",
                Loop(gameObject, "ScaleRelative", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (float elapsedTime) => ScaleRelative(gameObject, animationCurve, elapsedTime, animationData)));

        }

        public static void ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = gameObject.AddOrGetComponent<AnimationData>();

            gameObject.transform.localScale = animationData.transformData.scale + animationCurve.Evaluate(elapsedTime);

        }

        public static void ScaleTo(GameObject gameObject, Vector3 newScale, float duration = 1.0f)
        {

            Vector3AnimationCurve animationCurve = new Vector3AnimationCurve();

            Vector3 currentScale = gameObject.transform.localScale;

            animationCurve.x = AnimationCurve.EaseInOut(0, currentScale.x, duration, newScale.x);
            animationCurve.y = AnimationCurve.EaseInOut(0, currentScale.y, duration, newScale.y);
            animationCurve.z = AnimationCurve.EaseInOut(0, currentScale.z, duration, newScale.z);

            Scale(gameObject, animationCurve);

        }

    }

}
