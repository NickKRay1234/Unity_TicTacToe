using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MVP.Model
{
    [HelpURL("https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns")]
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [Inject] private CommandInvoker _invoker;
        [Inject] private HeuristicStrategyAI _heuristicStrategyAI;
        private CommandFactory _commandFactory;
        
        public CellPresenter Presenter { get; private set; }
        public CellModel Cell { get; set; }

        
        public void Initialize(CellPresenter presenter, CommandFactory commandFactory)
        {
            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            _commandFactory = commandFactory;
        }

        private void Start()
        {
            if (Presenter == null) throw new InvalidOperationException("Presenter is not set.");
            _button.onClick.AddListener(() => Presenter.PlaceMarkIfCellFree(Cell, transform, _invoker,_commandFactory, _invoker.IsGameWithAI, _heuristicStrategyAI));
        }
    }
}