using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

namespace Networking
{
    public class LocalPlayerEventFunctionsHandler : NetworkBehaviour
    {
        private List<ILocalUpdate> _localUpdaters;
        private List<ILocalStart> _localStarters; 

        private void Awake()
        {
            _localUpdaters = GetComponentsInChildren<ILocalUpdate>(true).ToList();
            _localStarters = GetComponentsInChildren<ILocalStart>(true).ToList();
        }

        private void Start()
        {
            if (isLocalPlayer)
            {
                _localStarters.ForEach(item => item.LocalStart());
            }
        }

        private void Update()
        {
            if (isLocalPlayer)
            {
                _localUpdaters.ForEach(item => item.LocalUpdate());
            }
        }
    }
}