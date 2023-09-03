namespace MVP.TicTacToeView
{
    using UnityEngine;

    public abstract class View : MonoBehaviour
    {
        protected Presenter.Presenter _presenter;
        protected void Init(Presenter.Presenter presenter) => _presenter = presenter;
    }
}