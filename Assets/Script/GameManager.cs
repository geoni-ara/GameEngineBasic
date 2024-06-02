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

    public void UpdateStat(){
        resultStat.maxHp = playerStat.maxHp + itemStat.maxHp;
        resultStat.currentHp = playerStat.currentHp + itemStat.currentHp;
        resultStat.speed = playerStat.speed + itemStat.speed;
        resultStat.damage = playerStat.damage + itemStat.damage;
    }
}
