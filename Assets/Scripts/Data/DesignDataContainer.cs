using MVP.Model;
using SignFactory;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "DesignDataContainer", order = 1)]
public class DesignDataContainer : ScriptableObject
{
    [SerializeField] private X_Factory _XFactory;
    [SerializeField] private O_Factory _OFactory;
    [SerializeField] private Cell_Factory _cellFactory;
    public X_Factory GlobalXFactory => _XFactory;
    public O_Factory GlobalOFactory => _OFactory;
    public Cell_Factory GlobalCellFactory => _cellFactory;

    public int GRID_SIZE = 3;
    public const int MAX_NUMBER_OF_MOVES = 9;
    public const int MARK_INDEX_IN_CELL = 0;
    public const string Initial = "Initial";
    public const string Main = "Main";
    public const string UIData = "UIData";
    public const string Data = "Data";
    
    public PlayerMark CurrentPlayer;
}