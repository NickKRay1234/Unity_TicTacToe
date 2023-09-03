using MVP.Model;
using TMPro;
using UnityEngine;

public class WinState : MonoBehaviour, IState
{
     [SerializeField] private TextMeshProUGUI _winnerText;
     public void Enter()
     {
         // TODO: Change Names in the future;
         DecisionMaker _decision = ServiceLocator.Current.Get<DecisionMaker>();
         _winnerText.text = "Player " + _decision.Winner + " Win!";
         gameObject.SetActive(true);
 #if UNITY_EDITOR
         Debug.Log("<color=cyan>I entered in Win state</color>");
 #endif
     }
 
     public void Exit()
     {
         DecisionMaker _decision = ServiceLocator.Current.Get<DecisionMaker>();
         _decision.Winner = PlayerMark.None;
         gameObject.SetActive(false);
 #if UNITY_EDITOR
         Debug.Log("<color=cyan>I came out of my Win state</color>");
 #endif
     }
 }