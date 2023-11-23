using UnityEngine;

namespace SignFactory
{
    public class X_Product : MonoBehaviour, IProduct
    {
        [SerializeField] private Sprite _XSprite;
        public string ProductName { get; set; }
        public void Initialize() => ProductName = "X";
        public GameObject GetGameObject() => gameObject;

        public void SetSprite(Sprite newSprite)
        {
            _XSprite = newSprite;
        }
    }
}