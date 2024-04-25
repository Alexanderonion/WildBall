using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class BlockPullDown : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    private void OnTriggerEnter()
    {
        _door.GetComponent<Animation>().Play("BlockDoorAnimation");
    }
}