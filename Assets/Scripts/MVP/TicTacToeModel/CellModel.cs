using SignFactory;
using UnityEngine;

namespace MVP.Model
{
    public class CellModel : Model
    {
        public IProduct Cell;
        public GameObject CellBody;
        private bool _isOccupied;
        private PlayerMark _player;

        public int X { get; }

        public int Y { get; }

        public bool IsOccupied => _isOccupied;
        public PlayerMark Player => _player;

        public CellModel()
        {
            _isOccupied = false;
        }
        
        public CellModel(int x, int y)
        {
            X = x;
            Y = y;
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
    }

}