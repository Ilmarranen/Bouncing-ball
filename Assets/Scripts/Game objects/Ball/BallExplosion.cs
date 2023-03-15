using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExplosion : MonoBehaviour
{
    public float explosionRadius = 0.5f;
    [SerializeField] private GameObject explosionEffect;
    private float destructionDelay = 1f;
    private bool explosionHappened;
    private Collider objectCollider;
    private Color objectColor;

    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider>();
        objectColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, GetObjectRadius() + explosionRadius);
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Obstacle"))
                {
                    Destroyer.instance.DestroyObject(col.gameObject, destructionDelay, objectColor, explosionEffect);
                    explosionHappened = true;
                }
            }
            if(explosionHappened)
            {
                Destroyer.instance.DestroyObject(gameObject);
            }
        }
    }

    private float GetObjectRadius()
    {
        return objectCollider.bounds.size.x / 2;
    }


    //Explosion size debug
    private void OnDrawGizmos()
    {
        if (!objectCollider)
        {
            objectCollider = GetComponent<Collider>();
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, GetObjectRadius() + explosionRadius);
    }
}
