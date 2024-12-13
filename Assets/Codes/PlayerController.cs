using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform firePoint;
    public GameObject bubblePrefab;
    public float bulletSpeed = 10f;
    private Animator animator;
    private bool facingRight = true;
    public GameObject shootMouth;
    
   
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (firePoint == null)
        {
            firePoint = transform;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        
        print(isGrounded);
        animator.SetFloat("xSpeed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
        
        float ySpeed = rb.velocity.y;
        animator.SetFloat("ySpeed", ySpeed);
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(ySpeed) < 0.1f && isGrounded)
        {
          
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
            
            
        }

        if (Input.GetButtonDown("Fire"))
        {
            Shoot();
            
        }
        
    }
    
    void Shoot()
    {
        GameObject bubble = Instantiate(bubblePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;

       
        bubble.layer = LayerMask.NameToLayer("Bubble");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Bubble"), true);

        if (shootMouth != null)
        {
            shootMouth.SetActive(true);
        }
        
        
        
        Destroy(bubble, 2f);
        StartCoroutine(DeactivateShootingMouth());
    }
    
    private IEnumerator DeactivateShootingMouth()
    {
        yield return new WaitForSeconds(0.1f);
        if (shootMouth != null)
        {
            shootMouth.SetActive(false);
        }
    }


     private void OnCollisionEnter2D(Collision2D collision)
     {
         Debug.Log(collision.gameObject + " is grounded");
         if (collision.gameObject.CompareTag("Ground"))
         {
             isGrounded = true;
             animator.SetFloat("ySpeed", 0);
             
             
         }
         
         else if (!isGrounded)
         {
             animator.SetFloat("ySpeed", 1);
         }
     }
    
     private void OnCollisionExit2D(Collision2D collision)
     {
         Debug.Log(collision.gameObject + " is not grounded");
         if (collision.gameObject.CompareTag("Ground"))
         {
             isGrounded = false;
             
         }
     }
   
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    private bool _canMove = true;
}
