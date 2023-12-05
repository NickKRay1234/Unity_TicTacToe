using MVP.Model;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "DesignDataContainer", order = 1)]
public class DesignDataContainer : ScriptableObject
{
    [Range(3, 6)] public int GRID_SIZE = 3;
    [Range(3, 6)] public int WIN_LINE = 3;
    
    public const int MAX_NUMBER_OF_MOVES = 9;
    public const int MARK_INDEX_IN_CELL = 0;
    
    public const string Initial = "Initial";
    public const string Main = "Main";
    public const string UIData = "UIData";
    public const string Data = "Data";
    
    public const string LoadingText = "You don't have to say a word, because your actions speak volumes for you";

    public static readonly int[,] Corners = { { 0, 0 }, { 0, 2 }, { 2, 0 }, { 2, 2 } };
    public const int MaxAttempts = 10;
    public const int CenterX = 1;
    public const int CenterY = 1;
    
    public PlayerMark InitialPlayer = PlayerMark.X;
    public PlayerMark CurrentPlayer;
    
    [Space] [Header("Players Score: ")]
    public int Player1Score = 0;
    public int Player2Score = 0;
}