using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class PlayerView : EventView, ILocalStart
    {
        public event Action LocalPlayerSpawn;

        public void LocalStart()
        {
            Debug.Log("LocalStart");
            OnLocalPlayerSpawn();
        }

        protected virtual void OnLocalPlayerSpawn()
        {
            var handler = LocalPlayerSpawn;
            if (handler != null) handler();
        }
    }
}