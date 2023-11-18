using UnityEngine;

namespace MVP.Model.Shop
{
    public abstract class ShopItem : ScriptableObject
    {
        [field: SerializeField] public GameObject Model { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField, Range(0, 10000)] public int Price { get; private set; }
    }
}