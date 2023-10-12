using UnityEngine;

namespace SignFactory
{
    public class X_Product : MonoBehaviour, IProduct
    {
        public string ProductName { get; set; }
        public void Initialize() => ProductName = "X";
        public GameObject GetGameObject() => gameObject;
    }
}