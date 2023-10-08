using MVP.Model;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerMarkCommand : BaseCommand
{

    public PlayerMarkCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell) 
        : base(cellPresenter, parent, image, cell) {}
    
    protected override PlayerMark GetPlayerMark() => DesignDataContainer.CurrentPlayer;
    
}