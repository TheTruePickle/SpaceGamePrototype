using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserScript : MonoBehaviour
{
    public float dmg;
    private float speed;
    private SpriteRenderer sR;
    private TrailRenderer tR;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        speed = 48;
        tR = gameObject.GetComponent<TrailRenderer>();
        sR = gameObject.GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed *Time.deltaTime;   
    }
    public float GetDmg(){
        return dmg;
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            tR.enabled = false;
            sR.enabled = false; 
            this.enabled = false;
            speed = 0;
        }
    }
}