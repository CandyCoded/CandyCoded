using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CandyCoded.Experimental
{

    public static class SaveManager
    {

        public static void SaveData<T>(T obj, string filePath, bool relative)
        {

            var path = filePath;

            if (relative)
            {

                path = string.Format("{0}{1}{2}", Application.persistentDataPath, Path.DirectorySeparatorChar, filePath);

            }

            using(var fs = File.Create(path))
            {

                try
                {

                    var bf = new BinaryFormatter();

                    bf.Serialize(fs, obj);

                }
                catch (SerializationException err)
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

        public static void SaveData<T>(T obj, string relativeFilePath)
        {

            SaveData(obj, relativeFilePath, true);

        }

        public static T LoadData<T>(string filePath, bool relative)
        {

            var path = filePath;

            if (relative)
            {

                path = string.Format("{0}{1}{2}", Application.persistentDataPath, Path.DirectorySeparatorChar, filePath);

            }

            using(var fs = File.OpenRead(path))
            {

                T data;

                try
                {

                    var bf = new BinaryFormatter();

                    data = (T)bf.Deserialize(fs);

                }
                catch (SerializationException err)
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

        public static T LoadData<T>(string relativeFilePath)
        {

            return LoadData<T>(relativeFilePath, true);

        }

    }

}
