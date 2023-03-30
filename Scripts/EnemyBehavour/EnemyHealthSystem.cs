using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public float health;
    public float scoreVal;
    public GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Bullet"){
            health -= col.gameObject.GetComponent<LaserScript>().GetDmg();
        }
        if(health <= 0){
            Destroy(gameObject);
            scoreText.GetComponent<ScoreScript>().addScore(scoreVal);
        }
    }
}
