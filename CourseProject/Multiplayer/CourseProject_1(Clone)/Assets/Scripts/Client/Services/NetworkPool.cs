using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Services
{
    public class NetworkPool : ComponentPool
    {
        public NetworkHash128 Hash128 { get; private set; }

        public NetworkPool(Component prefab, Transform parent) 
            : base(prefab, parent)
        {
            ReadHash(prefab);
        }

        private void ReadHash(Component prefab)
        {
            try
            {
                var identity = prefab.GetComponent<NetworkIdentity>();
                if (identity == null)
                    throw new NullReferenceException();

                Hash128 = identity.assetId;
            }

            catch (NullReferenceException e)
            {
                e = new NullReferenceException(string.Format(
                    @"Couldn't find ""NetworkIdentity"" component on {0}", prefab.name));
                Debug.LogErrorFormat(e.Message);
                throw;
            }
        }
    }
}