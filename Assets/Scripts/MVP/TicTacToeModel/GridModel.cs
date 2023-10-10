namespace MVP.Model
{
    public class GridModel
    {
        public readonly CellModel[,] GridCells;

        public GridModel(int gridSize)
        {
            GridCells = new CellModel[gridSize, gridSize];
        }
    }
}