using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;
    public float chaseRadius;
    public bool chaseStatus;
    public Transform player;
    public int deathAnimationDuration = 1;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            animator.SetInteger("healthStatus", 0);
            StartCoroutine(DestroyAfterAnimation(deathAnimationDuration));
            return;
        }

        if (HeartSystem.health == 0)
        {
            speed = 0;
            animator.SetBool("chaseStatus", false);
            return;
        }

        if (player != null && Vector2.Distance(transform.position, player.position) <= chaseRadius)
        {
            chaseStatus = true;
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);

            if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            chaseStatus = false;
        }

        if (chaseStatus)
        {
            animator.SetBool("chaseStatus", true);
        }
        else
        {
            animator.SetBool("chaseStatus", false);
        }
    }

    private IEnumerator DestroyAfterAnimation(int delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (HeartSystem.health > 0)
            {
                HeartSystem.health -= 1;
                StopChase();
                Attack();
            }
            else
            {
                animator.SetBool("chaseStatus", false);
                chaseStatus = false;
                speed = 0;
            }
        }
    }

    private void StopChase()
    {
        chaseStatus = false;
        speed = 0;
    }

    private void Attack()
    {
        animator.SetBool("attackStatus", true);
    }

    public void OnAttackAnimationEnd()
    {
        animator.SetBool("attackStatus", false);
        speed = 5;
    }
}
