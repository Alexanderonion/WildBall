using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitState : IGameState
{
    private StateMachine _stateMachine;

    public ExitState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}