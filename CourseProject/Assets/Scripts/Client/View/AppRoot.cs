using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class AppRoot : ContextView
    {
        private void Awake()
        {
            context = new AppContext(this, true);
            context.Start();
        }
    }
}