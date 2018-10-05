// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace CandyCoded
{

    public static class LoadAssetBundle
    {

        public static IEnumerator FromUrl(string assetBundleUrl, string name, LoadSceneMode loadSceneMode)
        {

            using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(assetBundleUrl))
            {

                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError || uwr.isHttpError)
                {

                    Debug.LogError(uwr.error);

                }
                else
                {

                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);

                    if (bundle.isStreamedSceneAssetBundle)
                    {

                        yield return LoadAndAddScenesFromBundle(bundle, name, loadSceneMode);

                    }
                    else
                    {

                        LoadAndInstantiateFromBundle(bundle, name);

                    }

                    bundle.Unload(false);

                }

            }

        }

        public static IEnumerator FromUrl(string assetBundleUrl, string name)
        {

            return FromUrl(assetBundleUrl, name, LoadSceneMode.Additive);

        }

        public static IEnumerator LoadAndAddScenesFromBundle(AssetBundle bundle, string name, LoadSceneMode loadSceneMode)
        {

            var scenes = bundle.GetAllScenePaths();

            for (int i = 0; i < scenes.Length; i += 1)
            {

                if (scenes[i].Equals(name))
                {

                    yield return SceneManager.LoadSceneAsync(scenes[i], loadSceneMode);

                    Scene sceneRef = SceneManager.GetSceneByPath(scenes[i]);

                    SceneManager.SetActiveScene(sceneRef);

                }

            }

        }

        public static void LoadAndInstantiateFromBundle(AssetBundle bundle, string name)
        {

            var gameObjects = bundle.LoadAllAssets<GameObject>();

            for (int i = 0; i < gameObjects.Length; i += 1)
            {

                if (gameObjects[i].name.Equals(name))
                {

                    Object.Instantiate(gameObjects[i]);

                }

            }

        }

    }

}
