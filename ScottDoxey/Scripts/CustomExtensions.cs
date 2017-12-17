using UnityEngine;

public static class CustomExtensions {

    public static bool Contains(this LayerMask layerMask, string layerName) {

        return layerMask.Contains(LayerMask.NameToLayer(layerName));

    }

    public static bool Contains(this LayerMask layerMask, int layerInt) {

        return layerMask == (layerMask | (1 << layerInt));

    }

}
