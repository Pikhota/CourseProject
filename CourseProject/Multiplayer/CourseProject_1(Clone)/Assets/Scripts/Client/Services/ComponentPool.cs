using UniRx.Toolkit;
using UnityEngine;

namespace Services
{
    public class ComponentPool : ObjectPool<Component>
    {
        private readonly Component _prefab;
        private readonly Transform _parent;

        protected ComponentPool(Component prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        protected override Component CreateInstance()
        {
            var obj = Object.Instantiate(_prefab);
            obj.transform.SetParent(_parent);

            return obj;
        }
    }
}