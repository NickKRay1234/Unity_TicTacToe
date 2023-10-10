namespace MVP.Model
{
    public class GridModel
    {
        public const int GRID_SIZE = 3;
        public readonly CellModel[,] GridCells = new CellModel[GRID_SIZE,GRID_SIZE];
    }
}