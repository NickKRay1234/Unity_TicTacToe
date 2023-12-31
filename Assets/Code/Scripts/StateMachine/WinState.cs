﻿using MVP.Model;
using TMPro;
using UnityEngine;
using VContainer;

public class WinState : MonoBehaviour, IState
{
    [SerializeField] private GameObject _headHUD;
    [SerializeField] private TextMeshProUGUI _winnerText;
    [Inject] private Referee _decision;

    public void Enter()
    {
        _winnerText.text = "Player " + _decision.PlayerMarkResult + " Win!";
        gameObject.SetActive(true);
        _headHUD.SetActive(true);
    }

    public void Exit()
    {
        _decision.PlayerMarkResult = PlayerMark.None;
        gameObject.SetActive(false);
        _headHUD.SetActive(false);
    }
}