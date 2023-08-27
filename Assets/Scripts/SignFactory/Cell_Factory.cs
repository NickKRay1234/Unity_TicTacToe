using UnityEngine;

namespace SignFactory
{
    public class Cell_Factory : Factory
    {
        [SerializeField] private Cell_Product _productPrefab;
        
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = Instantiate(_productPrefab.gameObject, parent.position, Quaternion.identity, parent);
            Cell_Product newProduct = instance.GetComponent<Cell_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}