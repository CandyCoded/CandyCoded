// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections;
using UnityEngine;

namespace CandyCoded
{

    public static class Animate
    {

        private delegate void AnimationFunc(float elapsedTime);

        private static IEnumerator Loop(GameObject gameObject, string coroutineKey, bool isLooping, float maxTime, AnimationFunc animationFunc)
        {

            var runner = gameObject.AddOrGetComponent<Runner>();

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

            var runner = gameObject.AddOrGetComponent<Runner>();

            runner.RemoveCoroutine(coroutineKey);

            return runner.AddCoroutine(coroutineKey, routine);

        }

        /// <summary>
        /// Stop animation attached to a GameObject by name.
        /// </summary>
        /// <param name="gameObject">GameObject to stop animation on.</param>
        /// <param name="animationName">Name of animation to stop. Equivalent to the static method called to start animation.</param>
        /// <returns>void</returns>

        public static void Stop(GameObject gameObject, string animationName)
        {

            var runner = gameObject.AddOrGetComponent<Runner>();

            runner.RemoveCoroutine(animationName);

        }

        /// <summary>
        /// Stops all animations attached to a GameObject.
        /// </summary>
        /// <param name="gameObject">GameObject to stop all animations on.</param>
        /// <returns>void</returns>

        public static void StopAll(GameObject gameObject)
        {

            var runner = gameObject.AddOrGetComponent<Runner>();

            runner.RemoveAllCoroutines();

        }

        /// <summary>
        /// Fades all of the materials in a GameObject with an AnimationCurve.
        /// </summary>
        /// <param name="gameObject">GameObject to fade.</param>
        /// <param name="animationCurve">AnimationCurve to evaluate.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine Fade(GameObject gameObject, AnimationCurve animationCurve)
        {

            var animationData = gameObject.AddOrGetComponent<AnimationData>();

            return StartCoroutine(gameObject, "Fade",
                Loop(gameObject, "Fade", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (elapsedTime) => Fade(animationCurve, elapsedTime, animationData)));

        }

        /// <summary>
        /// Changes the alpha of all materials in a GameObject to the evaluated float calulcated from a AnimationCurve object.
        /// </summary>
        /// <param name="animationCurve">AnimationCurve to evaluate.</param>
        /// <param name="elapsedTime">The time elapsed since the animation started.</param>
        /// <param name="animationData">AnimationData object containing cached references to all materials in the GameObject.</param>
        /// <returns>void</returns>

        public static void Fade(AnimationCurve animationCurve, float elapsedTime, AnimationData animationData)
        {

            var globalAlpha = animationCurve.Evaluate(elapsedTime);

            foreach (MaterialData materialData in animationData.Materials)
            {

                materialData.Material.color = Materials.SetColorAlpha(materialData.Material.color, materialData.StartColor.a * globalAlpha);

            }

        }

        /// <summary>
        /// Fades a GameObject from a specified alpha to another.
        /// </summary>
        /// <param name="gameObject">GameObject to fade.</param>
        /// <param name="from">Starting alpha.</param>
        /// <param name="to">Ending alpha.</param>
        /// <param name="duration">Length of the animation in seconds.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine Fade(GameObject gameObject, float from, float to, float duration)
        {

            var animationCurve = AnimationCurve.EaseInOut(0, from, duration, to);

            return Fade(gameObject, animationCurve);

        }

        /// <summary>
        /// Fades a GameObject from a specified alpha to another.
        /// </summary>
        /// <param name="gameObject">GameObject to fade.</param>
        /// <param name="from">Starting alpha.</param>
        /// <param name="to">Ending alpha.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine Fade(GameObject gameObject, float from, float to)
        {

            return Fade(gameObject, from, to, 1);

        }

