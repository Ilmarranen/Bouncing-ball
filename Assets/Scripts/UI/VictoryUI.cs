using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryUI : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] TextMeshProUGUI victoryText;

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
        if (newState == GameState.Victory)
        {
            restartButton.SetActive(true);
            victoryText.gameObject.SetActive(true);
        }
    }
}
