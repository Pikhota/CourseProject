using Networking;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Services;
using Signals;
using UnityEngine;

namespace Contexts
{
    public class ServerContext : MVCSContext
    {
        public ServerContext() : base() { }
        public ServerContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

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

            injectionBinder
                .Bind<StartServerSignal>()
                .ToSingleton()
                .CrossContext();
            injectionBinder.Bind<IServer>().To<UnityServer>()
                .ToSingleton()
                .CrossContext();
            injectionBinder.Bind<ICLientConnector>().To<UnityClientConnector>()
                .ToSingleton()
                .CrossContext();
        }
    }
}