using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteplatGen : MonoBehaviour
{
    public GameObject platformPrefab3;


    public int numberofPlatforms;
    public float minY = 0f;
    public float maxY = 20f;
    public float levelWidth = 5.3f;


    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        GameObject whiteplat;
        float trans = Random.Range(1, 3);

        for (int i = 0; i < numberofPlatforms; i++)
        {

            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            whiteplat = Instantiate(platformPrefab3, spawnPosition, Quaternion.identity);
            EdgeCollider2D whitecollider = whiteplat.GetComponent<EdgeCollider2D>();
            whitecollider.enabled = false;
            while (Physics2D.OverlapCircle(whiteplat.transform.position, 2f) != null)
            {
                whiteplat.transform.Translate(new Vector3(0, trans));
            }
            whitecollider.enabled = true;
        }
    }
}
