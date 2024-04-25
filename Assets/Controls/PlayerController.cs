using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Range(0, 200)]
    [SerializeField] private float _moveSpeed;

    private Vector3 _moveValue;
    private Rigidbody _playerRigidBody;

    private bool _isMoved;

    public static Action ActionActivate;
    public static Action PauseActivate;

    private void OnEnable()
    {
        GoldCup.IsMoved += SetMovedStatus;
        OpenChest.IsMoved += SetMovedStatus;
        SliderMovement.IsMoved += SetMovedStatus;
        LoosedArea.IsMoved += SetMovedStatus;
    }

    private void OnDisable()
    {
        GoldCup.IsMoved -= SetMovedStatus;
        OpenChest.IsMoved -= SetMovedStatus;
        SliderMovement.IsMoved -= SetMovedStatus;
        LoosedArea.IsMoved -= SetMovedStatus;
    }

    public bool IsMoved
    {
        get { return _isMoved; }
        set { _isMoved = IsMoved; }
    }
    private void Start()
    {
        _isMoved = true;
        _moveSpeed = _moveSpeed;
        _playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_isMoved)
        {
            Move(_moveValue);
        }
        else
        {
            _playerRigidBody.velocity = Vector3.zero;
        }
    }

    private void Move(Vector3 directionMove)
    {
        _playerRigidBody.AddForce(directionMove * _moveSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveValue = context.ReadValue<Vector3>();
    }

    public void OnAxiliration(InputAction.CallbackContext context)
    {
        if (PlayerStatus._speedAvailable)
        {
            _moveSpeed += _moveSpeed;
        }
    }

    private void SetMovedStatus(bool isMoved)
    {
        _isMoved = isMoved;
    }

    public void PauseOnOff(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PauseActivate?.Invoke();
        }
    }
    
    public void OnAction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ActionActivate?.Invoke();
        }
    }
}