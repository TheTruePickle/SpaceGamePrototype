using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthSystem : MonoBehaviour
{
    public GameObject cam;
    public GameObject txt;
    public float health;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public float getHealth(){
        return health;
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "DmgLaser"){
            health -= col.gameObject.GetComponent<EnemyLaserScript>().GetDmg();
        }
        if(health <= 0){
            txt.SetActive(true);
            cam.GetComponent<CameraScript>().enabled = false;
            transform.position+=new Vector3(0, -100, 0);
            gameObject.SetActive(false);
        }
    }
}
