﻿using UnityEngine;
using UnityEngine.UI;

namespace MVP.Model
{
    public class CellView : TicTacToeView.View, IService
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        public readonly CellPresenter Presenter = new();
        public CellModel cell;

        private void Start() => _button.onClick.AddListener(PlaceCurrentPlayerMark);

        public void PlaceCurrentPlayerMark()
        {
            CommandInvoker invoker = ServiceLocator.Current.Get<CommandInvoker>();
            invoker.Execute(new PlaceMarkCommand(Presenter, transform, _image, cell));
        }
    }
}