using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;
    public GameObject EnemyBulletPrefab;
    private float wait;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        movement = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position - transform.position).magnitude > 100){
            Debug.Log("DestroyedThis");
            Destroy(gameObject);
            this.enabled = false;
        }
        wait+=Time.deltaTime;
        if((player.transform.position - transform.position).magnitude < 50){
            if(wait>= 2f){
                GameObject enemyBullet = Instantiate(EnemyBulletPrefab);
                enemyBullet.transform.position = transform.position+transform.right*2;
                enemyBullet.transform.rotation = transform.rotation;
                wait = 0;
            }
            movement+=transform.right*0.4f;
            transform.position += movement*Time.deltaTime;
            if(movement.magnitude >= 20f){
                movement.x = movement.x*0.90f;
                movement.y = movement.y*0.90f;
            }
            Vector2 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 7 * Time.deltaTime);
        } 
        
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Bullet"){ 
            Destroy(gameObject);
        }
    }
}
