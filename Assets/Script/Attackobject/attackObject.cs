using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
        if(weapon.atkType == "melee"){
            setPos();
        }
        Invoke("Disappear", weapon.disappearTime);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(weapon.atkType == "area"){
            location();
        }
        if(weapon.penetrate ==0){
            Disappear();
        }
    }

    void move(){
        rigid.velocity = weapon.forwardSpeed* dir;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle+90);
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == 9){
            monster monSc = other.gameObject.GetComponent<monster>();
            monSc.Damaged(Mathf.FloorToInt(GameManager.info.resultStat.damage * weapon.damageCoaf));
            weapon.penetrate --;
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
    void location(){
        transform.position = GameManager.info.wControl.transform.position;
    }
    void setPos(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movePos = new Vector3(h,v,0).normalized;
        transform.position = movePos + GameManager.info.wControl.transform.position;
    }
}
