using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class monster : MonoBehaviour
{
    public float hp = 10;
    float speed = 3;
    public Rigidbody2D target;

    bool isLive =true;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.FindWithTag("Player");
        target = player.GetComponent<Rigidbody2D>();
    }
    void Start(){
        hp *= GameManager.info.level*0.2f +1;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(!isLive){
            Destroy(gameObject);
        }

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
        spriteRenderer.flipX = nextVec.x < 0;
    }
    
    public void Damaged(int dmg){
        hp -= dmg;
        if(hp<=0){
            isLive = false;
        }
    }
}
