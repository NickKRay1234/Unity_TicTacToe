using System;
using MVP.TicTacToeView;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MVP.Model
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        public CellPresenter Presenter { get; private set; }
        [Inject] private CommandInvoker _invoker;
        [Inject] private HeuristicAI _heuristicAI;
        [Inject] private DesignDataContainer _designDataContainer;
        public CellModel Cell { get; set; }

        
        public void Initialize(CellPresenter presenter) =>
            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));

        private void Start()
        {
            if (Presenter == null) throw new InvalidOperationException("Presenter is not set.");
            _button.onClick.AddListener(PlaceCurrentPlayerMark);
        }

        public void PlaceCurrentPlayerMark()
        {
            if (!Cell.IsOccupied)
            {
                if (_invoker.IsGameWithAI)
                    _invoker.Execute(new CompositeCommand(new PlayerMoveCommand(Presenter, transform, _image, Cell), new AIMoveCommand(Presenter, transform, _image, Cell, _heuristicAI)));
                else 
                    _invoker.Execute(new PlayerMarkCommand(Presenter, transform, _image, Cell, _designDataContainer));
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