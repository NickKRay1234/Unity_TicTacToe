using UnityEngine;

namespace SignFactory
{
    public sealed class Cell_Factory : Factory, IService
    {
        [SerializeField] private Cell_Product _product;
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = Instantiate(_product.gameObject, parent.position, Quaternion.identity, parent);
            Cell_Product newProduct = instance.GetComponent<Cell_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}