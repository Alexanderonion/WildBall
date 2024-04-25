using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class LoadingState : IGameState
{
    private StateMachine _stateMachine;
    private AsyncOperationHandle<SceneInstance> _sceneLoad;

    public LoadingState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _sceneLoad = Addressables.LoadSceneAsync("LoadingScene", activateOnLoad: true);
    }

    public void Exit()
    {
    }
}