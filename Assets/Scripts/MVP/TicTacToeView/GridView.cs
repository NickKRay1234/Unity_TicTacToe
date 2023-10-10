using MVP.Model;
using MVP.TicTacToePresenter;
using SignFactory;
using UnityEngine;

namespace MVP.TicTacToeView
{
    public sealed class GridView : View, IGridCleanable
    {
        // Using a property to cast the base presenter to GridPresenter.
        // This ensures that the GridView always works with a GridPresenter instance.
        public GridPresenter Presenter
        {
            get => BasePresenter as GridPresenter;
            private set => BasePresenter = value;
        }

        private void Awake()
        {
            // Presenter is initialized before the game starts.
            Presenter ??= new GridPresenter(new GridModel(), this);
        }

        private void Start() => Init(Presenter);

        public void InitializeGrid()
        {
            DesignDataContainer.CurrentPlayer = PlayerMark.X;
            for (int i = 0; i < DesignDataContainer.GRID_SIZE; i++)
                for (int j = 0; j < DesignDataContainer.GRID_SIZE; j++)
                    InitializeGridCell(i, j);
        }
        
        private void InitializeGridCell(int i, int j)
        {
            var cellModel = new CellModel(i, j);
            Presenter.Model.GridCells[i, j] = cellModel;
            
            // Using a global factory to produce cells.
            IProduct product = DesignDataContainer.GlobalCellFactory.GetProduct(transform);
            GameObject cellBody = product.GetGameObject();
            cellModel.CellObject = cellBody;

            // Linking the cell view component with its corresponding model.
            CellView cellViewComponent = cellBody.GetComponent<CellView>();
            if (cellViewComponent != null)
                cellViewComponent.Cell = cellModel;
        }

        public void Clear()
        {
            // Destroying each cell game object in the grid.
            for (int i = 0; i < DesignDataContainer.GRID_SIZE; i++)
            for (int j = 0; j < DesignDataContainer.GRID_SIZE; j++)
            {
                GameObject cellBody = Presenter.Model.GridCells[i, j].CellObject;
                if (cellBody)
                {
                    Destroy(cellBody);
                    Presenter.Model.GridCells[i, j].CellObject = null; // Reset the reference to the object after its destruction
                }
            }
        }
    }
}