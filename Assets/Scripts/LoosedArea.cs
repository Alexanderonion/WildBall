using UnityEngine;
using System.Collections;
using System;

public class LoosedArea : MonoBehaviour
{
    private GameObject _player;

    private MeshRenderer _playerMesh;

    private Vector3 _startLevelPosition;

    private float duration = 1f;

    public static Action<bool> IsMoved;

    private ParticleSystem _looseParticle;

    private void OnEnable()
    {
        SpikeMoves.HitThePlayer += Loose;
    }

    private void OnDisable()
    {
        SpikeMoves.HitThePlayer -= Loose;
    }

    private void Start()
    {
        _player = GameObject.Find("ball_lp");
        _looseParticle = _player.transform.GetChild(0).GetComponent<ParticleSystem>();
        _startLevelPosition = _player.transform.position;
        _playerMesh = _player.transform.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ball_lp")
        {
            Loose();
        }
    }

    private void Loose()
    {
        _looseParticle.Play();
        StartCoroutine(MoveToStartPosition());
        IsMoved?.Invoke(false);
    }

    public IEnumerator MoveToStartPosition()
    {
        Vector3 loosePosition = _player.transform.position;
        float elapsedTime = 0f;
        _player.transform.GetComponent<MeshRenderer>().enabled = false;
        _player.transform.GetComponent<SphereCollider>().enabled = false;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            _player.transform.position = Vector3.Lerp(loosePosition, _startLevelPosition, t);
            yield return null;
        }

        IsMoved?.Invoke(false);
        _player.transform.GetComponent<SphereCollider>().enabled = true;
        _player.transform.position = _startLevelPosition;
        _player.transform.GetComponent<MeshRenderer>().enabled = true;
        IsMoved?.Invoke(true);
    }
}