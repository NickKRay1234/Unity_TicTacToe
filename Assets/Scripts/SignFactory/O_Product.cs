using UnityEngine;

namespace SignFactory
{
    public class O_Product : MonoBehaviour, IProduct
    {
        public string ProductName { get; set; }
        public void Initialize() => ProductName = "O";
        public GameObject GetGameObject() => gameObject;
    }
}