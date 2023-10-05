using UnityEngine;

namespace SignFactory
{
    public class O_Factory : Factory, IService
    {
        [SerializeField] private O_Product _productPrefab;
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = Instantiate(UIContainer.O_Prefab.gameObject, parent.position, Quaternion.identity, parent);
            O_Product newProduct = instance.GetComponent<O_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}