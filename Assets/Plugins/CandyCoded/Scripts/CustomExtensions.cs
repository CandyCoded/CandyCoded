// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using UnityEngine;

#pragma warning disable S3903
// Disables "Types should be defined in named namespaces" warning as component should be available at all times.

public static class CustomExtensions
{

    /// <summary>
    /// Returns a reference to an existing component or a new component if it didn't already exist.
    /// </summary>
    /// <returns><typeparamref name="T"/></returns>
    public static T AddOrGetComponent<T>(this GameObject gameObject) where T : Component
    {

        var component = gameObject.GetComponent<T>();

        if (component == null)
        {

            component = gameObject.AddComponent<T>();

        }

        return component;

    }

    /// <summary>
    /// Tests LayerMask for the supplied Layer name.
    /// </summary>
    /// <param name="layerName">Layer name to compare against layerMask.</param>
    /// <returns>bool</returns>
    public static bool Contains(this LayerMask layerMask, string layerName)
    {

        return layerMask.Contains(LayerMask.NameToLayer(layerName));

    }

    /// <summary>
    /// Tests LayerMask for the supplied Layer int.
    /// </summary>
    /// <param name="layerInt">Layer number to compare against layerMask.</param>
    /// <returns>bool</returns>
    public static bool Contains(this LayerMask layerMask, int layerInt)
    {

        return ((int)layerMask).Contains(1 << layerInt);

    }

    /// <summary>
    /// Is value in mask?
    /// </summary>
    /// <param name="value">Value to compare against mask.</param>
    /// <returns>bool</returns>
    public static bool Contains(this int mask, int value)
    {

        return mask == (mask | value);

    }

    /// <summary>
    /// Edit the value of a keyframe in an AnimationCurve leaving the time and curve untouched.
    /// </summary>
    /// <param name="key">Key of keyframe to modify.</param>
    /// <param name="value">Value to update keyframe with.</param>
    /// <returns>void</returns>
    public static void EditKeyframeValue(this AnimationCurve animationCurve, int key, float value)
    {

        Keyframe[] keys = animationCurve.keys;

        keys[key].value = value;

        animationCurve.keys = keys;

    }

    /// <summary>
    /// Edit the values of the corresponding keyframes in a Vector3AnimationCurve leaving the time and curve of each keyframe untouched.
    /// </summary>
    /// <param name="key">Key of each keyframe to modify.</param>
    /// <param name="vector">Vector3 to update each corresponding keyframe with.</param>
    /// <returns>void</returns>
    public static void EditKeyframeValue(this CandyCoded.Vector3AnimationCurve animationCurve, int key, Vector3 vector)
    {

        animationCurve.x.EditKeyframeValue(key, vector.x);
        animationCurve.y.EditKeyframeValue(key, vector.y);
        animationCurve.z.EditKeyframeValue(key, vector.z);

    }

    /// <summary>
    /// Edit the values of the corresponding keyframes in a Vector2AnimationCurve leaving the time and curve of each keyframe untouched.
    /// </summary>
    /// <param name="key">Key of each keyframe to modify.</param>
    /// <param name="vector">Vector2 to update each corresponding keyframe with.</param>
    /// <returns>void</returns>
    public static void EditKeyframeValue(this CandyCoded.Vector2AnimationCurve animationCurve, int key, Vector2 vector)
    {

        animationCurve.x.EditKeyframeValue(key, vector.x);
        animationCurve.y.EditKeyframeValue(key, vector.y);

    }

    /// <summary>
    /// Get children transforms of parent transform by GameObject name.
    /// </summary>
    /// <param name="name">Name of GameObject</param>
    /// <returns>Transform[]</returns>
    public static Transform[] GetChildrenByName(this Transform parentTransform, string name)
    {

        var childTransforms = new List<Transform>();

        for (int i = 0; i < parentTransform.childCount; i += 1)
        {

            var childTransform = parentTransform.GetChild(i);

            if (childTransform.gameObject.name.Equals(name))
            {

                childTransforms.Add(childTransform);

            }

        }

        return childTransforms.ToArray();

    }

    /// <summary>
    /// Tests to see if AnimationCurve loops.
    /// </summary>
    /// <returns>bool</returns>
    public static bool IsLooping(this AnimationCurve animationCurve)
    {

        return animationCurve != null && (animationCurve.postWrapMode == WrapMode.Loop || animationCurve.postWrapMode == WrapMode.PingPong);

    }

