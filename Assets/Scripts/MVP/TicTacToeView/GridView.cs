using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using SignFactory;
using UnityEngine;

namespace MVP.TicTacToeView
{
    public class GridView : View, IDisposable
    {
        private GridPresenter _gridPresenter;
        private Cell_Factory _cellFactoryInstance;

        public GridView(GridPresenter presenter, Cell_Factory cellFactory)
        {
            _gridPresenter = presenter;
            _cellFactoryInstance = cellFactory;
        }
        
        // TODO: VContainer
        private void Start()
        {
            if (_presenter == null) 
            {
                _gridPresenter = new GridPresenter();
                _gridPresenter.SetView(this);
            }
            _cellFactoryInstance = _cellFactoryInstance ?? FindObjectOfType<Cell_Factory>();
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