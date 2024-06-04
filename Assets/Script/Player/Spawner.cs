using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[System.Serializable]
public class SpawnData{
    public float spawnTime;
    public float levelCoaf;
}

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    float spawnTime =0.8f;
    public float spawnCoaf; 
    float timer;

    void Awake(){
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spawnCoaf = GameManager.info.level*0.1f +1;
        if (timer > spawnTime/spawnCoaf){
            Spawn();
            timer = 0;
        }
    }
    void Spawn(){
        GameObject monster = GameManager.info.monsterManager.Get(GameManager.info.level%2);
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
