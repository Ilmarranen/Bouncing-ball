using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTransparency : MonoBehaviour
{
    private Renderer ballRenderer;

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
        ballRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeTransparency(0.5f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            ChangeTransparency(1f);
        }
    }

    private void ChangeTransparency(float a)
    {
        ballRenderer.material.color = new Color(ballRenderer.material.color.r,
                                                ballRenderer.material.color.g,
                                                ballRenderer.material.color.b,
                                                a);
    }

    private void OnDisable()
    {
        ChangeTransparency(1f);
    }
}
