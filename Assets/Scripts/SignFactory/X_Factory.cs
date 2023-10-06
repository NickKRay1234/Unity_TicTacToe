using UnityEngine;

namespace SignFactory
{
    public class X_Factory : Factory, IService
    {
        public override IProduct GetProduct(Transform parent)
        {
            GameObject instance = Instantiate(UIDesignDataContainer.Instance.X_Prefab.gameObject, parent.position, Quaternion.identity, parent);
            X_Product newProduct = instance.GetComponent<X_Product>();
            newProduct.Initialize();
            return newProduct;
        }
    }
}