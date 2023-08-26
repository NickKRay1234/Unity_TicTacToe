namespace MVP.TicTacToeView
{
    using UnityEngine;

    public abstract class View : MonoBehaviour
    {
        protected Presenter.Presenter _presenter;
        
        public void Init(Presenter.Presenter presenter)
        {
            _presenter = presenter;
        }
    }
}