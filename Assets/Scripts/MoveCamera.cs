using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private Vector3 _spacing;

    private void Start()
    {
        _player = GameObject.Find("ball_lp");
        transform.SetPositionAndRotation(new Vector3(0f, 6.75f, -6.5f) + _player.transform.position, Quaternion.Euler(45, 0, 0));
        _spacing = transform.position - _player.transform.position;
    }

    void FixedUpdate()
    {
        transform.position = _player.transform.position + _spacing;
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }
}