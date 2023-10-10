namespace MVP.Model
{
    public interface ICellStateChangeable
    {
        void OccupyCell(CellModel model, PlayerMark player);
        void DeoccupyCell(CellModel model);
    }
}