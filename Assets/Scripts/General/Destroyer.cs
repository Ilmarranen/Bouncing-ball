using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public static Destroyer instance;
    private Rigidbody objectRb;

    private void Awake()
    {
        //Singleton
        if (instance && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void DestroyObject(GameObject objectToDestroy, float timeBeforeDestruction = 0f, 
                              Color? newColor = null, GameObject destructionEffect = null, 
                              float destructionEffectTime = 0.5f)
    {
        if (newColor != null)
        {
            objectToDestroy.GetComponent<Renderer>().material.color = (Color)newColor;
        }

        objectRb = objectToDestroy.GetComponent<Rigidbody>();
        if (objectRb)
        {
            objectRb.useGravity = false;
            objectRb.velocity = Vector3.zero;
        }

        if (destructionEffect)
        {
            StartCoroutine(PlayDestructionEffect(timeBeforeDestruction, destructionEffect, 
                                                 objectToDestroy.transform.position, destructionEffectTime));  
        }

        Destroy(objectToDestroy, timeBeforeDestruction);
    }

    private IEnumerator PlayDestructionEffect(float timeToWait, GameObject destructionEffect, 
                                              Vector3 effectPosition, float destructionEffectTime)
    {
        yield return new WaitForSeconds(timeToWait);

        //Instantiate effect, and then destroy it after it plays
        Destroy(Instantiate(destructionEffect, effectPosition, Quaternion.identity),
                            destructionEffectTime);

    }
}
