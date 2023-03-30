using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    private float wait;
    public GameObject enemyPrefab;
    public float spawnSpeed;
    private int n;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnSpeed -= 0.0001f;
        wait+=Time.deltaTime;
        if(wait >= spawnSpeed || Input.GetKeyDown(KeyCode.P)){
                GameObject enemy = Instantiate(enemyPrefab);
                int x;
                int y;
                if(Random.Range(1, -1) == 1){
                    x = Random.Range(-20, -25);
                }
                else{
                    x = Random.Range(20, 25);
                }
                if(Random.Range(1, -1) == 1){
                    y = Random.Range(-20, -25);
                }
                else{
                    y = Random.Range(20, 25);
                }
                enemy.transform.position = transform.position+new Vector3(x, y, -1);
                wait = 0;
        }
    }
}
