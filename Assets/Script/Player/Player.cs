using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float h, v;
    float speed;
    
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        if(GameManager.info.resultStat.currentHp <= 0){
            Dead();
        }
    }

    void Move(){
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        speed = GameManager.info.resultStat.speed;
        rigid.velocity = new Vector2(speed*h,speed*v);

        if (h != 0 || v != 0){
            anim.SetBool("isWalk",true);
        }
        else{
            anim.SetBool("isWalk",false);
        }
        //움직임에 따른 방향 전환
        if(h > 0){
            spriteRenderer.flipX = true;
        }else if(h < 0){
            spriteRenderer.flipX =false;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.layer == 6){
            GameManager.info.resultStat.currentHp -= 1;
            HPManager hpbar = FindObjectOfType<HPManager>();
            hpbar.UpdateSlider();
        }
    }

    void Dead(){
        Time.timeScale = 0;
        SceneManager.LoadScene("GlassArea");
    }
}
