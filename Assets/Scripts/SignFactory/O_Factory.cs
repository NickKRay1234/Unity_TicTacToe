using UnityEngine;

namespace SignFactory
{
    public class O_Factory : Factory
    {
        [SerializeField] private O_Product _productPrefab;
        public override IProduct GetProduct(Vector3 position, Transform parent)
        {
            GameObject instance = Instantiate(_productPrefab.gameObject, position, Quaternion.identity, parent);
            O_Product newProduct = instance.GetComponent<O_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}