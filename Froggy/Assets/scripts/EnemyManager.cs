using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed=1.5f;

    
    [SerializeField] private LayerMask groundedMask;
    [SerializeField] private GameObject groundedCheck;
    [SerializeField] private GameObject wallCheck;
    [SerializeField] private LayerMask wallMask;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!UtilisMethod.isGrounded(groundedCheck.transform,0.2f,groundedMask) || isWall())
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
    }
    private bool isWall()
    {
        return Physics2D.OverlapCircle(wallCheck.transform.position, 0.1f,wallMask);
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = speed * transform.localScale.x;
    }
}
