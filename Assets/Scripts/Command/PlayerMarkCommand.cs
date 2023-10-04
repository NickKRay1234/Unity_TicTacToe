using MVP.Model;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerMarkCommand : AbstractCommand, ICommand
{
    private Color _oldColor;
    private PlayerMark _oldPlayerMark;
    private const int MARK_INDEX_IN_CELL = 0;

    public PlayerMarkCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell) : base(cellPresenter, parent, image, cell)
    {
        _oldColor = _image.color;
        _oldPlayerMark = _cellPresenter.GetCurrentPlayer();
    }

    public void Execute()
    {
        PlaceMark(_cellPresenter.GetCurrentPlayer());
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