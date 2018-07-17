using System;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Services
{
    public interface ICLientConnector
    {
        void Connect(string ip, int port);
        void Disconect();

        void Send(short msgId, MessageBase msg);
        void RegisterHandlers(IEnumerable<IClientHandler> handlers);
    }
}