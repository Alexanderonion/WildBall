using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public StateMachine _stateMachine;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _stateMachine = new StateMachine();
        _stateMachine.ChangeState<InitializeGameState>();
    }
}