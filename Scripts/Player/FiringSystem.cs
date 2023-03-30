using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSystem : MonoBehaviour
{
    private float wait;
    public GameObject bulletPrefab;
    public AudioSource blasterSound;
    void Start()
    {
    }
    void Update()
    {   
        wait+=Time.deltaTime;
        if(Input.GetAxis("Fire1") != 0){
            if(wait >= 0.4){
                blasterSound.Play();
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position+transform.right*2;
                bullet.transform.rotation = transform.rotation;
                wait = 0;
            }
        }
    }
}
