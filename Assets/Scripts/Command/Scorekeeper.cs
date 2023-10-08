using TMPro;
using UnityEngine;
using VContainer;

namespace MVP.Model
{
    public class Scorekeeper : MonoBehaviour
    {
        [Inject] private Referee _referee;
        [SerializeField] private TextMeshProUGUI _player1;
        [SerializeField] private TextMeshProUGUI _player2;
        private int _player1Score;
        private int _player2Score;

        private void OnEnable() => _referee.ScoreChanged += ChangeScoreVisual;

        private void ChangeScoreVisual()
        {
            switch (_referee.PlayerMarkResult)
            {
                case PlayerMark.X:
                    _player1Score = Result(_player1Score, _player1);
                    break;
                case PlayerMark.O:
                    _player2Score = Result(_player2Score, _player2);
                    break;
                case PlayerMark.None:
                    _player1Score = Result(_player1Score, _player1);
                    _player2Score = Result(_player2Score, _player2);
                    break;
            }
        }

        private int Result(int playerScore, TextMeshProUGUI meshProText)
        {
            playerScore += 1;
            meshProText.text = $"{playerScore}";
            return playerScore;
        }

        public void Reset()
        {
            _player1Score = 0;
            _player2Score = 0;
            _player1.text = _player1Score.ToString();
            _player2.text = _player2Score.ToString();
        }

        private void OnDisable() => _referee.ScoreChanged -= ChangeScoreVisual;
    }
}