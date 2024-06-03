using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Xml.Serialization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public struct WeaponSetting{
        public GameObject atkObject;
        public float damageCoaf;
        public float cooldown;
        public Vector2 forwardSpeed;
        public int WeaponLevel;
    }
public abstract class myWeapon : MonoBehaviour
{
    public WeaponSetting Weapon;
    public abstract void InitSetting();
    public abstract void LevelUp();
    /*
    public virtual void Using(){
        GameObject atk = Instantiate(Weapon.atkObject, transform.position,Quaternion.identity);
        attackObject atkSc = atk.GetComponent<attackObject>();
        atkSc.setState(Weapon);
    }
    */
    public abstract void Using();
}
