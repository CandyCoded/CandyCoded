using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CandyCoded.Experimental
{

    public static class SaveManager
    {

        public static void SaveData<T>(T obj, string filePath)
        {

            using (var fs = File.Create(filePath))
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

        public static T LoadData<T>(string filePath)
        {

            using (var fs = File.OpenRead(filePath))
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

    }

}
