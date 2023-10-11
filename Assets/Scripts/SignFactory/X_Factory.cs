using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SignFactory
{
    public class X_Factory : Factory
    {
        private IObjectResolver _objectResolver;
        
        [Inject]
        private void Construct(IObjectResolver objectResolver) => _objectResolver = objectResolver;

        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = _objectResolver.Instantiate(UIDesignDataContainer.Instance.X_Prefab.gameObject, parent.position, Quaternion.identity, parent);
            X_Product newProduct = instance.GetComponent<X_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}