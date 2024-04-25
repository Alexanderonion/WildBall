using System.Collections.Generic;
using System;
using UnityEngine;

public class StateMachine
{
    private Dictionary<Type, IGameState> _states;
    private IGameState _currentState;

    public StateMachine()
    {
        _states = new Dictionary<Type, IGameState>
        {
            [typeof(InitializeGameState)] = new InitializeGameState(this),
            [typeof(PlayState)] = new PlayState(this),
            [typeof(LoadingState)] = new LoadingState(this),
            [typeof(PauseState)] = new PauseState(this),
            [typeof(ExitState)] = new ExitState(this),
        };
    }

    public IGameState CurrentState { get => _currentState; private set { } }

    public void ChangeState<T>() where T : IGameState
    {
        Type stateType = typeof(T);

        if (!_states.ContainsKey(stateType))
        {
            Debug.LogError($"Unknown state {stateType.Name}");
            return;
        }

        _currentState?.Exit();
        _currentState = _states[stateType];
        _currentState?.Enter();
    }
}