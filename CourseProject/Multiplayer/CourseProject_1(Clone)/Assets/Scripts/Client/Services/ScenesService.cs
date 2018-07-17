using System;
using System.Collections;
using Models;
using Signals;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class ScenesService
    {
        private readonly ChangeLevelSignal _changeLevelSignal;

        public ScenesService(ChangeLevelSignal changeLevelSignal)
        {
            _changeLevelSignal = changeLevelSignal;
        }

        public AsyncOperation LoadAsync(string name, LoadSceneMode loadMode = LoadSceneMode.Additive)
        {
            Debug.LogFormat(@"Loading started: ""{0}"" ", name);
            
            var operation = SceneManager.LoadSceneAsync(name, loadMode);
            operation.OnComplete(() => Debug.LogFormat(@"Loading finished: ""{0}"" ", name));

            return operation;
        }

        public AsyncOperation UnloadAsync(string name)
        {
            Debug.LogFormat(@"Unloading started: ""{0}"" ", name);

            var operation = SceneManager.UnloadSceneAsync(name);
            operation.OnComplete(() => Debug.LogFormat(@"Unloading finished: ""{0}"" ", name));

            return operation;
        }

        public bool IsAdded(string name)
        {
            return SceneManager.GetSceneByName(name).name == name;
        }

        public void SetActiveScene(string name)
        {
            var scene = SceneManager.GetSceneByName(name);
            if (SceneManager.SetActiveScene(scene))
            {
                Debug.LogFormat(@"Active scene: ""{0}"" ", name);
            }
            else
            {
                Debug.LogWarningFormat(@"The scene is not loaded: ""{0}"" ", name);
            }
        }

        public void ChangeLevel(string callerScene, string targetScene)
        {
            try
            {
                if (string.IsNullOrEmpty(callerScene))
                    throw new ArgumentException("", "callerScene");
                if (string.IsNullOrEmpty(targetScene))
                    throw new ArgumentException("", "targetScene");

                var info = new ChangeLevelInfo()
                {
                    CallerScene = callerScene,
                    TargetScene = targetScene
                };

                _changeLevelSignal.Dispatch(info);
            }

            catch (ArgumentException e)
            {
                var param = e.ParamName;
                e = new ArgumentNullException(
                    string.Format("Couldn't change level: invalid value in {0}", param));
                Debug.LogErrorFormat(e.Message);
                throw;
            }
        }
    }
}