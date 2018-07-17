using System;
using Models;
using strange.extensions.command.impl;
using Services;
using Signals;
using UnityEngine.SceneManagement;

namespace Commands
{
    public class ChangeLevel_Menu_Game_Command : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }

        public override void Execute()
        {
            ScenesService.ChangeLevel(
                Constants.MenuScene, 
                Constants.GameScene);
        }
    }
}