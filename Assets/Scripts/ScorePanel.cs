using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _CoinCountText;
    [SerializeField] private TextMeshProUGUI _GemCountText;
    [SerializeField] private TextMeshProUGUI _KeyCountText;

    private void OnEnable()
    {
        Inventory.EditUICoinText += ChangeCoinText;
        Inventory.EditUIKeyText += ChangeKeyText;
        Inventory.EditUIGemText += ChangeGemText;
    }

    private void OnDisable()
    {
        Inventory.EditUICoinText -= ChangeCoinText;
        Inventory.EditUIKeyText -= ChangeKeyText;
        Inventory.EditUIGemText -= ChangeGemText;
    }

    private void ChangeCoinText(int value)
    {
        _CoinCountText.text = value.ToString();
    }
    
    private void ChangeGemText(int value)
    {
        _GemCountText.text = value.ToString();
    }

    private void ChangeKeyText(int value)
    {
        _KeyCountText.text = value.ToString();
    }
}