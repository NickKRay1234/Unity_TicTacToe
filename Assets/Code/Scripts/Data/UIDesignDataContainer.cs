using SignFactory;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "UIDesignDataContainer", order = 2)]
public class UIDesignDataContainer : ScriptableObject
{
    [Header("Addressables names: ")]
    public string O_Prefab = "O";
    public string X_Prefab = "X";
    public string Cell_Prefab = "Cell";
    
    [Header("Products visual: ")]
    public Sprite ActiveXSprite;
    public Sprite ActiveOSprite;
    
    [Space]
    public X_Product X;
    public Cell_Product Cell;
    public Button SelectedButton;
}