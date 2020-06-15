using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreText;
    // Start is called before the first frame update

    public void Score(int score)
    {
        scoreText.GetComponent<Text>().text = score.ToString(); 
    }

}
