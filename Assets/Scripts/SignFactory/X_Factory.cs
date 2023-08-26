using UnityEngine;

namespace SignFactory
{
    public class X_Factory : Factory
    {
        [SerializeField] private X_Product _productPrefab;
        public override IProduct GetProduct(Vector3 position)
        {
            GameObject instance = Instantiate(_productPrefab.gameObject, position, Quaternion.identity);
            X_Product newProduct = instance.GetComponent<X_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}