using UnityEngine;

namespace Architecture.Infrastructure
{
    // GameBootstrapper — компонент MonoBehaviour, предназначенный
    // для инициализации игры. Этот класс должен быть присоединен к объекту в сцене Unity.
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}