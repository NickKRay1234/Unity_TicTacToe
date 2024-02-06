using System;
using MVP.Model;
using SignFactory;
using UnityEngine;
using Object = UnityEngine.Object;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public abstract class BaseCommand : ICommand
{
    protected readonly DesignDataContainer _designDataContainer;
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
    
    /// Deoccupies a cell and switches the current player
    public void DeoccupyCell(CellModel model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        if (!model.IsOccupied) return;
        model.OccupyingPlayer = PlayerMark.None;
        model.IsOccupied = false;
        ToggleCurrentPlayer();
    }
    
    /// Toggles between player X and player O
    public void ToggleCurrentPlayer() =>
        _designDataContainer.CurrentPlayer =
            _designDataContainer.CurrentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
    
    private void OccupyCellAndSwitchPlayer(CellModel cell, PlayerMark mark)
    {
        OccupyCell(cell, mark);
        ToggleCurrentPlayer();
    }
    
    /// Occupies a cell with a player's mark if it's not already occupied
    public void OccupyCell(CellModel model, PlayerMark player)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        if (model.IsOccupied) return;
        model.OccupyingPlayer = player;
        model.IsOccupied = true;
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
            DeoccupyCell(_lastMoveCell);
        }
    }
}