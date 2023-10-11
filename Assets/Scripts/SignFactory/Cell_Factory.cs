using MVP.Model;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SignFactory
{
    public sealed class Cell_Factory : Factory
    {
        private IObjectResolver _objectResolver;
        
        [Inject]
        private void Construct(IObjectResolver objectResolver) => _objectResolver = objectResolver;

        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = _objectResolver.Instantiate(UIDesignDataContainer.Instance.Cell_Prefab.gameObject, parent.position, Quaternion.identity, parent);
            _objectResolver.Inject(instance.GetComponent<CellView>());
            Cell_Product newProduct = instance.GetComponent<Cell_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}