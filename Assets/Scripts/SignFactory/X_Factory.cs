using UnityEngine;

namespace SignFactory
{
    public class X_Factory : Factory
    {
        [SerializeField] private X_Product _productPrefab;
        public override IProduct GetProduct(Vector3 position, Transform parent)
        {
            GameObject instance = Instantiate(_productPrefab.gameObject, position, Quaternion.identity, parent);
            X_Product newProduct = instance.GetComponent<X_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}