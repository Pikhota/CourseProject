using CompilerGenerated;
using Models;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;
using Signals;
using strange.extensions.context.impl;
using strange.extensions.injector.impl;
using Services;
using View;

namespace Contexts
{
    public class MainContext : MVCSContext
    {
        public MainContext() : base() { }
        public MainContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

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
        }
    }
}