namespace MVP.Model
{
    public interface ICellModel
    {
        PlayerMark Player { get; set; }
        bool IsOccupied { get; set; }
        int X { get; }
        int Y { get; }
    }
}