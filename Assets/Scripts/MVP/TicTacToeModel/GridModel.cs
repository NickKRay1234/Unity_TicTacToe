namespace MVP.Model
{
    public class GridModel : Model
    {
        public readonly CellModel[,] GridCells = new CellModel[DesignDataContainer.GRID_SIZE,DesignDataContainer.GRID_SIZE];
    }
}