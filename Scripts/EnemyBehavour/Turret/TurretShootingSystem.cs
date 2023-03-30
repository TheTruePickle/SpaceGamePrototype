using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShootingSystem : MonoBehaviour
{
    private GameObject player;
    public float fireSpeed;
    public GameObject laser;
    private float wait;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        wait+=Time.deltaTime;
        if(player.transform.position.magnitude - transform.position.magnitude <= 30){
            Vector2 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, counter);
            counter += 4 * Time.deltaTime;
            if(transform.rotation.Equals(rotation))
            {
                counter = 0f;
            }
            if(wait >= fireSpeed){
                GameObject turretLaser = Instantiate(laser);
                turretLaser.transform.rotation = transform.rotation;
                turretLaser.transform.position = transform.position;
                wait = 0;
            }
        }
    }
}
