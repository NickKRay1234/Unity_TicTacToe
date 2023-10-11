using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SignFactory
{
    public class O_Factory : Factory
    {
        private IObjectResolver _objectResolver;
        
        [Inject]
        private void Construct(IObjectResolver objectResolver) => _objectResolver = objectResolver;

        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = _objectResolver.Instantiate(UIDesignDataContainer.Instance.O_Prefab.gameObject, parent.position, Quaternion.identity, parent);
            O_Product newProduct = instance.GetComponent<O_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}