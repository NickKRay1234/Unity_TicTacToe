using SignFactory;
using UnityEngine;

namespace MVP.Model
{
    public class CellView : TicTacToeView.View
    {
        private SpriteRenderer _spriteRenderer;
        private X_Factory _xFactory;
        private O_Factory _oFactory;
        public readonly CellPresenter Presenter = new();

        // TODO: Add VContainer right there!
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _xFactory = FindObjectOfType<X_Factory>();
            _oFactory = FindObjectOfType<O_Factory>();
        }

        private void OnMouseDown()
        {
            if (!Presenter.Model.IsOccupied)
            {
                string currentPlayer = Presenter.GetCurrentPlayer();
                if (currentPlayer == "X")
                    _xFactory.GetProduct(Presenter.GetCurrentCellPosition());
                else if (currentPlayer == "O")
                    _oFactory.GetProduct(Presenter.GetCurrentCellPosition());
#if UNITY_EDITOR
                Debug.Log($"<color=green>x: {Presenter.Model.X}, y: {Presenter.Model.Y}</color>");
#endif
                _spriteRenderer.color = Color.green;
                Presenter.OccupyCell(currentPlayer);
            }
            else
#if UNITY_EDITOR
                Debug.Log($"<color=red>Cell ({Presenter.Model.X};{Presenter.Model.Y}) is occupied</color>");
#endif
        }
    }
}