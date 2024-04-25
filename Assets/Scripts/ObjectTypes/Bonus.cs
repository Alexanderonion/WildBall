using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Bonus : MonoBehaviour
{
    [SerializeField] private BonusTypes _bonusType;

    private Inventory _inventory;

    private AsyncOperationHandle<GameObject> _looseParticle;

    public static Action<int> PickUpKey;
    public static Action<int> PickUpGem;
    public static Action<int> PickUpCoin;

    private void Start()
    {
        _inventory = GameObject.Find("ball_lp").GetComponent<Inventory>();
        _looseParticle = Addressables.LoadAssetAsync<GameObject>("Effects Quadro");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ball_lp")
        {
            CollectedBonus();
        }
    }

    private void CollectedBonus()
    {
        switch (_bonusType)
        {
            case BonusTypes.Coin:
                PickUpCoin?.Invoke(1);
                DeleteBonus();
                break;
            case BonusTypes.Key:
                PickUpKey?.Invoke(1);
                DeleteBonus();
                break;
            case BonusTypes.Gem:
                PickUpGem?.Invoke(1);
                DeleteBonus();
                break;
            default:
                Debug.LogError("non-processable bonus");
                break;
        }
    }

    private void DeleteBonus()
    {
        Instantiate(_looseParticle.Result, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}