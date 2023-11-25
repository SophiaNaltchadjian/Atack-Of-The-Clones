

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int health;
    public int maxhealth;
    private Animator anim;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rb;
    private bool isjump;
    private Vector3 facingRight;
    private Vector3 facingleft;
    public int damage;
    public bool invulnerable = false;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //define what is facingright and facingleft
        facingRight = transform.localScale;
        facingleft = transform.localScale;
        facingleft.x = facingleft.x * -1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Atack");
        }
    }
    private void Move()
    {
        //player movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        float InputAxis = Input.GetAxis("Horizontal");
        if (InputAxis > 0)
        {
            transform.localScale = facingRight;
            anim.SetBool("walk", true);
        }
        if (InputAxis == 0)
        {
            anim.SetBool("walk", false);
        }
        if (InputAxis < 0)
        {
            transform.localScale = facingleft;
            anim.SetBool("walk", true);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isjump)
        {

            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.layer == 6)
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") ;
    Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.DamageEnemy(damage);
        }
    }
    //   IEnumerator Damage()
    //  {
    //      for (float i = 0; i < 1f; i += 0.1f)
    //   {
    //      yield return null;
    //  }
    //}
    //  public void DamagePlayer()
    // {
    //
    // }

}

