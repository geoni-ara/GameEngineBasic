using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public myWeapon flooring;
    public myWeapon spear;
    public myWeapon slash;
    
    Rigidbody2D rigid;
    float spearcool;
    float slashcool;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spearcool = spear.Weapon.cooldown;
        slashcool = slash.Weapon.cooldown;
        flooring.InitSetting();
        spear.InitSetting();
        slash.InitSetting();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack(){
        if(spearcool > 0){
            spearcool -= Time.deltaTime;
        }else{
            spear.Using();
            spearcool += spear.Weapon.cooldown;
        }
        if(slashcool >0){
            slashcool -= Time.deltaTime;
        }else{
            slash.Using();
            slashcool += slash.Weapon.cooldown;
        }
    }
}
