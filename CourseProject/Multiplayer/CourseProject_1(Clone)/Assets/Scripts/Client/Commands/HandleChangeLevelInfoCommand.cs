using System.Collections;
using Models;
using strange.extensions.command.impl;
using UniRx;
using UnityEngine;

namespace Commands
{
    public class HandleChangeLevelInfoCommand : Command
    {
        [Inject] public ChangeLevelInfo ChangeLevelInfo { get; set; }

        public override void Execute()
        {
            Retain();

            var operation = ChangeLevelInfo.Operation;
            Observable.FromMicroCoroutine(_ => LoadingCoroutine(operation)).Subscribe();
        }

        private IEnumerator LoadingCoroutine(AsyncOperation operation)
        {
            operation.allowSceneActivation = false;

            while (!Mathf.Approximately(operation.progress, 0.9f))
                yield return null;

            while (!Input.anyKey)
            {
                Debug.Log("Press any key");
                yield return null;
            }

            operation.allowSceneActivation = true;
            OnComplete();
        }

        private void OnComplete()
        {
            Debug.Log("Released");
            Release();
        }
    }
}