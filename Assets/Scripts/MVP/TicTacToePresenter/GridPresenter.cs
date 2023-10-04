using MVP.Model;
using MVP.TicTacToeView;

namespace MVP.TicTacToePresenter
{
    public class GridPresenter : Presenter.Presenter
    {
        public GridModel Model { get; private set; } = new();
        public GridView View { get; set; }
        
        public CellModel GetGridModel(int x, int y) => Model.GridCells[x,y];

        public void SetView(GridView gridView) => View = gridView;
    }
}