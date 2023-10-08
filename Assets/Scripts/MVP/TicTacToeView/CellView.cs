using MVP.TicTacToeView;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MVP.Model
{
    public class CellView : View
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        public readonly CellPresenter Presenter = new();
        [Inject] private CommandInvoker _invoker;
        public CellModel Cell;


        private void Start() => _button.onClick.AddListener(PlaceCurrentPlayerMark);

        public void PlaceCurrentPlayerMark()
        {
            if (!Cell.IsOccupied)
            {
                if (_invoker.IsGameWithAI)
                    _invoker.Execute(new CompositeCommand(new PlayerMoveCommand(Presenter, transform, _image, Cell), new AIMoveCommand(Presenter, transform, _image, Cell)));
                else 
                    _invoker.Execute(new PlayerMarkCommand(Presenter, transform, _image, Cell));
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log($"<color=red>Cell is occupied</color>");
#endif
            }
        }
    }
}