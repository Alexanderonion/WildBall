using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void OnClickToMenu()
    {
        _gameManager.ExitGameplay();
    }
    
    public void OnClickToExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}