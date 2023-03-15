using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Action<GameObject> onSpawn;
    [SerializeField] GameObject objectPrefab;
    private GameObject objectSpawned;
    [SerializeField] Transform positionTransform;

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
        if (newState != GameState.ClearObstacles)
        {
            this.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objectSpawned = Instantiate(objectPrefab, positionTransform.position,Quaternion.identity);
            onSpawn?.Invoke(objectSpawned);
        }
    }
}
