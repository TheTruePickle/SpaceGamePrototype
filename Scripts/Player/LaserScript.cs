using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float dmg;
    private float speed;
    private ParticleSystem pS;
    private SpriteRenderer sR;
    private TrailRenderer tR;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        speed = 48;
        tR = gameObject.GetComponent<TrailRenderer>();
        sR = gameObject.GetComponent<SpriteRenderer>();
        pS = gameObject.GetComponent<ParticleSystem>();
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
        if(col.gameObject.tag == "Enemy"){
            pS.Play(); 
            tR.enabled = false;
            sR.enabled = false; 
            this.enabled = false;
            speed = 0;
        }
    }
}
