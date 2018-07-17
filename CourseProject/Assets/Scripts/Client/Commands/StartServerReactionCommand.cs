using Networking;
using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Commands
{
    public class StartServerReactionCommand : Command
    {
        [Inject] public IServer Server { get; set; }
        [Inject] public int Port { get; set; }

        public override void Execute()
        {
            Server.Start(Port);
        }
    }
}