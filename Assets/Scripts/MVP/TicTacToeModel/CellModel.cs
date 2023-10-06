using UnityEngine;

namespace MVP.Model
{
    public class CellModel 
    {
        public GameObject CellGameObject { get; set; }
        public PlayerMark Player { get; set; } = PlayerMark.None;
        public bool IsOccupied { get; set; } = false;
        public int X { get; }
        public int Y { get; }

        public CellModel(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}