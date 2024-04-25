using UnityEngine;

public class PlayState : IGameState
{
    private StateMachine _stateMachine;

    public PlayState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Time.timeScale = 1f;
    }

    public void Exit()
    {
    }
}