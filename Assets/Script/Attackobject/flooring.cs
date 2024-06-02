using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class flooring : MonoBehaviour
{
    public float cooldown = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0){
            cooldown -= Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.layer == 9 && cooldown <= 0){
            monster monSc = other.gameObject.GetComponent<monster>();
            monSc.Damaged(3);
            cooldown += 1;
        }
    }
}
