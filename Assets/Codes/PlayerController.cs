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
    public GameObject bubblePrefab;
    public float bulletSpeed = 10f;
    
    
    void Shoot()
    {
        //Nimmt die bubble prefab, deren rigidbody, und wird nach 2 Sek zerstört
        GameObject bubble = Instantiate(bubblePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;

        Destroy(bubble, 2f); 
    }
    
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
    //Altes Input System, das neue ging bei mir nicht.. :(
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            //Yes Jump
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            //No Jump
        {
            isGrounded = false;
        }
    }
}
