using MVP.Model;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerMarkCommand : BaseCommand, ICommand
{

    public PlayerMarkCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell) : base(cellPresenter, parent, image, cell) {}

    public void Execute()
    {
        PlaceMark(DesignDataContainer.CurrentPlayer, _cell);
#if UNITY_EDITOR
        Debug.Log($"<color=green>x: {_cell.X}, y: {_cell.Y}</color>");
#endif
    }

    public void Undo()
    {
        Object.Destroy(_parent.GetChild(DesignDataContainer.MARK_INDEX_IN_CELL).gameObject);
        _cellPresenter.DeoccupyCell(_cell);
    }
}