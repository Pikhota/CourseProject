using strange.extensions.command.impl;
using Services;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Commands
{
    public class AddLoadingSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }

        public override void Execute()
        {
            var sceneName = Constants.LoadingScene;
            if (ScenesService.IsAdded(sceneName))
            {
                Debug.LogWarningFormat(@"""{0}"" scene is already unloaded", sceneName);
                return;
            }

            Retain();
            var operation = ScenesService.LoadAsync(sceneName);
            operation.OnComplete(Callback);
        }

        public void Callback()
        {
            Debug.Log("Released");
            Release();
        }
    }
}