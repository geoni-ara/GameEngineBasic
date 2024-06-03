using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class repositionMap : MonoBehaviour
{
    GameObject player;
    Collider2D col;
    void Awake(){
        player = GameObject.FindWithTag("Player");
        col = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D other){
        if(!other.CompareTag("area")){
            return;
        }
        
        Vector2 playerPos = player.transform.position;
        Vector2 myPos = transform.position;
        float diffX = playerPos.x - myPos.x;
        float diffY = playerPos.y - myPos.y;

        switch(transform.tag){
            case "ground":
                if(Mathf.Abs(diffX) > Mathf.Abs(diffY)){
                    float dirX = diffX > 0 ? 1 : -1;
                    transform.Translate(Vector2.right * dirX* 40);
                }
                else{
                    float dirY = diffY > 0 ? 1 : -1;
                    transform.Translate(Vector2.up * dirY* 40);
                }
                break;
            case "monster":
                if(col.enabled){
                    Vector2 dir = (playerPos - myPos).normalized;
                    transform.Translate(dir * 30 + new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f) ));
                }
                break;
        }
    }
}
