using System;
using MVP.TicTacToePresenter;
using UnityEngine;

namespace MVP.TicTacToeView
{
    public class GridView : View, IDisposable
    {
        [SerializeField] private GameObject cellPrefab;
        private GridPresenter presenter;

        private void Start()
        {
            if (presenter == null) 
            {
                presenter = new GridPresenter();
                presenter.SetView(this);
            }
            InitializeGrid();
        }

        // TODO: Add Factory
        private void InitializeGrid()
        {
            presenter.Model.GridCells = new GameObject[presenter.Model.GridSize, presenter.Model.GridSize];
            for (int i = 0; i < presenter.Model.GridSize; i++)
                for (int j = 0; j < presenter.Model.GridSize; j++)
                {
                    presenter.Model.GridCells[i, j] = 
                        Instantiate(cellPrefab, new Vector2(i,j), Quaternion.identity, transform);
                }
        }

        public void Dispose()
        {
            for (int i = 0; i < presenter.Model.GridSize; i++)
            for (int j = 0; j < presenter.Model.GridSize; j++)
                if(presenter.Model.GridCells[i, j])
                    Destroy(presenter.Model.GridCells[i, j]);
        }
    }
}