using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static Action onPlayerDestruction;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            onPlayerDestruction?.Invoke();
            Destroyer.instance.DestroyObject(gameObject, 1f, collision.gameObject.GetComponent<Renderer>().material.color);
        }       
    }
}
