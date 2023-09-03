using UnityEngine;

namespace SignFactory
{
    public class Cell_Product : MonoBehaviour, IProduct
    {
        private GameObject cell;
        public string ProductName { get; set; }

        public void Initialize()
        {
            ProductName = "Cell";
#if UNITY_EDITOR
            Debug.Log($"<color=yellow>{ProductName} is created</color>");
#endif
        }

        public GameObject GetGameObject() => gameObject;
    }
}