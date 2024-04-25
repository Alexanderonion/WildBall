using UnityEngine;

public class PauseState : IGameState
{
    private StateMachine _stateMachine;

    public PauseState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Time.timeScale = 0f;
    }

    public void Exit()
    {
    }
}