using MVP.Model;
using SignFactory;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public abstract class BaseCommand : ICommand
{
    [Inject] protected readonly DesignDataContainer _designDataContainer;
    protected readonly X_Factory _xFactory;
    protected readonly O_Factory _oFactory;
    
    protected readonly CellPresenter _cellPresenter;
    protected readonly Transform _parent;
    protected readonly CellModel _cell;

    protected Transform _lastMoveTransform;
    protected CellModel _lastMoveCell;

    protected BaseCommand(DesignDataContainer designDataContainer, X_Factory xFactory, O_Factory oFactory, CellPresenter cellPresenter, Transform parent, Image image, CellModel cell)
    {
        _designDataContainer = designDataContainer;
        _xFactory = xFactory;
        _oFactory = oFactory;
        _cellPresenter = cellPresenter;
        _parent = parent;
        _cell = cell;
    }
    
    public virtual void Execute()
    {
        PlaceMark(_cell, GetPlayerMark());
        
        _lastMoveTransform = _parent;
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