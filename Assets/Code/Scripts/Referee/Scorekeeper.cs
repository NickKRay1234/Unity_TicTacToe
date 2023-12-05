using TMPro;
using UnityEngine;
using VContainer;

namespace MVP.Model
{
    public class Scorekeeper : MonoBehaviour
    {
        [Tooltip("The player on the left side ")]
        [SerializeField] private TextMeshProUGUI _player1;
        
        [Tooltip("The player on the right side ")]
        [SerializeField] private TextMeshProUGUI _player2;
        
        [Inject] private Referee _referee;
        [Inject] private DesignDataContainer _data;

        private void Start()
        {
            _data.Player1Score = 0;
            _data.Player2Score = 0;
        }

        private void OnEnable() => _referee.ScoreChanged += ChangeScoreVisual;

        private void ChangeScoreVisual()
        {
            switch (_referee.PlayerMarkResult)
            {
                case PlayerMark.X:
                    _data.Player1Score = GetResult(_data.Player1Score, _player1);
                    break;
                case PlayerMark.O:
                    _data.Player2Score = GetResult(_data.Player2Score, _player2);
                    break;
                case PlayerMark.None:
                    _data.Player1Score = GetResult(_data.Player1Score, _player1);
                    _data.Player2Score = GetResult(_data.Player2Score, _player2);
                    break;
            }
        }

        private int GetResult(int playerScore, TextMeshProUGUI meshProText)
        {
            playerScore += 1;
            meshProText.text = $"{playerScore}";
            return playerScore;
        }

        public void Reset()
        {
            _data.Player1Score = 0;
            _data.Player2Score = 0;
            _player1.text = _data.Player1Score.ToString();
            _player2.text = _data.Player2Score.ToString();
        }

        private void OnDisable() => _referee.ScoreChanged -= ChangeScoreVisual;
    }
}