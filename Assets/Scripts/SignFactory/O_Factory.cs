using UnityEngine;
using VContainer.Unity;

namespace SignFactory
{
    public class O_Factory : Factory
    {
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = _objectResolver.Instantiate(_uiDesignDataContainer.O.gameObject, parent.position, Quaternion.identity, parent);
            O_Product newProduct = instance.GetComponent<O_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}