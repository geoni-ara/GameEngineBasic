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
        resultStat.speed = playerStat.speed + itemStat.speed;
        // foreach(string stat in PlayerStat.datas.Keys){
        //     if(stat == "nickName")
        //         continue;

        //     Type type = PlayerStat.datas[stat].GetValue(itemStat).GetType();

        //     double defalutStat = Convert.ToDouble(PlayerStat.datas[stat].GetValue(playerStat));
        //     double item = Convert.ToDouble(PlayerStat.datas[stat].GetValue(itemStat));

        //     object returnValue = Convert.ChangeType(defalutStat + item, Type.GetTypeCode(type));

        //     PlayerStat.datas[stat].SetValue(resultStat, returnValue);
        // }
    }
}
