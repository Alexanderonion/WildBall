using UnityEngine;

public class MoveObjectBehindPlayer : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("ball_lp");
    }

    void FixedUpdate()
    {
        transform.position = _player.transform.position;
    }
}