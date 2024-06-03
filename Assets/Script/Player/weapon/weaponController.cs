using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public myWeapon flooring;
    public myWeapon spear;
    public myWeapon slash;
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestT;
    
    Rigidbody2D rigid;
    float spearcool;
    float slashcool;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spearcool = spear.Weapon.cooldown;
        //slashcool = slash.Weapon.cooldown;
        //flooring.InitSetting();
        spear.InitSetting();
        //slash.InitSetting();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestT = getNear();
    }
    void Attack(){
        if(spearcool > 0){
            spearcool -= Time.deltaTime;
        }else{
            spear.Using();
            spearcool += spear.Weapon.cooldown;
        }
        /*
        if(slashcool >0){
            slashcool -= Time.deltaTime;
        }else{
            slash.Using();
            slashcool += slash.Weapon.cooldown;
        }
        */
    }

    Transform getNear(){
        Transform res = null;
        float diff = 100;

        foreach(RaycastHit2D target in targets){
            Vector2 myPos = transform.position;
            Vector2 targetPos = target.transform.position;
            float curDiff = Vector2.Distance(targetPos, myPos);

            if(curDiff < diff){
                diff = curDiff;
                res = target.transform;
            }
        }
        return res;
    }
}
