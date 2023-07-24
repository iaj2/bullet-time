using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemyScript : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Get the screen boundaries of the camera
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        // Check if the object's position is outside the camera's bounds
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);
        bool isOutsideBounds = viewPos.x < -0.1f || viewPos.x > 1.1f || viewPos.y < -0.1f || viewPos.y > 1.1f;

        // Destroy the object if it's outside the camera's bounds
        if (isOutsideBounds)
        {
            Destroy(gameObject);
        }
    }
}
