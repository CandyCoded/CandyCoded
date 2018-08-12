using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace CandyCoded
{

    public static class LoadAssetBundle
    {

        public static IEnumerator FromURL(string url, string name)
        {

            using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(url))
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

                        LoadAndAddScenesFromBundle(bundle, name, LoadSceneMode.Additive);

                    }
                    else
                    {

                        LoadAndInstantiateFromBundle(bundle, name);

                    }

                    bundle.Unload(false);

                }

            }

        }

        public static void LoadAndAddScenesFromBundle(AssetBundle bundle, string name, LoadSceneMode loadSceneMode)
        {

            var scenes = bundle.GetAllScenePaths();

            for (int i = 0; i < scenes.Length; i += 1)
            {

                if (scenes[i].Equals(name))
                {

                    SceneManager.LoadScene(scenes[i], loadSceneMode);

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
