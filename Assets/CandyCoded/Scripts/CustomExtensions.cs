using System.Collections.Generic;
using UnityEngine;

public static class CustomExtensions
{

    /// <summary>
    /// Is layerName in layerMask? layerName: Layer name to compare against layerMask.
    /// </summary>
    public static bool Contains(this LayerMask layerMask, string layerName)
    {

        return layerMask.Contains(LayerMask.NameToLayer(layerName));

    }

    /// <summary>
    /// Is layerInt in layerMask? layerInt: Layer number to compare against layerMask.
    /// </summary>
    public static bool Contains(this LayerMask layerMask, int layerInt)
    {

        return ((int) layerMask).Contains(1 << layerInt);

    }

    /// <summary>
    /// Is value in mask? value: Value to compare against mask.
    /// </summary>
    public static bool Contains(this int mask, int value)
    {

        return mask == (mask | value);

    }

    /// <summary>
    /// Rotates the transform so the forward vector points at target's position. target: Object to point towards. direction: Vector specifying the fotward direction.
    /// </summary>
    public static void LookAt2D(this Transform transform, Transform target, Vector3 direction)
    {

        Vector2 angle = target.position - transform.position;

        float deg = Vector3.Angle(Vector3.forward, direction) * Mathf.Sign(Vector3.Cross(Vector3.forward, direction).x);

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + deg, Vector3.forward);

    }

    /// <summary>
    /// Rotates the transform so the forward vector points at target's position. target: Object to point towards.
    /// </summary>
    public static void LookAt2D(this Transform transform, Transform target)
    {

        Vector2 angle = target.position - transform.position;

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg, Vector3.forward);

    }

    /// <summary>
    /// Replaces an existing keyframe in an animation curve. index: Index of the keyframe. key: New keyframe object.
    /// </summary>
    public static void ReplaceKey(this AnimationCurve animationCurve, int index, Keyframe key)
    {

        Keyframe[] keys = animationCurve.keys;

        keys[index] = key;

        animationCurve.keys = keys;

    }

    /// <summary>
    /// Creates a new copy of a list and shuffles the values.
    /// </summary>
    public static List<T> Shuffle<T>(this List<T> list)
    {

        List<T> shuffledList = new List<T>(list);

        int count = shuffledList.Count;

        for (int i = 0; i < count; i += 1)
        {

            int randomIndex = UnityEngine.Random.Range(i, count);

            var tempValue = shuffledList[i];

            shuffledList[i] = shuffledList[randomIndex];

            shuffledList[randomIndex] = tempValue;

        }

        return shuffledList;

    }

}
