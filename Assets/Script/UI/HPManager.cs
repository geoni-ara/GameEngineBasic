using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    private PlayerStat stat;
    public Slider hpbar;
    private int currentHP = 0;
    private int maxHP = 0;

    void Start()
    {
        stat = GameManager.info.resultStat;
        UpdateSlider();
    }

    
    public void UpdateSlider(){
        currentHP = stat.currentHp;
        maxHP = stat.maxHp;

        hpbar.value = currentHP / (float)maxHP;
    }
}
