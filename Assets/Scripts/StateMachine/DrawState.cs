using UnityEngine;

public class DrawState : MonoBehaviour, IState, IService
{
    [SerializeField] private GameObject _headHUD;
    public void Enter()
    {
        gameObject.SetActive(true);
        _headHUD.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I entered in Draw state</color>");
#endif
    }
    public void Exit()
    {
        gameObject.SetActive(false);
        _headHUD.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I came out of my Draw state</color>");
#endif
    }
}