using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class MenuRoot : ContextView
    {
        private void Awake()
        {
            context = new MenuContext(this, true);
            context.Start();
        }
    }
}