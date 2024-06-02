using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerStat", menuName = "ScriptAble/PlayerStat", order = int.MaxValue)]
public class PlayerStat : ScriptableObject
{
    public string nickName;
    public int level;
    public int maxHp;
    public int currentHp;
    public float speed;
    public int damage;
}