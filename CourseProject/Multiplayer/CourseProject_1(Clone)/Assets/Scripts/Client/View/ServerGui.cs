using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Networking;

namespace View
{
    public class ServerGui : EventView
    {
        public event Action<int> StartServer;
        public event Action RestartServer;
        public event Action StopServer;
    
        private void OnGUI()
        {
            GUILayout.Space(300);

            var probablyServerPort = 0;
            var input = GUILayout.TextField("Server port is here");
            if (int.TryParse(input, out probablyServerPort))
            {
            }

            if (!NetworkServer.active)
            {
                if (GUILayout.Button("Start"))
                {
                    OnStartServer(probablyServerPort);
                }
            }
            else
            {
                if (GUILayout.Button("Restart"))
                {
                    OnRestartServer();
                }

                if (GUILayout.Button("Stop"))
                {
                    OnStopServer();
                }
            }

            if (!NetworkServer.active)
                return;


            GUILayout.Space(20);

            GUILayout.Label("Server status:");

            GUILayout.Label("Server Errors");
        }

        protected virtual void OnStartServer(int obj)
        {
            var handler = StartServer;
            if (handler != null) handler(obj);
        }

        protected virtual void OnRestartServer()
        {
            var handler = RestartServer;
            if (handler != null) handler();
        }

        protected virtual void OnStopServer()
        {
            var handler = StopServer;
            if (handler != null) handler();
        }
    }
}