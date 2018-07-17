using strange.extensions.mediation.impl;
using Signals;
using UnityEngine;

namespace View
{
    public class MainMenuMediator : TargetMediator<MenuView>
    {
        [Inject] public SingleplayerModeSignal SingleplayerSignal { get; set; }
        [Inject] public AppExitSignal AppExitSignal { get; set; }

        public override void OnRegister()
        {
            View.SingleplayerButtonClick += HandleSingleplayerButtonClick;
            View.ExitButtonClick += HandleExitButtonClick;
        }

        public override void OnRemove()
        {
            View.SingleplayerButtonClick -= HandleSingleplayerButtonClick;
            View.ExitButtonClick -= HandleExitButtonClick;
        }

        private void HandleSingleplayerButtonClick()
        {
            SingleplayerSignal.Dispatch();    
        }

        private void HandleCooperativeButtonClick()
        {

        }

        private void HandleExitButtonClick()
        {
            AppExitSignal.Dispatch();
        }
    }
}