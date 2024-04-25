using UnityEngine;
using System;

public class SpikeMoves : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    public static Action HitThePlayer;

    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ball_lp")
        {
            HitThePlayer?.Invoke();
        }

        gameObject.GetComponentInParent<DartsShooter>().ReturnDartsToPool(this);
    }
}