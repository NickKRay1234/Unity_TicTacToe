using UnityEngine;

namespace MVP.Model
{
    [HelpURL("https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns")]
    public class GridModel
    {
        public readonly CellModel[,] GridCells;
        public GridModel(int gridSize) => GridCells = new CellModel[gridSize, gridSize];
    }
}