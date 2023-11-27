using UnityEngine;
using VContainer;

namespace SignFactory
{
    public abstract class Factory : MonoBehaviour
    {
        protected IObjectResolver _objectResolver;
        protected UIDesignDataContainer _uiDesignDataContainer;
        
        [Inject]
        protected void Construct(IObjectResolver objectResolver, UIDesignDataContainer uiDesignDataContainer)
        {
            _objectResolver = objectResolver;
            _uiDesignDataContainer = uiDesignDataContainer;
        }
        
        
        public abstract IProduct GetProduct(Transform parent);
    }
}