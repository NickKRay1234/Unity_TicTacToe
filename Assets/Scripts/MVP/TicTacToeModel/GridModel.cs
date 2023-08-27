using UnityEngine;

namespace MVP.Model
{
    public class GridModel : Model
    {
        public const int GridSize = 3;
        public readonly CellModel[,] GridCells = new CellModel[GridSize,GridSize];
    }
}