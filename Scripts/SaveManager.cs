// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CandyCoded
{

    /// <summary>
    /// SaveManager
    /// </summary>
    public static class SaveManager
    {

        /// <summary>
        ///     Save serializable object to a local file.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fileName">File name to save the serialized file to.</param>
        /// <param name="directory">Directory to store file in.</param>
        /// <returns>void</returns>
        public static void SaveData<T>(T obj, string fileName, string directory)
        {

            var path = Path.Combine(directory, fileName);

            var binaryFormatter = new BinaryFormatter();

            using (var fs = File.Create(path))
            {

                try
                {

                    binaryFormatter.Serialize(fs, obj);

                }
                catch (Exception err)
                {

                    Debug.LogError(err.Message);

                    throw;

                }
                finally
                {

                    fs.Close();

                }

            }

        }

        /// <summary>
        ///     Save serializable object to a local file.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="fileName">File name to save the serialized file to.</param>
        /// <returns>void</returns>
        public static void SaveData<T>(T obj, string fileName)
        {

            SaveData(obj, fileName, Application.persistentDataPath);

        }

        /// <summary>
        ///     Load serializable object from a local file.
        /// </summary>
        /// <param name="fileName">File to load.</param>
        /// <param name="directory">Directory file is in.</param>
        /// <returns>void</returns>
        public static T LoadData<T>(string fileName, string directory)
        {

            var path = Path.Combine(directory, fileName);

            var binaryFormatter = new BinaryFormatter();

            using (var fs = File.OpenRead(path))
            {

                T data;

                try
                {

                    data = (T)binaryFormatter.Deserialize(fs);

                }
                catch (Exception err)
                {

                    Debug.LogError(err.Message);

                    throw;

                }
                finally
                {

                    fs.Close();

                }

                return data;

            }

        }

        /// <summary>
        ///     Load serializable object from a local file.
        /// </summary>
        /// <param name="fileName">File to load.</param>
        /// <returns>void</returns>
        public static T LoadData<T>(string fileName)
        {

            return LoadData<T>(fileName, Application.persistentDataPath);

        }

        /// <summary>
        ///     Delete a local file.
        /// </summary>
        /// <param name="fileName">File to delete.</param>
        /// <param name="directory">Directory file is in.</param>
        /// <returns>void</returns>
        public static void DeleteData(string fileName, string directory)
        {

            var path = Path.Combine(directory, fileName);

            File.Delete(path);

        }

        /// <summary>
        ///     Delete a local file.
        /// </summary>
        /// <param name="fileName">File to delete.</param>
        /// <returns>void</returns>
        public static void DeleteData(string fileName)
        {

            DeleteData(fileName, Application.persistentDataPath);

        }

    }

}
