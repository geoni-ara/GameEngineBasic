using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : myWeapon
{
    public override void InitSetting()
    {
        Weapon.atkObject = Resources.Load<GameObject>("Prefab/AttackObject/slash");
        Weapon.damageCoaf = 1.2f;
        Weapon.cooldown = 1;
        Weapon.WeaponLevel = 0;
        Weapon.forwardSpeed = 0;
        Weapon.disappearTime = 2;
        Weapon.penetrate = 10;
        Weapon.sizeCoaf = 1;
        Weapon.atkType = "melee";
        Weapon.name = "slash";
        Weapon.description = "Damage x 1.1 \nsize x 1.1 \ncooldown x 0.9";
    }

    public override void LevelUp()
    {
        Weapon.WeaponLevel ++;
        if(Weapon.WeaponLevel !=0){
            Weapon.damageCoaf *= 1.1f;
            Weapon.cooldown *= 0.9f;
            Weapon.sizeCoaf *= 1.1f;
        }
    }

}
