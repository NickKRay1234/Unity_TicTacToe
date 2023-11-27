using UnityEngine;

public class SelectGameState : MonoBehaviour, IState
{
    public void Enter() => gameObject.SetActive(true);
    public void Exit() => gameObject.SetActive(false);
}