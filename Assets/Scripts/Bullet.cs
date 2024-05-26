using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float timeDestroy;
    public float bulletForce;
    public int damage;
    public GameObject hitEffect;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name != "Player" && hitInfo.name != "table" && hitInfo.name != "ButtonTrigger" && hitInfo.name != "fence" && hitInfo.name != "WALL" && hitInfo.name != "NPC_1_Dialog" && hitInfo.name != "NPC_2_Dialog" && hitInfo.name != "NPC_3_Dialog" && hitInfo.name != "FishCarryChecker" && hitInfo.name != "BoxColliderDefBear")
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
            if(hitInfo.CompareTag("Enemy"))
            {
                hitInfo.GetComponent<Bear>().TakeDamage(damage);
            }
            if (hitInfo.CompareTag("Can"))
            {
                Rigidbody2D bankRigidbody = hitInfo.GetComponent<Rigidbody2D>();
                if (bankRigidbody != null)
                {
                    Vector2 direction = hitInfo.transform.position - transform.position;
                    direction = direction.normalized;
                    bankRigidbody.AddForce(direction * bulletForce, ForceMode2D.Impulse);
                }
            }
            Destroy(gameObject);
        }
    }
}
