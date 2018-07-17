using strange.extensions.signal.impl;
using View;

namespace Signals
{
    public class LocalPLayerSpawnSignal : Signal<PlayerView> { }
    public class StartServerSignal : Signal<int> { }
    public class RestartServerSignal : Signal { }
    public class StopServerSignal : Signal { }
}