    /// <summary>
    /// Rotates transform so the forward vector points at target's position.
    /// </summary>
    /// <param name="target">Object to point towards.</param>
    /// <param name="direction">Vector specifying the forward direction.</param>
    /// <returns>void</returns>
    public static void LookAt2D(this Transform transform, Transform target, Vector3 direction)
    {

        Vector2 angle = target.position - transform.position;

        float deg = Vector3.Angle(Vector3.forward, direction) * Mathf.Sign(Vector3.Cross(Vector3.forward, direction).x);

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + deg, Vector3.forward);

    }

    /// <summary>
    /// Creates a LayerMask from a GameObject's layer property.
    /// </summary>
    /// <returns>LayerMask</returns>
    public static LayerMask GetLayerMask(this GameObject gameObject)
    {

        return 1 << gameObject.layer;

    }

    /// <summary>
    /// Rotates transform so the forward vector points at target's position.
    /// </summary>
    /// <param name="target">Object to point towards.</param>
    /// <returns>void</returns>
    public static void LookAt2D(this Transform transform, Transform target)
    {

        Vector2 angle = target.position - transform.position;

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg, Vector3.forward);

    }

    /// <summary>
    /// Returns duration of the AnimationCurve.
    /// </summary>
    /// <returns>float</returns>
    public static float MaxTime(this AnimationCurve animationCurve)
    {

        return (animationCurve != null && animationCurve.keys.Length > 0) ? animationCurve.keys[animationCurve.keys.Length - 1].time : 0;

    }

    /// <summary>
    /// Returns a list of all possible combinations for a list of items.
    /// </summary>
    /// <returns>List<List/></returns>
    public static List<List<T>> Permutations<T>(this List<T> list)
    {

        var results = new List<List<T>>();

        var numberOfPossibleCombinations = (int)Mathf.Pow(2, list.Count);

        for (int i = 1; i < numberOfPossibleCombinations; i += 1)
        {

            var combination = new List<T>();

            for (int j = 0; j < list.Count; j += 1)
            {

                if ((i >> j & 1) == 1)
                {

                    combination.Add(list[j]);

                }

            }

            results.Add(combination);

        }

        return results;

    }

    /// <summary>
    /// Creates a new copy of a list and shuffles the values.
    /// </summary>
    /// <returns>List<typeparamref name="T"/></returns>
    public static List<T> Shuffle<T>(this List<T> list)
    {

        var shuffledList = new List<T>(list);

        int count = shuffledList.Count;

        for (int i = 0; i < count; i += 1)
        {

            var randomIndex = UnityEngine.Random.Range(i, count);

            T tempValue = shuffledList[i];

            shuffledList[i] = shuffledList[randomIndex];

            shuffledList[randomIndex] = tempValue;

        }

        return shuffledList;

    }

    /// <summary>
    /// Returns a shallow copy of a portion of a list.
    /// </summary>
    /// <param name="index">Index of list to start at.</param>
    /// <param name="count">Number of items to return.</param>
    /// <returns>List<typeparamref name="T"/></returns>
    public static List<T> Slice<T>(this List<T> list, int index, int count)
    {

        var partialList = list.GetRange(index, count);

        return partialList;

    }

    /// <summary>
    /// Returns a shallow copy of a portion of a list.
    /// </summary>
    /// <param name="count">Number of items to return.</param>
    /// <returns>List<typeparamref name="T"/></returns>
    public static List<T> Slice<T>(this List<T> list, int count)
    {

        return list.Slice(0, count);

    }

    /// <summary>
    /// Returns a shallow copy of a portion of a list.
    /// </summary>
    /// <returns>List<typeparamref name="T"/></returns>
    public static List<T> Slice<T>(this List<T> list)
    {

        return list.Slice(0, 1);

    }

    /// <summary>
    /// Removes and returns a shallow copy of a portion of a list.
    /// </summary>
    /// <param name="index">Index of list to start at.</param>
    /// <param name="count">Number of items to return and remove.</param>
    /// <returns>List<typeparamref name="T"/></returns>
    public static List<T> Splice<T>(this List<T> list, int index, int count)
    {

        var partialList = list.GetRange(index, count);

        list.RemoveRange(index, count);

        return partialList;

    }

    /// <summary>
    /// Removes and returns a shallow copy of a portion of a list.
    /// </summary>
    /// <param name="count">Number of items to return and remove.</param>
    /// <returns>List<typeparamref name="T"/></returns>
    public static List<T> Splice<T>(this List<T> list, int count)
    {

        return list.Splice(0, count);

    }

    /// <summary>
    /// Removes and returns a shallow copy of a portion of a list.
    /// </summary>
    /// <returns>List<typeparamref name="T"/></returns>
    public static List<T> Splice<T>(this List<T> list)
    {

        return list.Splice(0, 1);

    }

}

#pragma warning restore S3903
