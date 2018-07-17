using Commands;
using Networking;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Services;
using Signals;
using UnityEngine;
using View;

namespace Contexts
{
    public class MenuContext : MVCSContext
    {
        public MenuContext() : base()
        {
        }

        public MenuContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
        {
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override IContext Start()
        {
            base.Start();
            var startSignal = injectionBinder.GetInstance<StartSignal>();
            startSignal.Dispatch();
            return this;
        }

        protected override void mapBindings()
        {
            commandBinder.Bind<StartSignal>()
                .Once();
            commandBinder.Bind<SingleplayerModeSignal>()
                .To<ChangeLevel_Menu_Game_Command>();
            commandBinder.Bind<AppExitSignal>()
                .To<AppExitCommand>();

            mediationBinder.Bind<MenuView>()
                .To<MainMenuMediator>();
        }
    }
}