using UnityEngine;
using VContainer.Unity;

namespace SignFactory
{
    public class X_Factory : Factory
    {
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = _objectResolver.Instantiate(_uiDesignDataContainer.X.gameObject, parent.position, Quaternion.identity, parent);
            X_Product newProduct = instance.GetComponent<X_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}