﻿using MVP.Model;
using MVP.Presenter;
using MVP.TicTacToeView;

namespace MVP.TicTacToePresenter
{
    public class GridPresenter : BasePresenter
    {
        public GridModel Model { get; } = new();
        public GridView View { get; set; }

        public void SetView(GridView gridView) => View = gridView;
    }
}