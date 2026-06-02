using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Range(-1,1)] private float moveDirection;
    [Range(-1,1)] private float lastDirection;
    
    
    

    private Rigidbody2D rb;
    private Animator an;
    
    
    
    [SerializeField] private GameObject groundedCheck;
    [SerializeField] private LayerMask groundedLayer;

    private float playerSpeed=6f;
    private float playerJumpForce = 12f;
    private float calcolSpeed;
    private float currentSpeed;



    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;
    private float reloading=0.5f;
    private float nextFire;




    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource fireAudio;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
    }

    public void isMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>().x;
        if(moveDirection!=0)
            lastDirection = moveDirection;
        
        transform.localScale = new Vector3(lastDirection, 1,1);
    }


    public void jump(InputAction.CallbackContext context)
    {
        if (isGrounded())
        {
            rb.linearVelocityY = playerJumpForce;
            jumpAudio.Play();
        }
        
        if (context.canceled && rb.linearVelocityY>0f)
            rb.linearVelocityY =5f;
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundedCheck.transform.position, 0.2f, groundedLayer);
    }

    private void Update()
    {
        an.SetBool("isGrounded",isGrounded());
        an.SetFloat("Yvelocity",rb.linearVelocityY);
        if (moveDirection != 0)
            an.SetBool("isMove",true);
        else
            an.SetBool("isMove",false);
    }

    private void FixedUpdate()
    {
        calcolSpeed = moveDirection * playerSpeed;
        currentSpeed=Mathf.Lerp(currentSpeed,calcolSpeed,0.1f);
        rb.linearVelocityX = currentSpeed;

    }


    public void fire(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time > nextFire)
        {
            GameObject b=Instantiate(bullet, gun.transform.position, Quaternion.identity);
            b.transform.localScale=new Vector3(b.transform.localScale.x * transform.localScale.x, b.transform.localScale.y, b.transform.localScale.z);
            nextFire = Time.time + reloading;
            fireAudio.Play();
        }
        

    }
}
