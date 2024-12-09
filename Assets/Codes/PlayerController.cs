using System.Collections;
using System.Collections.Generic;
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
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    
    
   
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (firePoint == null)
        {
            firePoint = transform; 
        }

        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 1.1f, groundLayer);
        Debug.Log("isGrounded: " + isGrounded);

        
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
             Debug.Log("Jumping");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        
         if (Input.GetButtonDown("Fire"))
        {
            Shoot();
        }
        
  
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;

        Destroy(bullet, 2f); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
