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
    public int deathAnimationDuration = 1;
    public GameObject bearHead;
    private Animator animator;
    private Transform playerPos;
    private GameObject player;
    public AudioClip[] sounds;
    private AudioSource audioSrc;

    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        audioSrc.PlayOneShot(clip, volume);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        playerPos = player.transform;
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            animator.SetInteger("healthStatus", 0);
            StartCoroutine(DestroyAfterAnimation(deathAnimationDuration));
            Instantiate(bearHead, transform.position, Quaternion.identity);
            this.enabled = false;
        }

        if (HeartSystem.health == 0)
        {
            speed = 0;
            animator.SetBool("chaseStatus", false);
            return;
        }

        if (playerPos != null && Vector2.Distance(transform.position, playerPos.position) <= chaseRadius)
        {
            chaseStatus = true;
            Vector2 direction = (playerPos.position - transform.position).normalized;
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
        PlayAttackSound();
    }

    public void OnAttackAnimationEnd()
    {
        animator.SetBool("attackStatus", false);
        speed = 5;
    }

    private void PlayIdleSound()
    {
        PlaySound(sounds[0], 1f);
    }

    private void PlayChaseSound()
    {
        PlaySound(sounds[1], 1f);
    }

    private void PlayRunSound()
    {
        PlaySound(sounds[2], 1f);
    }

    private void PlayAttackSound()
    {
        PlaySound(sounds[3], 1f);
    }

    private void PlayDieSound()
    {
        PlaySound(sounds[4], 1f);
    }
}
