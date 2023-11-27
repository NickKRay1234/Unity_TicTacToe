using UnityEngine;

public class BackState : MonoBehaviour, IState
{
    [SerializeField] private GameObject _undo;
    public void Enter()
    {
        gameObject.SetActive(true);
        _undo.SetActive(false);
    }

    public void Exit()
    {
        gameObject.SetActive(false);
        _undo.SetActive(true);
    }
}
