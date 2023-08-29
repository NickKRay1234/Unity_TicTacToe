using UnityEngine;

namespace SignFactory
{
    public class O_Product : MonoBehaviour, IProduct
    {
        [SerializeField] private string _productName = "O";
        public string ProductName { get; set; }
        public void Initialize()
        {
#if UNITY_EDITOR
            Debug.Log($"<color=yellow>{ProductName} is created</color>");
#endif
        }

        public GameObject GetGameObject() => gameObject;
    }
}