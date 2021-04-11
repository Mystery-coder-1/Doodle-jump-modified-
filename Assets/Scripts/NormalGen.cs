using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NormalGen : MonoBehaviour
{
    public GameObject platformPrefab;
    

    public int numberofPlatforms;
    public float minY = .2f;
    public float maxY = 3f;
    public float levelWidth = 5.3f;
   
   
    void Start()
    {

        Vector3 spawnPosition = new Vector3();
        GameObject normalplat;
        float trans = Random.Range(1,3);
        //Generate random level of platforms
        for (int i = 0; i < numberofPlatforms; i++)
        {
            
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            normalplat = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            //prevent overlapping platforms
            EdgeCollider2D normalcollider = normalplat.GetComponent<EdgeCollider2D>();
            normalcollider.enabled = false;
            while(Physics2D.OverlapCircle(normalplat.transform.position, 2f)!= null)
            {
                normalplat.transform.Translate(new Vector3(0, trans));
            }
            normalcollider.enabled = true;
        }
    }

   
}
