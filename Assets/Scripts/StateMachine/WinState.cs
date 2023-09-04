using MVP.Model;
using TMPro;
using UnityEngine;

public class WinState : MonoBehaviour, IState
{
    [SerializeField] private GameObject _headHUD;
    [SerializeField] private TextMeshProUGUI _winnerText;

    public void Enter()
    {
        // TODO: Change Names in the future;
        Referee _decision = ServiceLocator.Current.Get<Referee>();
        _winnerText.text = "Player " + _decision.Winner + " Win!";
        gameObject.SetActive(true);
        _headHUD.SetActive(true);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I entered in Win state</color>");
#endif
    }

    public void Exit()
    {
        Referee _decision = ServiceLocator.Current.Get<Referee>();
        _decision.Winner = PlayerMark.None;
        gameObject.SetActive(false);
        _headHUD.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("<color=cyan>I came out of my Win state</color>");
#endif
    }
}