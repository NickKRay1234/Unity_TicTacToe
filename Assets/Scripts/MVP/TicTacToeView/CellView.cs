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
        public CellModel cell;

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
                PlayerMark currentPlayerMark = Presenter.GetCurrentPlayer();

                switch (currentPlayerMark)
                {
                    case PlayerMark.X:
                        _xFactory.GetProduct(transform);
                        break;
                    case PlayerMark.O:
                        _oFactory.GetProduct(transform);
                        break;
                }

#if UNITY_EDITOR
                Debug.Log($"<color=green>x: {cell.X}, y: {cell.Y}</color>");
#endif
                _image.color = Color.green;
                Presenter.OccupyCell(currentPlayerMark);
            }
            else
#if UNITY_EDITOR
                Debug.Log($"<color=red>Cell ({cell.X};{cell.Y}) is occupied</color>");
#endif
        }
    }
}