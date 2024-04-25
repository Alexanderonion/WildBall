using UnityEngine;

public class PlatformMagnetization: MonoBehaviour
{
    private float _magnetForce;
    private bool _onPlatform;

    private Vector3 _magnetVector;

    [SerializeField] private GameObject _player;

    private void Start()
    {
        _magnetForce = 0.9f;
        _player = GameObject.Find("ball_lp");
    }

    private void FixedUpdate()
    {
        if (_onPlatform)
        {
            _magnetVector = transform.position - _player.transform.position;
            _player.transform.GetComponent<Rigidbody>().AddForce(_magnetVector * _magnetForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _onPlatform = true;
    }

    void OnTriggerExit(Collider other)
    {
        _onPlatform = false;
    }
}