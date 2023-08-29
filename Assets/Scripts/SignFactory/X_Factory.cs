using UnityEngine;

namespace SignFactory
{
    public class X_Factory : Factory, IService
    {
        [SerializeField] private X_Product _productPrefab;
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = Instantiate(_productPrefab.gameObject, parent.position, Quaternion.identity, parent);
            X_Product newProduct = instance.GetComponent<X_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}