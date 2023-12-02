using MVP.Model;
using SignFactory;
using UnityEngine;
using UnityEngine.UI;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public sealed class PlayerMoveCommand : BaseCommand
{
    public PlayerMoveCommand(DesignDataContainer designDataContainer, X_Factory xFactory, O_Factory oFactory, CellPresenter cellPresenter, Transform parent, Image image, CellModel cell) 
        : base(designDataContainer, xFactory, oFactory, cellPresenter, parent, image, cell) { }
    
    protected override PlayerMark GetPlayerMark() => PlayerMark.X;
}