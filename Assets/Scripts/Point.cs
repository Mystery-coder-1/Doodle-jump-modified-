
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public Text LoadPoint;
    void Start()
    {
        LoadPoint.text = PlayerPrefs.GetInt("Record").ToString();
    }

    
}
