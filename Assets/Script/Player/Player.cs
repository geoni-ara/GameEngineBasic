using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h, v;
    Vector3 pDir;
    Rigidbody2D rigid;
    public GameObject dectOb;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Detect();
    }

    void Move(){
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(3*h,3*v);
    }

    void Detect(){
        if(h !=0 || v != 0){
            pDir = new Vector3(h,v,0);    
        }
        Debug.DrawRay(rigid.position, 0.7f*pDir, Color.red);
        var objectHit = Physics2D.Raycast(rigid.position, pDir,0.7f, LayerMask.GetMask("Npc"));
        if(objectHit.collider != null){
            dectOb = objectHit.collider.gameObject;
        }
    }
}
