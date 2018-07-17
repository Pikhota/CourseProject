using System.Collections;
using strange.extensions.command.impl;
using UniRx;
using UnityEditor;
using UnityEngine;

namespace Commands
{
    public class AppExitCommand : Command
    {
        public override void Execute()
        {
            Debug.Log("ClosingApp");
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN
            Application.Quit();
#endif
        }
    }
}