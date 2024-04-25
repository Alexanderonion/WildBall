using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class InstantiatePlayer : MonoBehaviour
{
    private AsyncOperationHandle<GameObject> _playerOperationHandler;
    private GameObject _player;

    private void Awake()
    {
        GameObject player = GameObject.Find("ball_lp");

        if (player is null)
        {
            _playerOperationHandler = Addressables.LoadAsset<GameObject>("ball_lp");
            _playerOperationHandler.Completed += CreatePlayer;
        }
    }

    private void CreatePlayer(AsyncOperationHandle<GameObject> operation)
    {
        if (operation.Status == AsyncOperationStatus.Succeeded)
        {
            MoveCamera moveCamera = GameObject.Find("Camera").GetComponent<MoveCamera>();
            _player = Instantiate(operation.Result, transform.position, transform.rotation);
            _player.name = "ball_lp";
            moveCamera.SetPlayer(_player);
        }
    }
}