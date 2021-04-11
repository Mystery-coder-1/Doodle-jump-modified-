using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplat : MonoBehaviour
{
    public float jumpforce = 10f;
    public float sidewaysForce = 2f;
    public Rigidbody2D rb;

     void Start()
    {
        rb.velocity = new Vector2(sidewaysForce * Time.deltaTime, 0);
    }
    void FixedUpdate()
    {
        //Make this kind of platforms move horizontally
        if(transform.position.x > 5.3f)
        {
            rb.velocity = new Vector2(-sidewaysForce * Time.deltaTime, 0);
        }else if(transform.position.x <-5.3f)
        {
            rb.velocity = new Vector2(sidewaysForce * Time.deltaTime, 0);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;
            }
        }

    }
}
