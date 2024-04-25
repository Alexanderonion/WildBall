using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    private GameManager _gameManager;
    private StateMachine _stateMachine;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _stateMachine = GameObject.Find("EntryPoint").GetComponent<EntryPoint>()._stateMachine;
    }

    public void OnLevelButtonClick(int levelNumber)
    {
        _gameManager.SetCurrentLevel(levelNumber);
        _gameManager.SetMaximumLevel(3);
        _stateMachine.ChangeState<LoadingState>();
    }
}