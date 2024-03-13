using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h, v;
    float speed;
    
    PlayerStat stat;
    
    Vector3 pDir;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public GameObject dectOb;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stat = Resources.Load<PlayerStat>("Prefab/Player/Player1");
    }

    void Update()
    {
        Move();
        Detect();
    }

    void Move(){
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        speed = stat.speed;
        rigid.velocity = new Vector2(speed*h,speed*v);

        //움직임에 따른 방향 전환
        if(h > 0){
            spriteRenderer.flipX = false;
        }else if(h < 0){
            spriteRenderer.flipX =true;
        }
    }

    void Detect(){
        if(h !=0 || v != 0){
            pDir = new Vector3(h,v,0);
        }
        var objectHit = Physics2D.Raycast(rigid.position, pDir,0.7f, LayerMask.GetMask("Npc")); //특정 layer인 게임 오브젝트 감지
        if(objectHit.collider != null){
            dectOb = objectHit.collider.gameObject;
        }
    }
}
