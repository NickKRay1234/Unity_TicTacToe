using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SignFactory
{
    public class X_Factory : Factory
    {
        public override IProduct GetProduct(Transform parent)
        {
            var handle = Addressables.InstantiateAsync(_uiDesignDataContainer.X_Prefab, parent.position, Quaternion.identity, parent);
            handle.Completed += OnObjectInstantiated;
            return null;
        }

        private void OnObjectInstantiated(AsyncOperationHandle<GameObject> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject instance = handle.Result;
                X_Product newProduct = instance.GetComponent<X_Product>();
                if (newProduct != null)
                    newProduct.Initialize();
            }
            else
                Debug.LogError("Failed to instantiate an X object via Addressables");
        }
    }
}