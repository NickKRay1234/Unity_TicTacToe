using MVP.Model;
using SignFactory;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerMarkCommand : BaseCommand
{
    public PlayerMarkCommand(DesignDataContainer designDataContainer, X_Factory xFactory, O_Factory oFactory, CellPresenter cellPresenter, Transform parent, Image image, CellModel cell) 
        : base(designDataContainer, xFactory, oFactory, cellPresenter, parent, image, cell) { }
    
    protected override PlayerMark GetPlayerMark() => _designDataContainer.CurrentPlayer;
    
}