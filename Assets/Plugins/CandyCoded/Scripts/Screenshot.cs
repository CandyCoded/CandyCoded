// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace CandyCoded
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

            var path = Save();

            Debug.Log($"Saved screenshot to {path}");

        }

        [MenuItem("Window/CandyCoded/Save Screenshot @ 2x")]
        private static void SaveHighResolutionImage()
        {

            EditorApplication.ExecuteMenuItem("Window/General/Game");

            var path = Save(2);

            Debug.Log($"Saved screenshot to {path}");

        }

        [MenuItem("Window/CandyCoded/Save Transparent Screenshot")]
        private static void SaveTransparentImage()
        {

            EditorApplication.ExecuteMenuItem("Window/General/Game");

            var path = SaveTransparent();

            Debug.Log($"Saved screenshot to {path}");

        }
#endif

        /// <summary>
        /// Save a screenshot to the applications persistent data path (device specific) with a random file name.
        /// </summary>
        /// <param name="ratio">Ratio to save the image at.</param>
        /// <returns>string</returns>
        public static string Save(int ratio)
        {

            var path = Path.Combine(Application.persistentDataPath, $"{GetTimestamp()}.png");

            ScreenCapture.CaptureScreenshot(path, ratio);

            return path;

        }

        /// <summary>
        /// Save a screenshot to the applications persistent data path (device specific) with a random file name.
        /// </summary>
        /// <returns>string</returns>
        public static string Save()
        {

            return Save(1);

        }

        /// <summary>
        /// Save a transparent screenshot to the applications persistent data path (device specific) with a random file name.
        /// </summary>
        /// <returns>string</returns>
        public static string SaveTransparent(Camera camera)
        {

            if (camera == null)
            {
                return null;
            }

            var path = Path.Combine(Application.persistentDataPath, $"{GetTimestamp()}.png");

            var renderTexture = new RenderTexture(Screen.width, Screen.height, 24);

            var texture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);

            var originalTargetTexture = camera.targetTexture;
            var originalRenderTexture = RenderTexture.active;

            camera.targetTexture = renderTexture;

            RenderTexture.active = renderTexture;

            camera.Render();

            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

            texture.Apply();

            File.WriteAllBytes(path, texture.EncodeToPNG());

            camera.targetTexture = originalTargetTexture;

            RenderTexture.active = originalRenderTexture;

            UnityEngine.Object.DestroyImmediate(renderTexture);

            UnityEngine.Object.DestroyImmediate(texture);

            return path;

        }

        /// <summary>
        /// Save a transparent screenshot to the applications persistent data path (device specific) with a random file name.
        /// </summary>
        /// <returns>string</returns>
        public static string SaveTransparent()
        {

            return SaveTransparent(Camera.main);

        }

    }

}
