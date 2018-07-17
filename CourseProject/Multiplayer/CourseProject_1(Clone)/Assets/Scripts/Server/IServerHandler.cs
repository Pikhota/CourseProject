using UnityEngine.Networking;

namespace Networking
{
    public interface IServerHandler
    {
        short MessageType { get; }
        void Handle(NetworkMessage message);
    }
}