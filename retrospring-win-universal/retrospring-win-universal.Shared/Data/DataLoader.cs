using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace retrospring_win_universal.Data
{
    class DataLoader
    {
        public async static Task SerializeAndSave(Type typeToSave, object objToSave, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeToSave);

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            using (Stream stream = await folder.OpenStreamForWriteAsync(filename, CreationCollisionOption.ReplaceExisting))
            {
                serializer.Serialize(stream, objToSave);
            }
        }

        public async static Task<T> DeserializeAndLoad<T>(string filename)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            try
            {
                using (Stream stream = await folder.OpenStreamForReadAsync(filename))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    return (T)serializer.Deserialize(stream);
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
