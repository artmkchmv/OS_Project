using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public int health;
    public float speed = 5;
    public float chaseRadius;
    public bool chaseStatus;
    public Animator animator;
    public Transform player;
    public int deathAnimationDuration = 1;

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
            StopChase();
            Attack();
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
        // Возможно, здесь нужно будет добавить логику нанесения урона игроку
    }

    public void OnAttackAnimationEnd()
    {
        animator.SetBool("attackStatus", false);
        speed = 5;
    }
}
