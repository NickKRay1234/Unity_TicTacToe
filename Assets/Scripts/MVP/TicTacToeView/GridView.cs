using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using SignFactory;
using UnityEngine;

namespace MVP.TicTacToeView
{
    public sealed class GridView : View, IDisposable
    {
        private GridPresenter _gridPresenter;
        private Cell_Factory _cellFactoryInstance;

        public GridView(GridPresenter presenter)
        {
            _gridPresenter = presenter;
        }

        private void Start()
        {
            _cellFactoryInstance = GetComponent<Cell_Factory>();
            if (_presenter == null)
            {
                _gridPresenter = new GridPresenter();
                _gridPresenter.SetView(this);
            }
            InitializeGrid();
        }
        
        private void InitializeGrid()
        {
            for (int i = 0; i < GridModel.GridSize; i++)
                for (int j = 0; j < GridModel.GridSize; j++)
                    InitializeGridCell(i, j);
        
#if UNITY_EDITOR
            Debug.Log($"<color=orange>Initialization ended</color>");
#endif
        }
        
        private void InitializeGridCell(int i, int j)
        {
            var cellModel = new CellModel(i, j);
            _gridPresenter.Model.GridCells[i, j] = cellModel;
        
#if UNITY_EDITOR
            Debug.Log($"<color=orange>x: {cellModel.X}, y: {cellModel.Y}</color>");
#endif

            GameObject cellBody = _cellFactoryInstance.GetProduct(transform).GetGameObject();
            cellModel.CellBody = cellBody;

            CellView cellViewComponent = cellBody.GetComponent<CellView>();
            if (cellViewComponent != null)
                cellViewComponent.cell = cellModel;
        }

        public void Dispose()
        {
            for (int i = 0; i < GridModel.GridSize; i++)
            for (int j = 0; j < GridModel.GridSize; j++)
            {
                GameObject cellBody = _gridPresenter.Model.GridCells[i, j].CellBody;
                if (cellBody) Destroy(cellBody);
            }
        }
    }
}