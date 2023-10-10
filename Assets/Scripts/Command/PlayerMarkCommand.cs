using MVP.Model;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public sealed class PlayerMarkCommand : BaseCommand
{
    private DesignDataContainer _designDataContainer;

    public PlayerMarkCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell, DesignDataContainer designDataContainer) : base(cellPresenter, parent, image, cell)
    {
        _designDataContainer = designDataContainer;
    }
    
    protected override PlayerMark GetPlayerMark() => _designDataContainer.CurrentPlayer;
    
}