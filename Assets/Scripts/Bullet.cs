using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float timeDestroy = 3f;
    public int damage = 10;
    public GameObject hitEffect;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name != "Player")
        {
            Debug.Log(hitInfo.name);
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
