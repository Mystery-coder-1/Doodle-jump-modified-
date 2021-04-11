using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGen : MonoBehaviour
{
    public GameObject platformPrefab1;


    public int numberofPlatforms;
    public float minY = 0f;
    public float maxY = 200f;
    public float levelWidth = 5.3f;


    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        GameObject flyplat;
        float trans = Random.Range(1, 3);

        for (int i = 0; i < numberofPlatforms; i++)
        {
            
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            flyplat = Instantiate(platformPrefab1, spawnPosition, Quaternion.identity);
            EdgeCollider2D flycollider = flyplat.GetComponent<EdgeCollider2D>();
            flycollider.enabled = false;
            while(Physics2D.OverlapCircle(flyplat.transform.position, 2f) != null)
            {
                flyplat.transform.Translate(new Vector3(0, trans));
            }
            flycollider.enabled = true;
        }
    }

}
