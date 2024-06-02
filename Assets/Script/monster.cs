using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class monster : MonoBehaviour
{
    public int hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Damaged(int dmg){
        hp -= dmg;
        Debug.Log("현재 체력 : " + hp);
    }
}
