// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR

using System.IO;
using UnityEditor;

public static class CreateAssetBundles
{

    private readonly static string assetBundleDirectory = "Assets/AssetBundles";

    [MenuItem("Assets/CandyCoded/Tools/Build AssetBundles")]
    private static void BuildAllAssetBundles()
    {

        if (!Directory.Exists(assetBundleDirectory))
        {

            Directory.CreateDirectory(assetBundleDirectory);

        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

    }

}

#endif
