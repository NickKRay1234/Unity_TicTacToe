using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using SignFactory;
using UnityEngine;

namespace MVP.TicTacToeView
{
    public sealed class GridView : View, IDisposable, IService
    {
        private Cell_Factory _cellFactoryInstance;
        
        public GridPresenter GridPresenter { get; private set; }

        public GridView(GridPresenter presenter)
        {
            GridPresenter = presenter;
        }

        private void Start()
        {
            _cellFactoryInstance = GetComponent<Cell_Factory>();
            if (_presenter == null)
            {
                GridPresenter = new GridPresenter();
                GridPresenter.SetView(this);
            }
            InitializeGrid();
        }
        
        public void InitializeGrid()
        {
            CellPresenter.CurrentPlayer = PlayerMark.X;
            for (int i = 0; i < GridModel.GRID_SIZE; i++)
                for (int j = 0; j < GridModel.GRID_SIZE; j++)
                    InitializeGridCell(i, j);
        
#if UNITY_EDITOR
            Debug.Log($"<color=orange>Initialization ended</color>");
#endif
        }
        
        private void InitializeGridCell(int i, int j)
        {
            var cellModel = new CellModel(i, j, PlayerMark.None);
            GridPresenter.Model.GridCells[i, j] = cellModel;
        
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
            for (int i = 0; i < GridModel.GRID_SIZE; i++)
            for (int j = 0; j < GridModel.GRID_SIZE; j++)
            {
                GameObject cellBody = GridPresenter.Model.GridCells[i, j].CellBody;
                if (cellBody) Destroy(cellBody);
            }
        }
    }
}