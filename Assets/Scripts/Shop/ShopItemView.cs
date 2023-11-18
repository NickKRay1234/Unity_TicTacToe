using System;
using MVP.Model.Shop;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ShopItemView : MonoBehaviour, IPointerClickHandler
{
    public event Action<ShopItemView> Click;

    [SerializeField] private Sprite _standardBackground;
    [SerializeField] private Sprite _highlightBackground;

    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _lockImage;

    [SerializeField] private IntValueView _priceView;

    [SerializeField] private Image _selectionText;

    private Image _backgroundImage;

    public ShopItem Item { get; private set; }

    public bool IsLock { get; private set; }

    public int Price => Item.Price;
    public GameObject Model => Item.Model;

    public void Initialize(ShopItem item) // Initialize the shop item view with data
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = _standardBackground;

        Item = item;

        _contentImage.sprite = item.Icon;

        _priceView.Show(Price);
    }

    public void OnPointerClick(PointerEventData eventData) => Click?.Invoke(this);
    
    public void Lock()
    {
        IsLock = true;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Show(Price);
    }

    public void Unlock()
    {
        IsLock = false;
        _lockImage.gameObject.SetActive(IsLock);
        _priceView.Hide();
    }

    // Select this shop item
    public void Select() => _selectionText.gameObject.SetActive(true);
    
    // Unselect this shop item
    public void Unselect() => _selectionText.gameObject.SetActive(false);

    // Highlight the background of the shop item
    public void Highlight() => _backgroundImage.sprite = _highlightBackground;
    
    // Remove the highlight from the background of the shop item
    public void UnHighlight() => _backgroundImage.sprite = _standardBackground;
}