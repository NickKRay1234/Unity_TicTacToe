using UnityEngine;

namespace MVP.Model
{
    [HelpURL("https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns")]
    public class CellModel 
    {
        public GameObject CellObject { get; set; }
        public PlayerMark OccupyingPlayer { get; set; } = PlayerMark.None;
        public bool IsOccupied { get; set; }
        public int X { get; }
        public int Y { get; }

        public CellModel(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}