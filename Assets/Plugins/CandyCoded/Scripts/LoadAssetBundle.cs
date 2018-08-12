using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace CandyCoded
{

    public static class LoadAssetBundle
    {

        public static IEnumerator FromURL(string assetBundleUrl, string name)
        {

            using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(assetBundleUrl))
            {

                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError || uwr.isHttpError)
                {

                    Debug.Log(uwr.error);

                }
                else
                {

                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);

                    if (bundle.isStreamedSceneAssetBundle)
                    {

                        yield return LoadAndAddScenesFromBundle(bundle, name, LoadSceneMode.Additive);

                    }
                    else
                    {

                        LoadAndInstantiateFromBundle(bundle, name);

                    }

                    bundle.Unload(false);

                }

            }

        }

        public static IEnumerator LoadAndAddScenesFromBundle(AssetBundle bundle, string name, LoadSceneMode loadSceneMode)
        {

            var scenes = bundle.GetAllScenePaths();

            for (int i = 0; i < scenes.Length; i += 1)
            {

                if (scenes[i].Equals(name))
                {

                    yield return SceneManager.LoadSceneAsync(scenes[i], loadSceneMode);

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
