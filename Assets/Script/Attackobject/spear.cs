using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class spear : myWeapon
{
    public override void InitSetting()
    {
        Weapon.atkObject = Resources.Load<GameObject>("Prefab/AttackObject/spear");
        Weapon.image = Resources.Load<Sprite>("Prefab/AttackObject/boltImg");
        Weapon.damageCoaf = 1;
        Weapon.cooldown = 1;
        Weapon.WeaponLevel = 1;
        Weapon.forwardSpeed = 5;
        Weapon.disappearTime = 3;
        Weapon.penetrate = 2;
        Weapon.sizeCoaf = 1;
        Weapon.atkType = "projectile";
        Weapon.name = "spear";
        Weapon.description = "Damage x 1.1 \ncooldown x 0.9";
    }

    public override void LevelUp()
    {
        Weapon.WeaponLevel ++;
        Weapon.damageCoaf *= 1.1f;
        Weapon.cooldown *= 0.9f;
    }

}
