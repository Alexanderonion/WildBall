using System;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static bool _megaPowerAvailable;
    public static bool _speedAvailable;
    
    public static Action<PowerUpType> OnCollectedPowerUp;

    private void OnEnable()
    {
        OnCollectedPowerUp += CollectedPowerUp;
    }

    private void OnDisable()
    {
        OnCollectedPowerUp -= CollectedPowerUp;
    }

    void Start()
    {
        _megaPowerAvailable = false;
        _speedAvailable = false;
    }

    private void CollectedPowerUp(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.Speed:
                _speedAvailable = true; 
                break;
            case PowerUpType.MegaPower:
                _megaPowerAvailable = true; 
                break;
        }
    }
}