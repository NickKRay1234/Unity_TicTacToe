using MVP.Model;
using SignFactory;
using UnityEngine;
using UnityEngine.UI;

public class PlaceMarkCommand : ICommand
{
    private CellPresenter _cellPresenter;
    private Transform _parent;
    private CellModel _cell;
    private Image _image;
    private Color _oldColor;
    private PlayerMark _oldPlayerMark;
    private const int MARK_INDEX_IN_CELL = 0;

    public PlaceMarkCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell)
    {
        _cellPresenter = cellPresenter;
        _parent = parent;
        _image = image;
        _cell = cell;
        _oldColor = _image.color;
        _oldPlayerMark = _cellPresenter.GetCurrentPlayer();
    }

    public void Execute()
    {
        PlayerMark currentPlayerMark = _cellPresenter.GetCurrentPlayer();
        X_Factory xFactory = ServiceLocator.Current.Get<X_Factory>();
        O_Factory oFactory = ServiceLocator.Current.Get<O_Factory>();
        switch (currentPlayerMark)
        {
            case PlayerMark.X:
                _cell.Player = PlayerMark.X;
                xFactory.GetProduct(_parent);
                break;
            case PlayerMark.O:
                _cell.Player = PlayerMark.O;
                oFactory.GetProduct(_parent);
                break;
        }

        _image.color = Color.green;
        _cellPresenter.OccupyCell(currentPlayerMark);

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