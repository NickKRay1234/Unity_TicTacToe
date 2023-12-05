using System;
using MVP.Model;
using MVP.TicTacToeView;
using UnityEngine;

namespace MVP.TicTacToePresenter
{
    [HelpURL("https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns")]
    public class GridPresenter
    {
        public GridModel Model { get; }
        public GridView View { get; private set; }

        ///This ensures that both critical components are set upon creation of the GridPresenter.
        public GridPresenter(GridModel model, GridView view)
        {
            Model = model ?? throw new ArgumentException(nameof(model));
            View = view ?? throw new ArgumentException(nameof(view));
        }
    }
}