using Contexts;
using strange.extensions.context.impl;

namespace View
{ 
    public class GameRoot : ContextView
    {
        private void Awake()
        {
            context = new GameContext(this, true);
            context.Start();
        }
    }
}
