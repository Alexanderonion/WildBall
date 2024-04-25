using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int _coinCount;
    private int _keysCount;
    [SerializeField] private int _gemCount;
    private GameManager _gameManager;

    public static Action<int> EditUICoinText;
    public static Action<int> EditUIKeyText;
    public static Action<int> EditUIGemText;

    public int Coins
    {
        get { return _coinCount; }
    }

    public int Keys
    {
        get { return _keysCount; }
    }

    public int GemCount 
    {
        get { return _gemCount; }
    }

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        Bonus.PickUpKey += ChangeCountKey;
        Bonus.PickUpGem += ChangeCountGem;
        Bonus.PickUpCoin += ChangeCountCoins;
        SliderMovement.OnTakeCoinsFromChest += ChangeCountCoins;
        OpenChest.UseKey += ChangeCountKey;
    }

    private void OnDisable()
    {
        Bonus.PickUpKey -= ChangeCountKey;
        Bonus.PickUpGem -= ChangeCountGem;
        Bonus.PickUpCoin -= ChangeCountCoins;
        SliderMovement.OnTakeCoinsFromChest -= ChangeCountCoins;
        OpenChest.UseKey -= ChangeCountKey;
    }

    private void ChangeCountCoins(int coinsReward)
    {
        _coinCount += coinsReward;
        EditUICoinText?.Invoke(_coinCount);
    }

    private void ChangeCountKey(int countKey)
    { 
        _keysCount += countKey;
        EditUIKeyText?.Invoke(_keysCount);
    }

    private void ChangeCountGem(int countGem)
    { 
        _gemCount += countGem;
        EditUIGemText?.Invoke(_gemCount);
    }
}