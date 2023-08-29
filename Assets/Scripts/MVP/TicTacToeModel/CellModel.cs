using UnityEngine;

namespace MVP.Model
{
    public class CellModel : Model
    {
        public GameObject CellBody;
        private bool _isOccupied;
        private PlayerMark _player;
        
        public PlayerMark Player { get; set; }
        public int X { get; }
        public int Y { get; }

        public bool IsOccupied => _isOccupied;

        public CellModel(PlayerMark player)
        {
            Player = player;
            _isOccupied = false;
        }
        
        public CellModel(int x, int y, PlayerMark player)
        {
            X = x;
            Y = y;
            Player = player;
            _isOccupied = false;
        }

        public void OccupyCell(PlayerMark player)
        {
            if(!_isOccupied)
            {
                _player = player;
                _isOccupied = true;
            }
        }
        
        public void DeoccupyCell(PlayerMark player)
        {
            if(_isOccupied)
            {
                _player = player;
                _isOccupied = false;
            }
        }
    }

}