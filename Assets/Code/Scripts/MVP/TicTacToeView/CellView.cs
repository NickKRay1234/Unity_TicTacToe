using System;
using UnityEngine;
using UnityEngine.UI;
namespace MVP.Model
{
    [HelpURL("https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns")]
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        public CellPresenter Presenter { get; set; }

        private void OnEnable() => Initialize(Presenter);

        public void Initialize(CellPresenter presenter)
        {
            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            _button.onClick.AddListener(OnCellClicked);
        }
        
        private void OnCellClicked() => Presenter.CellClicked();
    }
}