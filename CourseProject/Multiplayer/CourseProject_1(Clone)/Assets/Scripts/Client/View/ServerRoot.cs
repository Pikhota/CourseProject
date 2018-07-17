using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class ServerRoot : ContextView
    {
        private void Awake()
        {
            context = new ServerContext(this, true);
            context.Start();
        }
    }
}