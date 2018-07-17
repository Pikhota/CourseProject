using Commands;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Signals;
using UnityEngine;

namespace Contexts
{
    public class LoadingContext : MVCSContext
    {
        public LoadingContext() : base()
        {
        }

        public LoadingContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
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
            injectionBinder.Bind<LoadingSignal>()
                .ToSingleton()
                .CrossContext();

            commandBinder.Bind<StartSignal>()
                .Once();
            commandBinder.Bind<LoadingSignal>()
                .To<HandleChangeLevelInfoCommand>()
                .To<RemoveLoadingSceneCommand>()
                .InSequence();
        }

        public override void OnRemove()
        {
            injectionBinder.Unbind<LoadingSignal>();
        }
    }
}