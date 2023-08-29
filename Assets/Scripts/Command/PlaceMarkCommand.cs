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
    
    public PlaceMarkCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell)
    {
        _cellPresenter = cellPresenter;
        _parent = parent;
        _image = image;
        _cell = cell;
    }

    public void Execute()
    {
        if (!_cellPresenter.Model.IsOccupied)
        {
            PlayerMark currentPlayerMark = _cellPresenter.GetCurrentPlayer();
            X_Factory xFactory = ServiceLocator.Current.Get<X_Factory>();
            O_Factory oFactory = ServiceLocator.Current.Get<O_Factory>();
            switch (currentPlayerMark)
            {
                case PlayerMark.X:
                    xFactory.GetProduct(_parent);
                    break;
                case PlayerMark.O:
                    oFactory.GetProduct(_parent);
                    break;
            }

            _image.color = Color.green;
            _cellPresenter.OccupyCell(currentPlayerMark);
            
#if UNITY_EDITOR
            Debug.Log($"<color=green>x: {_cell.X}, y: {_cell.Y}</color>");
#endif
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log($"<color=red>Cell ({_cell.X};{_cell.Y}) is occupied</color>");
#endif
        }
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }
}