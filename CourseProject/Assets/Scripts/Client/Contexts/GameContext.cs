using Commands;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;
using Signals;
using strange.extensions.context.impl;
using View;

namespace Contexts
{
    public class GameContext : MVCSContext
    {
        public GameContext() : base() { }
        public GameContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

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
            commandBinder.Bind<LocalPLayerSpawnSignal>()
                .To<AddMainCameraCommand>();

            mediationBinder.Bind<PlayerView>()
                .To<PlayerViewMediator>();
        }
    }
}