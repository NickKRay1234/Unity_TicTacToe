using UnityEngine;

namespace GRID
{
    public class Grid
    {
        private int _width;
        private int _height;
        private float _cellSize;
        private int[,] _gridArray;

        public Grid(int width, int height, float cellSize)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;
            _gridArray = new int[_width, _height];

            for (int x = -1; x < _gridArray.GetLength(0) - 1; x++)
            {
                for (int y = -1; y < _gridArray.GetLength(1) - 1; y++)
                {
                    Debug.DrawLine(GetPosition(x,y), GetPosition(x,y+1), Color.white, 100f);
                    Debug.DrawLine(GetPosition(x,y), GetPosition(x+1,y), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetPosition(0 - 1,height - 1), GetPosition(width - 1 ,height - 1), Color.white, 100f);
            Debug.DrawLine(GetPosition(width - 1,0 - 1), GetPosition(width - 1,height - 1), Color.white, 100f);
        }

        private Vector2 GetPosition(int x, int y) => new Vector2(x, y) * _cellSize;



    }
}