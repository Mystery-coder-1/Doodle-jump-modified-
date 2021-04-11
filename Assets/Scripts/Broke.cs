using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broke : MonoBehaviour
{

    public GameObject Brokenplatform;
    public float time = 1f;
    private GameObject instantiateobj;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 spawnPos = new Vector2(transform.position.x,transform.position.y);
        //This platform will only destroy when doodler collide with it
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Destroy(gameObject);
                instantiateobj = (GameObject) Instantiate(Brokenplatform, spawnPos, Quaternion.identity);
                Destroy(instantiateobj, time);
                
            }
        }

    }
}
