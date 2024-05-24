using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 30f;
    public float timeDestroy = 3f;
    public float bulletForce = 50f;
    public int damage = 20;
    public GameObject hitEffect;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name != "Player" && hitInfo.name != "table" && hitInfo.name != "ButtonTrigger" && hitInfo.name != "fence")
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
