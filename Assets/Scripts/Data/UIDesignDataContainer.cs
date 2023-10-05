using SignFactory;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "UIDesignDataContainer", order = 2)]
public class UIDesignDataContainer : ScriptableObject
{
    public O_Product O_Prefab;
    public X_Product X_Prefab;
}