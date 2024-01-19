using MVP.Model;
using SignFactory;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public abstract class BaseCommand : ICommand
{
    [Inject] protected readonly DesignDataContainer _designDataContainer;
    protected readonly CellPresenter _cellPresenter;
    protected Transform _lastMoveTransform;
    protected readonly X_Factory _xFactory;
    protected readonly O_Factory _oFactory;
    protected readonly Transform _parent;
    protected readonly CellModel _cell;
    protected CellModel _lastMoveCell;
    
    protected BaseCommand(CommandParameters parameters)
    {
        _designDataContainer = parameters.DesignDataContainer;
        _xFactory = parameters.XFactory;
        _oFactory = parameters.OFactory;
        _cellPresenter = parameters.CellPresenter;
        _parent = parameters.Parent;
        _cell = parameters.Cell;
    }

    public virtual void Execute() => PlaceMarkAndHandleLastMove(_cell, GetPlayerMark(), _parent);
    
    /// Place the mark and process the last move
    protected void PlaceMarkAndHandleLastMove(CellModel cell, PlayerMark mark, Transform parent)
    {
        OccupyCellAndSwitchPlayer(cell, mark);
        CreateAndPlaceMark(parent, mark);
        UpdateLastMove(cell, parent);
    }

    private void OccupyCellAndSwitchPlayer(CellModel cell, PlayerMark mark)
    {
        _cellPresenter.OccupyCell(cell, mark);
        _cellPresenter.ToggleCurrentPlayer();
    }

    private void CreateAndPlaceMark(Transform parent, PlayerMark mark)
    {
        IMarkFactory factory = mark != PlayerMark.X ? _oFactory : _xFactory;
        factory.GetProduct(parent);
    }

    protected void UpdateLastMove(CellModel cell, Transform parent)
    {
        _lastMoveTransform = parent;
        _lastMoveCell = cell;
    }

    public virtual void Undo() => UndoMove();

    protected abstract PlayerMark GetPlayerMark();

    protected void UndoMove()
    {
        // Deleting the object of the last move and clearing the cell
        if (_lastMoveTransform.childCount > 0)
        {
            Object.Destroy(_lastMoveTransform.GetChild(0).gameObject);
            _cellPresenter.DeoccupyCell(_lastMoveCell);
        }
    }
}