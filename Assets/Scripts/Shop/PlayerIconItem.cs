using UnityEngine;

namespace MVP.Model.Shop
{
    [CreateAssetMenu(fileName = "PlayerIconItem", menuName = "Shop/PlayerIconItem")]
    public class PlayerIconItem : ShopItem
    {
        [field: SerializeField] public PlayerIcons IconItem { get; private set; }
    }
}