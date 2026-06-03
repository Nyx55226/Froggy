
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

        if (UtilisMethod.isGrounded(transform,0.2f,layer))
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
