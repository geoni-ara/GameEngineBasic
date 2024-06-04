using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class monster : MonoBehaviour
{
    public float hp = 10;
    public int level;
    float speed = 3;
    public Rigidbody2D target;
    Vector2 moveVec;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    WaitForFixedUpdate wait;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.FindWithTag("Player");
        target = player.GetComponent<Rigidbody2D>();
        wait = new WaitForFixedUpdate();
    }
    void Start(){
        level = GameManager.info.level;
        hp *= level*0.2f +1;
    }

    // Update is called once per frame
    void FixedUpdate(){
        move();
    }
    void move(){
        Vector2 dirVec = target.position - rigid.position;
        moveVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
        rigid.velocity = Vector2.zero;
        spriteRenderer.flipX = moveVec.x < 0;
    }
    public void Damaged(int dmg){
        hp -= dmg;
        StartCoroutine(DamagedEvent());
        if(hp<=0){
            GameManager.info.getExp(level+1);
            Dead();
        }
    }

    void Dead(){
        Destroy(gameObject);
    }
    IEnumerator DamagedEvent(){
        yield return wait;
        rigid.AddForce(-moveVec, ForceMode2D.Impulse);
        spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,0.5f);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,1);
    }
}
