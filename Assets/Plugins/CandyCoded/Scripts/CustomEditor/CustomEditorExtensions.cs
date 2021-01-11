// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CandyCoded
{

    /// <summary>
    /// CustomEditorExtensions
    /// </summary>
    public static class CustomEditorExtensions
    {

        /// <summary>
        ///     Find or create GameObject found in the asset menu.
        /// </summary>
        /// <param name="name">GameObject name.</param>
        /// <param name="menuPath">Path of the GameObject in the create asset menu.</param>
        /// <returns>GameObject</returns>
        public static GameObject FindOrCreateGameObjectFromAssetMenu(string name, string menuPath)
        {

            var gameObject = GameObject.Find(name);

            if (gameObject)
            {
                return gameObject;
            }

            EditorApplication.ExecuteMenuItem(menuPath);

            gameObject = GameObject.Find(name);

            return gameObject;

        }

        /// <summary>
        ///     Find or create prefab found in the asset menu.
        /// </summary>
        /// <param name="name">GameObject name.</param>
        /// <param name="menuPath">Path of the GameObject in the create asset menu.</param>
        /// <param name="prefabPath">File path of prefab.</param>
        /// <returns>GameObject</returns>
        public static GameObject FindOrCreatePrefabFromAssetMenu(string name, string menuPath, string prefabPath)
        {

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            if (prefab)
            {
                return prefab;
            }

            EditorApplication.ExecuteMenuItem(menuPath);

            var gameObject = GameObject.Find(name);

            PrefabUtility.SaveAsPrefabAsset(gameObject, prefabPath);

            Object.DestroyImmediate(gameObject);

            prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            return prefab;

        }

        /// <summary>
        ///     Find or create scriptable object by type.
        /// </summary>
        /// <param name="assetPath">File path of the scriptable object.</param>
        /// <returns>
        ///     <typeparamref name="T" />
        /// </returns>
        public static T FindOrCreateScriptableObjectAtPath<T>(string assetPath) where T : ScriptableObject
        {

            var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);

            if (asset)
            {
                return asset;
            }

            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<T>(), assetPath);

            asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);

            return asset;

        }

    }

}

#endif
