using System;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] private Transform player; 
    private float smoothTime=0.05f;
    private Vector3 velocity=Vector3.zero;

    private void LateUpdate()
    {
        Vector3 followPlayer = player.position + new Vector3(0, 0, -10);

        transform.position = Vector3.SmoothDamp(transform.position, followPlayer, ref velocity, smoothTime);
        
    }
}
