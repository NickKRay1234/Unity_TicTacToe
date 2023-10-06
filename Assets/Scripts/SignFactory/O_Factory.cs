using UnityEngine;

namespace SignFactory
{
    public class O_Factory : Factory, IService
    {
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = Instantiate(UIDesignDataContainer.Instance.O_Prefab.gameObject, parent.position, Quaternion.identity, parent);
            O_Product newProduct = instance.GetComponent<O_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}