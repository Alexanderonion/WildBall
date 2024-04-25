using UnityEngine;
using System;
using UnityEngine.UI;

public class GoldCup : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _levelCompletePanel;

    public static Action<bool> IsMoved;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnLevelComplete);
        _menuButton.onClick.AddListener(OnMenuLoad);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnLevelComplete);
        _menuButton.onClick.RemoveListener(OnMenuLoad);
    }

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ball_lp")
        {
            IsMoved?.Invoke(false);
            _levelCompletePanel.SetActive(true);
        }
    }

    public void OnLevelComplete()
    {
        _gameManager.LevelCompleted();
    }
    
    public void OnMenuLoad()
    { 
        _gameManager.ExitGameplay();
    }
}