using MVP.Model;
using MVP.TicTacToePresenter;
using SignFactory;
using UnityEngine;

namespace MVP.TicTacToeView
{
    public sealed class GridView : View, IService, IGridCleanable
    {
        private Cell_Factory _cellFactory;

        public GridPresenter GridBasePresenter
        {
            get => BasePresenter as GridPresenter;
            private set => BasePresenter = value;
        }

        private void Start()
        {
            Init(BasePresenter);
            _cellFactory = ServiceLocator.Current.Get<Cell_Factory>();
        }
        
        public void InitializeGrid()
        {
            DesignDataContainer.CurrentPlayer = PlayerMark.X;
            for (int i = 0; i < DesignDataContainer.GRID_SIZE; i++)
                for (int j = 0; j < DesignDataContainer.GRID_SIZE; j++)
                    InitializeGridCell(i, j);
#if UNITY_EDITOR
            Debug.Log($"<color=orange>Initialization ended</color>");
#endif
        }
        
        private void InitializeGridCell(int i, int j)
        {
            if(_cellFactory == null)
                _cellFactory = GetComponent<Cell_Factory>();
            if (BasePresenter == null)
            {
                GridBasePresenter = new GridPresenter();
                GridBasePresenter.SetView(this);
            }
            
            var cellModel = new CellModel(i, j);
            GridBasePresenter.Model.GridCells[i, j] = cellModel;
        
#if UNITY_EDITOR
            Debug.Log($"<color=orange>x: {cellModel.X}, y: {cellModel.Y}</color>");
#endif

            GameObject cellBody = _cellFactory.GetProduct(transform).GetGameObject();
            cellModel.CellGameObject = cellBody;

            CellView cellViewComponent = cellBody.GetComponent<CellView>();
            if (cellViewComponent != null)
                cellViewComponent.cell = cellModel;
        }

        public void Clear()
        {
            for (int i = 0; i < DesignDataContainer.GRID_SIZE; i++)
            for (int j = 0; j < DesignDataContainer.GRID_SIZE; j++)
            {
                GameObject cellBody = GridBasePresenter.Model.GridCells[i, j].CellGameObject;
                if (cellBody) Destroy(cellBody);
            }
        }
    }
}