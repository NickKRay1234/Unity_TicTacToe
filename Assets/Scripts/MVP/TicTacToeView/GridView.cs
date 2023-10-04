using MVP.Model;
using MVP.TicTacToePresenter;
using SignFactory;
using UnityEngine;

namespace MVP.TicTacToeView
{
    public sealed class GridView : View, IService, IGridCleanable
    {
        private Cell_Factory _cellFactoryInstance;

        public GridPresenter GridPresenter
        {
            get => _presenter as GridPresenter;
            private set => _presenter = value;
        }

        private void Start()
        {
            Init(_presenter);
            _cellFactoryInstance = ServiceLocator.Current.Get<Cell_Factory>();
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
            if(_cellFactoryInstance == null)
                _cellFactoryInstance = GetComponent<Cell_Factory>();
            if (_presenter == null)
            {
                GridPresenter = new GridPresenter();
                GridPresenter.SetView(this);
            }
            
            var cellModel = new CellModel(i, j, PlayerMark.None);
            GridPresenter.Model.GridCells[i, j] = cellModel;
        
#if UNITY_EDITOR
            Debug.Log($"<color=orange>x: {cellModel.X}, y: {cellModel.Y}</color>");
#endif

            GameObject cellBody = _cellFactoryInstance.GetProduct(transform).GetGameObject();
            cellModel.CellGameObject = cellBody;

            CellView cellViewComponent = cellBody.GetComponent<CellView>();
            if (cellViewComponent != null)
                cellViewComponent.cell = cellModel;
        }

        public void Clear()
        {
            for (int i = 0; i < GridModel.GRID_SIZE; i++)
            for (int j = 0; j < GridModel.GRID_SIZE; j++)
            {
                GameObject cellBody = GridPresenter.Model.GridCells[i, j].CellGameObject;
                if (cellBody) Destroy(cellBody);
            }
        }
    }
}