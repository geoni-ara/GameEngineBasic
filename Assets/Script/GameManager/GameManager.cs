using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager info { get{return instance;}}
    private static GameManager instance;

    public PlayerStat playerStat;
    public PlayerStat itemStat;
    public PlayerStat resultStat;

    public MonsterManager monsterManager;

    public float playTime;
    public int level;
    public void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }

        itemStat = ScriptableObject.CreateInstance<PlayerStat>();
        resultStat = ScriptableObject.CreateInstance<PlayerStat>();

        UpdateStat();
    }

    void Update() {
        playTime += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.info.playTime/10);
    }
    public void UpdateStat(){
        resultStat.maxHp = playerStat.maxHp + itemStat.maxHp;
        resultStat.currentHp = playerStat.currentHp + itemStat.currentHp;
        resultStat.speed = playerStat.speed + itemStat.speed;
        resultStat.damage = playerStat.damage + itemStat.damage;
    }
}
