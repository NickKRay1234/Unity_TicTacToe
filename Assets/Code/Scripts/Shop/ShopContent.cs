using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MVP.Model.Shop
{
    [CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/ShopContent")]
    public class ShopContent : ScriptableObject
    {
        [SerializeField] private List<PlayerIconItem> _playerIconItems;

        public IEnumerable<PlayerIconItem> PlayerIconItems => _playerIconItems;

        private void OnValidate()
        {
            var playerIconsDuplicates =
                _playerIconItems.GroupBy(item => item.IconItem).Where(array => array.Count() > 1);

            if (playerIconsDuplicates.Any())
                throw new InvalidOperationException(nameof(_playerIconItems));
        }
    }
}