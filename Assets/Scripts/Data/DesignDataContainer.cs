using MVP.Model;
using SignFactory;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "DesignDataContainer", order = 1)]
public class DesignDataContainer : ScriptableObject
{
    private static DesignDataContainer _instance;
    public static DesignDataContainer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<DesignDataContainer>(Data); 
                if (_instance == null)
                {
#if UNITY_EDITOR
                    Debug.LogError("There should be one DesignDataContainer in the project!");
#endif
                }
            }
            return _instance;
        }
    }
    
    
    [SerializeField] private X_Factory _XFactory;
    [SerializeField] private O_Factory _OFactory;
    public static X_Factory GlobalXFactory => Instance._XFactory;
    public static O_Factory GlobalOFactory => Instance._OFactory;

    public const int GRID_SIZE = 3;
    public const int MAX_NUMBER_OF_MOVES = 9;
    public const int MARK_INDEX_IN_CELL = 0;
    public const string Initial = "Initial";
    public const string Main = "Main";
    public const string UIData = "UIData";
    public const string Data = "Data";
    
    public static PlayerMark CurrentPlayer;
}