using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public myWeapon[] myWeapons;
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestT;
    
    Rigidbody2D rigid;
    public float[] cool;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        cool = new float[myWeapons.Length];
        for (int i = 0;i<myWeapons.Length;i++){
            if(myWeapons[i] != null){
                myWeapons[i].InitSetting();
                cool[i] = myWeapons[i].Weapon.cooldown;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestT = getNear();
    }
    void Attack(){
        for (int i = 0;i<myWeapons.Length;i++){
            if(cool[i] >0){
                cool[i] -= Time.deltaTime;
            }else{
                if(nearestT != null && myWeapons[i].Weapon.WeaponLevel != 0){
                    myWeapons[i].Weapon.target = nearestT;
                    myWeapons[i].Using();
                    cool[i] = myWeapons[i].Weapon.cooldown;
                }
            }
        }
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
