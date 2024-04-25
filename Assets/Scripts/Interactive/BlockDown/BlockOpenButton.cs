using UnityEngine;
using TMPro;

public class BlockOpenButton : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private TextMeshProUGUI _pressButtonText;
    private bool _inFront;

    private void OnEnable()
    {
        PlayerController.ActionActivate += OpenBlockDoor;
    }

    private void OnDisable()
    {
        PlayerController.ActionActivate -= OpenBlockDoor;
    }

    private void OnTriggerEnter()
    {
        _pressButtonText.gameObject.SetActive(true);
        _inFront = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _pressButtonText.gameObject.SetActive(false);
        _inFront = false;
    }

    private void OpenBlockDoor()
    {
        if (_inFront)
        {
            _door.GetComponent<Animation>().Play("BlockDoorAnimation");
        }
    }
}