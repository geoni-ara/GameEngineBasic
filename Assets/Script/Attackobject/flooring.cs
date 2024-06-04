using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class flooring : myWeapon
{
    public override void InitSetting()
    {
        Weapon.atkObject = Resources.Load<GameObject>("Prefab/AttackObject/flooring");
        Weapon.damageCoaf = 0.5f;
        Weapon.cooldown = 1;
        Weapon.WeaponLevel = 0;
        Weapon.forwardSpeed = 0;
        Weapon.disappearTime = 1;
        Weapon.penetrate = 50;
        Weapon.sizeCoaf = 1;
        Weapon.atkType = "area";
        Weapon.name = "flooring";
        Weapon.description = "Damage x 1.2 \nsize x 1.2";
    }

    public override void LevelUp()
    {
        Weapon.WeaponLevel ++;
        if(Weapon.WeaponLevel != 0){
            Weapon.damageCoaf *= 1.2f;
            Weapon.sizeCoaf *=1.2f;
        }
    }

}
