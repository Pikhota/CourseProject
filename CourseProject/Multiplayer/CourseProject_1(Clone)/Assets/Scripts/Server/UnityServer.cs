using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Networking
{
    public class UnityServer : IServer
    {
        public event Action<bool> OnServerConnected;
        public event Action<string> OnServerError;
        public event Action<bool> OnServerDisconnect;
        
        public int Port { get; private set; }
        public IEnumerable<int> ActiveConnections
        {
            get
            {

                var connections = NetworkServer.connections;
                var intConnection = connections.Select(p => p.connectionId);
                return intConnection;

            }
        }

        public void Start(int port)
        {
            Port = port;
            NetworkServer.Listen(port);
            if (NetworkServer.active)
            {
                Debug.Log("Server started on port: " + port);
            }
            else
            {
                Debug.Log("Couldn't start server on port: " + port);
            }
        }

        public void Restart()
        {
            Shutdown();
            Start(Port);
        }

        public void Shutdown()
        {
            NetworkServer.Shutdown();
            Debug.Log("Stop server");
        }

        public void SendToAll(short msgType, MessageBase msg)
        {
            NetworkServer.SendToAll(msgType, msg);
        }

        public void SendToClient(int connectionId, short msgType, MessageBase msg)
        {
            NetworkServer.SendToClient(connectionId, msgType, msg);
        }

        public void SendToClientOfPlayer(GameObject player, short msgType, MessageBase msg)
        {
            NetworkServer.SendToClientOfPlayer (player, msgType, msg);
        }

        public void RegisterHandlers(IEnumerable<IServerHandler> handlers)
        {
            foreach (var h in handlers)
            {
                NetworkServer.RegisterHandler(h.MessageType, h.Handle);
            }
        }
    }
}