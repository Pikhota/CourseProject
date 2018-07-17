using Cinemachine;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using View;

namespace Commands
{
    public class AddMainCameraCommand : Command
    {
        [Inject] public PlayerView PlayerView { get; set; }

        public override void Execute()
        {
            Debug.Log("SetUpCameraCommand started");
            var vc = Object.FindObjectOfType<CinemachineVirtualCamera>();
            vc.Follow = PlayerView.transform;
        }
    }
}