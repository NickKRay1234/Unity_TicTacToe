namespace MVP.Model
{
    public class GridModel : Model
    {
        public const int GRID_SIZE = 3;
        public readonly CellModel[,] GridCells = new CellModel[GRID_SIZE,GRID_SIZE];
    }
}