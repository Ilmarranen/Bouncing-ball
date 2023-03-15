using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    public int bounceHeight = 5, bounceForce = 5;
    private GameObject road;
    private Rigidbody ballRb;

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
        if (newState == GameState.Fire)
        {
            this.enabled = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        road = GameObject.FindWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ballRb.useGravity = true;
            ballRb.AddForce(new Vector3(Mathf.Sin(road.transform.rotation.eulerAngles.y * Mathf.Deg2Rad) * bounceForce, bounceHeight, 
                                        Mathf.Cos(road.transform.rotation.eulerAngles.y * Mathf.Deg2Rad) * bounceForce), ForceMode.Impulse);
            //Get rid of script after one execution (script, but not the object it is attached too)
            Destroy(this);
        }
    }
}
