using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class spear : myWeapon
{
    public override void InitSetting()
    {
        Weapon.atkObject = Resources.Load<GameObject>("Prefab/AttackObject/spear");
        Weapon.damageCoaf = 1;
        Weapon.cooldown = 0.5f;
        Weapon.WeaponLevel = 1;
        Weapon.forwardSpeed = 5;
    }

    public override void LevelUp()
    {
        Weapon.damageCoaf += 0.1f;
        Weapon.cooldown *= 0.9f;
    }

    public override void Using()
    {
        GameObject atk = Instantiate(Weapon.atkObject, transform.position,Quaternion.identity);
        attackObject atkSc = atk.GetComponent<attackObject>();
        atkSc.setState(Weapon);
    }
}
