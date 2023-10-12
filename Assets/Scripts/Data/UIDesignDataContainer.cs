using SignFactory;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "UIDesignDataContainer", order = 2)]
public class UIDesignDataContainer : ScriptableObject
{
    public O_Product O;
    public X_Product X;
    public Cell_Product Cell;
}