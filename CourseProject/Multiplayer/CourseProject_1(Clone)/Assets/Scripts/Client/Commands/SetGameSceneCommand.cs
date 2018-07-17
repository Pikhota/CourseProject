using strange.extensions.command.impl;
using Services;
using Signals;
using UniRx;
using UnityEngine;

namespace Commands
{
    public class SetGameSceneCommand : Command
    {
        [Inject] public ScenesService SceneLoader { get; set; }

        public override void Execute()
        {
            var operation = SceneLoader.LoadAsync("Game");
            operation.allowSceneActivation = false;
        }
    }
}