using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MVP.Model
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [Inject] private CommandInvoker _invoker;
        [Inject] private HeuristicAI _heuristicAI;
        
        public CellPresenter Presenter { get; private set; }
        public CellModel Cell { get; set; }

        
        public void Initialize(CellPresenter presenter) =>
            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));

        private void Start()
        {
            if (Presenter == null) throw new InvalidOperationException("Presenter is not set.");
            _button.onClick.AddListener(() => Presenter.PlaceCurrentPlayerMark(Cell, transform, _image, _invoker.IsGameWithAI, _invoker, _heuristicAI));
        }
    }
}