using UnityEngine;

namespace SignFactory
{
    public class X_Product : MonoBehaviour, IProduct
    {
        [SerializeField] private string _productName = "X";
        public string ProductName { get; set; }
        
        
        public void Initialize()
        {
#if UNITY_EDITOR
            Debug.Log($"<color=yellow>{ProductName} is created</color>");
#endif
        }
    }
}