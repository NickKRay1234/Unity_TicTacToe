using MVP.Model;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "DesignDataContainer", order = 1)]
public class DesignDataContainer : ScriptableObject
{
    public int GRID_SIZE = 3;
    public const int MAX_NUMBER_OF_MOVES = 9;
    public const int MARK_INDEX_IN_CELL = 0;
    public const string Initial = "Initial";
    public const string Main = "Main";
    public const string UIData = "UIData";
    public const string Data = "Data";
    
    public PlayerMark InitialPlayer = PlayerMark.X;
    public PlayerMark CurrentPlayer;
}