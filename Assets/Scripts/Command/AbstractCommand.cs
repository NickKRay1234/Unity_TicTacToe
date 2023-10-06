using MVP.Model;
using SignFactory;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractCommand
{
    protected readonly CellPresenter _cellPresenter;
    protected readonly X_Factory _xFactory;
    protected readonly O_Factory _oFactory;
    protected readonly Transform _parent;
    protected readonly CellModel _cell;
    protected readonly Image _image;

    protected AbstractCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell)
    {
        _xFactory = ServiceLocator.Current.Get<X_Factory>();
        _oFactory = ServiceLocator.Current.Get<O_Factory>();
        _cellPresenter = cellPresenter;
        _parent = parent;
        _image = image;
        _cell = cell;
    }
    
    protected void PlaceMark(PlayerMark mark, CellModel cellModel)
    {
        _cellPresenter.OccupyCell(mark, cellModel);
        if (mark == PlayerMark.X)
            _xFactory.GetProduct(_parent);
        else if (mark == PlayerMark.O)
            _oFactory.GetProduct(_parent);
#if UNITY_EDITOR
        Debug.Log($"<color=green>[X,Y]: [{_cell.X}, {_cell.Y}]</color>");
#endif
    }
    
    protected void PlaceMark(CellModel cell, PlayerMark mark, Transform parent)
    {
        _cellPresenter.OccupyCell(cell, mark);
        if (mark != PlayerMark.X)
            _oFactory.GetProduct(parent);
        else
            _xFactory.GetProduct(parent);
#if UNITY_EDITOR
        Debug.Log($"<color=green>X,Y]: [{_cell.X}, {_cell.Y}]</color>");
#endif
    }
}