using Contexts;
using strange.extensions.context.impl;

namespace View
{ 
    public class MainRoot : ContextView
    {
        private void Awake()
        {
            context = new MainContext(this, true);
            context.Start();
        }
    }
}
