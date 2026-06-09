using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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

    [SerializeField] private PlayerInput input;
    



    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;
    private float reloading=0.2f;
    private float nextFire;
    
    

    [SerializeField] private AudioSource[] resourceAudio;

    [SerializeField] private int stelle;
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
        if (UtilisMethod.isGrounded(groundedCheck.transform, 0.1f, groundedLayer))
        {
            rb.linearVelocityY = playerJumpForce;
            resourceAudio[0].Play();
        }
    }

    private void Update()
    {
        an.SetBool("isGrounded",UtilisMethod.isGrounded(groundedCheck.transform, 0.2f, groundedLayer));
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
        if (!context.performed || !(Time.time > nextFire)) return;
        GameObject b=Instantiate(bullet, gun.transform.position, Quaternion.identity);
        b.transform.localScale=new Vector3(b.transform.localScale.x * transform.localScale.x, b.transform.localScale.y, b.transform.localScale.z);
        nextFire = Time.time + reloading;
        resourceAudio[1].Play();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spike"))
        {
            AudioSource.PlayClipAtPoint(resourceAudio[2].clip,transform.position);
            loadTheDeadScene();
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            TransitionManager.instance.loadNextLevel();
        }

        if (other.gameObject.CompareTag("TriggerStart"))
        {
            CameraLogic.Deactive();
            AudioSource.PlayClipAtPoint(resourceAudio[2].clip,transform.position);
            loadTheDeadScene();
        }
        if (other.gameObject.CompareTag("collectible"))
        {
            resourceAudio[3].Play();
            Destroy(other.gameObject);
        }
    }
    
    private void loadTheDeadScene()
    {
        input.DeactivateInput();
        DeadTransitionManager.Instance.StartDeadanimation();
    }
}
