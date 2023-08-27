using UnityEngine;

namespace SignFactory
{
    public class O_Factory : Factory
    {
        [SerializeField] private O_Product _productPrefab;
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = Instantiate(_productPrefab.gameObject, parent.position, Quaternion.identity, parent);
            O_Product newProduct = instance.GetComponent<O_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}