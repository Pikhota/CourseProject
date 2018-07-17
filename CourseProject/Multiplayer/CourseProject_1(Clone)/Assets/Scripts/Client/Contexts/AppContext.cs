using Commands;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Services;
using Signals;
using UnityEngine;

namespace Contexts
{
    public class AppContext : MVCSContext
    {
        public AppContext() : base() { }
        public AppContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

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
            injectionBinder.Bind<ScenesService>()
                .ToSingleton()
                .CrossContext();

            commandBinder.Bind<StartSignal>()
                .To<AddMenuSceneCommand>()
                .To<AddCamerasSceneCommand>()
                .InSequence()
                .Once();

            commandBinder.Bind<ChangeLevelSignal>()
                .To<AddLoadingSceneCommand>()
                .To<RemoveCallerSceneCommand>()
                .To<AddTargetSceneCommand>()
                .InSequence();
        }
    }
}