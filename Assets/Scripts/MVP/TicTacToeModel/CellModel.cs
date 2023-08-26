﻿namespace MVP.Model
{
    public class CellModel : Model
    {
        private bool _isOccupied;
        private string _player; // "X", "O" или ""

        public int X { get; }

        public int Y { get; }

        public bool IsOccupied => _isOccupied;
        public string Player => _player;

        public CellModel()
        {
            _player = "";
            _isOccupied = false;
        }
        
        public CellModel(int x, int y)
        {
            X = x;
            Y = y;
            _player = "";
            _isOccupied = false;
        }

        public void OccupyCell(string player)
        {
            if(!_isOccupied)
            {
                _player = player;
                _isOccupied = true;
            }
        }
    }

}