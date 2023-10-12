using MVP.TicTacToeView;
using UnityEngine;
using VContainer;

namespace SignFactory
{
    public class Cell_Product : MonoBehaviour, IProduct
    {
        [Inject] private CommandInvoker _invoker;
        [Inject] private GridView _gridView;
        [Inject] private Referee _referee;
        public string ProductName { get; set; }
        public void Initialize() => ProductName = "Cell";
        public GameObject GetGameObject() => gameObject;
    }
}