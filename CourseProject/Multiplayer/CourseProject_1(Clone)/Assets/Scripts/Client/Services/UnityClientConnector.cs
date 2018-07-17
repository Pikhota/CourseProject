using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Services
{
    public class UnityClientConnector : ICLientConnector
    {
        private NetworkClient _client;

        public void Connect(string ip, int port)
        {
            _client = new NetworkClient();
            _client.Connect(ip, port);
        }

        public void Disconect()
        {
            if (_client != null)
            {
                _client.Disconnect();
            }
            else
            {
                Debug.LogError("You should connect to server first");
            }
        }

        public void Send(short msgId, MessageBase msg)
        {
            if (_client != null)
            {
                _client.Send(msgId, msg);
            }
            else
            {
                Debug.LogError("You should connect to server first");
            }
        }

        public void RegisterHandlers(IEnumerable<IClientHandler> handlers)
        {
            foreach (var h in handlers)
            {
                _client.RegisterHandler(h.MessageType, h.Handle);
            }
        }
    }
}