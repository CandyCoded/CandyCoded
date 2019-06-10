// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded.Experimental
{

    public static class Screenshot
    {

        private static readonly DateTime epoch = new DateTime(1970, 1, 1);

        private static int GetTimestamp()
        {

            return (int)(DateTime.UtcNow - epoch).TotalSeconds;

        }

#if UNITY_EDITOR
        [MenuItem("Window/CandyCoded/Save Screenshot")]
#endif
        public static void SaveNormalResolutionImage()
        {

            Save(1);

        }

#if UNITY_EDITOR
        [MenuItem("Window/CandyCoded/Save Screenshot @ 2x")]
#endif
        public static void SaveHighResolutionImage()
        {

            Save(2);

        }

        public static void Save(int ratio)
        {

            var filename = $"{Application.persistentDataPath}/{GetTimestamp()}.png";

            ScreenCapture.CaptureScreenshot(filename, ratio);

            Debug.Log($"Saved screenshot to {filename}");

        }

    }

}
