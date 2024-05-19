using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Sound
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Player.Scope.performed += context => Scope();
        playerControls.Player.Shoot.performed += context => Shoot();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Player.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        myAnimator.SetBool("Attack", false);
    }

    private void Scope()
    {
        if (myAnimator.GetBool("Scope"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            myAnimator.SetBool("Scope", false);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            myAnimator.SetBool("Scope", true);
        }
    }

    private void Shoot()
    {
        if (myAnimator.GetBool("Scope"))
        {
            myAnimator.SetBool("Attack", true);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            PlaySound(sounds[1], 2f);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            myAnimator.SetBool("Scope", false);
        }
        else
        {
            myAnimator.SetBool("Attack", false);
        }
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }

    private void SnowSound()
    {
        PlaySound(sounds[0]);
    }
}
