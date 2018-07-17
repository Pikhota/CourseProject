using Signals;

namespace View
{
    public class ServerGuiMediator : TargetMediator<ServerGui>
    {
        [Inject] public StartServerSignal StartServerSignal { get; set; }

        public override void OnRegister()
        {
            View.StartServer += OnStartServer;
        }

        public override void OnRemove()
        {
            View.StartServer -= OnStartServer;
        }

        public void OnStartServer(int port)
        {
            StartServerSignal.Dispatch(port);
        }
    }
}