using System.Collections;
using Models;
using strange.extensions.command.impl;
using Services;
using Signals;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Commands
{
    public class AddTargetSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }
        [Inject] public LoadingSignal LoadingSignal { get; set; }
        [Inject] public ChangeLevelInfo ChangeLevelInfo { get; set; }

        public override void Execute()
        {
            var sceneName = ChangeLevelInfo.TargetScene;
            if (ScenesService.IsAdded(sceneName))
            {
                Debug.LogWarningFormat(@"""{0}"" scene is already loaded", sceneName);
                return;
            }

            Retain();
            
            var operation = ScenesService.LoadAsync(sceneName);
            ChangeLevelInfo.Operation = operation;
            LoadingSignal.Dispatch(ChangeLevelInfo);

            operation.OnComplete(Callback);
        }

        public void Callback()
        {
            Debug.Log("Released");
            ScenesService.SetActiveScene(ChangeLevelInfo.TargetScene);
            Release();
        }
    }
}