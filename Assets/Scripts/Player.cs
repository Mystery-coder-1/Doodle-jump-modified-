using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{   
     
    public float movementSpeed = 10f;
    public float jumpSpeed = 20f;
    public GameObject target;

    private float  actioncooldown = 10f;
    private float timesinceaction = 10f;

    float movement = 0f;
    
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        //horizontal movement
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //space jump cooldown
        timesinceaction += Time.deltaTime;
    }
    void FixedUpdate()
    {
        //horizontal movement
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
        //press space to jump and there is 10 seconds cooldown
        if (Input.GetKeyDown("space") && timesinceaction > actioncooldown)
        {
            timesinceaction = 0f;
            Vector2 velocityup = rb.velocity;
            velocityup.y = jumpSpeed ;
            rb.velocity = velocityup;
        }
        //If you reach the boundary of +-x direction, you will be transformed to -+x direction 
        if (transform.position.x > 6f)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }else if(transform.position.x < -6f)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        //gameover condition
        if(transform.position.y < target.transform.position.y -7f)
        {
            FindObjectOfType<Endgame>().EndGame();
        }
    }
}
