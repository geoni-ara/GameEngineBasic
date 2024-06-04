using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager info { get{return instance;}}
    private static GameManager instance;

    public PlayerStat playerStat;
    public PlayerStat itemStat;
    public PlayerStat resultStat;

    public MonsterManager monsterManager;
    public expManager expBar;
    public TMP_Text timerText;

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
        Timer();
    }
    public void UpdateStat(){
        resultStat.maxHp = playerStat.maxHp + itemStat.maxHp;
        resultStat.currentHp = playerStat.currentHp + itemStat.currentHp;
        resultStat.speed = playerStat.speed + itemStat.speed;
        resultStat.damage = playerStat.damage + itemStat.damage;
        resultStat.level = playerStat.level;
    }
    public void getExp(int exp){
        resultStat.currentExp += exp;
        if (resultStat.currentExp >= resultStat.level*10){
            Levelup();
        }
        expBar.UpdateSlider();
    }
    void Levelup(){
        resultStat.level++;
        resultStat.currentExp = 0;
        Debug.Log("Level Up");
    }
    void Timer(){
        playTime += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.info.playTime/10);
        int min = Mathf.FloorToInt(playTime/60);
        int sec = Mathf.FloorToInt(playTime%60);
        timerText.text = string.Format("{0:D2}:{1:D2}",min,sec);
    }
}
