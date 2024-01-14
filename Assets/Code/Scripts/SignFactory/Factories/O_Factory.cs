using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SignFactory
{
    public class O_Factory : Factory, IMarkFactory
    {
        public override IProduct GetProduct(Transform parent)
        {
            var handle = Addressables.InstantiateAsync(_uiDesignDataContainer.O_Prefab, parent.position, Quaternion.identity, parent);
            handle.Completed += OnObjectInstantiated;
            return null;
        }

        private void OnObjectInstantiated(AsyncOperationHandle<GameObject> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject instance = handle.Result;
                O_Product newProduct = instance.GetComponent<O_Product>();
                if (newProduct != null)
                    newProduct.Initialize();
            }
            else
                Debug.LogError("Failed to instantiate an O object via Addressables");
        }
    }
}