using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    private void Start()
    {
    }

    public void Score(int score)
    {
        text.text = score.ToString();
    }

}
