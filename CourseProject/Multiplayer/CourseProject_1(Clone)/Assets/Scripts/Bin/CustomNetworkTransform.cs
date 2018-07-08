using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Networking
{
    public class CustomNetworkTransform : NetworkBehaviour
    {
        //    public struct NetworkState
        //    {
        //        public Vector3 Position;
        //        public double Timestamp;

        //        public NetworkState(Vector3 p, double t)
        //        {
        //            Position = p;
        //            Timestamp = t;
        //        }
        //    }

        //    private NetworkState[] stateBuffer = new NetworkState[20];
        //    private int stateCount = 0;
        //    private float interpolationBackTime = 0.1f;

        //    private void BufferState(NetworkState state)
        //    {
        //        for(int i = stateBuffer.Length - 1; i > 0; i--)
        //        {
        //            stateBuffer[i] = stateBuffer[i - 1];
        //        }

        //        stateBuffer[0] = state;
        //        stateCount = Mathf.Min(stateCount + 1, stateBuffer.Length);
        //    }

        //    private void Update()
        //    {
        //        if (!isLocalPlayer)
        //        {
        //            if (stateCount == 0) return; // no states to interpolate
        //            double currentTime = Network.time;
        //            double interpolationTime = currentTime - interpolationBackTime;
        //            if (stateBuffer[0].Timestamp > interpolationTime)
        //            {
        //                for (int i = 0; i < stateCount; i++)
        //                {
        //                    if (stateBuffer[i].Timestamp <= interpolationTime || i == stateCount - 1)
        //                    {
        //                        // the state closest to network time
        //                        NetworkState lhs = stateBuffer[i];
        //                        // the state one slot newer
        //                        NetworkState rhs = stateBuffer[Mathf.Max(i - 1, 0)];
        //                        // use time between lhs and rhs to interpolate
        //                        double length = rhs.Timestamp - lhs.Timestamp;
        //                        float t = 0f;
        //                        if (length > 0.0001)
        //                        {
        //                            t = (float)((interpolationTime - lhs.Timestamp) /
        //                              length);
        //                        }
        //                        transform.position = Vector3.Lerp(lhs.Position,
        //                          rhs.Position, t);
        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //        else if (isLocalPlayer)
        //        {
        //            CmdMove(transform.position);
        //        }
        //    }

        //    [Command]
        //    public void CmdMove(Vector3 vector)
        //    {
        //        RpcMove(vector, Network.time);
        //    }

        //    [ClientRpc]
        //    public void RpcMove(Vector3 vector, double timeStamp)
        //    {
        //        if (isLocalPlayer)
        //            return;

        //        BufferState(new NetworkState(vector, timeStamp));
        //    }

        [SyncVar] public Vector3 RealPosition;

        private void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                RealPosition = transform.position;
                CmdSync(RealPosition);
            }

            else
            {
                transform.position = Vector3.Lerp(transform.position, RealPosition, 0.1f);
            }
        }

        [Command]
        public void CmdSync(Vector3 position)
        {
            RealPosition = position;
        }
    }
}
