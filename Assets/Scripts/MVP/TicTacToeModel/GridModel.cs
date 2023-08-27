using UnityEngine;

namespace MVP.Model
{
    public class GridModel : Model
    {
        public readonly int GridSize = 3;
        public GameObject[,] GridCells;
    }
}