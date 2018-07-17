using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class LoadingRoot : ContextView
    {
        private void Awake()
        {
            context = new LoadingContext(this, true);
            context.Start();
        }
    }
}