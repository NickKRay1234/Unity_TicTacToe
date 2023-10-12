using UnityEngine;

public class StartState : MonoBehaviour, IState
{
    public void Enter() => gameObject.SetActive(true);
    public void Exit() => gameObject.SetActive(false);
}