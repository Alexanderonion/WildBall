using System.Collections.Generic;
using UnityEngine;

public class DartsShooter : MonoBehaviour
{
    [SerializeField] private SpikeMoves _dartsPrefab;
    private List<SpikeMoves> _dartsPool;
    [SerializeField] private int _poolSize = 3;
    [SerializeField] private Transform _startPosision;

    void Start()
    {
        _dartsPool = new List<SpikeMoves>();

        for (int i = 0; i < _poolSize; i++)
        {
            SpikeMoves darts = Instantiate(_dartsPrefab, transform);
            darts.gameObject.SetActive(false);
            _dartsPool.Add(darts);
        }

        InvokeRepeating(nameof(GetDartsFromPool), 2f, 2f);
    }

    public void ReturnDartsToPool(SpikeMoves darts)
    {
        if (darts.gameObject.activeInHierarchy)
        {
            darts.gameObject.SetActive(false);
            darts.transform.SetPositionAndRotation(_startPosision.position, _startPosision.rotation);
        }
    }

    public SpikeMoves GetDartsFromPool()
    {
        foreach (SpikeMoves darts in _dartsPool)
        {
            if (!darts.gameObject.activeInHierarchy)
            {
                darts.gameObject.SetActive(true);
                return darts;
            }
        }

        SpikeMoves newdarts = Instantiate(_dartsPrefab);
        _dartsPool.Add(newdarts);
        return newdarts;
    }
}