using Models;
using strange.extensions.command.impl;
using Services;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Commands
{
    public class RemoveCallerSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }
        [Inject] public ChangeLevelInfo ChangeLevelInfo { get; set; }

        public override void Execute()
        {
            var sceneName = ChangeLevelInfo.CallerScene;
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