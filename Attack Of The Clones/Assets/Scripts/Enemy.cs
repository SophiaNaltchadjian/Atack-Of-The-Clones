using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{

    protected SpriteRenderer sprite;
    public int health;
    public float speed;
    public float distancefor;
    public Transform target;
    public bool isright = false;

    protected Animator anim;
   
    protected Rigidbody2D rb ;
    public int Damage = 4;
  


    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        target =GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }




    // Update is called once per frame
    protected virtual void Update()
    { 
        if(Vector2.Distance(transform.position, target.position) > distancefor)
        {
            transform.position     = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        }
    }


   
    public void DamageEnemy(int damage)
    {
        health -= damage;
        StartCoroutine(Damagee());
        if (health <= 1)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Damagee()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {

        }
    }
}






