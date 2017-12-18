using UnityEngine;

public static class CustomExtensions {

    public static bool Contains(this LayerMask layerMask, string layerName) {

        return layerMask.Contains(LayerMask.NameToLayer(layerName));

    }

    public static bool Contains(this LayerMask layerMask, int layerInt) {

        return layerMask == (layerMask | (1 << layerInt));

    }

    public static void LookAt2D(this Transform transform, Transform target, Vector3 direction) {

        Vector2 angle = target.position - transform.position;

        float deg = Vector3.Angle(Vector3.forward, direction) * Mathf.Sign(Vector3.Cross(Vector3.forward, direction).x);

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + deg, Vector3.forward);

    }

    public static void LookAt2D(this Transform transform, Transform target) {

        Vector2 angle = target.position - transform.position;

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg, Vector3.forward);

    }

}
