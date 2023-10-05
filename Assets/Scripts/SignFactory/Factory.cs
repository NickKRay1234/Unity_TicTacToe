using UnityEngine;

namespace SignFactory
{
    public abstract class Factory : MonoBehaviour
    {
        protected UIDesignDataContainer UIContainer;

        protected void Awake() =>
            UIContainer = Resources.Load<UIDesignDataContainer>(DesignDataContainer.UIData);

        public abstract IProduct GetProduct(Transform parent);
    }
}