        /// <summary>
        /// Animates the position of a GameObject with a Vector3AnimationCurve.
        /// </summary>
        /// <param name="gameObject">GameObject to move.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine Position(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "Position",
                Loop(gameObject, "Position", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (elapsedTime) => Position(gameObject, animationCurve, elapsedTime)));

        }

        /// <summary>
        /// Changes the position of a GameObject to the evaluated Vector3 calulcated from a Vector3AnimationCurve object.
        /// </summary>
        /// <param name="gameObject">GameObject to move.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <param name="elapsedTime">The time elapsed since the animation started.</param>
        /// <returns>void</returns>

        public static void Position(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime)
        {

            gameObject.transform.localPosition = animationCurve.Evaluate(elapsedTime);

        }

        /// <summary>
        /// Animates the position of a GameObject to the specified Vector3 over time.
        /// </summary>
        /// <param name="gameObject">GameObject to move.</param>
        /// <param name="newPosition">New Vector3 position.</param>
        /// <param name="duration">Length of the animation in seconds.</param>
        /// <param name="relativeTo">Coordinate system to animate with.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine MoveTo(GameObject gameObject, Vector3 newPosition, float duration, Space relativeTo)
        {

            var animationCurve = new Vector3AnimationCurve();

            var currentPosition = gameObject.transform.localPosition;

            if (relativeTo == Space.World)
            {

                currentPosition = gameObject.transform.position;

            }

            animationCurve.x = AnimationCurve.EaseInOut(0, currentPosition.x, duration, newPosition.x);
            animationCurve.y = AnimationCurve.EaseInOut(0, currentPosition.y, duration, newPosition.y);
            animationCurve.z = AnimationCurve.EaseInOut(0, currentPosition.z, duration, newPosition.z);

            if (relativeTo == Space.World)
            {

                return Position(gameObject, animationCurve);

            }

            return PositionRelative(gameObject, animationCurve);

        }

        /// <summary>
        /// Animates the position of a GameObject to the specified Vector3 over time.
        /// </summary>
        /// <param name="gameObject">GameObject to move.</param>
        /// <param name="newPosition">New Vector3 position.</param>
        /// <param name="duration">Length of the animation in seconds.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine MoveTo(GameObject gameObject, Vector3 newPosition, float duration)
        {

            return MoveTo(gameObject, newPosition, duration, Space.Self);

        }

        /// <summary>
        /// Animates the position of a GameObject to the specified Vector3 over time.
        /// </summary>
        /// <param name="gameObject">GameObject to move.</param>
        /// <param name="newPosition">New Vector3 position.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine MoveTo(GameObject gameObject, Vector3 newPosition)
        {

            return MoveTo(gameObject, newPosition, 1);

        }

        /// <summary>
        /// Animates the position of a GameObject, relative to it's original position, with a Vector3AnimationCurve.
        /// </summary>
        /// <param name="gameObject">GameObject to move.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            var animationData = gameObject.AddOrGetComponent<AnimationData>();

            return StartCoroutine(gameObject, "PositionRelative",
                Loop(gameObject, "PositionRelative", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (elapsedTime) => PositionRelative(gameObject, animationCurve, elapsedTime, animationData)));

        }

        /// <summary>
        /// Changes the position of a GameObject, relative to it's original position, to the evaluated Vector3 calulcated from a Vector3AnimationCurve object.
        /// </summary>
        /// <param name="gameObject">GameObject to move.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <param name="elapsedTime">The time elapsed since the animation started.</param>
        /// <param name="animationData">AnimationData object containing cached transform data.</param>
        /// <returns>void</returns>

        public static void PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData)
        {

            gameObject.transform.localPosition = animationData.TransformData.Position + animationCurve.Evaluate(elapsedTime);

        }

        /// <summary>
        /// Changes the position of a GameObject, relative to it's original position, to the evaluated Vector3 calulcated from a Vector3AnimationCurve object.
        /// </summary>
        /// <param name="gameObject">GameObject to move.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <param name="elapsedTime">The time elapsed since the animation started.</param>
        /// <returns>void</returns>

        public static void PositionRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime)
        {

            var animationData = gameObject.AddOrGetComponent<AnimationData>();

            gameObject.transform.localPosition = animationData.TransformData.Position + animationCurve.Evaluate(elapsedTime);

        }

        /// <summary>
        /// Animates the rotation of a GameObject with a Vector3AnimationCurve.
        /// </summary>
        /// <param name="gameObject">GameObject to rotate.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine Rotation(GameObject gameObject, Vector4AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "Rotation",
                Loop(gameObject, "Rotation", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (elapsedTime) => Rotation(gameObject, animationCurve, elapsedTime)));

        }

        /// <summary>
        /// Changes the rotation of a GameObject to the evaluated Vector3 calulcated from a Vector3AnimationCurve object.
        /// </summary>
        /// <param name="gameObject">GameObject to rotate.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <param name="elapsedTime">The time elapsed since the animation started.</param>
        /// <returns>void</returns>

        public static void Rotation(GameObject gameObject, Vector4AnimationCurve animationCurve, float elapsedTime)
        {

            var rotation = animationCurve.Evaluate(elapsedTime);

            gameObject.transform.localRotation = new Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);

        }

        /// <summary>
        /// Animates the rotation of a GameObject to the specified Vector3 over time.
        /// </summary>
        /// <param name="gameObject">GameObject to rotate.</param>
        /// <param name="newRotation">New Vector3 rotation.</param>
        /// <param name="duration">Length of the animation in seconds.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine RotateTo(GameObject gameObject, Vector3 newRotation, float duration)
        {

            return RotateTo(gameObject, Quaternion.Euler(newRotation), duration);

        }

        /// <summary>
        /// Animates the rotation of a GameObject to the specified Vector3 over time.
        /// </summary>
        /// <param name="gameObject">GameObject to rotate.</param>
        /// <param name="newRotation">New Vector3 rotation.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine RotateTo(GameObject gameObject, Vector3 newRotation)
        {

            return RotateTo(gameObject, Quaternion.Euler(newRotation), 1);

        }

        /// <summary>
        /// Animates the rotation of a GameObject to the specified Quaternion over time.
        /// </summary>
        /// <param name="gameObject">GameObject to rotate.</param>
        /// <param name="newRotation">New Quaternion rotation.</param>
        /// <param name="duration">Length of the animation in seconds.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine RotateTo(GameObject gameObject, Quaternion newRotation, float duration)
        {

            var animationCurve = new Vector4AnimationCurve();

            Quaternion currentRotation = gameObject.transform.localRotation;

            var newRotationCopy = Quaternion.SlerpUnclamped(currentRotation, newRotation, 1);

            animationCurve.x = AnimationCurve.EaseInOut(0, currentRotation.x, duration, newRotationCopy.x);
            animationCurve.y = AnimationCurve.EaseInOut(0, currentRotation.y, duration, newRotationCopy.y);
            animationCurve.z = AnimationCurve.EaseInOut(0, currentRotation.z, duration, newRotationCopy.z);
            animationCurve.w = AnimationCurve.EaseInOut(0, currentRotation.w, duration, newRotationCopy.w);

            return Rotation(gameObject, animationCurve);

        }

        /// <summary>
        /// Animates the rotation of a GameObject to the specified Quaternion over time.
        /// </summary>
        /// <param name="gameObject">GameObject to rotate.</param>
        /// <param name="newRotation">New Quaternion rotation.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine RotateTo(GameObject gameObject, Quaternion newRotation)
        {

            return RotateTo(gameObject, newRotation, 1);

        }

        /// <summary>
        /// Animates the scale of a GameObject with a Vector3AnimationCurve.
        /// </summary>
        /// <param name="gameObject">GameObject to scale.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine Scale(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            return StartCoroutine(gameObject, "Scale",
                Loop(gameObject, "Scale", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (elapsedTime) => Scale(gameObject, animationCurve, elapsedTime)));

        }

        /// <summary>
        /// Changes the scale of a GameObject to the evaluated Vector3 calulcated from a Vector3AnimationCurve object.
        /// </summary>
        /// <param name="gameObject">GameObject to scale.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <param name="elapsedTime">The time elapsed since the animation started.</param>
        /// <returns>void</returns>

        public static void Scale(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime)
        {

            gameObject.transform.localScale = animationCurve.Evaluate(elapsedTime);

        }

        /// <summary>
        /// Animates the scale of a GameObject to the specified Vector3 over time.
        /// </summary>
        /// <param name="gameObject">GameObject to scale.</param>
        /// <param name="newScale">New Vector3 scale.</param>
        /// <param name="duration">Length of the animation in seconds.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine ScaleTo(GameObject gameObject, Vector3 newScale, float duration)
        {

            var animationCurve = new Vector3AnimationCurve();

            Vector3 currentScale = gameObject.transform.localScale;

            animationCurve.x = AnimationCurve.EaseInOut(0, currentScale.x, duration, newScale.x);
            animationCurve.y = AnimationCurve.EaseInOut(0, currentScale.y, duration, newScale.y);
            animationCurve.z = AnimationCurve.EaseInOut(0, currentScale.z, duration, newScale.z);

            return Scale(gameObject, animationCurve);

        }

        /// <summary>
        /// Animates the scale of a GameObject to the specified Vector3 over time.
        /// </summary>
        /// <param name="gameObject">GameObject to scale.</param>
        /// <param name="newScale">New Vector3 scale.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine ScaleTo(GameObject gameObject, Vector3 newScale)
        {

            return ScaleTo(gameObject, newScale, 1);

        }

        /// <summary>
        /// Animates the scale of a GameObject, relative to it's original scale, with a Vector3AnimationCurve.
        /// </summary>
        /// <param name="gameObject">GameObject to scale.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <returns>Coroutine</returns>

        public static Coroutine ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve)
        {

            var animationData = gameObject.AddOrGetComponent<AnimationData>();

            return StartCoroutine(gameObject, "ScaleRelative",
                Loop(gameObject, "ScaleRelative", animationCurve.IsLooping(), animationCurve.MaxTime(),
                    (elapsedTime) => ScaleRelative(gameObject, animationCurve, elapsedTime, animationData)));

        }

        /// <summary>
        /// Changes the scale of a GameObject, relative to it's original scale, to the evaluated Vector3 calulcated from a Vector3AnimationCurve object.
        /// </summary>
        /// <param name="gameObject">GameObject to scale.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <param name="elapsedTime">The time elapsed since the animation started.</param>
        /// <param name="animationData">AnimationData object containing cached transform data.</param>
        /// <returns>void</returns>

        public static void ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime, AnimationData animationData)
        {

            gameObject.transform.localScale = animationData.TransformData.Scale + animationCurve.Evaluate(elapsedTime);

        }

        /// <summary>
        /// Changes the scale of a GameObject, relative to it's original scale, to the evaluated Vector3 calulcated from a Vector3AnimationCurve object.
        /// </summary>
        /// <param name="gameObject">GameObject to scale.</param>
        /// <param name="animationCurve">Vector3AnimationCurve to evaluate.</param>
        /// <param name="elapsedTime">The time elapsed since the animation started.</param>
        /// <returns>void</returns>

        public static void ScaleRelative(GameObject gameObject, Vector3AnimationCurve animationCurve, float elapsedTime)
        {

            var animationData = gameObject.AddOrGetComponent<AnimationData>();

            gameObject.transform.localScale = animationData.TransformData.Scale + animationCurve.Evaluate(elapsedTime);

        }

    }

}
