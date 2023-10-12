using MVP.Model;
using UnityEngine;
using VContainer.Unity;

namespace SignFactory
{
    public sealed class Cell_Factory : Factory
    {
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = _objectResolver.Instantiate(_uiDesignDataContainer.Cell.gameObject, parent.position, Quaternion.identity, parent);
            _objectResolver.Inject(instance.GetComponent<CellView>());
            Cell_Product newProduct = instance.GetComponent<Cell_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}