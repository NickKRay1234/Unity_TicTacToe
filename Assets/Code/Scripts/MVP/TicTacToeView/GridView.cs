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
        [Inject] private Cell_Factory _cellFactory;
        [Inject] private X_Factory _xFactory;
        [Inject] private O_Factory _oFactory;
        [Inject] private DesignDataContainer _designDataContainer;
        
        private GridPresenter _presenter;
        public GridPresenter Presenter
        {
            get => _presenter;
            private set => _presenter = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        public void InitializeGrid()
        {
            Presenter ??= new GridPresenter(new GridModel(_designDataContainer.GRID_SIZE), this);
            _designDataContainer.CurrentPlayer = _designDataContainer.InitialPlayer;
            for (int i = 0; i < _designDataContainer.GRID_SIZE; i++)
            for (int j = 0; j < _designDataContainer.GRID_SIZE; j++)
                InitializeGridCell(i, j);
        }
        
        private void InitializeGridCell(int i, int j)
        {
            CellModel cellModel = new CellModel(i, j);
            Presenter.Model.GridCells[i, j] = cellModel;
            
            // Using a global factory to produce cells.
            IProduct product = _cellFactory.GetProduct(transform);
            GameObject cellBody = product.GetGameObject();
            cellModel.CellObject = cellBody;

            // Linking the cell view component with its corresponding model.
            CellView cellViewComponent = cellBody.GetComponent<CellView>();
            if (cellViewComponent == null) throw new InvalidOperationException("cellModel is null.");
            cellViewComponent.Initialize(new CellPresenter(_designDataContainer, _xFactory, _oFactory));
            cellViewComponent.Cell = cellModel;
        }

        public void Clear()
        {
            // Destroying each cell game object in the grid.
            for (int i = 0; i < _designDataContainer.GRID_SIZE; i++)
            for (int j = 0; j < _designDataContainer.GRID_SIZE; j++)
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