
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform FollowCamera;
    public Text scoreText;
    public static int highscore;

     void Update()
    {
       scoreText.text = FollowCamera.position.y.ToString("0");
        highscore = (int)FollowCamera.position.y;
    }
     void OnDestroy()
    {
        //record the scores to gameover scene
        PlayerPrefs.SetInt("Record", highscore);
    }
}
