using System;
using strange.extensions.context.impl;
using UnityEngine.EventSystems;
using strange.extensions.mediation.impl;

namespace View
{
    public class MenuView : EventView
    {
        public event Action SingleplayerButtonClick;
        public event Action CooperativeButtonClick;
        public event Action ExitButtonClick;

        public virtual void OnExitClick()
        {
            var handler = ExitButtonClick;
            if (handler != null) handler();
        }

        public virtual void OnSingleplayerClick()
        {
            var handler = SingleplayerButtonClick;
            if (handler != null) handler();
        }

        protected virtual void OnCooperativeButtonClick()
        {
            var handler = CooperativeButtonClick;
            if (handler != null) handler();
        }
    }
}