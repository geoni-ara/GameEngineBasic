using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackObject : MonoBehaviour
{
    WeaponSetting weapon;
    Rigidbody2D rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void move(){
        rigid.velocity = weapon.forwardSpeed;
        float angle = Mathf.Atan2(weapon.forwardSpeed.y, weapon.forwardSpeed.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == 9){
            monster monSc = other.gameObject.GetComponent<monster>();
            monSc.Damaged(3);
        }
    }

    public void setState(WeaponSetting state){
        weapon = state;
    }
}
