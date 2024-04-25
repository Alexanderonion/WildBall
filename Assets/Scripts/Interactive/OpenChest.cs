using UnityEngine;
using System;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private GameObject _chestWindow;
    private Inventory _inventory;
    private StateMachine _stateMachine;

    public static Action<int> UseKey;
    public static Action<bool> IsMoved;

    private void Awake()
    {
        _stateMachine = GameObject.Find("EntryPoint").GetComponent<EntryPoint>()._stateMachine;
    }

    private void Start()
    {
        _inventory = GameObject.Find("ball_lp").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ball_lp" && _inventory.Keys > 0)
        {
            IsMoved?.Invoke(false);
            OpenChestWindow();
            UseKey?.Invoke(-1);
        }
        else
        {
            Debug.Log("Need key");
        }
    }

    private void OpenChestWindow()
    {
        _chestWindow.SetActive(true);
    }
}