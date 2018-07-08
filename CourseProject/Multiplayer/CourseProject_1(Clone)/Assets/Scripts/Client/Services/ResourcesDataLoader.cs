using System;
using System.IO;
using UnityEngine;

namespace Services
{
    public class ResourcesDataLoader : IDataLoader
    {
        public T Load<T>(string path)
        {
            try
            {
                var asset = Resources.Load(path);
                if (asset == null)
                    throw new FileNotFoundException();

                return (T) Convert.ChangeType(asset, typeof(T));
            }

            catch (InvalidCastException e)
            {
                Debug.LogException(e);
                throw;
            }

            catch (FileNotFoundException e)
            {
                e = new FileNotFoundException(
                    string.Format("Couldn't find asset by path: {0}/{1}",
                    Application.dataPath, path));
                Debug.LogErrorFormat(e.Message);
                throw;
            }
        }
    }
}