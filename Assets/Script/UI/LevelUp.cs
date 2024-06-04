using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public weaponController wControl;
    public myWeapon skill;
    public TMP_Text SkillText;
    void OnEnable(){
        wControl = GameManager.info.wControl;
        reloadSkill();
    }
    public void reloadSkill(){
        skill = wControl.myWeapons[Random.Range(0, wControl.myWeapons.Length)];
        if(skill.Weapon.WeaponLevel == 8){
            skill = wControl.myWeapons[Random.Range(0, wControl.myWeapons.Length)];
        }
        SkillText.text = skill.Weapon.name+ "\n"+skill.Weapon.description;
        Time.timeScale = 0;
    } 
    public void onClick(){
        skill.LevelUp();
        GameManager.info.lvObject.SetActive(false);
        Time.timeScale=1;
    }
}
