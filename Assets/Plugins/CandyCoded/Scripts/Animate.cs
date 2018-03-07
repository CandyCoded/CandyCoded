using System.Collections;
using UnityEngine;

namespace CandyCoded
{

    public static class Animate
    {

        public delegate void Vector3AnimationFunc(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null);
        public delegate void AnimationFunc(GameObject gameObject, AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null);

        public static IEnumerator Loop(GameObject gameObject, Vector3AnimationCurve animationCurve, Vector3AnimationFunc animationFunc)
        {

            AnimationData animationData = gameObject.AddOrGetComponent<AnimationData>();

            Runner runner = gameObject.AddOrGetComponent<Runner>();

            string coroutineKey = animationFunc.Method.Name;

            float elapsedTime = 0;
            float maxTime = animationCurve.MaxTime();

            while (animationCurve.IsLooping() || elapsedTime <= maxTime)
            {

                animationFunc(gameObject, animationCurve, elapsedTime, animationData);

                elapsedTime = Mathf.Min(elapsedTime + Time.deltaTime, maxTime);

                yield return null;

            }

            runner.RemoveCoroutine(coroutineKey);

        }

        public static IEnumerator Loop(GameObject gameObject, AnimationCurve animationCurve, AnimationFunc animationFunc)
        {

            AnimationData animationData = gameObject.AddOrGetComponent<AnimationData>();

            Runner runner = gameObject.AddOrGetComponent<Runner>();

            string coroutineKey = animationFunc.Method.Name;

            float elapsedTime = 0;
            float maxTime = animationCurve.MaxTime();

            while (animationCurve.IsLooping() || elapsedTime <= maxTime)
            {

                animationFunc(gameObject, animationCurve, elapsedTime, animationData);

                elapsedTime = Mathf.Min(elapsedTime + Time.deltaTime, maxTime);

                yield return null;

            }

            runner.RemoveCoroutine(coroutineKey);

        }

        public static Coroutine StartCoroutine(GameObject gameObject, string coroutineKey, IEnumerator routine)
        {

            Runner runner = gameObject.AddOrGetComponent<Runner>();

            runner.RemoveCoroutine(coroutineKey);

            return runner.AddCoroutine(coroutineKey, routine);

        }

        public static Coroutine Fade(GameObject gameObject, AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "Fade", Loop(gameObject, animationCurve, CandyCoded.Animate.Fade));

        }

        public static void Fade(GameObject gameObject, AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null)
        {

            float globalAlpha = animationCurve.Evaluate(elapsedTime);

            foreach (CandyCoded.MaterialData materialData in animationData.materials)
            {

                materialData.material.color = CandyCoded.Materials.SetColorAlpha(materialData.material.color, materialData.startColor.a * globalAlpha);

            }

        }

        public static void Fade(GameObject gameObject, float from, float to, float duration)
        {

            AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, from, duration, to);

            Fade(gameObject, animationCurve);

        }

        public static Coroutine Position(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "Position", Loop(gameObject, animationCurve, CandyCoded.Animate.Position));

        }

        public static void Position(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null)
        {

            gameObject.transform.localPosition = animationCurve.Evaluate(elapsedTime);

        }

        public static Coroutine PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "PositionRelative", Loop(gameObject, animationCurve, CandyCoded.Animate.PositionRelative));

        }

        public static void PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = gameObject.AddOrGetComponent<AnimationData>();

            gameObject.transform.localPosition = animationData.transformData.position + animationCurve.Evaluate(elapsedTime);

        }

        public static void MoveTo(GameObject gameObject, Vector3 newPosition, float duration)
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

            return StartCoroutine(gameObject, "Rotation", Loop(gameObject, animationCurve, CandyCoded.Animate.Rotation));

        }

        public static void Rotation(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null)
        {

            gameObject.transform.localRotation = Quaternion.Euler(animationCurve.Evaluate(elapsedTime));

        }

        public static void RotateTo(GameObject gameObject, Vector3 newRotation, float duration)
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

            return StartCoroutine(gameObject, "Scale", Loop(gameObject, animationCurve, CandyCoded.Animate.Scale));

        }

        public static void Scale(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null)
        {

            gameObject.transform.localScale = animationCurve.Evaluate(elapsedTime);

        }

        public static Coroutine ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "ScaleRelative", Loop(gameObject, animationCurve, CandyCoded.Animate.ScaleRelative));

        }

        public static void ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData = null)
        {

            if (animationData == null) animationData = gameObject.AddOrGetComponent<AnimationData>();

            gameObject.transform.localScale = animationData.transformData.scale + animationCurve.Evaluate(elapsedTime);

        }

        public static void ScaleTo(GameObject gameObject, Vector3 newScale, float duration)
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
