﻿using MVP.Model;
using SignFactory;
using UnityEngine;
using UnityEngine.UI;

[HelpURL("https://unity.com/how-to/use-command-pattern-flexible-and-extensible-game-systems")]
public sealed class AIMoveCommand : BaseCommand
{
    private readonly HeuristicAI _heuristicAI;

    public AIMoveCommand(
        DesignDataContainer designDataContainer,
        X_Factory xFactory,
        O_Factory oFactory,
        CellPresenter cellPresenter,
        Transform parent,
        Image image,
        CellModel cell,
        HeuristicAI heuristicAI
    ) : base(designDataContainer, xFactory, oFactory, cellPresenter, parent, image, cell) =>
        _heuristicAI = heuristicAI;

    public override void Execute()
    {
        CellModel bestMove = _heuristicAI.GetAvailableBestMove();
        if (bestMove == null) return;
        PlaceMark(bestMove, PlayerMark.O, bestMove.CellObject.transform);
        _lastMoveTransform = bestMove.CellObject.transform;
        _lastMoveCell = bestMove;
    }
    
    protected override PlayerMark GetPlayerMark() => PlayerMark.O;
}