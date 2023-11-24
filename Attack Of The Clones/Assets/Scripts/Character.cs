using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rb;
    private bool isjump;
    private Vector3 facingRight;
    private Vector3 facingleft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = transform.localScale;
        facingleft = transform.localScale;
        facingleft.x = facingleft.x * -1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        float InputAxis = Input.GetAxis("Horizontal");
        if(InputAxis > 0)
        {
            transform.localScale = facingRight;
        }
        if (InputAxis < 0)
        {
            transform.localScale = facingleft;
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isjump)
        {

            rb.AddForce(new Vector2(0f,JumpForce),ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 6) 
        { 

         isjump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            isjump = true;
        }
    }
}
