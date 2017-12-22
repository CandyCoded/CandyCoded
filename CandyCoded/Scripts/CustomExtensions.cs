using UnityEngine;

public static class CustomExtensions {

    /// <summary>
    /// Is laeyrName in layerMask? layerName: Layer name to compare against layerMask.
    /// </summary>
    public static bool Contains(this LayerMask layerMask, string layerName) {

        return layerMask.Contains(LayerMask.NameToLayer(layerName));

    }

    /// <summary>
    /// Is layerInt in layerMask? layerInt: Layer number to compare against layerMask.
    /// </summary>
    public static bool Contains(this LayerMask layerMask, int layerInt) {

        return layerMask == (layerMask | (1 << layerInt));

    }

    /// <summary>
    /// Rotates the transform so the forward vector points at target's position. target: Obkect to point towards. direction: Vector specifying the fotward direction.
    /// </summary>
    public static void LookAt2D(this Transform transform, Transform target, Vector3 direction) {

        Vector2 angle = target.position - transform.position;

        float deg = Vector3.Angle(Vector3.forward, direction) * Mathf.Sign(Vector3.Cross(Vector3.forward, direction).x);

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + deg, Vector3.forward);

    }

    /// <summary>
    /// Rotates the transform so the forward vector points at target's position. target: Obkect to point towards.
    /// </summary>
    public static void LookAt2D(this Transform transform, Transform target) {

        Vector2 angle = target.position - transform.position;

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg, Vector3.forward);

    }

}
