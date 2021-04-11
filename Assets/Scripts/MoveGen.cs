using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGen : MonoBehaviour
{
    public GameObject platformPrefab1;


    public int numberofPlatforms;
    public float minY = 0f;
    public float maxY = 50f;
    public float levelWidth = 5.3f;


    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        GameObject moveplat;
        float trans = Random.Range(1,3);

        for (int i = 0; i < numberofPlatforms; i++)
        {

            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            moveplat = Instantiate(platformPrefab1, spawnPosition, Quaternion.identity);
            EdgeCollider2D movecollider = moveplat.GetComponent<EdgeCollider2D>();
            movecollider.enabled = false;
            while(Physics2D.OverlapCircle(moveplat.transform.position, 2f)!= null)
            {
                moveplat.transform.Translate(new Vector3(0,trans));
            }
            movecollider.enabled = true;
        }
    }




}
