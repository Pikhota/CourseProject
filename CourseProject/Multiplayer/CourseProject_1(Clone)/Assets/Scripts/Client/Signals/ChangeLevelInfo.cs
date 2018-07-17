using UniRx;
using UnityEngine;

namespace Models
{
    public class ChangeLevelInfo
    {
        public string CallerScene;
        public string TargetScene;
        public AsyncOperation Operation;
    }
}