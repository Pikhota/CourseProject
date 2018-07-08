using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Services
{
    public class JsonFileDataSaver : IDataSaver
    {
        public void Save(object obj, string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException();

                using (var stream = new StreamWriter(path))
                {
                    var json = JsonUtility.ToJson(obj, true);
                    stream.Write(json);
                }
            }

            catch (FileNotFoundException e)
            {
                e = new FileNotFoundException(
                    string.Format("Couldn't find file by path: {0}", path));
                Debug.LogErrorFormat(e.Message);
                throw;
            }
        }
    }
}