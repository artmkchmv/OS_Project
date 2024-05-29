using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Sound
{
    [SerializeField] private float moveSpeed = 1f;
    public int health;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public VectorValue pos;
    public Texture2D cursorTextureBase;
    public Texture2D cursorTextureScope;
    public static bool dieStatus;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private GameObject mainHouse;
    private GameObject npcHouse;

    private void Awake()
    {
        transform.position = pos.intitialValue;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        dieStatus = false;
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Player.Scope.performed += context => Scope();
        playerControls.Player.Shoot.performed += context => Shoot();
    }

    private void Update()
    {
        if (health == 0)
        {
            dieStatus = true;
            myAnimator.SetTrigger("DieTrigger");
            this.enabled = false;
        }
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
            BackCursor();
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            myAnimator.SetBool("Scope", true);
            ChangeCursor();
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
            BackCursor();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
        }
        
        if (collision.gameObject.name == "BoardsCarryChecker")
        {
            ArrowsStart.arrowBoardsCarry.SetActive(false);
            ArrowsStart.arrowBoardsDrop.SetActive(true);
        }
    }

    public void ChangeCursor()
    {
        Cursor.SetCursor(cursorTextureScope, Vector2.zero, CursorMode.Auto);
    }

    public void BackCursor()
    {
        Cursor.SetCursor(cursorTextureBase, Vector2.zero, CursorMode.Auto);
    }
}
