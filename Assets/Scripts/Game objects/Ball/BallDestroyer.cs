using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{

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
            Destroyer.instance.DestroyObject(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            Destroyer.instance.DestroyObject(gameObject, 1f, collision.gameObject.GetComponent<Renderer>().material.color);
        }
    }

}
