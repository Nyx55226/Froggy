
using System;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private readonly float _speed= 8f;
    [SerializeField] private LayerMask layer;
    private float time = 3f;

    private void Start()
    {
        Destroy(gameObject, time);
    }

    private void Update()
    {
        transform.Translate(transform.right * (_speed * transform.localScale.x * Time.deltaTime));

        if (isGrounded())
        {
            Destroy(gameObject);
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 0.2f, layer);
    }
}
