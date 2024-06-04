using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackObject : MonoBehaviour
{
    WeaponSetting weapon;
    Rigidbody2D rigid;
    Vector2 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        setDir();
        Invoke("Disappear", 2);
    }

    // Update is called once per frame
    void Update()
    {
        move();   
    }

    void move(){
        rigid.velocity = weapon.forwardSpeed* dir;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle+90);
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == 9){
            monster monSc = other.gameObject.GetComponent<monster>();
            monSc.Damaged(10);
            Debug.Log("target Pos =" + dir);
        }
    }

    public void setState(WeaponSetting state){
        weapon = state;
    }

    void setDir(){
        Vector2 target = weapon.target.position - transform.position;
        dir = target.normalized;
    }
    void Disappear(){
        Destroy(gameObject);
    }
}
