
using System;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private readonly float _speed= 6f;
    [SerializeField] private LayerMask layer;
    private float elapsedTime = 0;
    


    private void Update()
    {
        transform.Translate(transform.right * (_speed * transform.localScale.x * Time.deltaTime));
        if (UtilisMethod.isGrounded(transform,0.2f,layer))
        {
            Destroy(gameObject);
        }

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 2f)
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
