using Signals;
using UnityEngine;

namespace View
{
    public class PlayerViewMediator : TargetMediator<PlayerView>
    {
        [Inject] public LocalPLayerSpawnSignal LocalPlayerSpawnSignal { get; set; }

        public override void OnRegister()
        {
            Debug.Log("OnEnbaled");
            View.LocalPlayerSpawn += OnPlayerSpawn;
        }

        public override void OnRemove()
        {
            View.LocalPlayerSpawn -= OnPlayerSpawn;
        }

        private void OnPlayerSpawn()
        {
            LocalPlayerSpawnSignal.Dispatch(View);
        }
    }
}