namespace MVP.TicTacToeView
{
    using UnityEngine;

    public abstract class View : MonoBehaviour
    {
        protected Presenter.BasePresenter BasePresenter;
        protected void Init(Presenter.BasePresenter basePresenter) => BasePresenter = basePresenter;
    }
}