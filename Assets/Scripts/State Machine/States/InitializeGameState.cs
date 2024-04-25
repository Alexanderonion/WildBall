using UnityEngine;

public class InitializeGameState : IGameState
{
    private StateMachine _stateMachine;

    public InitializeGameState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("Инициализация нужных сервисов");
        _stateMachine.ChangeState<LoadingState>();
    }

    public void Exit()
    {
        Debug.Log("Все сервисы инициализированы");
    }
}
