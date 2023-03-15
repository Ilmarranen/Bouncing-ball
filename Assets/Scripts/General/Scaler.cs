using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public static Action onScaleLimitReached;
    public bool scaleLimited = false;
    public float scaleLimit = 0f;
    public float scaleSpeed = 0.5f;
    public bool upscale = true;
    private GameObject checkScaleLimitTo;

    private void Awake()
    {
        GameManager.onGameStateChanged += OnGameStateChanged;
        Spawner.onSpawn += OnSpawn;
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

    private void OnSpawn(GameObject spawnedObject)
    {
        if (scaleLimited)
        {
            checkScaleLimitTo = spawnedObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (upscale) 
            {
                transform.localScale += Vector3.one * Time.deltaTime * scaleSpeed;
            } 
            else 
            {
                transform.localScale -= Vector3.one * Time.deltaTime * scaleSpeed;
            }
        }

        //Checking scale limits if applied
        if (scaleLimited && scaleLimit != 0
            && Vector3.Distance(transform.localScale, Vector3.one * scaleLimit) < 0.05)
        {
            onScaleLimitReached?.Invoke();
        }
        //No less than a ball spawned inside
        //2nd variant - numerical scale limit is not required
        else if (scaleLimited && checkScaleLimitTo 
                && Vector3.Distance(transform.localScale,checkScaleLimitTo.transform.localScale) < 0.05 )
        {
            onScaleLimitReached?.Invoke();
        }
    }

   

}
