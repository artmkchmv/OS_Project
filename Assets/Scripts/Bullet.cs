using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float timeDestroy = 3f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.position * bulletSpeed;
    }
}
