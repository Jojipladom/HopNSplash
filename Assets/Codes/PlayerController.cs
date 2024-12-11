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
   
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        if (firePoint == null)
        {
            firePoint = transform;
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 1.1f, groundLayer);
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
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
        
        Destroy(bubble, 2f);
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

    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    private bool _canMove = true;
}
