using MVP.Model;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerMoveCommand : BaseCommand
{
    public PlayerMoveCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell) 
        : base(cellPresenter, parent, image, cell) { }
    
    protected override PlayerMark GetPlayerMark() => PlayerMark.X;
}