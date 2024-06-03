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
    public SpawnData[] spawnData;
    float timer;

    void Awake(){
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f){
            Spawn();
            timer = 0;
        }
    }
    void Spawn(){
        GameObject monster = GameManager.info.monsterManager.Get(GameManager.info.level%2);
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
