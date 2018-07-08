using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace View
{
    public class PlayerAnimationsHandler : NetworkBehaviour, ILocalPlayer
    {
        [SerializeField] private PlayerAxisController _playerController;
        [SerializeField] private Animator _anim;

        void ILocalPlayer.Execute()
        {
            var xAxis = _playerController.AxisX;
            var yAxis = _playerController.AxisY;

            _anim.SetFloat("Vx", xAxis);
            _anim.SetFloat("Vy", yAxis);
        }
    }
}