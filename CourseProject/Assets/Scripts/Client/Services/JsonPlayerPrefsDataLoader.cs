using System;
using System.IO;
using UnityEngine;

namespace Services
{
    public class JsonPlayerPrefsDataLoader : IDataLoader
    {
        public T Load<T>(string key)
        {
            try
            {
                if (!PlayerPrefs.HasKey(key))
                    throw new FileNotFoundException();

                var json = PlayerPrefs.GetString(key);
                Debug.Log("Loaded: " + typeof(T));
                return JsonUtility.FromJson<T>(json);
            }

            catch (FileNotFoundException e)
            {
                e = new FileNotFoundException(
                    string.Format("Couldn't find JsonFile marked by key: '{0}'", key));
                Debug.LogErrorFormat(e.Message);
                return default(T);
            }
        }
    }
}