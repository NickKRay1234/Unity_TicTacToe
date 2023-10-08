using MVP.Model;
using UnityEngine;
using UnityEngine.UI;

public sealed class AIMoveCommand : BaseCommand
{
    private readonly HeuristicAI _heuristicAI; // AI algorithm to find the best move.
    public AIMoveCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell)
        : base(cellPresenter, parent, image, cell)
    {
        _heuristicAI = Object.FindObjectOfType<HeuristicAI>(); // Find the AI object in the scene.
    }

    public override void Execute()
    {
        CellModel bestMove = _heuristicAI.GetAvailableBestMove();
        if (bestMove == null) return;

        Transform parent = bestMove.CellGameObject.transform;
        Image cellBackground = bestMove.CellGameObject.GetComponent<Image>();
        PlaceMark(bestMove, PlayerMark.O, parent); // Place AI's mark (typically 'O') on the board.
        _lastMoveTransform = parent;
        _lastMoveImage = cellBackground;
        _lastMoveCell = bestMove;
    }

    protected override PlayerMark GetPlayerMark() => PlayerMark.O;
}