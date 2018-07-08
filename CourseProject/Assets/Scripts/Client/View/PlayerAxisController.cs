using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace View
{
    public class PlayerAxisController : NetworkBehaviour, ILocalPlayer
    {
        public float AxisX { get; private set; }
        public float AxisY { get; private set; }

        void ILocalPlayer.Execute()
        {
            AxisX = Input.GetAxisRaw("Horizontal");
            AxisY = Input.GetAxisRaw("Vertical");
        }
    }
}