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
        Debug.Log("������������� ������ ��������");
        _stateMachine.ChangeState<LoadingState>();
    }

    public void Exit()
    {
        Debug.Log("��� ������� ����������������");
    }
}
