using MVP.Model.Shop;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemViewFactory", menuName = "Shop/ShopItemViewFactory")]
public class ShopItemViewFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _characterSkinItemPrefab;
    [SerializeField] private ShopItemView _mazeSkinItemPrefab;

    public ShopItemView Get(ShopItem shopItem, Transform parent)
    {
        ShopItemVisitor visitor = new ShopItemVisitor(_characterSkinItemPrefab, _mazeSkinItemPrefab);
        //visitor.Visit(shopItem);

        ShopItemView instance = Instantiate(visitor.Prefab, parent);
        instance.Initialize(shopItem);

        return instance;
    }

    private class ShopItemVisitor : IShopItemVisitor
    {
        private ShopItemView _characterSkinItemPrefab;
        private ShopItemView _mazeSkinItemPrefab;

        public ShopItemVisitor(ShopItemView characterSkinItemPrefab, ShopItemView mazeSkinItemPrefab)
        {
            _characterSkinItemPrefab = characterSkinItemPrefab;
            _mazeSkinItemPrefab = mazeSkinItemPrefab;
        }

        public ShopItemView Prefab { get; private set; }

        //public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

        public void Visit(PlayerIconItem playerIconItem) => Prefab = _characterSkinItemPrefab;
    }
}