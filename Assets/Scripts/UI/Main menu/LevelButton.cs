using UnityEngine;
using System;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private LevelPanel _levelPanel;

    public void OnClick()
    {
        string levelText = GetComponentInChildren<TMP_Text>().text;
        int level = Convert.ToInt32(levelText);
        _levelPanel.OnLevelButtonClick(level);
    }
}