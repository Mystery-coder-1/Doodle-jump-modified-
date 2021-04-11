using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGen : MonoBehaviour
{
    public GameObject platformPrefab2;


    public int numberofPlatforms;
    public float minY = 0f;
    public float maxY = 25f;
    public float levelWidth = 5.3f;


    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        GameObject brokenplat;
        float trans = Random.Range(1, 3);

        for (int i = 0; i < numberofPlatforms; i++)
        {

            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            brokenplat = Instantiate(platformPrefab2, spawnPosition, Quaternion.identity);
            EdgeCollider2D brokencollider = brokenplat.GetComponent<EdgeCollider2D>();
            brokencollider.enabled = false;
            while(Physics2D.OverlapCircle(brokenplat.transform.position, 2f) != null)
            {
                brokenplat.transform.Translate(new Vector3(0, trans));
            }
            brokencollider.enabled = true;
        }
    }
}
