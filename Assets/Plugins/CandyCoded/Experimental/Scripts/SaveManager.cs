using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CandyCoded.Experimental
{

    public static class SaveManager
    {

        public static bool SaveData<T>(T obj, string filePath)
        {

            var bf = new BinaryFormatter();

            var fs = new FileStream(filePath, FileMode.Create);

            bf.Serialize(fs, obj);

            fs.Close();

            return true;

        }

        public static T LoadData<T>(string filePath)
        {

            if (File.Exists(filePath))
            {

                var bf = new BinaryFormatter();

                var fs = new FileStream(filePath, FileMode.Open);

                var data = (T)bf.Deserialize(fs);

                fs.Close();

                return data;

            }

            throw new FileNotFoundException("File not found.");

        }

    }

}
