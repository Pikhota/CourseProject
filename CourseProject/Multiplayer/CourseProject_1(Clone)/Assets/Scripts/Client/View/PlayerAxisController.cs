using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Networking;

namespace View
{
    public class PlayerAxisController : NetworkBehaviour, ILocalUpdate
    {
        public float AxisX { get; private set; }
        public float AxisY { get; private set; }

        public void LocalUpdate()
        {
            AxisX = Input.GetAxisRaw("Horizontal");
            AxisY = Input.GetAxisRaw("Vertical");
        }
    }
}