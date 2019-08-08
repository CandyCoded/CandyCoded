// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.IO;
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
        private static void SaveNormalResolutionImage()
        {

            EditorApplication.ExecuteMenuItem("Window/General/Game");

            Debug.Log($"Saved screenshot to {Save(1)}");

        }

        [MenuItem("Window/CandyCoded/Save Screenshot @ 2x")]
        private static void SaveHighResolutionImage()
        {

            EditorApplication.ExecuteMenuItem("Window/General/Game");

            Debug.Log($"Saved screenshot to {Save(2)}");

        }
#endif

        /// <summary>
        /// Save a screenshot to the applications persistent data path (device specific) with a random file name.
        /// </summary>
        /// <param name="ratio">Ratio to save the image at. Default is 1.</param>
        /// <returns>string</returns>
        public static string Save(int ratio)
        {

            var filename = Path.Combine(Application.persistentDataPath, $"{GetTimestamp()}.png");

            ScreenCapture.CaptureScreenshot(filename, ratio);

            return filename;

        }

    }

}
