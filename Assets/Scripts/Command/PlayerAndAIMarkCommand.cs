using MVP.Model;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public sealed class PlayerAndAIMarkCommand : AbstractCommand, ICommand
{
    private HeuristicAI _heuristicAI;

    // Player's last move details
    private Transform _aiLastMoveTransform;
    private Image _aiLastMoveImage;
    private PlayerMark _aiLastMoveMark;
    private CellModel _aiLastMoveCell;

    // AI's last move details
    private Transform _playerLastMoveTransform;
    private Image _playerLastMoveImage;
    private PlayerMark _playerLastMoveMark;
    private CellModel _playerLastMoveCell;

    public PlayerAndAIMarkCommand(CellPresenter cellPresenter, Transform parent, Image image, CellModel cell) : base(
        cellPresenter, parent, image, cell) =>
        _heuristicAI = new HeuristicAI();

    public void Execute()
    {
        PlayerMove();
        AIMove();
    }

    private void PlayerMove()
    {
        PlaceMark(PlayerMark.X, _cell);
        _playerLastMoveTransform = _parent;
        _playerLastMoveImage = _image;
        _playerLastMoveMark = PlayerMark.X;
        _playerLastMoveCell = _cell;
    }

    private void AIMove()
    {
        CellModel bestMove = _heuristicAI.GetAvailableBestMove();
        if (bestMove == null) return;

        Transform parent = bestMove.CellGameObject.transform;
        Image cellBackground = bestMove.CellGameObject.GetComponent<Image>();
        PlaceMark(bestMove, PlayerMark.O, parent);
        _aiLastMoveTransform = parent;
        _aiLastMoveImage = cellBackground;
        _aiLastMoveMark = PlayerMark.O;
        _aiLastMoveCell = bestMove;
    }

    public void Undo()
    {
        UndoMove(_aiLastMoveTransform, _aiLastMoveCell);
        UndoMove(_playerLastMoveTransform, _playerLastMoveCell);
    }

    private void UndoMove(Transform moveTransform, CellModel moveCell)
    {
        Object.Destroy(moveTransform.GetChild(0).gameObject);
        _cellPresenter.DeoccupyCell(moveCell);
    }
}