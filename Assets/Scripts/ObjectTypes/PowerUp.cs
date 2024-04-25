using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType _powerUpType;

    private void OnTriggerEnter(Collider other)
    {
        PlayerStatus.OnCollectedPowerUp?.Invoke(_powerUpType);
        Destroy(gameObject);
    }
}