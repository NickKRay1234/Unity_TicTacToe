using MVP.Model;
using SignFactory;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCommand : ICommand
{
    protected readonly CellPresenter _cellPresenter;
    protected readonly X_Factory _xFactory;
    protected readonly O_Factory _oFactory;
    protected readonly Transform _parent;
    protected readonly CellModel _cell;
    protected readonly Image _image;
    
    protected Transform _lastMoveTransform;
    protected Image _lastMoveImage;
    protected CellModel _lastMoveCell;

    protected BaseCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell)
    {
        _xFactory = ServiceLocator.Current.Get<X_Factory>();
        _oFactory = ServiceLocator.Current.Get<O_Factory>();
        _cellPresenter = cellPresenter;
        _parent = parent;
        _image = image;
        _cell = cell;
    }
    
    public virtual void Execute()
    {
        PlaceMark(_cell, GetPlayerMark());
        _lastMoveTransform = _parent;
        _lastMoveImage = _image;
        _lastMoveCell = _cell;
    }
    
    public virtual void Undo() => UndoMove(_lastMoveTransform, _lastMoveCell);

    protected abstract PlayerMark GetPlayerMark();

    protected void PlaceMark(CellModel cell, PlayerMark mark, Transform parent = null)
    {
        _cellPresenter.OccupyCell(cell, mark);
        _cellPresenter.SwitchPlayer();
        if (parent == null)
            parent = _parent;

        if (mark != PlayerMark.X)
            _oFactory.GetProduct(parent);
        else
            _xFactory.GetProduct(parent);
    }
    
    protected void UndoMove(Transform moveTransform, CellModel moveCell)
    {
        Object.Destroy(moveTransform.GetChild(0).gameObject);
        _cellPresenter.DeoccupyCell(moveCell);
    }
}