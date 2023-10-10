using MVP.Model;
using MVP.TicTacToePresenter;
using SignFactory;
using UnityEngine;

namespace MVP.TicTacToeView
{
    public sealed class GridView : View, IGridCleanable
    {
        public GridPresenter Presenter
        {
            get => BasePresenter as GridPresenter;
            private set => BasePresenter = value;
        }

        private void Start()
        {
            if (Presenter == null)
            {
                Presenter = new GridPresenter();
                Presenter.SetView(this);
            }
            Init(Presenter);
            
        }

        public void InitializeGrid()
        {
            DesignDataContainer.CurrentPlayer = PlayerMark.X;
            for (int i = 0; i < DesignDataContainer.GRID_SIZE; i++)
                for (int j = 0; j < DesignDataContainer.GRID_SIZE; j++)
                    InitializeGridCell(i, j);
        }
        
        private void InitializeGridCell(int i, int j)
        {
            if (BasePresenter == null)
            {
                Presenter = new GridPresenter();
                Presenter.SetView(this);
            }
            
            var cellModel = new CellModel(i, j);
            Presenter.Model.GridCells[i, j] = cellModel;
            IProduct product = DesignDataContainer.GlobalCellFactory.GetProduct(transform);
            GameObject cellBody = product.GetGameObject();
            cellModel.CellObject = cellBody;

            CellView cellViewComponent = cellBody.GetComponent<CellView>();
            if (cellViewComponent != null)
                cellViewComponent.Cell = cellModel;
        }

        public void Clear()
        {
            for (int i = 0; i < DesignDataContainer.GRID_SIZE; i++)
            for (int j = 0; j < DesignDataContainer.GRID_SIZE; j++)
            {
                GameObject cellBody = Presenter.Model.GridCells[i, j].CellObject;
                if (cellBody) Destroy(cellBody);
            }
        }
    }
}