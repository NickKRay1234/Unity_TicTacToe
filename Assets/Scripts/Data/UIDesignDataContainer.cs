using SignFactory;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "UIDesignDataContainer", order = 2)]
public class UIDesignDataContainer : ScriptableObject
{
    [SerializeField] public O_Product _o;
    [SerializeField] public X_Product _x;
    public X_Product X_Prefab => _x;
    public O_Product O_Prefab => _o;
    
    private static UIDesignDataContainer _instance;
    public static UIDesignDataContainer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<UIDesignDataContainer>(DesignDataContainer.UIData); 
                if (_instance == null)
                {
#if UNITY_EDITOR
                    Debug.LogError("There should be one UIDesignDataContainer in the project!");
#endif
                }
            }
            return _instance;
        }
    }
}