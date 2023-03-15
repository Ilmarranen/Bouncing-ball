using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefeatUI : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] TextMeshProUGUI defeatText;

    private void Awake()
    {
        GameManager.onGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newState)
    {
        if (newState == GameState.Defeat)
        {
            restartButton.SetActive(true);
            defeatText.gameObject.SetActive(true);
        }
    }
}
