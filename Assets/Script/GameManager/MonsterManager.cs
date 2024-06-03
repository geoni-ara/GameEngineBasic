using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsters;

    List<GameObject>[] monsterList;

    void Awake(){
        monsterList = new List<GameObject>[monsters.Length];
        for (int i = 0; i<monsterList.Length; i++){
            monsterList[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index){
        GameObject select = null;
        if(select == null){
            select = Instantiate<GameObject>(monsters[index], transform);
            monsterList[index].Add(select);
        }
        return select;
    }
}
