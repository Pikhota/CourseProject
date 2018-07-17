using UnityEngine.Networking;

namespace Services
{
    public interface IClientHandler
    {
        short MessageType { get; }
        void Handle(NetworkMessage message);
    }
}