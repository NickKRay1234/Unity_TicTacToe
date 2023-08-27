using SignFactory;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Model
{
    public class CellView : TicTacToeView.View
    {
        [SerializeField] private Button _button;
        private Image _image;
        private X_Factory _xFactory;
        private O_Factory _oFactory;
        public readonly CellPresenter Presenter = new();

        // TODO: Add VContainer right there!
        private void Start()
        {
            _button.onClick.AddListener(PlaceCurrentPlayerMark);
            _image = GetComponent<Image>();
            _xFactory = FindObjectOfType<X_Factory>();
            _oFactory = FindObjectOfType<O_Factory>();
        }

        public void PlaceCurrentPlayerMark()
        {
            if (!Presenter.Model.IsOccupied)
            {
                string currentPlayer = Presenter.GetCurrentPlayer();
                if (currentPlayer == "X")
                    _xFactory.GetProduct(transform.position, transform);
                else if (currentPlayer == "O")
                    _oFactory.GetProduct(transform.position, transform);
#if UNITY_EDITOR
                Debug.Log($"<color=green>x: {Presenter.Model.X}, y: {Presenter.Model.Y}</color>");
#endif
                _image.color = Color.green;
                Presenter.OccupyCell(currentPlayer);
            }
            else
#if UNITY_EDITOR
                Debug.Log($"<color=red>Cell ({Presenter.Model.X};{Presenter.Model.Y}) is occupied</color>");
#endif
        }
    }
}