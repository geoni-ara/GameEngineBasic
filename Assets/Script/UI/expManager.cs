using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class expManager : MonoBehaviour
{
    private int currentExp = 0;
    private int maxExp = 0;
    private PlayerStat stat;
    public Slider expBar;
    public TMP_Text currnetLevel;
    void Start()
    {
        stat = GameManager.info.resultStat;
        UpdateSlider();
    }

    public void UpdateSlider(){
        currentExp = stat.currentExp;
        maxExp = stat.level*10;
        expBar.value = currentExp / (float)maxExp;

        currnetLevel.text = "Lv."+stat.level; 
    }
}
