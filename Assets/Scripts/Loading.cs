using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;
using TMPro;

public class Loading : MonoBehaviour
{
    private AsyncOperationHandle<SceneInstance> _sceneLoadOpHandle;

    private GameManager _gameManager;
    private StateMachine _stateMachine;
    [SerializeField] private Slider _LoadingSlider;
    [SerializeField] private TMP_Text _LoadingText;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _stateMachine = GameObject.Find("EntryPoint").GetComponent<EntryPoint>()._stateMachine;
        StartCoroutine("LoadScene");
        _LoadingText.transform.gameObject.SetActive(true);
    }

    private IEnumerator LoadScene()
    {
        _sceneLoadOpHandle = Addressables.LoadSceneAsync(_gameManager.LoadingLevelName, activateOnLoad: true);

        while (!_sceneLoadOpHandle.IsDone)
        {
            _LoadingSlider.value = _sceneLoadOpHandle.PercentComplete;
            
            if (_sceneLoadOpHandle.PercentComplete >= 0.9f)
            {
                _LoadingText.transform.gameObject.SetActive(false);
                _stateMachine.ChangeState<PlayState>();
            }

            yield return null;
        }
    }
}