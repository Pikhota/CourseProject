using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Networking;
using View;

namespace Services
{
    public class NetworkSpawnServcie
    {
        private readonly NetworkPool _pool;

        public NetworkSpawnServcie(NetworkPool pool)
        {
            _pool = pool;
        }

        public GameObject Spawn(Vector3 position, NetworkHash128 assetId)
        {
            var obj = _pool.Rent().gameObject;
            obj.transform.position = position;

            return obj;
        }

        public void UnSpawn(GameObject spawned)
        {
            _pool.Return(spawned.transform);
        }

        public void Register()
        {
            ClientScene.RegisterSpawnHandler(_pool.Hash128, Spawn, UnSpawn);
        }
    }
}