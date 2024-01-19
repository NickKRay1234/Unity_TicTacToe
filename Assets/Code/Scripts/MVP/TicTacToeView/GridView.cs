using System;
using MVP.Model;
using MVP.TicTacToePresenter;
using SignFactory;
using UnityEngine;
using VContainer;

namespace MVP.TicTacToeView
{
    [HelpURL("https://unity.com/how-to/build-modular-codebase-mvc-and-mvp-programming-patterns")]
    public sealed class GridView : MonoBehaviour, IGridCleanable
    {
        [Inject] private DesignDataContainer _designDataContainer;
        [Inject] private Cell_Factory _cellFactory;
        [Inject] private X_Factory _xFactory;
        [Inject] private O_Factory _oFactory;
        
        private GridPresenter _presenter;
        public GridPresenter Presenter
        {
            get => _presenter;
            private set => _presenter = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        /// Initializes the grid with cells
        public void InitializeGrid()
        {
            Presenter ??= new GridPresenter(new GridModel(_designDataContainer.GRID_SIZE), this);
            _designDataContainer.CurrentPlayer = _designDataContainer.InitialPlayer;
            CreateGridCells();
        }
        
        /// Populates the grid with cells
        private void CreateGridCells()
        {
            for (int rowIndex = 0; rowIndex < _designDataContainer.GRID_SIZE; rowIndex++)
            for (int colIndex = 0; colIndex < _designDataContainer.GRID_SIZE; colIndex++)
                InitializeGridCell(rowIndex, colIndex);
        }
        
        /// Initializes an individual cell
        private void InitializeGridCell(int rowIndex, int colIndex)
        {
            CellModel cellModel = new CellModel(rowIndex, colIndex);
            Presenter.Model.GridCells[rowIndex, colIndex] = cellModel;
            SetupCellView(cellModel);
        }
        
        /// Links the CellView with its model
        private void SetupCellView(CellModel cellModel)
        {
            GameObject cellObject = CreateCellGameObject(cellModel);
            CellView cellViewComponent = cellObject.GetComponent<CellView>() 
                                         ?? throw new InvalidOperationException("CellView component is missing.");

            CellPresenter cellPresenter = new CellPresenter(_designDataContainer);
            CommandFactory commandFactory = new CommandFactory(cellPresenter, _xFactory, _oFactory, _designDataContainer);
            cellViewComponent.Initialize(cellPresenter, commandFactory);
            cellViewComponent.Cell = cellModel;
        }
        
        /// Creates the GameObject for a cell
        private GameObject CreateCellGameObject(CellModel cellModel)
        {
            IProduct product = _cellFactory.GetProduct(transform);
            GameObject cellBody = product.GetGameObject();
            cellModel.CellObject = cellBody;
            return cellBody;
        }
        
        /// Destroys a single cell object
        private void DestroyCell(int row, int col)
        {
            GameObject cellBody = Presenter.Model.GridCells[row, col].CellObject;
            if (cellBody)
            {
                Destroy(cellBody);
                Presenter.Model.GridCells[row, col].CellObject = null;
            }
        }

        /// Destroying each cell game object in the grid.
        public void ClearGrid()
        {
            for (int rowIndex = 0; rowIndex < _designDataContainer.GRID_SIZE; rowIndex++)
            for (int colIndex = 0; colIndex < _designDataContainer.GRID_SIZE; colIndex++)
                DestroyCell(rowIndex, colIndex);
        }
    }
}