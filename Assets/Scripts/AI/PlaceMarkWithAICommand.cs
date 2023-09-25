using MVP.Model;
using MVP.TicTacToePresenter;
using MVP.TicTacToeView;
using SignFactory;
using UnityEngine;
using UnityEngine.UI;

public class PlaceMarkWithAICommand : ICommand
{
    private CellPresenter _cellPresenter;
    private Transform _parent;
    private CellModel _cell;
    private Image _image;
    private Color _oldColor;
    private PlayerMark _oldPlayerMark;
    private const int MARK_INDEX_IN_CELL = 0;
    private Referee _referee;
    private GridPresenter _presenter;
    
    
    public void Execute()
    {
        O_Factory oFactory = ServiceLocator.Current.Get<O_Factory>();
        GridView view = ServiceLocator.Current.Get<GridView>();
        CellModel[,] test = new CellModel[GridModel.GRID_SIZE,GridModel.GRID_SIZE];
        test = view.GridPresenter.Model.GridCells;
        if (test.Length > 0)
        {
            CellModel cell = ServiceLocator.Current.Get<MiniMax>().FindBestMove(test);
                cell.X = ServiceLocator.Current.Get<MiniMax>().FindBestMove(test).X;
                cell.Y = ServiceLocator.Current.Get<MiniMax>().FindBestMove(test).Y;
            Debug.Log($"Step: X: {cell.X}, Y: {cell.Y}" );
            oFactory.GetProduct(test[cell.X, cell.Y].CellBody.transform);
        }
#if UNITY_EDITOR
        Debug.Log($"<color=green>x: {_cell.X}, y: {_cell.Y}</color>");
#endif
    }

    public void Undo()
    {
        Object.Destroy(_parent.GetChild(MARK_INDEX_IN_CELL).gameObject);
        _cellPresenter.DeoccupyCell(_oldPlayerMark);
        _image.color = _oldColor;
    }
}