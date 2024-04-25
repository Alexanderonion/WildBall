using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _maxAvailableLevel;
    private bool _isPaused;

    public string LoadingLevelName { get; private set; }

    private void OnEnable()
    {
        PlayerController.PauseActivate += Pause;
    }

    private void OnDisable()
    {
        PlayerController.PauseActivate -= Pause;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _isPaused = false;
        _stateMachine = GameObject.Find("EntryPoint").GetComponent<EntryPoint>()._stateMachine;
        LoadingLevelName = "Menu";
    }

    public void SetCurrentLevel(int level)
    {
        _currentLevel = level;
        LoadingLevelName = "Level" + $"{level}";
    }

    public void SetMaximumLevel(int maxLevel)
    {
        _maxAvailableLevel = maxLevel;
    }

    public void LevelCompleted()
    {
        _currentLevel++;

        if (_currentLevel > _maxAvailableLevel)
        {
            _currentLevel = 1;
        }

        LoadingLevelName = "Level" + $"{_currentLevel}";
        _stateMachine.ChangeState<LoadingState>();
    }

    public void ExitGameplay()
    {
        LoadingLevelName = "Menu";
        _stateMachine.ChangeState<LoadingState>();
    }

    private void Pause()
    {
        if (!_isPaused)
        {
            _stateMachine.ChangeState<PauseState>();
            _isPaused = true;
        }
        else
        {
            _stateMachine.ChangeState<PlayState>();
            _isPaused = false;
        }
    }
}