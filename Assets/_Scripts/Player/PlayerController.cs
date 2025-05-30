using System;
using System.Data.Common;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float addedRotation;

    [Header("Projectile VARS")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform muzzleTransform;
    private GameObject projectile;
    private Vector2 shootDirection;
    private float angle;


    private Rigidbody2D playerRB;
    private Vector2 moveInput;
    private Vector3 mouseWorldPos;
    public static PlayerController instance;


    //add audio for gunshot
    private AudioSource playerAudioSource;

    [SerializeField] AudioClip pistolShot;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        playerAudioSource = this.GetComponent<AudioSource>();
        playerAudioSource.clip = pistolShot;
    }

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        PlayerMovement();
        rotatePlayerTowardsMouse();
    }

    private void PlayerMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
        playerRB.linearVelocity = moveInput * moveSpeed;
    }

    private void rotatePlayerTowardsMouse()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + addedRotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        //if you are reading this psy, this smooths the rotation.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
    }

    private void Shoot()
    {
        shootDirection = -transform.up;

        projectile = Instantiate(projectilePrefab, muzzleTransform.position, Quaternion.identity);

        projectile.GetComponent<PlayerProjectile>().SetDirection(shootDirection);

        angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg -90f;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        playerAudioSource.Play();
    }


}
