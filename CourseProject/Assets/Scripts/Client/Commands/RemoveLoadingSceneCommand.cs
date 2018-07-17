using strange.extensions.command.impl;
using Services;
using UniRx;
using UnityEngine;

namespace Commands
{
    public class RemoveLoadingSceneCommand : Command
    {
        [Inject]
        public ScenesService ScenesService { get; set; }

        public override void Execute()
        {
            var sceneName = Constants.LoadingScene;
            if (!ScenesService.IsAdded(sceneName))
            {
                Debug.LogWarningFormat(@"""{0}"" scene is already unloaded", sceneName);
                return;
            }

            Retain();
            var operation = ScenesService.UnloadAsync(sceneName);
            operation.OnComplete(Callback);
        }

        private void Callback()
        {
            Debug.Log("Released");
            Release();
        }
    }
}