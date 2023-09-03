using UnityEngine;

public class BackState : MonoBehaviour, IState
{
    [SerializeField] private GameObject _undo;
    [SerializeField] private GameObject _home;
    public void Enter()
    {
        gameObject.SetActive(true);
        _undo.SetActive(false);
        _home.SetActive(true);
    }

    public void Exit()
    {
        gameObject.SetActive(false);
        _undo.SetActive(true);
        _home.SetActive(false);
    }
}
