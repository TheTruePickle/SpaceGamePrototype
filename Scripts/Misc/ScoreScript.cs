using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreDisp;
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisp.text = ""+score;
    }
    public void addScore(float add){
        score += add;
    }
}
