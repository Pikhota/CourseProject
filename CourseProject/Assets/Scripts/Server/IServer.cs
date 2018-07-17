using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Networking
{
    public interface IServer
    {
        event Action<bool> OnServerConnected;
        event Action<string> OnServerError;
        event Action<bool> OnServerDisconnect;

        IEnumerable<int> ActiveConnections { get; }

        void Start(int port);
        void Restart();
        void Shutdown();

        void SendToAll(short msgType, MessageBase msg);
        void SendToClient(int connectionId, short msgType, MessageBase msg);
        void RegisterHandlers(IEnumerable<IServerHandler> handlers);
    }
}