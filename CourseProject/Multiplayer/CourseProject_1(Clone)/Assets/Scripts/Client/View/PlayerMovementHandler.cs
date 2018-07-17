using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Networking;
using UniRx;
using UniRx.Triggers;

namespace View
{
    public class PlayerMovementHandler : NetworkBehaviour, ILocalUpdate
    {
        [SerializeField] private float _speed;
        [SerializeField] private PlayerAxisController _playerController;
        [SerializeField] private Rigidbody2D _rigidBody2d;

        public void LocalUpdate()
        {
            var xAxis = _playerController.AxisX;
            var yAxis = _playerController.AxisY;

            var vector = new Vector2(xAxis, yAxis);
            _rigidBody2d.velocity = _speed*vector.normalized;
        }
    }
}
