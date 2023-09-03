using TMPro;
using UnityEngine;

namespace MVP.Model
{
    public class Scorekeeper : MonoBehaviour, IService
    {
        private Referee _referee;
        [SerializeField] private TextMeshProUGUI _player1;
        [SerializeField] private TextMeshProUGUI _player2;
        private int _player1Score;
        private int _player2Score;

        private void OnEnable()
        {
            _referee = ServiceLocator.Current.Get<Referee>();
            _referee.ScoreChanged += ChangeScoreVisual;
        }

        private void ChangeScoreVisual()
        {
            switch (_referee.Winner)
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

        private void OnDisable() => _referee.ScoreChanged -= ChangeScoreVisual;
    }
}