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
    }
}
