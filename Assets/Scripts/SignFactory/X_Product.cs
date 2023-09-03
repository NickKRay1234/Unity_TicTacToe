using UnityEngine;

namespace SignFactory
{
    public class X_Product : MonoBehaviour, IProduct
    {
        public string ProductName { get; set; }

        public void Initialize()
        {
            ProductName = "X";
#if UNITY_EDITOR
            Debug.Log($"<color=yellow>{ProductName} is created</color>");
#endif
        }
        
        public GameObject GetGameObject() => gameObject;
    }
}