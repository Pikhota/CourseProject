using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Networking;

namespace View
{
    public class PlayerMovementHandler : NetworkBehaviour, ILocalPlayer
    {
        [SerializeField] private float _speed;
        [SerializeField] private PlayerAxisController _playerController;
        [SerializeField] private Rigidbody2D _rigidBody2d;

        void ILocalPlayer.Execute()
        {
            var xAxis = _playerController.AxisX;
            var yAxis = _playerController.AxisY;

            var vector = new Vector2(xAxis, yAxis);
            _rigidBody2d.velocity = _speed * vector.normalized;
        }
    }
}
