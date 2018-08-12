#if UNITY_EDITOR

using System.IO;
using UnityEditor;

public class CreateAssetBundles
{

    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {

        string assetBundleDirectory = "Assets/AssetBundles";

        if (!Directory.Exists(assetBundleDirectory))
        {

            Directory.CreateDirectory(assetBundleDirectory);

        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);

    }
}

#endif
