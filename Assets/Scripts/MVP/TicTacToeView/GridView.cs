using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using UnityEngine;

namespace MVP.TicTacToeView
{
    public class GridView : View, IDisposable
    {
        [SerializeField] private GameObject cellPrefab;
        private new GridPresenter _presenter;
        private CellPresenter _cellPresenter;

        private void Start()
        {
            if (_presenter == null) 
            {
                _presenter = new GridPresenter();
                _presenter.SetView(this);
            }
            InitializeGrid();
        }

        // TODO: Add Factory
        private void InitializeGrid()
        {
            for (int i = 0; i < GridModel.GridSize; i++)
                for (int j = 0; j < GridModel.GridSize; j++)
                {
                    _presenter.Model.GridCells[i, j] = new CellModel(i,j);
#if UNITY_EDITOR
                    Debug.Log($"<color=orange>x: {_presenter.Model.GridCells[i, j].X}, y: {_presenter.Model.GridCells[i, j].Y}</color>");
#endif
                    _presenter.Model.GridCells[i, j].Cell = Instantiate(cellPrefab, new Vector3(0,0,0), Quaternion.identity, transform);
                    _presenter.Model.GridCells[i, j].Cell.GetComponent<CellView>().cell = _presenter.Model.GridCells[i, j];
                }
#if UNITY_EDITOR
            Debug.Log($"<color=orange>Initialization ended</color>");
#endif
        }

        public void Dispose()
        {
            for (int i = 0; i < GridModel.GridSize; i++)
            for (int j = 0; j < GridModel.GridSize; j++)
                if(_presenter.Model.GridCells[i, j].Cell)
                    Destroy(_presenter.Model.GridCells[i, j].Cell);
        }
    }
}