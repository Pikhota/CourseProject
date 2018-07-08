using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

namespace Networking
{
    public class MultiplayerSwitcher : NetworkBehaviour
    {
        private List<ILocalPlayer> _localPlayer;

        private void Awake()
        {
            _localPlayer = GetComponentsInChildren<ILocalPlayer>(true).ToList();
        }

        private void Update()
        {
            if (isLocalPlayer)
            {
                _localPlayer.ForEach(item => item.Execute());
            }
        }
    }
}