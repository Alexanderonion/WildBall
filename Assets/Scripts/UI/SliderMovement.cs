using UnityEngine;
using UnityEngine.UI;
using System;

public class SliderMovement : MonoBehaviour
{
    [SerializeField] private GameObject _chest;
    [SerializeField] private Slider _slider;
    private float _speed = 11f;

    private bool _isMoving = true;
    private bool _isReversed = false;

    public static Action<int> OnTakeCoinsFromChest;
    public static Action<bool> IsMoved;
    private StateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = GameObject.Find("EntryPoint").GetComponent<EntryPoint>()._stateMachine;
    }

    private void Update()
    {
        if (_isMoving)
        {
            if (!_isReversed)
            {
                _slider.value += _speed * Time.deltaTime;

                if (_slider.value >= _slider.maxValue)
                {
                    _isReversed = true;
                }
            }
            else
            {
                _slider.value -= _speed * Time.deltaTime;

                if (_slider.value <= _slider.minValue)
                {
                    _isReversed = false;
                }
            }
        }

        if (_stateMachine.CurrentState.GetType() == typeof(PlayState) && Input.GetMouseButtonDown(0))
        {
            _isMoving = !_isMoving;

            if (_slider.value < 1.2f)
            {
                OnTakeCoinsFromChest?.Invoke(3);
            }
            else if (_slider.value > 1.2f && _slider.value < 4.6f)
            {
                OnTakeCoinsFromChest?.Invoke(1);
            }
            else if (_slider.value > 4.6f && _slider.value < 5.4f)
            {
                OnTakeCoinsFromChest?.Invoke(5);
            }
            else if (_slider.value > 5.4f && _slider.value < 8.8f)
            {
                OnTakeCoinsFromChest?.Invoke(1);
            }
            else if (_slider.value > 8.8f)
            {
                OnTakeCoinsFromChest?.Invoke(3);
            }

            _slider.value = 0;
            _isMoving = !_isMoving;
            IsMoved?.Invoke(true);
            Destroy(_chest);
        }
    }
}