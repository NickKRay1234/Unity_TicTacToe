using UnityEngine;

namespace MVP.Model
{
    public class CellModel : Model
    {
        public GameObject CellGameObject;
        public PlayerMark Player;
        
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsOccupied { get; set; }

        public CellModel()
        {
            Player = PlayerMark.None;
            IsOccupied = false;
        }
        
        public CellModel(int x, int y, PlayerMark player)
        {
            X = x;
            Y = y;
            Player = player;
            IsOccupied = false;
        }

        public void OccupyCell(PlayerMark player)
        {
            if(!IsOccupied)
            {
                Player = player;
                IsOccupied = true;
            }
        }
        
        public void DeoccupyCell(PlayerMark player)
        {
            if(IsOccupied)
            {
                Player = player;
                IsOccupied = false;
            }
        }
    }

}