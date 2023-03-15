using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FireUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fireText;

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
        fireText.gameObject.SetActive(newState == GameState.Fire);
    }
}

